using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain.Parameters;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Resource.Attribute;

namespace Uni2uni.ERP.Domain
{
    [Serializable]
    [Database(DatabaseEnum = EnumDatabase.NHibernateDB)]
    public class Goods : StandardEntity<Guid>
    {
        public Goods()
        {
          
            base.CreateAboutInfo();
        }
        public virtual long GoodsCode { protected set; get; }
        public virtual Product Product { protected set; get; }
        public virtual string GoodsName { protected set; get; }
        public virtual decimal GoodsPrice { protected set; get; }
        public virtual decimal SalePrice { protected set; get; }
        public virtual string GoodsDetailPath { protected set; get; }

        public static bool CreateInstance(GoodsParam goodsParam, out Goods newGoods, out string msg)
        {
            msg = string.Empty;
            newGoods = new Goods
            {
                Id=goodsParam.GoodsId,
                Product = goodsParam.Product,
                GoodsName = goodsParam.GoodsName,
                GoodsPrice = goodsParam.GoodsPrice,
                SalePrice = goodsParam.SalePrice,
                GoodsDetailPath = goodsParam.GoodsDetailPath
            };
            return true;
        }

    }

}
