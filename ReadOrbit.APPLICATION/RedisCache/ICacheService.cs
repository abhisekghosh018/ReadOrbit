namespace ReadOrbit.APPLICATION.RedisCache
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key);

        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);

        Task RemoveAsync(string key);

        Task<bool> KeyExistsAsync(string key);

        Task<IEnumerable<T>> GetPaginatedAsync<T>(string indexKey, string keyPrefix, int pageNumber, int pageSize) where T : class;

        //Task CacheMassDataAsync<T>(IEnumerable<T> dataList, string indexKey, string keyPrefix, Func<T, string> idSelector, Func<T, double> scoreSelector) where T : class;
        Task CacheMassDataAsync<T>(IEnumerable<T> dataList, string indexKey, string keyPrefix, Func<T, string> idSelector, Func<T, double> scoreSelector, int chunkSize = 25_000) where T : class;
    }
}
