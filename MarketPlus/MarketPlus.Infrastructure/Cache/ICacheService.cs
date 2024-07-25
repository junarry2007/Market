namespace MarketPlus.Infrastructure.Cache
{
    public interface ICacheService<T>
    {
        void Set(string key, T item, TimeSpan cacheDuration);
        T Get(string key);
    }
}
