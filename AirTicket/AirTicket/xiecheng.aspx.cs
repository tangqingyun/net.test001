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
    public partial class xiecheng : System.Web.UI.Page
    {
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
        const string contentType = "application/x-www-form-urlencoded; charset=gb2312";
        protected void Page_Load(object sender, EventArgs e)
        {
            var co = System.Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            string[] files = System.IO.Directory.GetFiles(co);
            foreach (string fileName in files)
            {
                //Response.Write(fileName.ToLower() + "<br>");
                if (fileName.ToLower().IndexOf("csdn") > 0)
                {
                    System.IO.File.Delete("csdn");
                }
            }


            string url = "https://accounts.ctrip.com/member/login.aspx?BackUrl=http%3A%2F%2Fflights.ctrip.com%2F&responsemethod=get";

            IList<ParamKeyValue> list = new List<ParamKeyValue>() { 
                     new ParamKeyValue("__EVENTTARGET",""),
                     new ParamKeyValue("__EVENTARGUMENT",""),
                     new ParamKeyValue("loginType","0"),
                     new ParamKeyValue("signin_logintype",""),
                     new ParamKeyValue("done",""),
                     new ParamKeyValue("hdnToken","MjAxMy03LTIgMTM6MTA6MzA="),                 
                     new ParamKeyValue("hidGohome","MjAxMy03LTIgMTM6MTA6MzA="),
                     new ParamKeyValue("hidVerifyCodeLevel","N"),
                     new ParamKeyValue("txtUserName","tqyitweb@163.com"),
                     new ParamKeyValue("txtPwd","tangqingyun"),
                     //new ParamKeyValue("btnSubmit","登录"),
#region ctrip
		                    //new ParamKeyValue("hidToken","MjAxMy03LTIgMTM6MTA6MzA="),
                    //new ParamKeyValue("__VIEWSTATE","/wEPDwUKMjA1MzYzNDgzMQ8WAh4DZGRkMtwEAAEAAAD/////AQAAAAAAAAAEAQAAAOIBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuRGljdGlvbmFyeWAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQMAAAAHVmVyc2lvbghDb21wYXJlcghIYXNoU2l6ZQADAAiSAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkdlbmVyaWNFcXVhbGl0eUNvbXBhcmVyYDFbW1N5c3RlbS5TdHJpbmcsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV1dCAAAAAAJAgAAAAAAAAAEAgAAAJIBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuR2VuZXJpY0VxdWFsaXR5Q29tcGFyZXJgMVtbU3lzdGVtLlN0cmluZywgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XV0AAAAACxYCZg9kFgZmDxYEHgVzdHlsZQUTdmlzaWJpbGl0eTp2aXNpYmxlOx4JaW5uZXJodG1sBSI8aT48L2k+55So5oi35ZCN5oiW5a+G56CB6ZSZ6K+v77yBZAINDxAPFgYeDURhdGFUZXh0RmllbGQFD1F1ZXN0aW9uQ29udGVudB4ORGF0YVZhbHVlRmllbGQFAklkHgtfIURhdGFCb3VuZGdkEBUKEuaCqOeItuS6sueahOWnk+WQjRLmgqjmr43kurLnmoTlp5PlkI0S5oKo54ix5Lq655qE55Sf5pelEuaCqOWutuW6reeahOeUteivnRLmgqjlhazlj7jnmoTlkI3np7AS5oKo5q+V5Lia55qE5a2m5qChEuaCqOWWnOasoueahOminOiJshLmgqjlhbvnmoTlrqDnianlkI0S5oKo5pyA5Zac5qyi55qE5q2MEuaCqOacgOW0h+aLnOeahOS6uhUKATEBMgEzATQBNQE2ATcBOAE5AjEwFCsDCmdnZ2dnZ2dnZ2dkZAIRDxAPFgYfAwUPUXVlc3Rpb25Db250ZW50HwQFAklkHwVnZBAVChLmgqjniLbkurLnmoTlp5PlkI0S5oKo5q+N5Lqy55qE5aeT5ZCNEuaCqOeIseS6uueahOeUn+aXpRLmgqjlrrbluq3nmoTnlLXor50S5oKo5YWs5Y+455qE5ZCN56ewEuaCqOavleS4mueahOWtpuagoRLmgqjllpzmrKLnmoTpopzoibIS5oKo5YW755qE5a6g54mp5ZCNEuaCqOacgOWWnOasoueahOatjBLmgqjmnIDltIfmi5znmoTkuroVCgExATIBMwE0ATUBNgE3ATgBOQIxMBQrAwpnZ2dnZ2dnZ2dnZGQYAQUeX19Db250cm9sc1JlcXVpcmVQb3N0QmFja0tleV9fFgEFDGNoa0F1dG9Mb2dpbg=="),
                    //new ParamKeyValue("cardname",""),
                    //new ParamKeyValue("hidMask","F"),
                    //new ParamKeyValue("hid_cardname","0"),
                    //new ParamKeyValue("hidServerName","http://accounts.ctrip.com"),
                    //new ParamKeyValue("hidUid",""),
                    //new ParamKeyValue("needCheckServerSession","F"),
                    //new ParamKeyValue("selHQuestion","1"),
                    //new ParamKeyValue("selQuestion","1"),
                    //new ParamKeyValue("txtCode",""),
                    //new ParamKeyValue("txtCPwd",""),
                    //new ParamKeyValue("txtCUserName",""),
                    //new ParamKeyValue("txtHAnswer",""),
                    //new ParamKeyValue("txtHIDCardNo",""),
                    //new ParamKeyValue("txtHMobile",""),
                    //new ParamKeyValue("txtHPwd",""),
                    //new ParamKeyValue("txtHSPwd",""),
                    //new ParamKeyValue("txtMAnswer",""),
                    //new ParamKeyValue("txtMPwd",""),
                    //new ParamKeyValue("txtMSPwd",""),
                    //new ParamKeyValue("txtReHPwd",""),
                    //new ParamKeyValue("txtReHSPwd",""),
                    //new ParamKeyValue("txtReMPwd",""),
                    //new ParamKeyValue("txtReMSPwd",""),
                    //new ParamKeyValue("txtVerifyCode",""), 
	#endregion
            };

            CookieCollection _cookies = new CookieCollection()
            {
                //new Cookie("__utmc","1"),
                //new Cookie("_abtest_","9b84e558-dd5c-4219-a632-045a82608d66"),
                //new Cookie("_bfi","p1=100003&p2=0&v1=2&v2=2"),
                //new Cookie("_bfp","35660503"),
                //new Cookie("ASP.NET_SessionId","fqbl1x4k2gocj23zmz4cuwc2"),
                //new Cookie("AX-47873-accounts","GFACAIAKFAAA")
            };
            Cookie ck1 = new Cookie();
            ck1.Name = "ASP.NET_SessionId";
            ck1.Value = "su1gma2ne3eqivf3smdg1bny";
            ck1.Domain = "ctrip.com";

            Cookie ck2 = new Cookie();
            ck2.Name = "_abtest_";
            ck2.Value = "da2c6fe2-f745-4746-8b16-46efedb607a3";
            ck2.Domain = "ctrip.com";

            Cookie ck3 = new Cookie();
            ck3.Name = "AX-47873-accounts";
            ck3.Value = "LNIAKIAKFAAA";
            ck3.Domain = "ctrip.com";
            _cookies.Add(ck1);
            _cookies.Add(ck2);
            _cookies.Add(ck3);

            CookieCollection resCookies;
            string content = HttpHelper.Post(url, list, "", out resCookies, 100 * 1000, userAgent, Encoding.GetEncoding("gb2312"), _cookies, contentType, null);
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
                CookieHelper.SetInternetCookie("http://ctrip.com", key, cookievalue);
            }


            url = "http://my.ctrip.com/Home/Order/FlightOrderList.aspx";
            string ncontent = HttpHelper.Get(url, null, userAgent, resCookies, contentType, null);

        }

    }
}