using Fathcore.Infrastructure.Caching;

namespace Simantri.Data
{
    public class CacheSetting : ICacheSetting
    {
        public CacheSetting(string cachePrefix, int cacheTime)
        {
            CachePrefix = cachePrefix;
            CacheTime = cacheTime;
        }

        public string CachePrefix { get; set; }
        public int CacheTime { get; set; }
    }
}
