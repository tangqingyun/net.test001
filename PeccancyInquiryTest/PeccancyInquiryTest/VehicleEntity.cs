using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeccancyInquiryTest
{
    public class VehicleEntity
    {
        /// <summary>
        /// 省份简称ID
        /// </summary>
        public int ShortID { set; get; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { set; get; }
        /// <summary>
        /// 归属地
        /// </summary>
        public string EcarBelong { set; get; }
        /// <summary>
        /// 车牌编号
        /// </summary>
        public string EcarPart { set; get; }
        /// <summary>
        /// 发动机号
        /// </summary>
        public string EngineNum { set; get; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public string ProvinceCode { set; get; }
        /// <summary>
        /// 车辆类型 大型汽车=01,小型汽车=02,两三轮摩托车=07,轻便摩托车=08,其它=99
        /// </summary>
        public string EcarType { set; get; }
        /// <summary>
        /// 识别代码
        /// </summary>
        public string Evin { set; get; }
        /// <summary>
        /// 是否处理完成 true完成 false未完成
        /// </summary>
        public bool IsCompleted { set; get; }
    }
}
