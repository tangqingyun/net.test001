using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Net;
using System.Reflection;

namespace uni2uni.com.Framework.Common
{
    /// <summary>
    /// XmlHelper
    /// </summary>
    public class XmlHelper
    {
        #region Member variables
        #endregion

        #region Attribute
        private XmlDocument xmlDoc;
        /// <summary>
        /// get or set XmlDocument
        /// </summary>
        public XmlDocument XmlDoc
        {
            get { return xmlDoc; }
            set { xmlDoc = value; }
        }

        private string fileName;
        /// <summary>
        /// file path
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public XmlHelper()
        {
            Init();
        }

        public XmlHelper(XmlDocument XmlDoc)
        {
            this.xmlDoc = XmlDoc;
            Init();
        }
        #endregion

        #region base method

        protected void Init()
        {
            if (this.xmlDoc == null)
            {
                this.xmlDoc = new XmlDocument();
            }
        }

        #region Load mode
        /// <summary>
        /// xml load
        /// </summary>
        public void Load()
        {
            if (xmlDoc != null)
            {
                if (this.fileName.IndexOf("http://") != -1)
                {
                    Uri xmlUri = new Uri(this.fileName);
                    if (xmlUri.Scheme == Uri.UriSchemeHttp || xmlUri.Scheme == Uri.UriSchemeHttps)
                    {
                        // download the feed
                        byte[] feed = new WebClient().DownloadData(this.fileName);
                        this.xmlDoc.Load(new MemoryStream(feed));
                    }
                }
                else
                {
                    xmlDoc.Load(this.fileName);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public void Load(string filename)
        {
            this.fileName = filename;
            this.Load();
        }

        public void LoadXml(string XmlStr)
        {
            if (xmlDoc != null)
            {
                xmlDoc.LoadXml(XmlStr);
            }
        }
        #endregion

        /// <summary>
        /// read single node
        /// </summary>
        /// <param name="nodePath">node name</param>
        /// <returns></returns>
        public XmlNode GetSection(string nodePath)
        {
            return XmlDoc.SelectSingleNode(nodePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodePath"></param>
        /// <returns></returns>
        public XmlNodeList GetSectionList(string nodePath)
        {
            return XmlDoc.SelectNodes(nodePath);
        }

        public static string ToXmlExcel<T>(IList<T> data)
        {
            Type objType = typeof(T);
            System.Reflection.PropertyInfo[] propertys = objType.GetProperties();
            StringBuilder strXml = new StringBuilder();
            strXml.Append("<?xml version=\"1.0\"?>");
            strXml.Append("<?mso-application progid=\"Excel.Sheet\"?>");
            strXml.Append("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            strXml.Append(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            strXml.Append(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
            strXml.Append(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            strXml.Append(" xmlns:html=\"http://www.w3.org/TR/REC-html40\">");
            strXml.Append("<Worksheet ss:Name=\"Sheet1\">");
            strXml.Append("<Table ss:ExpandedColumnCount=\"");
            strXml.Append(propertys.Length.ToString());
            strXml.Append("\" ss:ExpandedRowCount=\"");
             strXml.Append((data.Count+1).ToString());
             strXml.Append("\" x:FullColumns=\"1\"");
             strXml.Append(" x:FullRows=\"1\" ss:DefaultColumnWidth=\"54\" ss:DefaultRowHeight=\"13.5\">");
             strXml.Append("<Row>");

            foreach (PropertyInfo item in propertys)
            {
                strXml.Append("<Cell>");
                strXml.Append("<Data ss:Type=\"String\">");
                strXml.Append(item.Name);
                strXml.Append("</Data></Cell>");
            }
            strXml.Append("</Row>");
            foreach (T t in data)
            {
                strXml.Append("<Row>");
                foreach (PropertyInfo type in propertys)
                {
                    strXml.Append("<Cell>");
                    strXml.Append("<Data ss:Type=\"String\">");
                    strXml.Append(type.GetValue(t,null).ToString());
                    strXml.Append("</Data></Cell>");
                }
                strXml.Append("</Row>");
            }
            strXml.Append("</Table>");
            strXml.Append("</Worksheet>");
            strXml.Append("</Workbook>");
            return strXml.ToString();
        }
        #endregion
    }
}
