using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.NHibernate;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Resource.Attribute;

namespace Uni2uni.ERP.Domain
{
    [Serializable]
    [Database(DatabaseEnum = EnumDatabase.NHibernateDB)]
    public class ProductCategory : StandardEntity<Guid>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ProductCategory()
        {
            base.CreateAboutInfo();
        }

        /// <summary>
        /// 分类名称
        /// </summary>
        public virtual string CategoryName { protected set; get; }

        /// <summary>
        /// 父级分类
        /// </summary>
        public virtual ProductCategory ParentId { protected set; get; }

        /// <summary> 
        /// 子类集合
        /// </summary>
        public virtual IList<ProductCategory> ChildrenList { protected set; get; }

        /// <summary>
        /// 实例化实体
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryName"></param>
        /// <param name="productCategory"></param>
        /// <param name="msg"></param>
        /// <param name="parentId">父类ID</param>
        /// <returns></returns>
        public static bool CreateInstance(Guid id, string categoryName, out ProductCategory productCategory, Guid parentId, out string msg)
        {

            productCategory = new ProductCategory()
            {
                Id = id,
                CategoryName = categoryName ?? "",
                ParentId = ProductCategory.Get(parentId),
                ChildrenList = new List<ProductCategory>()
            };
            msg = string.Empty;
            return true;
        }


        public virtual bool Change(string categoryName, Guid parentId)
        {
            CategoryName = categoryName;
            //ParentId = ProductCategory.Get(parentId);
            LastUpdateAboutInfo();
            return true;
        }

        /// <summary>
        /// 按ID获是对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ProductCategory Get(Guid id)
        {
            return Get<ProductCategory>(id);
        }

    }
}
