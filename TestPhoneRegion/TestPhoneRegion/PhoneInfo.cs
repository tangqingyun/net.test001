using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPhoneRegion
{
    /// <summary>
    /// 电话实体
    /// </summary>
    public class PhoneInfo
    {
        /// <summary>
        /// 所属省份
        /// </summary>
        public string Province { set; get; }
        /// <summary>
        /// 所属城市
        /// </summary>
        public string City { set; get; }
        /// <summary>
        /// 所属城镇
        /// </summary>
        public string Town { set; get; }
        /// <summary>
        /// 服务提供商
        /// </summary>
        public string Provider { set; get; }
        /// <summary>
        /// 号码
        /// </summary>
        public string PhoneCode { set; get; }
    }
}
