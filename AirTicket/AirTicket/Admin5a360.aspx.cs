using mshtml;
using ServiceForPetrolAutoRecharge.Recharge;
//using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket
{
    public partial class Admin5a360 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string loginUrl = "http://admin.5a360.com/Login.aspx";
            //InternetExplorer IE = new InternetExplorer();      
            //object nil = new object();
            //IE.Navigate(loginUrl, ref nil, ref nil, ref nil, ref nil);
            //HTMLDocument doc = (HTMLDocument)IE.Document;
            //HTMLInputElement userName=doc.getElementById("txtUserCode") as HTMLInputElement;
            //HTMLInputElement userPwd=doc.getElementById("txtPassWord")  as HTMLInputElement;
            //HTMLInputElement imgCode = doc.getElementById("ImgCode")  as HTMLInputElement;
            //HTMLInputElement button = doc.getElementById("Button1")  as HTMLInputElement;
            //userName.value = "tangqingyun";
            //userPwd.value = "a123456";
            //imgCode.value = GetValidateCode();

            //button.click();            
        }

        public  string GetValidateCode()
        {
            //图片验证码识别
            string imgsrc = "http://admin.5a360.com/ajax/validatacode.ashx?0.6681406223252474";
            GuangDongShiHua gd = new GuangDongShiHua();
            string filename = gd.GetVerificCode(Server.MapPath("/Images"), imgsrc);
            string code = gd.GetNewVerficCode(filename);
            return code;
        }

    }
}