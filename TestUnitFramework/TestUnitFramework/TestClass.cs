using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TestUnitFramework
{
    [TestFixture]
    public class TestClass
    {
        public TestClass() { }

        [Test]
        public void TestAdd()
        {
            int a = 1;
            int b = 2;
            int sum = a + b;
            Assert.AreEqual(sum, 3); 
        }

    }
}
