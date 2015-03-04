using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yun.shop.domain;

namespace yun.shop.domainMap
{
    public class CategoryMap : StandardEntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            Property(m => m.CategoryID).IsRequired();
            Property(m => m.CategoryName).IsRequired().HasMaxLength(30);
            HasKey(m => m.CategoryID);//设置主键

            HasMany(m => m.Children)
                .WithOptional(x => x.ParentCategory)
                .Map(x=>x.MapKey("ParentID"));
        }
    }
}
