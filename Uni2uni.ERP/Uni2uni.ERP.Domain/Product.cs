using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Resource.Attribute;

namespace Uni2uni.ERP.Domain
{
    [Serializable]
    [Database(DatabaseEnum = EnumDatabase.NHibernateDB)]
    public class Product : StandardEntity<Guid>
    {
        public Product()
        {
            base.CreateAboutInfo();
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        public virtual string ProductName { protected set; get; }

        /// <summary>
        /// 产品所属分类
        /// </summary>
        public virtual ProductCategory Category { protected set; get; }

        /// <summary>
        /// 商品集合
        /// </summary>
        public virtual IList<Goods> GoodsList { protected set; get; }

        /// <summary>
        ///  创建产品实体
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="categoryID"></param>
        /// <param name="productName"></param>
        /// <param name="newProduct"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool CreateInstance(Guid productID, Guid categoryID, string productName, out Product newProduct, out string msg)
        { 
            msg = string.Empty;
            newProduct=new Product
            {
                Id = productID,
                Category = ProductCategory.Get(categoryID),
                ProductName = productName,
                GoodsList=new List<Goods>()
            };
            return true;
        }

        public static Product Get(Guid id)
        {
            return Get<Product>(id);
        }

    }
}
