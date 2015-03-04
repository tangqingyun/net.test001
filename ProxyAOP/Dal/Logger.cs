using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class Logger : ILogger
    {
        public void LogWrite(string message)
        {
            Console.WriteLine("写入到SQL Server 数据库中：" + message);
        }

    }
}
