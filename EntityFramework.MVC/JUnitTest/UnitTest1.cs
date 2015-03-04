using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using EntityFramework.MVC.EF;
using EntityFramework.MVC.Domain;
using System.Collections.Generic;

namespace JUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var db = new DatabaselInitializer();
            //Database.SetInitializer<EFContext>(db);
            Guid courseID = Guid.NewGuid();
            Enrollment enrollment = new Enrollment();
          
            //Course model = new Course
            //{
            //    CourseID = courseID,
            //    Title = "China",
            //    Credits = 3
            //};

            //using (EFContext context = new EFContext())
            //{
            //    context.Courses.Add(model);
            //    context.SaveChanges();
            //}
        }

        [TestMethod]
        public void TestCustomer()
        {
         
            EFContext context = new EFContext();
            Customer customer = new Customer();
            customer.Address = "上海";
            customer.CustomerName = "lishi";
            customer.Gender = "男";
            customer.IDCardNumber = "456464";
            customer.PhoneNumber = "13265789963";
            context.Customers.Add(customer);
            context.SaveChanges();
            context.Dispose();
        }

        [TestMethod]
        public void GetSingeData()
        {
            using (EFContext context = new EFContext())
            {
                var sss = context.Courses.Find(new Guid("D4108572-FDE8-43D5-80D8-2DFF892D66DD"));
            }
        }

    }
}
