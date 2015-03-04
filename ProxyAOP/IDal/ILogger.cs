using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDal
{
    public interface ILogger
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message"></param>
        void LogWrite(string message);

    }
}
