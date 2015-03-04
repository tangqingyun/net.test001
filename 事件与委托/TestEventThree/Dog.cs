using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEventThree
{
    /// <summary>
    /// 狗实体
    /// </summary>
    public class Dog
    {
        public delegate void AlramEventHander(object sender, EventArgs args);
        public event AlramEventHander AlarmEvent;
        public void OnAlarm()
        {
            if (AlarmEvent != null)
            {
                while (true)
                {
                    string txt = Console.ReadLine();
                    if (txt != "abc")
                        return;
                    AlarmEvent(this, new EventArgs());
                }
            }
        }
    }
}
