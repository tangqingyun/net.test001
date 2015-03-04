using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yun.shop.domain;
using yun.shop.iservice;
using yun.shop.service;

namespace yun.shop.manager
{
    public class CategoryManager
    {
        ICategoryService service;
        public CategoryManager()
        {
            service = new CategoryService();
        }
        public Category AddCategory(Category entity)
        {
            return service.AddEntity(entity);
        }

        public IList<Category> GetCategoryAll()
        {
            return service.GetAllData();
        }

        public Category UpdateCategory(Category entity)
        {
            return service.UpdateEntity(entity);
        }

        public Category DeleteCategory(Guid id)
        {
            return service.DeleteEntity(id);
        }

    }
}
