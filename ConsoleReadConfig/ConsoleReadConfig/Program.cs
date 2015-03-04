using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ConsoleReadConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            string configFile = @"C:\Users\Administrator\Desktop\ConsoleReadConfig\ConsoleReadConfig\Database.config";
            //configFile = @"C:\Users\Administrator\Desktop\ConsoleReadConfig\ConsoleReadConfig\demo.config";
           //  string s=AppDomain.CurrentDomain.BaseDirectory;


            if (!string.IsNullOrEmpty(configFile))
            {
                var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configFile };
                var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                SectionHandler configSection = (SectionHandler)config.GetSection("database");
                // var values = from kv in configSection.Settings.Cast<SettingElement>();
                var list = configSection.Settings.Cast<SettingElement>();
                foreach (var itm in list)
                {
                    Console.WriteLine(itm.Name + "\r\n");
                }

                //var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configFile };
                //var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                //MySection3 configSection = (MySection3)config.GetSection("MySection3");
                Console.ReadKey();
            }
        }
    }
}
