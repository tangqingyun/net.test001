using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TestGoodsDataInsert
{
    public class DBHelper
    { 
         static readonly string connection = ConfigurationManager.ConnectionStrings["Uni2uni_GoodsInfo1"].ToString();
        public DBHelper()
        {
            
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static bool ExecteProcedure(string ProcedureName, IList<DbParameter> list, out string Result)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connection);
                Conn.Open();
                SqlCommand cmd = new SqlCommand("GM_Import_Goods", Conn);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (DbParameter itm in list)
                {
                    cmd.Parameters.Add(itm);
                }
                //cmd.Parameters.Add("@CategoryCode", SqlDbType.BigInt, 11);
                //cmd.Parameters.Add("@InfoCodeNumber", SqlDbType.BigInt, 11);            
                //cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 500);
                //cmd.Parameters.Add("@Result", SqlDbType.NVarChar, 500);

                //cmd.Parameters["@CategoryCode"].Value = 1000;
                //cmd.Parameters["@InfoCodeNumber"].Value = 1000;
                //cmd.Parameters["@Result"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                Result = cmd.Parameters["@Result"].Value.ToString();
                Conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Result = ex.Message;
                return false;
                throw new Exception(ex.Message);
            }
        }


    }
}
