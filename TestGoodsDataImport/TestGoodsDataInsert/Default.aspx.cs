using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestGoodsDataInsert
{
    public partial class Default : System.Web.UI.Page
    {
        public DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = @"D:\newGoodsDataTest.xlsx";
            //path = @"D:\老商品.xlsx";
            TamnyNPOI.ExcelNPOI npoi = new TamnyNPOI.ExcelNPOI(path);
            dt = npoi.ReadExcelToDataTable(false);
          
            
            string str = string.Empty;

            for (int n = 1; n < dt.Rows.Count; n++)
            {
                if (dt.Rows[n][3] == null)
                {
                    continue;
                }

                IList<DbParameter> list = new List<DbParameter>();
                SqlParameter param1 = new SqlParameter("@CategoryCode", SqlDbType.BigInt, 11);
                SqlParameter param2 = new SqlParameter("@InfoCodeNumber", SqlDbType.BigInt, 11);
                SqlParameter param3 = new SqlParameter("@ProductName", SqlDbType.NVarChar, 500);
                SqlParameter param4 = new SqlParameter("@Result", SqlDbType.NVarChar, 500);
                param4.Direction = ParameterDirection.Output;
               
                param1.Value = Convert.ToInt64(dt.Rows[n][3]);
                param2.Value = Convert.ToInt64(dt.Rows[n][2]);
                param3.Value = dt.Rows[n][1].ToString();
                list.Add(param4);
                list.Add(param3);
                list.Add(param2);
                list.Add(param1);
                string Result = string.Empty;
                bool bol = DBHelper.ExecteProcedure("", list, out Result);
                str += "<p>" + n.ToString() + "：" + Result + "</p>";
            }
            Response.Write(str);
        }

    }
}