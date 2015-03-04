using Domain;
using IDal;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringDotNetDI
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext context = ContextRegistry.GetContext();
            //var dal = context.GetObject("card") as ICard;
            //dal.Pay(100);
            var tamny=context.GetObject("tamny") as Tamny;
            Console.WriteLine(tamny.Name);
            Console.ReadKey();
        }
    }
}
