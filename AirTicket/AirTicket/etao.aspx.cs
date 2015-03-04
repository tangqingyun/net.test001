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
    public partial class etao : System.Web.UI.Page
    {
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
        const string contentType = "application/x-www-form-urlencoded; charset=gbk";
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://login.taobao.com/member/login.jhtml";
            IList<ParamKeyValue> list = new List<ParamKeyValue>()
            {
                  new ParamKeyValue("TPL_username","15901473139"),
                  new ParamKeyValue("TPL_password","*tamny2tamny*"),
                  new ParamKeyValue("loginsite","0"),
                  new ParamKeyValue("newlogin",""),
                  new ParamKeyValue("TPL_redirect_url","http://login.etao.com/loginmid.html?redirect_url=http%3A%2F%2Fdianying.taobao.com%2F&"),
                  new ParamKeyValue("from","etao"),
                  new ParamKeyValue("fc","default"),
                  new ParamKeyValue("style","miniall"),
                  new ParamKeyValue("css_style","etao"),
                  new ParamKeyValue("tid",""),
                  new ParamKeyValue("support","000001"),
                  new ParamKeyValue("CtrlVersion","1,0,0,7"),
                  new ParamKeyValue("loginType","3"),
                  new ParamKeyValue("minititle","etao"),
                  new ParamKeyValue("minipara",""),
                  new ParamKeyValue("umto","T5748f211cce20f0f547e9e4d881bea54"),
                  new ParamKeyValue("pstrong",""),
                  new ParamKeyValue("llnick",""),
                  new ParamKeyValue("sign",""),
                  new ParamKeyValue("need_sign",""),
                  new ParamKeyValue("isIgnore",""),
                  new ParamKeyValue("full_redirect","true"),
                  new ParamKeyValue("popid",""),
                  new ParamKeyValue("callback",""),
                  new ParamKeyValue("guf",""),
                  new ParamKeyValue("not_duplite_str",""),
                  new ParamKeyValue("need_user_id",""),
                  new ParamKeyValue("poy",""),
                  new ParamKeyValue("gvfdcname",""),
                  new ParamKeyValue("from_encoding",""),
                  new ParamKeyValue("sub",""),
                  new ParamKeyValue("oslanguage",""),
                  new ParamKeyValue("sr",""),
                  new ParamKeyValue("osVer",""),
                  new ParamKeyValue("naviVer",""),
            };
            CookieCollection _cookies = new CookieCollection(){ };
            CookieCollection resCookies;
            string content = HttpHelper.Post(url, list, "", out resCookies, 50 * 1000, userAgent, Encoding.UTF8, _cookies, contentType, null);

            for (int i = 0; i < resCookies.Count; i++)
            {
                string key = resCookies[i].Name;
                string value = resCookies[i].Value;
                DateTime expires = resCookies[i].Expires;
                string domain = resCookies[i].Domain;
                DateTime timeStamp = resCookies[i].TimeStamp;
                string path = resCookies[i].Path;
                string port = resCookies[i].Port;
                bool httpOnly = resCookies[i].HttpOnly;
                string cookievalue = value + ";" + path + ";expires=Sun,22-Feb-2015 00:00:00 GMT";
                CookieHelper.SetInternetCookie("http://taobao.com", key, cookievalue);
            }
            url = "http://member1.taobao.com/member/fresh/account_security.htm?spm=0.0.0.0.lLE04R";    
            string ncontent = HttpHelper.Get(url, null, userAgent, resCookies, contentType, null);
        }


    }
}