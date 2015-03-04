using QCMS.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestGoodsDataInsert
{
    public partial class BankTerminfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoadInfo_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper("Uni2uni_cloudshop");
            string sql = "SELECT * FROM Uni2uni_cloudshop.dbo.TerminalInfo WHERE BankID='6ce02f68-008c-42a0-b4fe-ec5cd79c31fc'";
            var dt = db.GetDataTable(sql, CommandType.Text, null);
            bindData.DataSource = dt;
            bindData.DataTextField = "Address";
            bindData.DataValueField = "SourceID";
            bindData.DataBind();
        }

    }
}