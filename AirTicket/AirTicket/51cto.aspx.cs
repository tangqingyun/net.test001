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
    public partial class _51cto : System.Web.UI.Page
    {
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
        const string contentType = "application/x-www-form-urlencoded; charset=UTF-8";
        protected void Page_Load(object sender, EventArgs e)
        {

            string url = "https://www.yongche.com/login/?source=login&done=http%3A%2F%2Fwww.yongche.com";
            IList<ParamKeyValue> list = new List<ParamKeyValue>()
            {
                  new ParamKeyValue("email",""),
                  new ParamKeyValue("passwd",""),
                  new ParamKeyValue("reback","http%3A%2F%2Fdown.51cto.com"),
            };

            CookieCollection _cookies = new CookieCollection();
            new Cookie();
        
            CookieCollection resCookies;
            string content = HttpHelper.Post(url, list, "", out resCookies, 50 * 1000, userAgent, Encoding.UTF8, _cookies, contentType, null);
            url = "http://www.yongche.com/user/center.php?login_type=phone";
            string ncontent = HttpHelper.Get(url, null, userAgent, resCookies, contentType, null);

        }

    }
}

