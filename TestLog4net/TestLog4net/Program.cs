using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestLog4net
{
    class Program
    {
        static void Main(string[] args)
        {

            #region MyRegion
            //string file = AppDomain.CurrentDomain.BaseDirectory + "log4net.config";
            //log4net.Config.XmlConfigurator.Configure(new FileInfo(file));//加载log4net配置文件;
            //log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
            //log.Info("eeeeeeee");
            //  ILog InfoLogger = LogManager.GetLogger("MethodActiveLogAdapter");
            //ILog InfoLogger = LogManager.GetLogger(typeof(SystemCommonPatternMessage));
            //ILog fileLogger = LogManager.GetLogger("SystemCommonErrorLogAdapter_RollingFile");
            //if (fileLogger.IsErrorEnabled)
            //{
            //    fileLogger.Error("写入错误信息01：error");
            //}
            //ILog InfoLogger = LogManager.GetLogger("MethodActiveLogAdapter");

            //if (!InfoLogger.IsInfoEnabled)
            //{
            //    return;
            //}
            //SystemSqlLog model = new SystemSqlLog("写入日志内容sdsds");
            //InfoLogger.Info(model);
            //Console.WriteLine("写入成功!"); 
            #endregion
            
           
            Console.ReadKey();
        }
    }
}
