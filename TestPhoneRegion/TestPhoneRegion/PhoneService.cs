using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace TestPhoneRegion
{
    public class PhoneService
    {
        public PhoneService()
        {

        }

        /// <summary>
        /// 获取手机归属地
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public PhoneInfo GetMobilePhoneInfo(string mobile)
        {
            string address = "http://www.00cha.com/shouji/?mobile=" + mobile;

            HttpWebRequest request =null;
            request = WebRequest.Create(address) as HttpWebRequest;
            request.ContentType ="application/x-www-form-urlencoded";
            request.Method = "GET";
            
            HttpWebResponse respone= request.GetResponse() as HttpWebResponse;
            Stream stream = respone.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("gb2312"));
            string result = reader.ReadToEnd();

            //WebClient webClient = new WebClient();
            //webClient.Encoding = Encoding.GetEncoding("gb2312");
            //string htmContent = webClient.DownloadString(address);

            string pattern = @"<b>[\s\S]*?</b>";
            MatchCollection mc = Regex.Matches(result, pattern, RegexOptions.IgnoreCase);
            PhoneInfo phone = new PhoneInfo();
            if (mc.Count >= 8)
            {
                string content = mc[8].Value.Replace("<b>","").Replace("</b>","");
                string[] arr = content.Split(' ');
                if (arr.Length > 0)
                {
                    phone.Province= arr[0];
                    phone.City = arr[1];
                    phone.PhoneCode = mobile;
                }
            }
            return phone;
        }

        /// <summary>
        /// 获取固定电话归属地
        /// </summary>
        /// <param name="telePhone"></param>
        /// <returns></returns>
        public PhoneInfo GetTelePhoneInfo(string telePhone)
        {
            string address = "http://www.00cha.com/114.asp?t=" + telePhone;
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.GetEncoding("gb2312");
            string htmContent = webClient.DownloadString(address);
            string pattern = @"<b>[\s\S]*?</b>";
            MatchCollection mc = Regex.Matches(htmContent, pattern, RegexOptions.IgnoreCase);
            PhoneInfo phone = new PhoneInfo();
            if (mc.Count > 0 && mc.Count >= 3)
            {
                string content = mc[2].Value.Replace("<b>", "").Replace("</b>", "");
                //湖南 长沙 岳麓区
                string[] arr = content.Split(' ');
                phone.Province = arr[0];
                phone.City = arr[1];
                phone.Town = arr.Length >= 3 ? arr[2] : "";
                phone.PhoneCode = telePhone;
            }
            return phone;
        }



        public PhoneInfo GetMobilePhone360Info(string mobile)
        {
            string address = "http://cx.shouji.360.cn/phonearea.php?number=15273919791";
            string content = SendGet(address);
            //{"code":0,"data":{"province":"\u6e56\u5357","city":"\u90b5\u9633","sp":"\u79fb\u52a8"}}
            string status = content.Substring(content.IndexOf(":") + 1, 1);
            if (status != "0") //如果返回的状态码为不为0说明没有获取到 归属地信息
            {
                return null;
            }

            string pattern = @"""[\s\S]*?""";
            MatchCollection mc = Regex.Matches(content, pattern, RegexOptions.IgnoreCase);
            if (mc.Count == 0)
            {
                return null;
            }
            PhoneInfo phone = new PhoneInfo
            {
                Province = !string.IsNullOrWhiteSpace(mc[5].Value) ? mc[5].Value.Replace("\\\"", "") : "",
                City = !string.IsNullOrWhiteSpace(mc[5].Value) ? mc[5].Value.Replace("\\\"", "") : "",
                Town = "",
                Provider = !string.IsNullOrWhiteSpace(mc[7].Value) ? mc[7].Value.Replace("\\\"", "") : "",
                PhoneCode = mobile
            };
            return phone;
        }


        private string SendGet(string address)
        {
            HttpWebRequest request = null;
            request = WebRequest.Create(address) as HttpWebRequest;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "GET";

            HttpWebResponse respone = request.GetResponse() as HttpWebResponse;
            Stream stream = respone.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("gb2312"));
            return reader.ReadToEnd();
        }

    }

}
