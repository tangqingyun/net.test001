using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uni2uni.ERP.Configuration
{
    public static class NHibernateConfig
    {
        /// <summary>
        /// 实体映射类库
        /// </summary>
        public static readonly string CurrentSessionMap="Uni2uni.ERP.NHiberantMap";

        /// <summary>
        /// nhibernateyge的session键值
        /// </summary>
        public const string CurrentSessionKey = "nhibernate.current_session";

    }
}
