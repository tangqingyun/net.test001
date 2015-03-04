using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uni2uni.ERP.Configuration
{
    public static class Log4NetConfig
    {
        /// <summary>
        ///配置文件基础路径
        /// </summary>
        public static readonly string BasePath = GlobleConfig.ConfigFilesBasePath;

        /// <summary>
        ///log4net文件路径
        /// </summary>
        public static readonly string CommonFileFullName = BasePath + @"\log4net.config";
    }
}
