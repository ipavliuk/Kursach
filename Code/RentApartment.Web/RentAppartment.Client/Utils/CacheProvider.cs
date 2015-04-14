using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace RentAppartment.Client.Utils
{
    public class CacheProvider
    {
        #region Initialisation Singlenton
        private CacheProvider() { }

        private static readonly Lazy<CacheProvider> _instance =
            new Lazy<CacheProvider>(() => new CacheProvider(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        public static CacheProvider Instance
		{
			get 
			{ return _instance.Value; }
		}

		#endregion

        private readonly ObjectCache cache = MemoryCache.Default;

        private readonly object _lock = new object();

        public void AddItem(string key, object value)
        {
            lock(_lock)
            {
                //DateTimeOffset.Now.AddSeconds(10.0);
                cache.Add(key, value, DateTimeOffset.MaxValue);
            }
        }

        public void Remove(string key)
        {
            lock (_lock)
            {
                //DateTimeOffset.Now.AddSeconds(10.0);
                cache.Remove(key);
            }
        }

        public object GetItem(string key)
        { 
            lock (_lock)
            {
                var res = cache[key];

                if (res == null)
                {
                    //WriteToLog("CachingProvider-GetItem: Don't contains key: " + key);
                }

                return res;
            }
            
        }
    }
}
