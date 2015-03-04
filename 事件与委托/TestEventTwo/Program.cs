using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEventTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberBll bll = new MemberBll();
            bll.Add();
            Console.ReadKey();
        }
    }
}
