using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLog4net
{
    public class SystemSqlLog
    {
        public SystemSqlLog(string message)
        {
            Message = message;
            CreateDate = DateTime.Now;
            Category = string.Empty;
            IP = string.Empty;
            UrlFull = string.Empty;
            Thread = string.Empty;
            LogLevel = string.Empty;
            Logger = string.Empty;
            Title = string.Empty;
            Exception = string.Empty;
        }
        public string Category { set; get; }
        public string IP { set; get; }
        public string UrlFull { set; get; }
        public string Thread { set; get; }
        public string LogLevel { set; get; }
        public string Logger { set; get; }
        public string Title { set; get; }
        public string Exception { set; get; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
