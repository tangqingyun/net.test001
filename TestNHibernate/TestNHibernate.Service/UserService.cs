using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNHibernate.Domain;
using TestNHibernate.IService;

namespace TestNHibernate.Service
{
    public class UserService : IUserService
    {
        private ISession session;
        public UserService(){
            var sessionManager = new SessionManager();
            ISessionFactory sessionFactory = sessionManager.CreateSessionFactory();
      
            session=sessionFactory.OpenSession();
         
        }
        public bool Save(User user)
        {
            session.Save(user);
            session.Flush();
            return true;
        }

    }
}
