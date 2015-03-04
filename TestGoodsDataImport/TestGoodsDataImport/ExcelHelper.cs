using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace TestGoodsDataImport
{
    public class ExcelHelper
    {
        #region 把数据从Excel装载到DataTable中
        /// <summary>
        /// 把数据从Excel装载到DataTable中
        /// </summary>
        /// <param name="pathName">带路径的Excel文件名</param>
        /// <param name="sheetName">工作表名</param>
        /// <param name="tbContainer">将数据存入的DataTable</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTableN(string pathName, string sheetName)
        {
            DataTable tbtable = new DataTable();
            string strConn = string.Empty;
            if (string.IsNullOrEmpty(sheetName)) { sheetName = "Sheet1"; }
            FileInfo file = new FileInfo(pathName);
            if (!file.Exists) { throw new Exception("文件不存在"); }
            string extension = file.Extension;
            switch (extension)
            {
                case ".xls":
                    strConn = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
                case ".xlsx":
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=0;'";
                    break;
                default:
                    strConn = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }

            OleDbConnection conn = new OleDbConnection(strConn);//链接Excel
            //读取Excel里面有 表Sheet1的工作表
            OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), conn);
            //将Excel里面有表内容装载到内存表中！
            oda.Fill(tbtable);
            return tbtable;
        }
        #endregion

        /// <summary>
        ///  把数据从Excel读入DataTable
        /// </summary>
        /// <param name="abPath">excel绝对路径</param>
        /// <param name="ext">excel后缀名</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string abPath)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + abPath + "; Extended Properties=Excel 8.0";
            string ext = Path.GetExtension(abPath);
            if (ext == ".xlsx")
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data source=" + abPath + ";" + "Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1;\"";
            }
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbDataAdapter myCommand = null;
            string sql = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(sql, strConn);
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            conn.Close();
            return dt;
        }

    }
}
