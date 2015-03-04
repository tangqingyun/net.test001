using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain;

namespace Uni2uni.ERP.NHiberantMap
{
    public class GoodsMap : StandardClassMap<Goods, Guid>
    {
        public GoodsMap():base("GoodsID")
        {
            Table("Goods");
            Map(m => m.GoodsCode).ReadOnly();   //为自增字段 标识为只读 这样在新增 修改时不会加入sql中
            Map(m => m.GoodsName).Not.Nullable();
            Map(m => m.GoodsPrice).Not.Nullable();
            Map(m => m.SalePrice).Not.Nullable();
            Map(m => m.GoodsDetailPath);

            //与产品做映射关联
            References(m => m.Product)
                .Column("ProductID")
                .Insert()
                .Update();
        }
    }
}
