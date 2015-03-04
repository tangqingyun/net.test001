using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class BasePage : System.Web.UI.Page
    {

        public BasePage() {
            if (Session["aaaa"] == null)
            {

            }
        }
    }
}