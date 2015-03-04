using System;
using System.Net;
using System.IO;
using System.Drawing;
using OCR.TesseractWrapper;


namespace TestValidateCode
{
    /// <summary>
    /// 读取图片
    /// </summary>
    public static class ReadPicture
    {
        public static string GetCodeByUrl(string url, string tessdata_Path, int ocrEngineMode, bool isSave, string saveFilePath)
        {
            WebResponse response = null;
            Stream st = null;
            string code = "";
            string newcode = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                response = request.GetResponse();
                st = response.GetResponseStream();
                Bitmap bitmap = (Bitmap)Bitmap.FromStream(st);

                code = getCode(bitmap, tessdata_Path, ocrEngineMode);
                //过滤异常字符
                newcode = getNewCode(code);
                //是否保存
                if (isSave)
                {
                    save(code, newcode, saveFilePath, bitmap);
                }
                bitmap.Dispose();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                if (response != null)
                    response.Close();
                if (st != null)
                    st.Close();
            }
            return newcode;
        }

        public static string GetCodeByFile(string fileName, string tessdata_Path, int ocrEngineMode, bool isSave, string saveFilePath)
        {
            string code = "";
            string newcode = "";
            Bitmap bitmap = (Bitmap)Bitmap.FromFile(fileName, false);
        
            code = getCode(bitmap, tessdata_Path, ocrEngineMode);
            newcode = getNewCode(code);
            //是否保存
            if (isSave)
            {
                save(code, newcode, saveFilePath, bitmap);
            }
            bitmap.Dispose();
            return newcode;
        }

        private static string getNewCode(string code)
        {
            //过滤异常字符
            code = code.Replace(" ", "").Replace("-", "").Replace(".", "").Replace("'", "").Replace("»", "").Replace("~", "").Replace("‘", "").Replace("’", "").Replace("\"", "").Replace(",", "").Replace("Z", "");
            //替换异常字符
            code = code.Replace("£", "4").Replace("f", "1").Replace("$", "6").Replace("y", "3").Replace("s", "5").Replace("¢", "4").Replace("!", "1").Replace("z", "2").Replace("d", "4").Replace("?", "7").Replace("r", "7").Replace("i", "1").Replace("%", "4").Replace(";", "1").Replace("/", "1").Replace(")", "7").Replace("t", "7").Replace("T", "7").Replace("I", "1");
            return code;
        }

        private static string getCode(Bitmap bitmap, string tessdata_Path, int ocrEngineMode)
        {
            var unCodeBase = new ProcessPicture(bitmap);
            bitmap = unCodeBase.GetPicChangeBigValue(1);
            int dgGrayValue = unCodeBase.GetDgGrayValue();
            unCodeBase.ClearNoise(dgGrayValue, 3);
            bitmap = unCodeBase.GetPicChangeBigValue(2);
            bitmap = unCodeBase.toGrayscale(bitmap, "1");
            //识别类初始化
            TesseractProcessor processor = new TesseractProcessor();
            processor.Init(tessdata_Path, "eng", ocrEngineMode);
            processor.Clear();
            processor.ClearAdaptiveClassifier();
            
            //开始识别图形
            string code = processor.Recognize(bitmap).Replace("\n", "");
            return code;
        }

        private static void save(string code, string newcode, string saveFilePath, Bitmap bitmap)
        {
            string fileName = "";
            if (code.Contains("?") || code.Contains("/") || code.Contains("\\") || code.Contains("*") || code.Contains("|") || code.Contains("\"") || code.Contains("<") || code.Contains(">") || code.Contains(":"))
                fileName = newcode + ".png";
            else
                fileName = newcode + "_" + code + ".png";

            //文件夹名
            if (!Directory.Exists(saveFilePath))
            {
                Directory.CreateDirectory(saveFilePath);
            }
            fileName = saveFilePath + fileName;
            //保存图片与价格
            SaveImage(bitmap, fileName);
        }

        /// <summary>
        /// 保存图片方法
        /// </summary>
        /// <param name="bitMap">图片Bitmap对象</param>
        private static void SaveImage(Bitmap bitMap, string fileName)
        {
            bool isSave = true;
            if (fileName != "" && fileName != null)
            {
                string fileExtName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToString();
                System.Drawing.Imaging.ImageFormat imgformat = null;
                if (fileExtName != "")
                {
                    switch (fileExtName)
                    {
                        case "jpg":
                            imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        case "bmp":
                            imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                            break;
                        case "gif":
                            imgformat = System.Drawing.Imaging.ImageFormat.Gif;
                            break;
                        case "png":
                            imgformat = System.Drawing.Imaging.ImageFormat.Png;
                            break;
                        default:
                            isSave = false;
                            break;
                    }
                }
                //默认保存为JPG格式
                if (imgformat == null)
                {
                    imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                }
                if (isSave)
                {
                    try
                    {
                        bitMap.Save(fileName, imgformat);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
        }
    }
}
