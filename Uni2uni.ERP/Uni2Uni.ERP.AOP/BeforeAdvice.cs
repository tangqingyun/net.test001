using Spring.Aop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Uni2uni.ERP.Common;
using Uni2uni.ERP.Resource.Attribute;

namespace Uni2Uni.ERP.AOP
{
    public class BeforeAdvice : IMethodBeforeAdvice
    {
        public void Before(System.Reflection.MethodInfo method, object[] args, object target)
        {
            object[] attr = method.GetCustomAttributes(typeof(AOPAttribute), false);
            if (attr.Length == 0)
            {
                return;
            }        
            string path=SystemBase.GetBinPath() + @"\error.txt";
            if (!File.Exists(path))
            {
                FileStream fs=File.Create(path);
                fs.Close();
            }
            using (StreamWriter sw = new StreamWriter(path,true))
            {
                sw.WriteLine("方法开始" + method.Name);
                sw.Close();
            }
        }
    }
}
