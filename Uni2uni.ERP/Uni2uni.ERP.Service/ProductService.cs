using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain;
using Uni2uni.ERP.Domain.Parameters;
using Uni2uni.ERP.IInfrastructure;
using Uni2uni.ERP.IService;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Resource.Attribute;
using Uni2Uni.ERP.IOC;

namespace Uni2uni.ERP.Service
{
    [Database(DatabaseEnum = EnumDatabase.NHibernateDB)]
    public class ProductService :IProductService
    {
        IProductRepository dao;
        public ProductService()
        {
            dao = (IProductRepository)InstanceFactory.GetInfrastructureInstance("ProductRepository");
        }

        //创建产品
        public bool CreateProduct(Guid productID,Guid categoryID,string productName,out Product newProduct,out string msg)
        {
            bool bol=Product.CreateInstance(productID, categoryID, productName ,out newProduct,out msg);
            if (bol)
            {
                newProduct.Save();
            }
            return bol;
        }

        //创建商品
        public bool CreateGoods(GoodsParam goodsParam, out Goods newGoods, out string msg)
        {
            bool bol= Goods.CreateInstance(goodsParam, out newGoods, out msg);
            if (bol)
            {
                newGoods.Save();
            }
            return true;
        }

    }
}
