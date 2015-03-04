using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestValidateCode
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificCode code = new VerificCode();
            //string imgsrc = "http://www.card.petrochina.com.cn/UserControl/Image.aspx";
            string imgsrc = "http://www.pay88.cn/index/verify?update=1397551917638&type=20";        
            string dir =Server.MapPath("/Images");
            string path = code.DownloadVerificCode(dir, imgsrc);
            string validateCode = code.AnalysisVerficCode(path);
            Response.Write(validateCode);
        }



    }
}