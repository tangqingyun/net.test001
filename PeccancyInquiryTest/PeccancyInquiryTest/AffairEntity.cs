using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeccancyInquiryTest
{
    /// <summary>
    /// 违章事项实体
    /// </summary>
    public class AffairEntity
    {
        /// <summary>
        /// 违章记分
        /// </summary>
        public int DeductScore { set; get; }
        /// <summary>
        /// 违章行为
        /// </summary>
        public string Content { set; get; }
        /// <summary>
        /// 违章地点
        /// </summary>
        public string Area { set; get; }
        /// <summary>
        /// 违章时间
        /// </summary>
        public DateTime Datestr { set; get; }
        /// <summary>
        /// 处罚依据
        /// </summary>
        public string Deal { set; get; }
        /// <summary>
        /// 处理状态
        /// </summary>
        public string Status { set; get; }
        /// <summary>
        /// 违规编码
        /// </summary>
        public int BreakrulesCode { set; get; }
        /// <summary>
        /// 处罚金额
        /// </summary>
        public decimal Penalty { set; get; }
    }
}
