using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yun.shop.domain;
using yun.shop.iinfrastructure;
using yun.shop.infrastructure;
using yun.shop.iservice;

namespace yun.shop.service
{
    public class CategoryService :ICategoryService
    {
        ICategoryRepository dao;
        public CategoryService()
        {
            dao = new CategoryRepository();
        }


        public Category AddEntity(Category entity)
        {
            return dao.AddEntity(entity);
        }

        public Category UpdateEntity(Category entity)
        {
            return dao.UpdateEntity(entity);
        }

        public Category DeleteEntity(Guid id)
        {
            return dao.DeleteEntity(id);
        }

        public IList<Category> GetAllData()
        {
            return dao.GetAllData();
        }

        public Category GetEntityById(Guid id)
        {
            return dao.GetEntityById(id);
        }

        public IList<Category> GetPageData(int pageIndex, int pageSize, Category entity, out int total)
        {
            throw new NotImplementedException();
        }
    }
}
