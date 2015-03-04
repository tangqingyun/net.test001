using IDal;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace UnityIOC
{
    class Program
    {
        private static readonly Hashtable UnityContainers = new Hashtable();
        static void Main(string[] args)
        {

            UnityContainer unityContainer = GetUnityContainer();
            var instance = GetInstance<IPerson>(unityContainer, "User");
            //string txt=instance.Speek();
            //Console.WriteLine(txt);
            //Console.ReadKey();
        }

        public static UnityContainer GetUnityContainer()
        {
            UnityContainer unityContainer = new UnityContainer();
            var unityFile = @"C:\Users\Administrator\Desktop\UnityIOC\UnityIOC\bin\Debug\Unity.config";
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = unityFile };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
            //unitySection.Configure(unityContainer, "defaultContainer");
            unityContainer.LoadConfiguration(unitySection, "defaultContainer");
           // UnityContainers.Add("10", unityContainer);
            return unityContainer;
        }

        public static T GetInstance<T>(UnityContainer unityContainer,string resolveName)
        {
            var instance = unityContainer.Resolve<T>(resolveName);
            return instance;
        }

    }
}
