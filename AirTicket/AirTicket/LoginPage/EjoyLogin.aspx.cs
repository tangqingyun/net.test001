using ServiceForPetrolAutoRecharge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using uni2uni.com.Framework.Common;

namespace AirTicket.LoginPage
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public partial class EjoyLogin : System.Web.UI.Page
    {
        //private const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.66 Safari/537.36";
        const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
        private static List<decimal> EjoyRechargeAmount = new List<decimal>();//易捷充值金额
        const string ValidatorURL = "http://secure.ejoy365.com/Common/ImageValidator.aspx?Type=login";
        readonly CookieCollection _cookies = new CookieCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            return;
            var ra = EjoyHelper.EjoyRecharegAmount;
            var ea=EjoyHelper.EjoyRechargeArea;
            var sa = EjoyHelper.SysRecharegAmount;

            #region Old MyRegion
            //HttpHeader header = new HttpHeader();
            //header.accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1,*/*";
            //header.contentType = "application/x-www-form-urlencoded";
            //header.method = "POST";
            //header.userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
            //header.maxTry = 300;
            //string html = GetHtml("http://secure.ejoy365.com/Recharge/RechargeStep1.aspx", GetCooKie(url, "action=Get&name=qingyun&pwd=123456", header), header); 

            //RechargeStep1
            //string ncontent = HttpHelper.Get("http://secure.ejoy365.com/Recharge/RechargeStep1.aspx", null, null, resCookies, null, null);
            #endregion

            string url = "http://secure.ejoy365.com/Customer/Login.aspx?ReturnUrl=http%3a%2f%2fsecure.ejoy365.com%2fRecharge%2fRechargeStep1.aspx";

            CookieCollection resCookies = null;
            bool islogin = HasLoginEjoy(out resCookies);

            #region ==第一步登陆易捷网
            if (!islogin)
            {
                //登陆易捷网
                IList<ParamKeyValue> postData = new List<ParamKeyValue>() { 
                     new ParamKeyValue("action","Get"),
                     new ParamKeyValue("name","abc100"),
                     new ParamKeyValue("pwd","123456")
                };
                bool loginBol = LoginEjoy(url, postData, out resCookies);
                if (loginBol == false)
                {
                    Response.Write("登陆易捷失败！");
                    return;
                }
            } 
            #endregion

            #region ==第二步填写充值信息
            IList<ParamKeyValue> step2Data = new List<ParamKeyValue>() { 
                     new ParamKeyValue("cardNumber","1000113200006467035"),
                     new ParamKeyValue("areaID","32"),
                     new ParamKeyValue("areaName","江苏"),
                     new ParamKeyValue("mobilePhone","13260184476"),
                     new ParamKeyValue("orderAmt","100"),
                     new ParamKeyValue("payTypeSysNo","67")
             };
            CookieCollection step2Cookies;
            string step2Result = HttpHelper.Post("http://secure.ejoy365.com/recharge/RechargeStep2.aspx", step2Data, "", out  step2Cookies, null, null, Encoding.UTF8, resCookies, null, null); 
            #endregion
           
            #region ==第三步创建易捷订单
            IList<ParamKeyValue> step3Data = step2Data;
            CookieCollection step3Cookies;
            string step3Result = HttpHelper.Post("http://secure.ejoy365.com/Ajax/Recharge/AjaxCreateSGCardOrder.aspx", step3Data, "", out  step3Cookies, null, null, Encoding.UTF8, resCookies, null, null);
            string pattern = @"value=[\s\S]*?/>";
            MatchCollection mc = Regex.Matches(step3Result, pattern, RegexOptions.IgnoreCase);
            //value="15864602"
            string sosysno = string.Empty;
            if (mc.Count == 2)
            {
                sosysno = mc[1].Value.Replace("\"", "").Replace("value=", "").Replace("/>", "");
            }
            if (string.IsNullOrWhiteSpace(sosysno))
            {
                Response.Write("易捷订单创建失败！");
                return;
            } 
            #endregion

            #region ==第四步确认充值信息并支付

            WriteInternetCookie(resCookies);
            Response.Redirect("http://secure.ejoy365.com/recharge/rechargestep3.aspx?sosysno=" + sosysno); 

            #endregion

        }


        public string GetVerificCode()
        {
            var fileFullName = string.Format(@"{0}\{1}.gif", System.AppDomain.CurrentDomain.BaseDirectory + @"LoginPage\ImageValidator\", Guid.NewGuid());
            try
            {
            var request = HttpHelper.CreateGetHttpResponse(ValidatorURL, 10 * 1000,UserAgent, _cookies, ContentType, null);
            System.Drawing.Image img = new System.Drawing.Bitmap(request.GetResponseStream());
            img.Save(fileFullName);
            }
            catch (Exception)
            {
                return "";   
            }
            return fileFullName;
        }

        /// <summary>
        /// 检测是否已经登陆易捷网
        /// </summary>
        /// <returns></returns>
        private static bool HasLoginEjoy(out CookieCollection cookieColltion)
        {
            cookieColltion = null;
            Uri uri = new Uri("http://secure.ejoy365.com");
            CookieContainer cc = CookieHelper.GetInternetCookie(uri);
            if (cc == null)
                return false;

            CookieCollection cookieColl = cc.GetCookies(uri);
            if (cookieColl["ASP.NET_SessionId"] == null)
            {
                return false;
            }
            cookieColltion = cookieColl;
            return true;
        }

        /// <summary>
        /// 登陆易捷网
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="resCookies"></param>
        /// <returns></returns>
        private static bool LoginEjoy(string url, IList<ParamKeyValue> postData, out CookieCollection resCookies)
        {
            string result = HttpHelper.Post(url, postData, "", out resCookies, null, null, Encoding.UTF8, null, null, null);
            //<title>用户登录 - 石化易捷网</title>
            string pattern = @"<title>[\s\S]*?</title>";
            string str = Regex.Match(result, pattern).Value;
            if (str.IndexOf("用户登录") >= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 向浏览器写入cookie信息
        /// </summary>
        /// <param name="resCookies"></param>
        private static void WriteInternetCookie(CookieCollection resCookies)
        {
            for (int i = 0; i < resCookies.Count; i++)
            {
                //HttpCookie cookie = new HttpCookie(resCookies[i].Name, resCookies[i].Value);
                //cookie.Expires = DateTime.Now.AddDays(30);//resCookies[i].Expires;
                //cookie.Domain = resCookies[i].Domain;
                //cookie.Path = resCookies[i].Path;
                //cookie.HttpOnly = true;
                //HttpContext.Current.Response.Cookies.Add(cookie);
                //HttpContext.Current.Response.AddHeader("P3P", "CP=CAO PSA OUR"); 
                string key = resCookies[i].Name;
                string value = resCookies[i].Value;
                DateTime expires = resCookies[i].Expires;
                string domain = resCookies[i].Domain;
                DateTime timeStamp = resCookies[i].TimeStamp;
                string path = resCookies[i].Path;
                string port = resCookies[i].Port;
                bool httpOnly = resCookies[i].HttpOnly;
                string cookievalue = value + ";" + path + ";expires=Sun,22-Feb-2015 00:00:00 GMT";
                CookieHelper.SetInternetCookie("http://secure.ejoy365.com", key, cookievalue);
            }
        }

        public static CookieContainer GetCooKie(string loginUrl, string postdata, HttpHeader header)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                CookieContainer cc = new CookieContainer();
                request = (HttpWebRequest)WebRequest.Create(loginUrl);
                request.Method = header.method;
                request.ContentType = header.contentType;
                byte[] postdatabyte = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = postdatabyte.Length;
                request.AllowAutoRedirect = false;
                request.CookieContainer = cc;
                request.KeepAlive = true;
                //提交请求
                Stream stream;
                stream = request.GetRequestStream();
                stream.Write(postdatabyte, 0, postdatabyte.Length);
                stream.Close();
                //接收响应
                response = (HttpWebResponse)request.GetResponse();
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                CookieCollection cook = response.Cookies;
                //Cookie字符串格式
                string strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);
                return cc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetHtml(string getUrl, CookieContainer cookieContainer, HttpHeader header)
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(getUrl);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = header.contentType;
                httpWebRequest.ServicePoint.ConnectionLimit = header.maxTry;
                httpWebRequest.Referer = getUrl;
                httpWebRequest.Accept = header.accept;
                httpWebRequest.UserAgent = header.userAgent;
                httpWebRequest.Method = "GET";
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("gb2312"));
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();
                return html;
            }
            catch (Exception e)
            {
                if (httpWebRequest != null) httpWebRequest.Abort();
                if (httpWebResponse != null) httpWebResponse.Close();
                return string.Empty;
            }
        }

    }

    public class HttpHeader
    {
        public string contentType { get; set; }

        public string accept { get; set; }

        public string userAgent { get; set; }

        public string method { get; set; }

        public int maxTry { get; set; }
    }

}