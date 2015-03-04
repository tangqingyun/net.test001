using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class BankCard:ICard
    {
        public void Deposit(double money)
        {
            Console.WriteLine("银行卡存入：{0}", money);
        }

        public void Pay(double money)
        {
            Console.WriteLine("银行卡支出：{0}", money);
        }
    }
}
