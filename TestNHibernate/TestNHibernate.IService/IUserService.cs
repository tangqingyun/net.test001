using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNHibernate.Domain;

namespace TestNHibernate.IService
{
    public interface IUserService
    {
        bool Save(User user);
    }
}
