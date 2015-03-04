using EntityFramework.MVC.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Reflection;


namespace EntityFramework.MVC.DomainMapping
{
    public class CourseMapping : EntityTypeConfiguration<Course>
    {
        public CourseMapping()
        {
            ToTable("Course");
            Property(x => x.CourseID).HasColumnName("CourseID");
            HasMany(c => c.Enrollments);
        }
    }
}
