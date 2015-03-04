using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEventTwo
{
    public class MemberDao
    {
        public MemberDao() { }
        public delegate void LogDelegate(object sender, LogEventArgs args);
        public event LogDelegate LogEvent;
        public bool Add()
        {
            Console.WriteLine("添加成功！");
            if (this.LogEvent != null)
            {
                LogEvent(this, new LogEventArgs()
                {
                    Creater = Guid.NewGuid(),
                    InsertDate = DateTime.Now
                });
            }
            return true;
        }

    }
}
