using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DataBaseAttribute:System.Attribute
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DatabaseName { set; get; }
    }
}
