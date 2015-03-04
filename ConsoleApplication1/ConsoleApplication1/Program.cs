using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using IDal;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IUnityContainer container = new UnityContainer();
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                //section.Containers["containerOne"].Configure(container);
                section.Configure(container, "containerOne");
                IClass classInfo = container.Resolve<IClass>("ConfigClass");
                classInfo.ShowInfo();
                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
