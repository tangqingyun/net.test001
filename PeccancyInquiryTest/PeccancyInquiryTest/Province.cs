using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeccancyInquiryTest
{
    public class Province
    {
        /// <summary>
        /// 省份ID
        /// </summary>
        public int ProvinceID { set; get; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { set; get; }
        /// <summary>
        /// 简称
        /// </summary>
        public string ProvinceShort { set; get; }
        /// <summary>
        /// 城市
        /// </summary>
        public IList<City> Citys { set; get; }
    }
}
