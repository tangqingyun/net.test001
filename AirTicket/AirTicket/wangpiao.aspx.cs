using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket
{
    public partial class wangpiao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ss = HttpUtility.UrlEncodeUnicode("tangqingyuncx@qq.com");
            
            //Response.Write(ss);
            WebClient web = new WebClient();
           // string content=web.DownloadString("http://www.yongche.com/user/center.php?login_type=phone");
            
        }
    }
}