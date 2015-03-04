using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Global;

namespace JUnit
{
    public class TestBase
    {
        public TestBase()
        {
            GlobalApplication.Application_Start();
        }
    }
}
