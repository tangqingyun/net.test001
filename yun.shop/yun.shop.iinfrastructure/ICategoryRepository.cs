using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yun.shop.domain;

namespace yun.shop.iinfrastructure
{
    public interface ICategoryRepository : IBaseRepository<Category, Guid>
    {

    }
}
