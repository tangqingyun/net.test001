using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web;
namespace TestPhoneRegion
{
    [TestFixture]
    public class NunitTest
    {
        PhoneService ps;
        public NunitTest() {
            ps = new PhoneService();
        }

        [Test]
        public void GetMobileInofTest()
        {
            PhoneInfo phone=ps.GetMobilePhone360Info("");
            Assert.AreNotEqual(phone,null);
            Console.Out.Write("输出字符");
        }

    }
}
