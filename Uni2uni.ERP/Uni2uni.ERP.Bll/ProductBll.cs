using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain;
using Uni2uni.ERP.Domain.Parameters;
using Uni2uni.ERP.IService;
using Uni2uni.ERP.Service;
using Uni2Uni.ERP.IOC;


namespace Uni2uni.ERP.Bll
{
    public class ProductBll
    {

        private IProductService dal;
        public ProductBll()
        {
           // dal = new ProductService();
            dal = (IProductService)InstanceFactory.GetServiceInstance("ProductService");
        }

          //创建产品
        public bool CreateProduct(Guid productID, Guid categoryID, string productName, out Product newProduct, out string msg)
        {
            return dal.CreateProduct(productID,categoryID,productName,out newProduct,out msg);
        }

        //创建商品
        public bool CreateGoods(GoodsParam goodsParam, out Goods newGoods, out string msg)
        {
            return dal.CreateGoods(goodsParam, out newGoods,out msg);
        }

    }
}
