using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain;

namespace Uni2uni.ERP.NHiberantMap
{
    public abstract class StandardClassMap<TDomain, TId> : ClassMap<TDomain> where TDomain : StandardEntity<TId>
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="keyName">需传入主键字段名称</param>
        public StandardClassMap(string keyName="")
        {
            //映射公共字段
            var identityPart=Id(x => x.Id);//映射主键
            if (!string.IsNullOrWhiteSpace(keyName))
            {
                identityPart.Column(keyName);
            }
            Map(m => m.Creater);
            Map(m => m.CreateDate);
            Map(m => m.Updater);
            Map(m => m.UpdateDate);
        }
    }
}
