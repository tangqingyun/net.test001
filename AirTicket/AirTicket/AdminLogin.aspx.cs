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
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // string loginUrl = "http://home.51cto.com/index.php?s=/Index/index/reback/http%253A%252F%252Fdown.51cto.com";
           // InternetExplorer IE = new InternetExplorer();
           // IE.Visible = true; 
           // object nil = new object();
           // IE.Navigate(loginUrl, ref nil, ref nil, ref nil, ref nil);
          
           // HTMLDocument doc = (HTMLDocument)IE.Document;
          
           // HTMLInputElement button=null;
           // IHTMLElementCollection inputCollection=doc.getElementsByTagName("input");
           // foreach (HTMLInputElement itm in inputCollection)
           // {
           //     switch (itm.name)
           //     {
           //         case "email":
           //             itm.value = "tamny@sohu.com";
           //             break;
           //         case "passwd":
           //             itm.value = "tangqingyun";
           //             break;
           //         case "button":
           //             button = itm;
           //             break;
           //     }
           // }
           // if (button!=null)
           //     button.click();

           // string home = "http://down.51cto.com/";
           // InternetExplorer ie2 = new InternetExplorer();
           // ie2.Navigate(home, ref nil, ref nil, ref nil, ref nil);
           // HTMLDocument doc2 = (HTMLDocument)ie2.Document;
           // IHTMLElement creditsspan=doc2.getElementById("creditsspan");
          
           // HTMLAnchorElement alink=creditsspan.children() as HTMLAnchorElement;
            
           // alink.click();
           // //while (ie2.StatusText.IndexOf("完成") == -1)
           //// string ss = ((mshtml.HTMLSpanElementClass)creditsspan).IHTMLElement_innerHTML;
           //// HTMLAnchorElement a = new HTMLAnchorElement();
           
           // creditsspan.click();

        }

        public string GetValidateCode()
        {
            //图片验证码识别
            string imgsrc = "http://admin.5a360.com/ajax/validatacode.ashx";
            GuangDongShiHua gd = new GuangDongShiHua();
            string filename = gd.GetVerificCode(Server.MapPath("/Images"), imgsrc);
            string code = gd.GetNewVerficCode(filename);
            return code;
        }

    }
}