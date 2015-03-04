using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Common;

namespace Uni2uni.ERP.Unity
{
    public static class InstanceFactory
    {
        private static readonly Hashtable UnityContainers = new Hashtable();
        static InstanceFactory()
        {

        }


        /// <summary>
        /// 创建服务层实例
        /// </summary>
        /// <typeparam name="T">接口类型</typeparam>
        /// <param name="resolveName">实例配置名称</param>
        /// <returns></returns>
        public static T GetServiceInstance<T>(string resolveName = "")
        {
            return GetInstance<T>(resolveName);
        }

        /// <summary>
        /// 获取UnityContainer
        /// </summary>
        /// <returns></returns>
        private static readonly object UnityContainerLock = new object();
        public static UnityContainer GetUnityContainer()
        {
            lock (UnityContainerLock)
            {
                try
                {
                    string key = "service";
                    if (UnityContainers.ContainsKey(key))
                    {
                        return UnityContainers[key] as UnityContainer;
                    }
                    UnityContainer unityContainer = new UnityContainer();
                    var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = SystemBase.GetBinPath() + @"\ConfigFiles\UnityService.config" };
                    var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                    var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
                    unityContainer.LoadConfiguration(unitySection, "defaultContainer");
                    UnityContainers.Add(key, unityContainer);
                    return unityContainer;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }


        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T">接口类型</typeparam>
        /// <param name="resolveName">实例配置名称</param>
        /// <returns></returns>
        public static T GetInstance<T>(string resolveName)
        {
            if (string.IsNullOrWhiteSpace(resolveName))
            {
                resolveName = "defaultRegister";
            }
            var unityContainer = GetUnityContainer();
            return unityContainer.Resolve<T>(resolveName);
        }


    }
}
