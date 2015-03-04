using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestFormAjax
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SampleCollection<string> sc = new SampleCollection<string>();
            sc[0] = "Hello";
            sc[1] = "zhang";
            Response.Write(sc[0]);

            if (Request.Form["dopost"] == "true")
            {
                string name = Request.Form["name"];
                string pwd = Request.Form["pwd"];
                string rad = Request.Form["rad"];
                Response.Write(name+"|"+pwd+"|"+rad);
                Response.End();
            }

        }
    }
}