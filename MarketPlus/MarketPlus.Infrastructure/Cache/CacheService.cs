using Microsoft.Extensions.Caching.Memory;

namespace MarketPlus.Infrastructure.Cache
{
    public class CacheService<T> : ICacheService<T>
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Set(string key, T item, TimeSpan cacheDuration)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = cacheDuration
            };
            _memoryCache.Set(key, item, cacheEntryOptions);
        }

        public T Get(string key)
        {
            _memoryCache.TryGetValue(key, out T item);
            return item;
        }
    }
}
