using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using EntityFramework.MVC.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using EntityFramework.MVC.DomainMapping;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.MVC.EF
{
   
    public class EFContext:DbContext
    {
        public static readonly string connectionString = "server=127.0.0.1;database=EFMvcDB;uid=sa;pwd=000000";
        public EFContext()
        {
            Database.SetInitializer<EFContext>(null);
        }
        public IList<IMapping> Mappings { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EFContext>(new DatabaselInitializer());
            //Database.SetInitializer(new DropCreateDatabaseAlways<EFContext>());
            base.OnModelCreating(modelBuilder);            

            //移除复数表名的契约    
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //防止黑幕交易 要不然每次都要访问 EdmMetadata这个表
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
           
        }


      
    }
}
