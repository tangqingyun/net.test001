using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    class GiftCard : ICard
    {
        public void Deposit(double money)
        {
            Console.WriteLine("礼品卡存入：{0}", money);
        }

        public void Pay(double money)
        {
            Console.WriteLine("礼品卡支出：{0}", money);
        }
    }
}
