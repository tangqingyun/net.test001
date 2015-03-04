using System;
using System.Collections.Generic;
using System.Linq;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Resource.Attribute;


namespace Uni2uni.ERP.Common.ExtensionMethod
{
    public static class DatabaseExtensionMethod
    {
        public static EnumDatabase GetDatabase(this Type t)
        {
            var att = t.GetCustomAttributes(false);
            foreach (var fieldDisplayAttribute in att.OfType<DatabaseAttribute>())
            {
                return fieldDisplayAttribute.DatabaseEnum;
            }
            return EnumDatabase.NHibernateDB;
        }

    }
}
