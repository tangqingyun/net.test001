using Dal;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProxyAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            
             
            ICard card = new BankCard();
            ProxyCard proxy = new ProxyCard(card);
            proxy.Invoke("Pay", new object[] { 100 });
            proxy.Invoke("Deposit", new object[] { 100 });
            Console.ReadKey();
        }
    }
}
