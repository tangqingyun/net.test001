using ServiceForPetrolAutoRecharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket.LoginPage
{
    public partial class EjoyStep1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string url = "http://secure.ejoy365.com/Recharge/RechargeStep1.aspx";
            string ncontent = HttpHelper.Get(url, null, null, null, null, null);

        }
    }
}