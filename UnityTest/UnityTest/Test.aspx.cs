using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IDal;
using Microsoft.Practices.Unity;


namespace UnityTest
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<IClass, MyClass>();
            ////另一种注册方法，不过没有RegisterType<>()方法来的方便
            ////container.RegisterType(typeof(IClass), typeof(MyClass));
            //IClass classInfo = container.Resolve<IClass>();

            ////另一种通过container获取具体对象的方法
            ////IClass classInfo = container.Resolve(typeof(IClass));
            //classInfo.ShowInfo();

          //  Microsoft.Practices.Unity.IUnityContainer container = new Microsoft.Practices.Unity.UnityContainer();
            //UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            ////section.Containers["containerOne"].Configure(container);
            //IClass classInfo = container.Resolve<IClass>("ConfigClass");
            //classInfo.ShowInfo();

        }

    }
}