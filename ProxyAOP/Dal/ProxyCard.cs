using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class ProxyCard
    {
        private ICard target;
        public ProxyCard(ICard target)
        {
            this.target = target;
        }

        public void Invoke(string method, object[] parameters)
        {
            if (target != null)
            {
                ILogger log = new Logger();
                double money = double.Parse(parameters[0].ToString());
                switch (method)
                {
                    case "Pay":
                        log.LogWrite("日志：" + DateTime.Now+ "支出" + money.ToString());
                        break;
                    case "Deposit":
                        log.LogWrite("日志：" + DateTime.Now + "存入" + money.ToString());
                        break;
                }
                Type type = target.GetType();
                type.GetMethod(method).Invoke(target, parameters);
            }
        }

    }
}
