using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uni2UniDownLoad
{
    public partial class Uni2Uni : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            web.Encoding = Encoding.UTF8;
           // string ss="";// = "<script>document.domain = \"uni2uni.com\";</script>";
            string content =web.DownloadString("http://product.uni2uni.com/50080960-0-0-1-0.shtml");
            //Regex regex = new Regex(@"<\s*a\shref=*[^>]*>([^<]|<(?!/a))*<\s*/a\s*>");
            string newContent = content.Replace("href", "#");

            string ncontent = Regex.Replace(content, @"href=""\/([^""]+)""",
                        new MatchEvaluator(
                            NewMethod()
                        ), RegexOptions.IgnoreCase
                );
            
            Response.Write(ncontent);

        }

        private static MatchEvaluator NewMethod()
        {
            return delegate(Match m)
            {
                string str="href=\"/" + m.Groups[1].Value.Replace("product.uni2uni.com", "localhost") + "\"";
                return str;
            };
        }

    }
}