using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestNHibernate.Service
{
    public class SessionManager
    {
        public string Server;
        public string DatabaseName;
        public string Username;
        public string Password;

        public SessionManager() {
            this.Server = "127.0.0.1";
            this.DatabaseName = "NHibernateDB";
            this.Username = "sa";
            this.Password = "000000";
        }

        public ISessionFactory CreateSessionFactory()
        {
            
            Assembly assemblyMapping = Assembly.Load("TestNHibernate.Mapping");
return Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(c =>
                c.Server(Server)
                .Database(DatabaseName)
                .Username(Username)
                .Password(Password)))
                .Mappings(m => m.FluentMappings.AddFromAssembly(assemblyMapping))
                                                                    .BuildSessionFactory();
            
        }

    }

}
