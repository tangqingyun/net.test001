using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNHibernate.BLLManager;
using TestNHibernate.Domain;

namespace TestNHibernate.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserManager bll = new UserManager();
            User user = new User
            {
                ID = Guid.NewGuid(),
                UserName = "zhangsan",
                Sex = "男"
            };
            bool bol=bll.Save(user);
            Assert.IsFalse(bol, "失败");
        }
    }
}
