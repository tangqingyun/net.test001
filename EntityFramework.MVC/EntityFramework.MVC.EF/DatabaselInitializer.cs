using EntityFramework.MVC.Domain;
using EntityFramework.MVC.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EntityFramework.MVC.EF
{
    public class DatabaselInitializer : DropCreateDatabaseIfModelChanges<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            context.Customers.Add(new Customer()
            {
                Address = "北京",
                CustomerName = "zhangsan",
                Gender = "男",
                IDCardNumber = "79879879",
                PhoneNumber = "13260185578"
            });

            //courses.ForEach(s => context.Courses.Add(s)); context.SaveChanges();

            //var enrollments = new List<Enrollment> { 
            //    new Enrollment { StudentID = 1, CourseID = 1, Grade = 1 }, 
            //    new Enrollment { StudentID = 1, CourseID = 2, Grade = 3 }, 
            //    new Enrollment { StudentID = 1, CourseID = 3, Grade = 1 }, 
            //    new Enrollment { StudentID = 2, CourseID = 4, Grade = 2 }, 
            //    new Enrollment { StudentID = 2, CourseID = 5, Grade = 4 } }; 

            // enrollments.ForEach(s => context.Enrollments.Add(s)); context.SaveChanges();
        }
    }
}
