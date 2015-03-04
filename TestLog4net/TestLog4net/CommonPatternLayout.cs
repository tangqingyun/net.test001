using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLog4net
{
    public class CommonPatternLayout : PatternLayout
    {
        public CommonPatternLayout()
        {
            this.AddConverter("property", typeof(XPatternLayoutConverter));
        }
    }
}
