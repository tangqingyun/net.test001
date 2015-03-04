using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using System.Collections;
using NPOI.HSSF.UserModel;
using System.Web;
using NPOI.HSSF.Util;
using NPOI.XSSF.UserModel;
namespace TamnyNPOI
{
    public class ExcelNPOI
    {
        /// <summary>
        /// 文件绝对路径
        /// </summary>
        private string abPath;

        /// <summary>
        /// 文件后缀
        /// </summary>
        private string ext;
        private ISheet workSheet;

        #region 带参构造函数
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="path">传入文件绝对路径</param>
        public ExcelNPOI(string path)
        {
            this.abPath = path;
            this.ext = Path.GetExtension(path);
            this.workSheet = this.GetSheets(ext, null)[0];
        } 
        #endregion


        #region 把Excel读入DataTable
        /// <summary>
        /// 把Excel读入DataTable中
        /// </summary>
        /// <param name="isHead">是否把第一行当数据 true是 false否</param>
        /// <returns></returns>
        public DataTable ReadExcelToDataTable(bool isHead)
        {
            IEnumerator rows = workSheet.GetRowEnumerator();
            DataTable dt = new DataTable();

            try
            {
                if (isHead)
                    rows.MoveNext();

                IRow head = workSheet.GetRow(0);
                for (int i = 0; i < head.LastCellNum; i++)
                {
                    //dt.Columns.Add(Convert.ToChar(((int)'A')+j).ToString());
                    if (!string.IsNullOrEmpty(head.GetCell(i).ToString()))
                    {
                        dt.Columns.Add(head.GetCell(i).ToString());
                    }
                }

               

                //先遍历行再遍历行中的每列
                while (rows.MoveNext())
                {
                    IRow row = (IRow)rows.Current;
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        ICell cell = row.GetCell(i);
                        if (!string.IsNullOrEmpty(cell.ToString()))
                        {
                            dr[i] = cell.ToString();
                        }
                        else
                        {
                            dr[i] = "";
                        }
                        //Response.Write(cell.CellType+"<br>");
                    }
                    if (dr != null)
                    {
                        //if(!string.IsNullOrEmpty(dr[0].ToString()))
                            dt.Rows.Add(dr);
                    }
                        
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }
        #endregion

        #region 将DataTable生成Excel文件并导出
        /// <summary>
        /// 将DataTable生成Excel文件并导出
        /// </summary>
        /// <param name="dt">传入DataTable</param>
        /// <param name="saveFileName">导出时保存的文件名</param>
        /// <param name="tableHead">设置导出Excel表头信息 如果为null 不设置</param>
        public void ExportDataTableToExcel(DataTable dt, string saveFileName, string[] tableHead)
        {

            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    HSSFWorkbook wb = new HSSFWorkbook();

                    MemoryStream ms = new MemoryStream();

                    ISheet sheet = wb.CreateSheet();
                    int rowNum = dt.Rows.Count;//表行数
                    int colNum = dt.Columns.Count;//表列数
                    int index = 0;

                    if (tableHead != null)
                    {
                        int arrLen = tableHead.Count();
                        if (arrLen != colNum)
                        {
                            HttpContext.Current.Response.Write("传入的表头列数与表的列数不一致!");
                            HttpContext.Current.Response.End();
                        }
                        else
                        {
                            index = 1;
                            //创建Excel表头 设置表头单元格背景颜色
                            ICellStyle headStyle = wb.CreateCellStyle();
                            headStyle.FillForegroundColor = HSSFColor.BLUE_GREY.index;
                            headStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;

                            IRow tHead = sheet.CreateRow(0);
                            for (int n = 0; n < arrLen; n++)
                            {
                                ICell cell = tHead.CreateCell(n);
                                cell.CellStyle = headStyle;
                                cell.SetCellValue(tableHead[n].ToString());
                            }
                        }

                    }


                    for (int i = index; i < rowNum; i++)
                    {
                        IRow row = sheet.CreateRow(i);
                        for (int j = 0; j < colNum; j++)
                        {
                            ICell cell = row.CreateCell(j);
                            cell.SetCellValue(dt.Rows[i][j].ToString());
                        }
                    }

                    string tmpPath = Environment.GetEnvironmentVariable("TEMP");
                    // string savePath = Path.GetFullPath("/" + saveFileName + ".xls");
                    string savePath = Path.Combine(tmpPath, saveFileName + ".xls");
                    FileStream file = new FileStream(savePath, FileMode.Create);
                    wb.Write(file);
                    file.Close();
                    DownLoadExcel(savePath, saveFileName);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

            }
            else
            {
                throw new Exception("传入的表为空!");
            }

        }
        #endregion

        #region 下载生成的临时Excel文件
        /// <summary>
        /// 下载生成Excel文件
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="fileName"></param>
        private void DownLoadExcel(string savePath, string fileName)
        {
            FileStream downFile = new FileStream(savePath, FileMode.Open);
            byte[] bytes = new byte[(int)downFile.Length];
            downFile.Read(bytes, 0, bytes.Length);
            downFile.Close();

            File.Delete(savePath);//删除文件
            //定义文档类型、字符编码
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.UrlEncode(fileName + ".xls", Encoding.UTF8));
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据扩展名用不同的NPOI对象获取工作表
        /// <summary>
        /// 根据扩展名用不同的NPOI对象获取工作表
        /// </summary>
        /// <param name="ext">文件扩展名</param>
        /// <param name="sr">流资源 为null时读取文件路径资料 否则直接从流中读取</param>
        /// <returns></returns>
        public List<ISheet> GetSheets(string ext,Stream sr)
        {
            List<ISheet> list = new List<ISheet>();
            try
            {
                Stream fs = sr == null ? new FileStream(this.abPath, FileMode.Open) : sr;
                IWorkbook wb = null;
                switch (ext)
                {
                    case ".xls":
                        wb = new HSSFWorkbook(fs);
                        break;
                    case ".xlsx":
                        wb = new XSSFWorkbook(fs);
                        break;
                    default:
                        wb = new HSSFWorkbook(fs);
                        break;
                }

                for (int i = 0; i < wb.NumberOfSheets; i++)
                {
                    list.Add(wb.GetSheetAt(i));
                }
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        } 
        #endregion
       
    }

}
