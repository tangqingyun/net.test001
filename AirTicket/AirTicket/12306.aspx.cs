using ServiceForPetrolAutoRecharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket
{
    public partial class _12306 : System.Web.UI.Page
    {
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
        const string contentType = "application/x-www-form-urlencoded; charset=UTF-8";
        protected string loginRand;
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://dynamic.12306.cn/otsweb/loginAction.do?method=loginAysnSuggest";
            IList<ParamKeyValue> list = new List<ParamKeyValue>()
            {
                new ParamKeyValue("loginRand","222")
            };
            //{"loginRand":"591","randError":"Y"}
            string content = HttpHelper.Post(url, list, "", 50 * 1000, userAgent, Encoding.UTF8, null, contentType, null);
            loginRand=Regex.Match(content, @"\d+").Value;//匹配出登陆数字随机码

            IList<ParamKeyValue> nlist = new List<ParamKeyValue>() { 
              new ParamKeyValue("loginRand",loginRand),
              new ParamKeyValue("loginUser.user_name",""),
              new ParamKeyValue("nameErrorFocus",""),
              new ParamKeyValue("passwordErrorFocus",""),
              new ParamKeyValue("randCode","5959"),
              new ParamKeyValue("randErrorFocus",""),
              new ParamKeyValue("refundFlag","Y"),
              new ParamKeyValue("refundLogin","N"),
              new ParamKeyValue("user.password",""),
            };
          //  string nurl = "https://dynamic.12306.cn/otsweb/loginAction.do?method=login";
         //   string result = HttpHelper.Post(nurl, nlist, "", 50 * 1000, userAgent, Encoding.UTF8, null, contentType, null);

        }
    }
}