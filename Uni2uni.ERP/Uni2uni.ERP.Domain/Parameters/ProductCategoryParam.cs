using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uni2uni.ERP.Domain.Parameters
{
    public class ProductCategoryParam
    {
        public  string CategoryName { protected set; get; }
        public  Guid ParentId { protected set; get; }
    }
}
