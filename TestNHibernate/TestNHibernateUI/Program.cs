using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNHibernate.BLLManager;
using TestNHibernate.Domain;

namespace TestNHibernateUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager bll = new UserManager();
            User user = new User
            {
                ID = Guid.NewGuid(),
                UserName = "zhangsan",
                Sex = "男"
            };
            bool bol = bll.Save(user);
        }
    }
}
