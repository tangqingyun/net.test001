using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TestGoodsDataImport
{
    public class DBHelper
    {
         static readonly string connection = ConfigurationManager.ConnectionStrings["Uni2uni_GoodsInfo"].ToString();
        public DBHelper()
        {
            
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static bool ExecteProcedure(string ProcedureName,out string Result)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connection);
                Conn.Open();
                SqlCommand cmd = new SqlCommand("GM_TestProduce", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@infoCode", SqlDbType.BigInt,10);
                cmd.Parameters.Add("@ProductCategoryID", SqlDbType.UniqueIdentifier,36);
                cmd.Parameters.Add("@Result",SqlDbType.NVarChar,500);
                cmd.Parameters["@infoCode"].Value =1000;
                cmd.Parameters["@ProductCategoryID"].Value = Guid.NewGuid();
                
                cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
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
