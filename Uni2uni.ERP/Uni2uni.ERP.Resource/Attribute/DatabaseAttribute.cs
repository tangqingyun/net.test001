using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uni2uni.ERP.Resource.Attribute
{
    /// <summary>
    /// 数据库属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class DatabaseAttribute : System.Attribute
    {
        public EnumDatabase DatabaseEnum { set; get; }
    }
}
