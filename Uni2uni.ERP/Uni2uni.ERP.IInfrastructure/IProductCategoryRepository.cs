using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Domain;
using Uni2uni.ERP.Domain.Parameters;

namespace Uni2uni.ERP.IInfrastructure
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory,Guid>
    {
        IList<ProductCategory> GetPageData(int pageIndex, int pageSize, ProductCategoryParam serach, out int total);
    }
}
