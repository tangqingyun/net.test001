using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;


namespace ServiceForPetrolAutoRecharge.Recharge
{
    public class GuangDongShiHua
    {
        readonly CookieCollection _cookies = new CookieCollection();
        const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
        const string ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        public GuangDongShiHua()
        {
            _cookies.Add(new Cookie("ASP.NET_SessionId", "", "/", ".gewara.com"));
        }

        public  string GetNewVerficCode(string fileFullName)
        {
            if (string.IsNullOrWhiteSpace(fileFullName))
            {
                return "";
            }
            if(!File.Exists(fileFullName))
            {
                return ""; 
            }
           
            //数据包
            string datasFiles = @"C:\Users\Administrator\Desktop\AirTicket\AirTicket\Files\GuangDongShiHua\Data4VerficCode\tessdata";
            var verficCode = GuangDongShiHua_ReadImg.GetCodeByFile(fileFullName, datasFiles, 3, false, "");

            return verficCode;
        }

        public  string GetVerificCode(string savePath,string codeUrl)
        {

            var fileFullName = string.Format(@"{0}\{1}.gif", savePath, Guid.NewGuid());
            try
            {
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                var request = HttpHelper.CreateGetHttpResponse(codeUrl, 10*1000,
                                                               UserAgent, _cookies, ContentType, null);

                System.Drawing.Image img = new System.Drawing.Bitmap(request.GetResponseStream());
                img.Save(fileFullName);
            }
            catch(Exception ex)
            {
                
                //Manager.ServiceStopBySysErr("【获取验证码失败】" + ex.Message);
                return "";
            }

            return fileFullName;
        }

    

        
        
    }
}
