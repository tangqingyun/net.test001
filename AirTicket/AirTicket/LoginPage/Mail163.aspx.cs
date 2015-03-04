using ServiceForPetrolAutoRecharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket.LoginPage
{
    public partial class Mail163 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<ParamKeyValue> postData = new List<ParamKeyValue>() { 
                 new ParamKeyValue("__EVENTARGUMENT",""),
                     new ParamKeyValue("__EVENTTARGET",""),
                     new ParamKeyValue("__EVENTVALIDATION","/wEdAAUyDI6H/s9f+ZALqNAA4PyUhI6Xi65hwcQ8/QoQCF8JIahXufbhIqPmwKf992GTkd0wq1PKp6+/1yNGng6H71Uxop4oRunf14dz2Zt2+QKDEIYpifFQj3yQiLk3eeHVQqcjiaAP"),
                     new ParamKeyValue("__VIEWSTATE","/wEPDwULLTE1MzYzODg2NzZkGAEFHl9fQ29udHJvbHNSZXF1aXJlUG9zdEJhY2tLZXlfXxYBBQtjaGtSZW1lbWJlcm1QYDyKKI9af4b67Mzq2xFaL9Bt"),
                     new ParamKeyValue("btnLogin","登  录"),
                     new ParamKeyValue("tbPassword","tangqingyun"),
                     new ParamKeyValue("tbUserName","tqyitweb"),
                     new ParamKeyValue("txtReturnUrl","http://www.cnblogs.com/")
                };
            string url = "http://passport.cnblogs.com/login.aspx?ReturnUrl=http%3a%2f%2fwww.cnblogs.com%2f";
            CookieCollection resCookies;
            string result = HttpHelper.Post(url, postData, "", out resCookies, null, null, Encoding.UTF8, null, null, null);

            string url2 = "http://home.cnblogs.com/set/account/";
            string htmlContent = HttpHelper.Get(url2, null, null, resCookies);

        }
    }
}