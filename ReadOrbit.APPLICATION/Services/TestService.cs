using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.APPLICATION.RedisCache;
using ReadOrbit.DOMAIN.DomainEntities;
using System.Diagnostics;

namespace ReadOrbit.APPLICATION.Services
{
    public class TestService
    {
        private readonly ITest _testRepository;
        private readonly ICacheService _cacheService;
        private const string CacheKey = "ol_works:all";
        private const string IndexKey = "ol_works:index";
        private const string KeyPrefix = "ol_work";
        public TestService(ITest testRepository, ICacheService cacheService)
        {
            _testRepository = testRepository;
            _cacheService = cacheService;
        }

        public async Task<IEnumerable<ol_works>> GetAllTestDataAsync()
        {

            // -----------------------------------------
            // 1. Redis GET
            // -----------------------------------------
            var redisGetSw = Stopwatch.StartNew();

            var cachedData = await _cacheService.GetAsync<List<ol_works>>(CacheKey);

            redisGetSw.Stop();

            Console.WriteLine($"Redis GET: {redisGetSw.ElapsedMilliseconds} ms");

            // -----------------------------------------
            // 2. Cache HIT
            // -----------------------------------------
            if (cachedData is not null)
            {
                Console.WriteLine($"Cache HIT - Records: {cachedData.Count}");
                return cachedData;
            }

            Console.WriteLine("Cache MISS");

            // -----------------------------------------
            // 3. PostgreSQL query
            // -----------------------------------------
            var dbSw = Stopwatch.StartNew();

            var data = await _testRepository.GetAllOlAsync();

            var dataList = data.ToList();

            dbSw.Stop();

            Console.WriteLine($"PostgreSQL: {dbSw.ElapsedMilliseconds} ms");

            Console.WriteLine($"Records loaded: {dataList.Count}");

            // -----------------------------------------
            // 4. Redis SET
            // -----------------------------------------
            var redisSetSw = Stopwatch.StartNew();

            await _cacheService.SetAsync(CacheKey, dataList);

            redisSetSw.Stop();

            Console.WriteLine($"Redis SET: {redisSetSw.ElapsedMilliseconds} ms");

            // -----------------------------------------
            // 5. Total
            // -----------------------------------------
            Console.WriteLine($"Total: {redisGetSw.ElapsedMilliseconds + dbSw.ElapsedMilliseconds + redisSetSw.ElapsedMilliseconds} ms");

            return dataList;
        }

        public async Task LoadOlWorksIntoRedisAsync(CancellationToken cancellationToken = default)
        {
            const int batchSize = 500000; // smaller = safer on your machine
            int skip = 0;
            int totalRecords = 0;
            int batchNumber = 0;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var dbSw = Stopwatch.StartNew();
                var batch = await _testRepository.GetOlWorksBatchAsync(skip, batchSize, cancellationToken);
                dbSw.Stop();

                if (batch.Count == 0) break;

                batchNumber++;
                double baseScore = skip;

                var redisSw = Stopwatch.StartNew();

                // ✅ Use CacheMassDataAsync — stores individual keys, pageable
                await _cacheService.CacheMassDataAsync(
                    batch,
                    IndexKey,
                    KeyPrefix,
                    item => item.OlKey!,
                    item => (double)item.Revision + baseScore
                );

                redisSw.Stop();
                totalRecords += batch.Count;

                Console.WriteLine(
                    $"Batch:{batchNumber} | Records:{batch.Count} | " +
                    $"Total:{totalRecords} | " +
                    $"DB:{dbSw.ElapsedMilliseconds}ms | " +
                    $"Redis:{redisSw.ElapsedMilliseconds}ms");

                skip += batch.Count;

                // Cap at 500K for now
                if (totalRecords >= 2000_000) break;
                if (batch.Count < batchSize) break;
            }

            Console.WriteLine($"✅ Done. Total cached: {totalRecords}");
        }



        //public async Task LoadOlWorksIntoRedisAsync(CancellationToken cancellationToken = default)
        //{
        //    const int batchSize = 50_0000;

        //    int skip = 0;
        //    int chunkNumber = 0;
        //    int totalRecords = 0;

        //    while (true)
        //    {
        //        var stopwatch = Stopwatch.StartNew();

        //        var batch = await _testRepository.GetOlWorksBatchAsync(skip, batchSize, cancellationToken);

        //        stopwatch.Stop();

        //        if (batch.Count == 0)
        //            break;

        //        chunkNumber++;

        //        string cacheKey = $"ol_works:chunk:{chunkNumber}";

        //        var redisStopwatch = Stopwatch.StartNew();

        //        await _cacheService.SetAsync(cacheKey, batch);

        //        redisStopwatch.Stop();

        //        totalRecords += batch.Count;

        //        Console.WriteLine(
        //            $"Chunk: {chunkNumber} | " +
        //            $"Records: {batch.Count} | " +
        //            $"Total: {totalRecords} | " +
        //            $"PostgreSQL: {stopwatch.ElapsedMilliseconds} ms | " +
        //            $"Redis: {redisStopwatch.ElapsedMilliseconds} ms");

        //        skip += batch.Count;

        //        if (batch.Count < batchSize)
        //            break;
        //    }

        //    Console.WriteLine($"Completed. Total records cached: {totalRecords}");
        //}

        public async Task<IEnumerable<ol_works>> Handle(int pageNumber, int pageSize)
        {
            // 1. Check index existence via interface
            if (await _cacheService.KeyExistsAsync(IndexKey))
            {
                return await _cacheService.GetPaginatedAsync<ol_works>(IndexKey, KeyPrefix, pageNumber, pageSize);
            }

            // 2. Cache Miss: Seed from Database into Cache using chunks
            int batchSize = 50000;
            int currentDbPage = 1;
            double mockScore = 0;

            while (true)
            {
                var chunk = await _testRepository.GetOlPageFromDbAsync(currentDbPage, batchSize);
                if (!chunk.Any()) break;

                // Notice we pass lambda expressions to map the generic logic safely
                await _cacheService.CacheMassDataAsync(chunk, IndexKey, KeyPrefix, item => item.OlKey, item => (double?)item.Revision ?? mockScore++);

                currentDbPage++;
                if ((currentDbPage - 1) * batchSize >= 500_000) break;
            }

            // 3. Return the specific requested page
            return await _cacheService.GetPaginatedAsync<ol_works>(IndexKey, KeyPrefix, pageNumber, pageSize);
        }

    }
}
