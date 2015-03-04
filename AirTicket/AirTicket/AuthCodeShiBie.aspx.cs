using ServiceForPetrolAutoRecharge.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket
{
    public partial class AuthCodeShiBie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //图片验证码识别
            string imgsrc = "http://admin.5a360.com/ajax/validatacode.ashx?0.6681406223252474";
            GuangDongShiHua gd = new GuangDongShiHua();
            string filename=gd.GetVerificCode(Server.MapPath("/Images"), imgsrc);
            string code = gd.GetNewVerficCode(filename);
            Response.Write(code);
        }
    }
}