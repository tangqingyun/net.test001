using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yun.shop.domain;
using yun.shop.domainMap;

namespace yun.shop.entityframework
{
    public class ShopContext:DbContext
    {

        public ShopContext() { }

        public ShopContext(string database)
            : base(database){ }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除复数表名的契约 
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //防止黑幕交易 要不然每次都要访问 EdmMetadata这个表 
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Configurations.Add(new CategoryMap());
        }

        public DbSet<Category> Categories { set; get; }

    }
}
