using EntityFramework.MVC.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace EntityFramework.MVC.DomainMapping
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
           
            HasKey(c => c.IDCardNumber).Property(c => c.IDCardNumber).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(c => c.IDCardNumber).HasMaxLength(20);
            this.Property(c => c.CustomerName).IsRequired().HasMaxLength(50);
            this.Property(c => c.Gender).IsRequired().HasMaxLength(1);
            this.Property(c => c.PhoneNumber).HasMaxLength(20);
        }
    }
}
