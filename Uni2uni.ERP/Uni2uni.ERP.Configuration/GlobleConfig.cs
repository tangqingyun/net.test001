using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Common;

namespace Uni2uni.ERP.Configuration
{
    public static class GlobleConfig
    {
        /// <summary>
        /// 默认时间格式
        /// </summary>
        public static readonly string DefaultDateTimeForamt = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 默认时间
        /// </summary>
        public static readonly DateTime DefaultDateTime = new DateTime(2000, 1, 1);

        /// <summary>
        /// bin文件夹全路径
        /// </summary>
        /// <returns></returns>
        public static readonly string GetBinPath = SystemBase.GetBinPath();

        /// <summary>
        /// Config文件所在文件夹全路径
        /// </summary>
        /// <returns></returns>
        public static readonly string ConfigFilesBasePath = GetBinPath + @"\ConfigFiles";

    }
}
