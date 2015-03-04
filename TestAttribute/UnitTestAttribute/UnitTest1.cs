using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAttribute;

using System.Collections.Generic;
using System.Linq;

namespace UnitTestAttribute
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string dname = GetCustomAttributes(typeof(Member));
            Assert.IsNotNull(dname);
        }

        public string GetCustomAttributes(Type t)
        {
            var att = t.GetCustomAttributes(false);
            foreach (var fieldDisplayAttribute in att.OfType<DataBaseAttribute>())
            {
                return fieldDisplayAttribute.DatabaseName;
            }
            return null;
        }

        public IEnumerable<T> GetCustomAttributes<T>(Type t)
        {
            var att = t.GetCustomAttributes(false);
            return att.OfType<T>();
        }

    }

}
