using ServiceForPetrolAutoRecharge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket
{
    public partial class yongche : System.Web.UI.Page
    {
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
        const string contentType = "application/x-www-form-urlencoded; charset=UTF-8";
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://www.yongche.com/login/?source=login&done=http%3A%2F%2Fwww.yongche.com";
            IList<ParamKeyValue> list = new List<ParamKeyValue>()
            {
                  new ParamKeyValue("login","15901473139"),
                  new ParamKeyValue("login_submit","denglu"),
                  new ParamKeyValue("password","tangqingyun"),
            };

            CookieCollection _cookies = new CookieCollection() { 
               
             };

            CookieCollection resCookies;
             string content = HttpHelper.Post(url, list, "", out resCookies, 50 * 1000, userAgent, Encoding.UTF8, _cookies, contentType, null);

            // Response.AddHeader("P3P", "CP=CAO PSA OUR");
            //  Response.Headers.Add("P3P", "CP=CAO PSA OUR");
         
            for (int i = 0; i < resCookies.Count; i++)
            {
                string key = resCookies[i].Name;
                string value=resCookies[i].Value;
                DateTime expires=resCookies[i].Expires;
                string domain=resCookies[i].Domain;
                DateTime timeStamp = resCookies[i].TimeStamp;
                string path = resCookies[i].Path;
                string port = resCookies[i].Port;
                bool httpOnly=resCookies[i].HttpOnly;
                string cookievalue = value + ";" + domain + ";" + path + ";expires=Sun,22-Feb-2015 00:00:00 GMT";
                CookieHelper.SetInternetCookie("http://yongche.com", key, cookievalue);
            }

           // System.Diagnostics.Process.Start("IEXPLORE.EXE", "http://www.yongche.com/user/center.php?login_type=phone");// 调用ie打开网页

           url = "http://www.yongche.com/user/center.php?login_type=phone";
           string ncontent = HttpHelper.Get(url, null, userAgent, resCookies, contentType, null);

            //"http://www.yongche.com?login_type=phone"
            //Response.Redirect(url);
        }


    }

}