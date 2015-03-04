using Spring.Aop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Uni2uni.ERP.Common;
using Uni2uni.ERP.Resource.Attribute;

namespace Uni2Uni.ERP.AOP
{
    public class AfterReturningAdvice : IAfterReturningAdvice
    {
        public void AfterReturning(object returnValue, System.Reflection.MethodInfo method, object[] args, object target)
        {
            object[] attr = method.GetCustomAttributes(typeof(AOPAttribute), false);
            if (attr.Length == 0)
            {
                return;
            }
            string file = SystemBase.GetBinPath() + @"\error.txt";
            if (!File.Exists(file))
            {
                FileStream fs = File.Create(file);
                fs.Close();
            }
            using (StreamWriter sw = new StreamWriter(file,true))
            {
                sw.WriteLine("方法结束" + method.Name);
                sw.Close();
            }
        }
    }
}
