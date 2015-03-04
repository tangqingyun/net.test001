using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Uni2uni.ERP.Configuration
{
    public static class HibernatingProfilerConfig
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public static bool Enable = GetBoolFromAppSettings("HibernatingProfiler.Enable");

        /// <summary>
        /// 监听地址
        /// </summary>
        public static readonly string HostToSendProfilingInformationTo = ConfigurationManager.AppSettings["HibernatingProfiler.HostToSendProfilingInformationTo"];

        private static readonly string PortStr = ConfigurationManager.AppSettings["HibernatingProfiler.Port"];
        /// <summary>
        /// 监听端口
        /// </summary>
        public static readonly int Port = string.IsNullOrWhiteSpace(PortStr) ? 22897 : int.Parse(PortStr);

        /// <summary>
        /// 写入到文件是否启用
        /// </summary>
        public static bool FileToLogToEnable = GetBoolFromAppSettings("HibernatingProfiler.FileToLogToEnable");
        /// <summary>
        /// 写入到文件
        /// </summary>
        public static readonly string FileToLogTo =ConfigurationManager.AppSettings["HibernatingProfiler.FileToLogTo"];

        public static bool GetBoolFromAppSettings(string settingKey)
        {
            var value = ConfigurationManager.AppSettings[settingKey];
            return !String.IsNullOrWhiteSpace(value) && Boolean.Parse(value);
        }

    }
}
