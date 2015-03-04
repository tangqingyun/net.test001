using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutocompleteTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Autocomplete.DataType = EnumAction.Emplyee.ToString();
            }
            //string q=Request.QueryString["q"];
            //if (q == null)
            //    return;

            //IList<ResultData> list = new List<ResultData>() { 
            // new ResultData(){ key=Guid.NewGuid(),value="zhangsan"},
            // new ResultData(){ key=Guid.NewGuid(),value="lishi"},
            // new ResultData(){ key=Guid.NewGuid(),value="wwww"},
            //};
            //System.Threading.Thread.Sleep(3000);
            //string json = new JavaScriptSerializer().Serialize(list);
            //Response.Write(json);
            //Response.End();
        }
    }

}

public class Person
{
    public Guid to { set; get; }
    public string name { set; get; }
}