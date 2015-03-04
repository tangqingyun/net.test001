using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            string path = @"C:\Users\Administrator\Desktop\Login\fdsafdsafdsf.html";
            Process.Start(path); 

            //HttpCookie cookie = new HttpCookie("login_uid", "dfsdfsdfd");
            //cookie.Domain = "ctrip.com";
            //cookie.Path = "/";
            //cookie.Expires = DateTime.Now.AddDays(1);
            //Response.Cookies.Add(cookie);
           // string html = webClient.DownloadString("https://accounts.ctrip.com/member/login.aspx");
            //Response.Write(html);

        }
    }
}