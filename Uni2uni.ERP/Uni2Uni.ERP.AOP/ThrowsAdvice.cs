using Spring.Aop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Uni2uni.ERP.Common;

namespace Uni2Uni.ERP.AOP
{
    public class ThrowsAdvice : IThrowsAdvice
    {
        public void AfterThrowing(Exception ex)
        {
            string file = SystemBase.GetBinPath() + @"\error.txt";
            if (!File.Exists(file))
            {
                FileStream fs = File.Create(file);
                fs.Close();
            }
            //记录异常日志;
            using (StreamWriter sw = new StreamWriter(file,true))
            {
                sw.WriteLine("异常消息：" + ex.Message);
                sw.Close();
            }

        }
        
    }
}
