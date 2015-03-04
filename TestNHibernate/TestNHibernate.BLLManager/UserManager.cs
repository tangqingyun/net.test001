using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNHibernate.Domain;
using TestNHibernate.IService;
using TestNHibernate.Service;

namespace TestNHibernate.BLLManager
{
    public class UserManager
    {
        IUserService service;
        public UserManager()
        {
            service = new UserService();
        }

        public bool Save(User user)
        {
            return service.Save(user);
        }

    } 
}
