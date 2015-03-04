using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPictureValidate
{
    class Program
    {
        /// <summary>
        /// 图片验证码识别程序
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //图片验证码识别
            string imgsrc = "http://admin.5a360.com/ajax/validatacode.ashx";
            string dbugDir = AppDomain.CurrentDomain.BaseDirectory+@"Images";
            VerificCode code = new VerificCode();
            string filePath=code.DownloadVerificCode(dbugDir,imgsrc);
            string validateCode = code.AnalysisVerficCode(filePath);
            Console.WriteLine(validateCode);
            Console.ReadKey();
        }
    }
}
