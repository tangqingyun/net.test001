using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Uni2uni.ERP.Configuration;
using Uni2uni.ERP.Resource;

namespace Uni2uni.ERP.NHibernate
{
    public class SessionManager
    {
        private static readonly Hashtable SessionFactories = new Hashtable();
        public SessionManager()
        {
           
        }

        private static readonly object OpenCurrentSessionLock = new object();
        public static ISession OpenCurrentSession(EnumDatabase key)
        {
            lock (OpenCurrentSessionLock)
            {
                var context = HttpContext.Current;
                if (context != null)
                {
                    var fullKey = string.Format("{0}.{1}", NHibernateConfig.CurrentSessionKey, key);
                    var currentSession = context.Items[fullKey] as ISession;
                    if (currentSession == null)
                    {
                        currentSession = CreateSession(key);
                        context.Items[fullKey] = currentSession;
                    }
                    return currentSession;
                }
                else
                {      
                    
                    var currentSession = CreateSession(key);                  
                    return currentSession;
                }

            }
           
        }

        public static ISession CreateSession(EnumDatabase key)
        {
            var sf = CreateSessionFactory(key);
            var session = sf.OpenSession();
            return session;
        }

        private static readonly object GetSessionFactoryLock = new object();
        public static ISessionFactory CreateSessionFactory(EnumDatabase key)
        {
            lock (GetSessionFactoryLock)
            {
                if (SessionFactories.ContainsKey(key))
                {
                    return SessionFactories[key] as ISessionFactory;
                }

                var dbInfo = DatabaseConfig.GetDatabaseInfo(key);
                if (dbInfo == null)
                {
                    throw new Exception("指定的数据库配置不存在");
                }

                Assembly ass = Assembly.Load(NHibernateConfig.CurrentSessionMap);
                var sfc = Fluently.Configure();
                sfc = sfc.Database(
               MsSqlConfiguration.MsSql2008.ConnectionString(c => c
                        .Server(dbInfo.Server)
                        .Database(dbInfo.DatabaseName)
                        .Username(dbInfo.Username)
                        .Password(dbInfo.Password)
                    )
                );

                sfc=sfc.Mappings(m => m.FluentMappings.AddFromAssembly(ass));

                sfc =sfc.ExposeConfiguration(c =>c.SetProperty(global::NHibernate.Cfg.Environment.CommandTimeout,TimeSpan.FromMinutes(3).TotalSeconds.ToString()));

                ISessionFactory bf;
                try
                {
                    bf = sfc.BuildSessionFactory();
                    SessionFactories.Add(key, bf);
                }
                catch (Exception)
                {
                    
                    throw;
                }
              
                return bf;
            }
           
        }

        public static void CloseCurrentSession()
        {
            var context = HttpContext.Current;
            if (context == null)
            {
                return;
            }
            var currentSession = context.Items[NHibernateConfig.CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                return;
            }
            currentSession.Close();
            context.Items.Remove(NHibernateConfig.CurrentSessionKey);
        }

        public static void CloseSessionFactory(EnumDatabase key)
        {
            if (SessionFactories.ContainsKey(key))
            {
                var sf = SessionFactories[key] as ISessionFactory;
                if (sf != null)
                {
                    sf.Close();
                }
            }
        }

    }



}
