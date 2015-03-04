using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Uni2uni.ERP.Common
{
    public static class SystemBase
    {
        /// <summary>
        /// 获取bin文件夹全路径
        /// </summary>
        /// <returns></returns>
        public static string GetBinPath()
        {
            var path = "";
            var hc = HttpContext.Current;
            path = hc != null ? hc.Server.MapPath("~/bin") : AppDomain.CurrentDomain.BaseDirectory;
            return path;
        }

        /// <summary>
        /// 获取根目录全路径
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath()
        {
            var path = "";
            var hc = HttpContext.Current;
            path = hc != null ? hc.Server.MapPath("~/") : AppDomain.CurrentDomain.BaseDirectory;
            return path;
        }

    }
}
