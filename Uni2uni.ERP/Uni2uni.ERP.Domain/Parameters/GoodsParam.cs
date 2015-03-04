using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uni2uni.ERP.Domain.Parameters
{
    /// <summary>
    /// 商品参数实体
    /// </summary>
    public class GoodsParam
    {
        public Guid GoodsId { set; get; }
        public  long GoodsCode {  set; get; }
        public  Product Product {  set; get; }
        public  string GoodsName {  set; get; }
        public  decimal GoodsPrice {  set; get; }
        public  decimal SalePrice {  set; get; }
        public  string GoodsDetailPath {  set; get; }
    }
}
