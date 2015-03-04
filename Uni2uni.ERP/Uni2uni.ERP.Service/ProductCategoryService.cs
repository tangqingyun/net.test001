using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain;
using Uni2uni.ERP.Domain.Parameters;
using Uni2uni.ERP.IInfrastructure;
using Uni2uni.ERP.Infrastructure;
using Uni2uni.ERP.IService;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Resource.Attribute;
using Uni2Uni.ERP.IOC;



namespace Uni2uni.ERP.Service
{
    [Database(DatabaseEnum=EnumDatabase.NHibernateDB)]
    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository dao; 
        public ProductCategoryService()
        {
            //dao = new ProductCategoryRepository();
            dao = (IProductCategoryRepository)InstanceFactory.GetInfrastructureInstance("ProductCategoryRepository");
        }

        /// <summary>
        /// 创建产品分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryName"></param>
        /// <param name="productCategory"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        [AOP]
        public bool CreateCategory(Guid id, string categoryName, out ProductCategory productCategory,  Guid parentId,out string msg)
        {
            productCategory = null;
            try
            {
                bool bol = ProductCategory.CreateInstance(id, categoryName, out productCategory, parentId,out msg);
                if (bol)
                {
                    productCategory.Save();
                }
                return bol;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
         
        }

        /// <summary>
        /// 修改分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryName"></param>
        /// <param name="parentId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool ChangeCategory(Guid id, string categoryName, Guid parentId, out string msg)
        {
            msg = string.Empty;
            var model=ProductCategory.Get(id);
            if (model == null)
            {
                msg = "对象不存在！";
                return false;
            }
            bool bol=model.Change(categoryName, parentId);
            if (bol)
            {
                model.Update();
            }
            return true;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <returns></returns>
        public IList<ProductCategory> GetPageData(int pageIndex, int pageSize, ProductCategoryParam searchWhere, out int total)
        {
            IList<ProductCategory> list= dao.GetPageData(pageIndex,pageSize,searchWhere,out total);
            return list;
        }

        /// <summary>
        /// 根据ID获取实体 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductCategory GetProductCategoryById(Guid id)
        {
            return ProductCategory.Get(id);
        }

    }
}
