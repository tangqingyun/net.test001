using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain;

namespace Uni2uni.ERP.NHiberantMap
{
    public class ProductCategoryMap : StandardClassMap<ProductCategory,Guid>
    {
        public ProductCategoryMap()
            : base("CategoryID")
        {
            Table("ProductCategory");
            DynamicUpdate();           
            Map(m => m.CategoryName).Not.Nullable();
            //Map(m => m.ParentId).Not.Nullable();

            References(m => m.ParentId)
                .Column("ParentId")
                .Insert()
                .Update();

            HasMany(m => m.ChildrenList)
                .KeyColumn("ParentId")
                .Inverse()
                .ExtraLazyLoad()
                .Cascade.All();
        }

    }
}
