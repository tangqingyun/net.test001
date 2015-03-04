using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEvent
{
    /// <summary>
    /// 事件参数
    /// </summary>
    public class OnUserRequestEventArgs : EventArgs
    {
        public string Name { set; get; }
    }
}
