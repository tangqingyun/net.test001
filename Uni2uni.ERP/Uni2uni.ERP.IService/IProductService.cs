using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain;
using Uni2uni.ERP.Domain.Parameters;

namespace Uni2uni.ERP.IService
{
    public interface IProductService
    {
         bool CreateProduct(Guid productID, Guid categoryID, string productName, out Product newProduct, out string msg);
         bool CreateGoods(GoodsParam goodsParam, out Goods newGoods, out string msg);

    }
}
