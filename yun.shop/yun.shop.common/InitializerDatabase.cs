using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yun.shop.entityframework;
using System.Data.Entity;

namespace yun.shop.common
{
    public class InitializerDatabase
    {
        public InitializerDatabase()
        {
            new InitDatabase();
        }
    }
}
