using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDal;

namespace Dal
{
    public class MyClass : IClass
    {
        public MyClass()
        {

        }

        public void ShowInfo()
        {
            Console.WriteLine("这个是我的班级");
        }
    }
}
