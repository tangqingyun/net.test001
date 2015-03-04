using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uni2Uni.ERP.IOC
{
    public abstract class InstanceFactory
    {
        private static readonly Hashtable IContexts = new Hashtable();

        public InstanceFactory()
        {

        }

        private static readonly object ContextLock = new object();
        public static IApplicationContext GetApplicationContext(string key)
        {
            lock (ContextLock)
            {
                if (IContexts.ContainsKey(key))
                {
                    return IContexts[key] as IApplicationContext;
                }
                IApplicationContext context = ContextRegistry.GetContext();
                IContexts.Add(key, context);
                return context;
            }

        }

        /// <summary>
        /// 获得服务层实例
        /// </summary>
        /// <param name="resolveName"></param>
        /// <returns></returns>
        public static object GetServiceInstance(string resolveNameId="")
        {
            var context=GetApplicationContext("object");
            return context.GetObject(resolveNameId);
        }

        /// <summary>
        /// 获得持久层实例
        /// </summary>
        /// <param name="resolveNameId"></param>
        /// <returns></returns>
        public static object GetInfrastructureInstance(string resolveNameId = "")
        {
            var context = GetApplicationContext("object");
            return context.GetObject(resolveNameId);
        }

    }
}
