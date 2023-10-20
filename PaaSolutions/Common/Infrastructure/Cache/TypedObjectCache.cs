using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Collections.Specialized;

namespace Common.Infrastructure.Cache
{
    public class TypedObjectCache<T> : MemoryCache where T : class
    {
        private CacheItemPolicy HardDefaultCacheItemPolicy = new CacheItemPolicy()
        {
            SlidingExpiration = new TimeSpan(0, 15, 0)
        };

        private CacheItemPolicy defaultCacheItemPolicy;

        public TypedObjectCache(string name, NameValueCollection nvc = null, CacheItemPolicy policy = null)
            : base(name, nvc)
        {
            defaultCacheItemPolicy = policy ?? HardDefaultCacheItemPolicy;
        }

        public void Set(string cacheKey, T cacheItem, CacheItemPolicy policy = null)
        {
            if (string.IsNullOrEmpty(cacheKey)) return;
            if (cacheItem == null) return;
            policy = policy ?? defaultCacheItemPolicy;
            base.Set(cacheKey, cacheItem, policy);
        }

        public void Remove(string cacheKey)
        {
            if (string.IsNullOrEmpty(cacheKey)) return;
            base.Remove(cacheKey);
        }

        public void Set(string cacheKey, Func<T> getData, CacheItemPolicy policy = null)
        {
            this.Set(cacheKey, getData(), policy);
        }

        public bool TryGetAndSet(string cacheKey, Func<T> getData, out T returnData, CacheItemPolicy policy = null)
        {
            if (TryGet(cacheKey, out returnData))
            {
                return true;
            }
            returnData = getData();
            this.Set(cacheKey, returnData, policy);
            return returnData != null;
        }

        public bool TryGet(string cacheKey, out T returnItem)
        {
            if (string.IsNullOrEmpty(cacheKey))
            {
                returnItem = null;
                return false;
            }
            returnItem = (T)this[cacheKey];
            return returnItem != null;
        }

        private static TypedObjectCache<T> _instance = new TypedObjectCache<T>("WinApplication");

        public static TypedObjectCache<T> Instance { get { return _instance; } }
    }
}
