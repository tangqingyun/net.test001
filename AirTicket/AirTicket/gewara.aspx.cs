using ServiceForPetrolAutoRecharge;
using ServiceForPetrolAutoRecharge.Recharge;
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
    public partial class gewara : System.Web.UI.Page
    {
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
        const string contentType = "application/x-www-form-urlencoded; charset=UTF-8";

        protected string random;
        protected void Page_Load(object sender, EventArgs e)
        {

            //string savePath = Server.MapPath("/Img/");
            // string codeUrl = "http://www.gewara.com/captcha.xhtml?captchaId=mnzYCSze35RxpBs9477fe6c2&r=1372829936893";
            // GuangDongShiHua gs = new GuangDongShiHua();
            // string fullName=gs.GetVerificCode(savePath, codeUrl);
            // string number=gs.GetNewVerficCode(fullName);
            //// Response.Write(number);


            //第一步 发送请求获得随机码 var data = {"retval":"GWViCVHWusTkjSnHcc1c3312","success":true}
            string goUrl = "http://www.gewara.com/getCaptchaId.xhtml?r=";
            string reJson = HttpHelper.Get(goUrl, null, userAgent, null, contentType, null);
            string[] arr1 = reJson.Split(',');
            string[] arr2 = arr1[0].Split(':');
            random = arr2[1].TrimStart('"').TrimEnd('"');


            CookieCollection cookies = new CookieCollection()
            {
                //new Cookie("bdshare_firstime","1372909255870","/","www.gewara.com"),
                // new Cookie("Sent","110000","/","www.gewara.com"),
            };

            //    string ss= client.DownloadString("http://www.gewara.com/login.xhtml?name=15901473139&errortype=captcha&TARGETURL=%2F");

            //if (Request.Form["dopost"] == "validate")
            //{
            //    try
            //    {

            //        //第二步
            //        string code = Request.Form["code"];
            //        string url = "http://www.gewara.com/cas/check_user.xhtml";
            //        IList<ParamKeyValue> list = new List<ParamKeyValue>() { 
            //         new ParamKeyValue("TARGETURL","/"),
            //         new ParamKeyValue("j_username","15901473139"),
            //         new ParamKeyValue("j_password","tangqingyun"),
            //         new ParamKeyValue("captchaId","mnzYCSze35RxpBs9477fe6c2"),
            //         new ParamKeyValue("captcha",code)         
            //        };

            //        string result = HttpHelper.Post(url, list, null, 50 * 1000, userAgent, Encoding.UTF8, null, null);
            //        string title = Regex.Match(result, @"<title>[\s\S]*</title>").Value;
            //        if (title.Contains("用户登录"))
            //        {
            //            Response.Write("N");
            //        }
            //        else
            //        {
            //            Response.Write("Y");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write(ex.Message);
            //    }
            //    Response.End();
            //}


            //url = "http://www.gewara.com/home/sns/personIndex.xhtml?tagNo=13733350572314048";
            //string ncontent = HttpHelper.Get(url, null, userAgent, resCookies, contentType, null);

            //WebClient webclient = new WebClient();
            //webclient.Encoding = Encoding.UTF8;
            //string content=webclient.DownloadString(url);
            // Response.Write(content);

        }


    }
}