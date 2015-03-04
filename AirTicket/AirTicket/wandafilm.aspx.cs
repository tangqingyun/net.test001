using ServiceForPetrolAutoRecharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket
{
    public partial class wandafilm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            IList<ParamKeyValue> list = new List<ParamKeyValue>() { 
                     new ParamKeyValue("autoLogin","true"),
                     new ParamKeyValue("code",""),
                     new ParamKeyValue("email","15901473139"),
                     new ParamKeyValue("password","a123456")
             };

            string url = "http://www.wandafilm.com/login.do?m=ajaxLogin";
           // string ncontent = HttpHelper.Post(url, list, null, 50 * 1000, null, Encoding.UTF8, null, null);
            CookieCollection hwrCookies;
            string result = HttpHelper.Post(url, list, "", out  hwrCookies, null, null, Encoding.UTF8, null, null, null); 

            //out CookieCollection cookies,
            Response.Write(result);

        }
    }
}