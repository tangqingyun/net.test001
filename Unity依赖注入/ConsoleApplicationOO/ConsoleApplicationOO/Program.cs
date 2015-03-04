using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using IDal;
using System.Web;

namespace ConsoleApplicationOO
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUnityContainer container = new UnityContainer();
            //UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //section.Configure(container, "containerOne");
            //IPerson person = container.Resolve<IPerson>("PersonClass");
            //string ss = person.Speak("");
            //Console.WriteLine(ss);

            UnityContainer unityContainer = GetUnityContainer();
            IPerson person = unityContainer.Resolve<IPerson>("PersonClass");
            Console.WriteLine(person.Speak(""));


          
            //ISeend send = unityContainer.Resolve<ISeend>("SeendClass");
            //Console.WriteLine(send.Send());
            Console.ReadKey();
        }

        /// <summary>
        /// 获取bin文件夹路径
        /// </summary>
        /// <returns></returns>
        public static string GetBinPath()
        {
            var path = "";
            var hc = HttpContext.Current;
            path = hc != null ? hc.Server.MapPath("~/bin") : AppDomain.CurrentDomain.BaseDirectory;
            return path;
        }

        public static UnityContainer GetUnityContainer()
        {
            UnityContainer unityContainer = new UnityContainer();
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = GetBinPath()+"Unity.config" };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
            unityContainer.LoadConfiguration(unitySection, "defaultContainer");
            return unityContainer;
        }

    }

}
