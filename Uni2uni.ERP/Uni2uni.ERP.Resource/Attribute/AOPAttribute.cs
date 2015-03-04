using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uni2uni.ERP.Resource.Attribute
{
    /// <summary>
    /// 只能作用于方法 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class AOPAttribute:System.Attribute
    {

    }
}
