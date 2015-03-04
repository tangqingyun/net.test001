using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using yun.shop.configuration;
using yun.shop.resource.Enums;

namespace yun.shop.entityframework
{
    public class ContextManager
    {
        private static readonly Hashtable ContextFactories = new Hashtable();
        
        public ContextManager()
        { 
        
        }
        private static readonly object ContextLock = new object();
        public static ShopContext CreateContext()
        {
            
            lock (ContextLock)
            {
                string connstr = DatabaseConfig.GetDatabaseInfo(EnumDatabase.ShopContext);
                var context = HttpContext.Current;
                if (context != null)
                {
                    var currentContext = context.Items["current_context"] as ShopContext;
                    if (currentContext == null)
                    {
                        var shopContext = new ShopContext();
                        currentContext = shopContext;
                        context.Items["current_context"] = shopContext;
                    }
                    return currentContext;
                }
                else
                {
                    return new ShopContext();
                }
            }
        }
        

    }
}
