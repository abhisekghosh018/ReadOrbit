using ReadOrbit.APPLICATION.RedisCache;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;

namespace ReadOrbit.INFRASTRUCTURE.Caching;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = _redis.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _database.StringGetAsync(key);
        if (value.IsNullOrEmpty) return default;
        return JsonSerializer.Deserialize<T>(value.ToString(), JsonOptions);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        var json = JsonSerializer.Serialize(value, JsonOptions);
        var sizeInBytes = Encoding.UTF8.GetByteCount(json);
        var sizeInMb = sizeInBytes / 1024.0 / 1024.0;
        Console.WriteLine($"Redis payload: {sizeInMb:F2} MB");

        // ✅ Fixed: now respects the expiration parameter
        await _database.StringSetAsync(key, json, expiration ?? TimeSpan.FromMinutes(30));
    }

    public async Task RemoveAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }

    public async Task<bool> KeyExistsAsync(string key)
    {
        return await _database.KeyExistsAsync(key);
    }

    public async Task<IEnumerable<T>> GetPaginatedAsync<T>(
        string indexKey,
        string keyPrefix,
        int pageNumber,
        int pageSize) where T : class
    {
        int start = (pageNumber - 1) * pageSize;
        int stop = start + pageSize - 1;

        var redisIds = await _database.SortedSetRangeByRankAsync(indexKey, start, stop);
        if (redisIds.Length == 0) return Enumerable.Empty<T>();

        var batch = _database.CreateBatch();
        var tasks = new List<Task<RedisValue>>();

        foreach (var id in redisIds)
            tasks.Add(batch.StringGetAsync($"{keyPrefix}:{id}"));

        batch.Execute();
        var results = await Task.WhenAll(tasks);

        var dataList = new List<T>();
        foreach (var value in results)
        {
            if (!value.IsNullOrEmpty)
            {
                var item = JsonSerializer.Deserialize<T>(value.ToString(), JsonOptions);
                if (item != null) dataList.Add(item);
            }
        }
        return dataList;
    }

    public async Task CacheMassDataAsync<T>(
        IEnumerable<T> dataList,
        string indexKey,
        string keyPrefix,
        Func<T, string> idSelector,
        Func<T, double> scoreSelector,
        int chunkSize = 25_000) where T : class
    {
        var chunk = new List<T>(chunkSize);

        foreach (var item in dataList)
        {
            chunk.Add(item);
            if (chunk.Count >= chunkSize)
            {
                await FlushChunkAsync(chunk, indexKey, keyPrefix, idSelector, scoreSelector);
                chunk.Clear();
                await Task.Delay(10);
            }
        }

        if (chunk.Count > 0)
            await FlushChunkAsync(chunk, indexKey, keyPrefix, idSelector, scoreSelector);

        // ✅ Set expiry on the sorted set index itself
        await _database.KeyExpireAsync(indexKey, TimeSpan.FromHours(24));
    }

    private async Task FlushChunkAsync<T>(
        List<T> chunk,
        string indexKey,
        string keyPrefix,
        Func<T, string> idSelector,
        Func<T, double> scoreSelector) where T : class
    {
        var batch = _database.CreateBatch();
        var tasks = new List<Task>();

        foreach (var item in chunk)
        {
            string id = idSelector(item);
            double score = scoreSelector(item);
            string json = JsonSerializer.Serialize(item, JsonOptions);

            tasks.Add(batch.StringSetAsync($"{keyPrefix}:{id}", json, TimeSpan.FromHours(24)));
            tasks.Add(batch.SortedSetAddAsync(indexKey, id, score));
        }

        batch.Execute();
        await Task.WhenAll(tasks);
    }
}