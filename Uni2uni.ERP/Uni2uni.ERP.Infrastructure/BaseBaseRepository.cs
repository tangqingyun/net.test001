using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Common.ExtensionMethod;
using System.Data.SqlClient;
using NHibernate;

namespace Uni2uni.ERP.Infrastructure
{
    public abstract class BaseBaseRepository
    {
         private readonly EnumDatabase _database;
         public BaseBaseRepository()
        {
            _database = GetType().GetDatabase();
           
        }

       
        protected class HqlParamenter
        {
            
            /// <summary>
            /// 参数名，必需
            /// </summary>
            public string ParameterName { get; set; }
            /// <summary>
            /// 参数值，当Values为null时有效
            /// </summary>
            public object Value { get; set; }
            /// <summary>
            /// 参数值（多条）
            /// </summary>
            public IList<object> ValueList { get; set; }
            /// <summary>
            /// 参数类型，必需
            /// </summary>
           // public NHibernate.Type.IType ParameterType { get; set; }
        }

    }
}
