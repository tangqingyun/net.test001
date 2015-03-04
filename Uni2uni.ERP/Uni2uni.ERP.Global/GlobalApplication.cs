using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Configuration;
using Uni2uni.ERP.NHibernate;

namespace Uni2uni.ERP.Global
{
    public class GlobalApplication
    {
        private static bool Application_Started = false;
        private static readonly object Application_Started_LockObj = new object();

        public static void Application_Start()
        {
            lock (Application_Started_LockObj)
            {
                if (Application_Started)
                {
                    return;
                }
                Application_Started = true;
                try
                {
                    //启动Hibernate Profiler监视
                    log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Log4NetConfig.CommonFileFullName));
                    var nHibernateAppenderConfiguration = new HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateAppenderConfiguration
                    {
                        HostToSendProfilingInformationTo = HibernatingProfilerConfig.HostToSendProfilingInformationTo,
                        Port = HibernatingProfilerConfig.Port
                    };

                    if (HibernatingProfilerConfig.FileToLogToEnable)
                    {
                        nHibernateAppenderConfiguration.FileToLogTo = HibernatingProfilerConfig.FileToLogTo;
                    }
                    HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize(
                        nHibernateAppenderConfiguration);
                }
                catch (Exception ex)
                {
                    new Exception("初始化失败！" + ex.Message);
                }

            }
           

        }

        public static void Session_End(object sender, EventArgs e)
        {
            SessionManager.CloseCurrentSession();
        }

    }
}
