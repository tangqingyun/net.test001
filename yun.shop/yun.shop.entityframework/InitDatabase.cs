using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yun.shop.entityframework
{
    public class InitDatabase
    {
        public InitDatabase()
        {
            System.Data.Entity.Database.SetInitializer(new ShopInitializer());
        }
    }
}
