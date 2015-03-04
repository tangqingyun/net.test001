using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain;

namespace Uni2uni.ERP.NHiberantMap
{
    public class ProductMap : StandardClassMap<Product, Guid>
    {
        public ProductMap()
            : base("ProductID")
        {
            Table("Product");
            DynamicUpdate();
            Map(m => m.ProductName).Not.Nullable();

            //产品分类与产品做映射关联
            References(m => m.Category)
                .Column("CategoryID")
                .Insert()
                .Update(); 

            //产品ProductID字段与商品做映射关联
            HasMany(m => m.GoodsList)
                .KeyColumn("ProductID")
                .Inverse() //true 父实体负责维护关联关系  true子实体负责维护关联关系
                .ExtraLazyLoad() //延迟加载
                .Cascade.All();    //级联更新 级联删除
        }

    }
}
