using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AirTicket.LoginPage
{
    public class EjoyHelper
    {
        private const string XMLPATH = @"C:\Users\Administrator\Desktop\测试项目\AirTicket\AirTicket\LoginPage\Ejoy.xml";
       
        private static List<decimal> ejoyRecharegAmount = null;//易捷充值金额
        public static List<decimal> EjoyRecharegAmount
        {
            get
            {
                if (ejoyRecharegAmount == null)
                {
                    ejoyRecharegAmount = new List<decimal>();
                    XElement root = XElement.Load(XMLPATH);
                    IEnumerable EjoyRAList = (from el in root.Elements("EjoyRechargeAmount").Elements("Amount") select el);
                    foreach (XElement el in EjoyRAList)
                    {
                        ejoyRecharegAmount.Add(Convert.ToDecimal(el.Value));
                    }
                }
                return ejoyRecharegAmount;
            }

        }

        private static IList<RechargeArea> ejoyRechargeArea = null;//易捷充值地区
        public static IList<RechargeArea> EjoyRechargeArea
        {
            get
            {
                if (ejoyRechargeArea == null)
                {
                    ejoyRechargeArea = new List<RechargeArea>();
                    XElement root = XElement.Load(XMLPATH);
                    IEnumerable EjoyRAList = (from el in root.Elements("EjoyRechargeArea").Elements("Area") select el);
                    foreach (XElement el in EjoyRAList)
                    {
                        ejoyRechargeArea.Add(new RechargeArea { AreaID = el.Attribute("ID").Value, AreaName = el.Value });
                    }
                }
                return ejoyRechargeArea;
            }
        }

        private static List<decimal> sysRecharegAmount = null;//系统允许充值金额
        public static List<decimal> SysRecharegAmount
        {
            get
            {
                if (sysRecharegAmount == null)
                {
                    sysRecharegAmount = new List<decimal>();
                    XElement root = XElement.Load(XMLPATH);
                    IEnumerable list = (from el in root.Elements("SysRechargeAmount").Elements("Amount") select el);
                    foreach (XElement el in list)
                    {
                        sysRecharegAmount.Add(Convert.ToDecimal(el.Value));
                    }
                }
                return sysRecharegAmount;
            }

        }

    }


    public class RechargeArea
    {
        /// <summary>
        /// 地区ID
        /// </summary>
        public string AreaID { set; get; }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string AreaName { set; get; }
    }
}