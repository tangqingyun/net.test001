using Basement.Framework.Data;
using Basement.Framework.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSqlMonitoring
{
    public static class Database
    {
        static Database() { }

        public static SqlServer Uni2uni_LocalLife
        {
            get
            {
                return new SqlServer(ConnectionConfig.Connections["Uni2uni_LocalLife"]);
            }
        }
     
    }
}
