using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace TestASPNETCache
{
    class Program
    {
        static void Main(string[] args)
        {
            CacheDependency dep = new CacheDependency("");
            HttpRuntime.Cache.Insert("", "Fish Li", dep,
            Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, RunOptionsUpdateCallback);
        
        }

        public static void RunOptionsUpdateCallback(string key, CacheItemUpdateReason reason,
                out object expensiveObject,
                out CacheDependency dependency,
                out DateTime absoluteExpiration,
                out TimeSpan slidingExpiration)
        {
            expensiveObject = null;
            dependency = null;
            absoluteExpiration = DateTime.Now;
            slidingExpiration = new TimeSpan(1000);
           
        }


    }
}
