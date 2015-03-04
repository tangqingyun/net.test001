using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirTicket
{
    public partial class Qlogin : System.Web.UI.Page
    {
        delegate void delegateLogin(StringBuilder html);
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb=new StringBuilder();
            delegateLogin login = new delegateLogin(Ctrip);
            string type = "zc";
            switch (type)
            {
                case "jp":
                    login = new delegateLogin(JiPiao);
                    break;
                case "zc":
                    login = new delegateLogin(ZuChe);
                    break;
                default:
                    break;
            }
            login(sb);
            Response.Write(sb.ToString());
        }

        private void Ctrip(StringBuilder sb)
        {
            sb.Append("Ctrip");
        }

        private void JiPiao(StringBuilder sb)
        {
            sb.Append("JiPiao");
        }
        private void ZuChe(StringBuilder sb)
        {
            sb.Append("ZuChe");
        }

    }
}