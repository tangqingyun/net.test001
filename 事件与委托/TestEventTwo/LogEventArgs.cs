using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEventTwo
{
    /// <summary>
    /// 日志事件参数
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        public Guid Creater { set; get; }
        public DateTime InsertDate { set; get; }
    }
}
