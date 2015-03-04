using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEventThree
{
    public class Host
    {
        public Host(Dog dog)
        {
            dog.AlarmEvent += new Dog.AlramEventHander(HostHandleAlarm);
        }

        void HostHandleAlarm(object sender, EventArgs args)
        {
            Console.WriteLine("主  人: 抓住了小偷！");  
        }

    }
}
