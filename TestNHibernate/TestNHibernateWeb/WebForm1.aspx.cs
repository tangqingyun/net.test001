using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestNHibernate.BLLManager;
using TestNHibernate.Domain;

namespace TestNHibernateWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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