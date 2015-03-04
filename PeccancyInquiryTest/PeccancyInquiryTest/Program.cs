using Basement.Framework.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;

namespace PeccancyInquiryTest
{
    class Program
    {
        readonly static string URL = "http://mobile.auto.sohu.com/wzcx/common/api/queryByCity.at?appKey=pc";
        const string XMLPATH = @"C:\Users\Administrator\Desktop\测试项目\PeccancyInquiryTest\PeccancyInquiryTest\ProvinceShort.xml";
        const string XMLPATH1 = @"C:\Users\Administrator\Desktop\测试项目\PeccancyInquiryTest\PeccancyInquiryTest\Citys.xml";
        const string XMLPATH2 = @"C:\Users\Administrator\Desktop\测试项目\PeccancyInquiryTest\PeccancyInquiryTest\Province.xml";
        static IList<Province> _Province = new List<Province>();
        static IList<ProvinceShort> pshort = new List<ProvinceShort>();
      
        static void Main(string[] args)
        {
            //ReaderToXml();
        
            ThreadProcess tprocess = new ThreadProcess();
            tprocess.Run();
            Console.ReadKey();
        }
        /// <summary>
        /// 读取创建XML文件
        /// </summary>
        private static void ReaderToXml()
        {
            XElement rootC = XElement.Load(XMLPATH);
            List<XElement> ProvincesList = (from el in rootC.Elements("Provinces").Elements("Province") select el).ToList();
            if (pshort.Count == 0)
            {
                ProvincesList.ForEach(itm =>
                {
                    pshort.Add(new ProvinceShort { ID = Convert.ToInt32(itm.Attribute("ID").Value), Name = itm.Value });
                });
            }

            return;
            XElement root = XElement.Load(XMLPATH2);
            List<XElement> plist = (from el in root.Elements("option") select el).ToList();
            if (_Province.Count == 0)
            {
                plist.ForEach(itm =>
                {
                    Province province = new Province();
                    province.ProvinceID = Convert.ToInt32(itm.Attribute("value").Value);
                    province.ProvinceName = itm.Value;
                    province.Citys = new List<City>();
                    XElement root1 = XElement.Load(XMLPATH1);
                    List<XElement> plist1 = (from el in root1.Elements(itm.Value) select el).ToList();
                    foreach (XElement xel in plist1)
                    {
                        var cityCode = xel.Elements("cityCode").FirstOrDefault().Value;
                        var cityName = xel.Elements("cityName").FirstOrDefault().Value;
                        City city = new City { CityID = Convert.ToInt32(cityCode), CityName = cityName };
                        province.Citys.Add(city);
                    }
                    ProvinceShort shortp = pshort.Where(m => m.ID == Convert.ToInt32(province.ProvinceID.ToString().Substring(0, 2))).SingleOrDefault();
                    province.ProvinceShort = shortp.Name;
                    _Province.Add(province);
                });
            }

            XDocument document = new XDocument();
            XElement contacts = new XElement("root");
            foreach (Province itm in _Province)
            {
                XElement province = new XElement("Province");
                province.Add(new XElement("ID", itm.ProvinceID));
                province.Add(new XElement("Name", itm.ProvinceName));
                province.Add(new XElement("ShortName", itm.ProvinceShort));
                XElement citys = new XElement("Citys");
                foreach (City op in itm.Citys)
                {
                    XElement xl = new XElement("City", new XAttribute("ID", op.CityID), op.CityName);
                    citys.Add(xl);
                }
                province.Add(citys);
                contacts.Add(province);
            }
            document.Add(contacts);
            document.Declaration = new XDeclaration("1.0", "utf-8", "true");
            document.Save(@"C:\Users\Administrator\Desktop\测试项目\PeccancyInquiryTest\PeccancyInquiryTest\text.xml");
        }

        static IList<VehicleEntity> LoadData()
        {
            IList<VehicleEntity> VehicleList = new List<VehicleEntity> { 
                    new VehicleEntity
                    {
                        City = "110000",
                        EcarBelong = "11",
                        EngineNum = "62002049",
                        EcarPart = "JH0018",
                        ProvinceCode = "110000",
                        ShortID = 11
                    },
                    new VehicleEntity
                    {
                        City = "110000",
                        EcarBelong = "11",
                        EngineNum = "375653",
                        EcarPart = "NN3T19",
                        ProvinceCode = "110000",
                        ShortID = 11
                    },
                    new VehicleEntity
                    {
                        City = "110000",
                        EcarBelong = "11",
                        EngineNum = "375653",
                        EcarPart = "NN3T10",
                        ProvinceCode = "110000",
                        ShortID = 11
                    }
            };
            return VehicleList;
        }

    }

   
    public class Message
    {
        public string use_cache { set; get; }
        public string ERRMSG { set; get; }
        public string STATUS { set; get; }
        public string ERRCODE { set; get; }
        public string WZCX { set; get; }
        public string breakrulesCode { set; get; }
        public string penalty { set; get; }
    }

}
