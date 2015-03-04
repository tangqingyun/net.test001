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
    public class ProductCategoryBll
    {
        private IProductCategoryService dal;
        public  ProductCategoryBll()
        {
            dal = (IProductCategoryService)InstanceFactory.GetServiceInstance("ProductCategoryService");
        }

        public bool CreateCategory(Guid id, string categoryName, Guid parentId, out ProductCategory productCategory, out string msg)
        {
           return dal.CreateCategory(id, categoryName, out productCategory, parentId,out msg);
        }

        public IList<ProductCategory> GetPageData(int pageIndex,int pageSize,ProductCategoryParam search,out int total)
        {
            return dal.GetPageData(pageIndex, pageSize, search, out total);
        }

        public ProductCategory GetProductCategoryById(Guid id)
        {
            return dal.GetProductCategoryById(id);
        }

        public bool ChangeCategory(Guid id,string categoryName,Guid parentId,out string msg)
        {
            return dal.ChangeCategory(id, categoryName, parentId, out msg);
        }
        
    }
}
