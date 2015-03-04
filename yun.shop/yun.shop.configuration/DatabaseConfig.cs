using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yun.shop.resource.Enums;

namespace yun.shop.configuration
{
    public static class DatabaseConfig
    {
        private static readonly Hashtable DatabaseInfos = new Hashtable();
        static DatabaseConfig()
        {
            ConnectionStringSettingsCollection collecton = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings itm in collecton)
            {
                DatabaseInfos.Add(itm.Name,itm.ToString());
            }
        }

        public static string GetDatabaseInfo(EnumDatabase key)
        {
            if (DatabaseInfos.ContainsKey(key.ToString()))
            {
                return DatabaseInfos[key.ToString()].ToString();
            }
            return null;
        }

    }
}
