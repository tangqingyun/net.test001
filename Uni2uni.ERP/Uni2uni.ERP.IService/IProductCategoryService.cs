using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain;
using Uni2uni.ERP.Domain.Parameters;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Resource.Attribute;

namespace Uni2uni.ERP.IService
{

    public interface IProductCategoryService
    {
        bool CreateCategory(Guid id, string categoryName, out ProductCategory productCategory, Guid parentId, out string msg);
        bool ChangeCategory(Guid id, string categoryName, Guid parentId, out string msg);
        ProductCategory GetProductCategoryById(Guid id);
        IList<ProductCategory> GetPageData(int pageIndex, int pageSize, ProductCategoryParam search, out int total);
    }
}
