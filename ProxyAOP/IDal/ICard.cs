using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDal
{
    public interface ICard
    {
        /// <summary>
        /// 存入
        /// </summary>
        /// <param name="money"></param>
        void Deposit(double money);
        /// <summary>
        /// 支出
        /// </summary>
        /// <param name="money"></param>
        void Pay(double money);

    }
}
