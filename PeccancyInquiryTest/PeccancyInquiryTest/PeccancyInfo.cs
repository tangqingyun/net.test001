using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeccancyInquiryTest
{
    /// <summary>
    /// 违章信息实体
    /// </summary>
    public class PeccancyInfo
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int STATUS { set; get; }
        /// <summary>
        /// 违章行为事项集合
        /// </summary>
        public IList<AffairEntity> WZCX { set; get; }
    }
}
