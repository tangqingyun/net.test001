using ServiceForPetrolAutoRecharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket
{
    public partial class AutoLogin : System.Web.UI.Page
    {
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
        const string contentType = "application/x-www-form-urlencoded; charset=utf-8";
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "http://www.yongche.com/";
           // url = "http://www.baidu.com";

            CookieHelper.SetInternetCookie(url, "myddd", "0123456;expires=Sun,22-Feb-2099 00:00:00 GMT");

            Uri uri = new Uri(url);
            CookieContainer cookie = CookieHelper.GetInternetCookie(uri);
            CookieCollection collection=cookie.GetCookies(uri);

            url = "http://www.yongche.com/user/center.php?login_type=phone";
            string ncontent = HttpHelper.Get(url, null, userAgent, collection, contentType, null);

        }

      

    }


}