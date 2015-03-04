using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yun.shop.domain;
using yun.shop.entityframework;
using yun.shop.iinfrastructure;

namespace yun.shop.infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        ShopContext context;
        public CategoryRepository()
        {
            context = ContextManager.CreateContext();
        }

        public Category AddEntity(Category entity)
        {
            try
            {
                var model = context.Categories.Add(entity);
                context.SaveChanges();
                context.Dispose();
                return model;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Category UpdateEntity(Category entity)
        {
            return context.Categories.Attach(entity);
        }

        public Category DeleteEntity(Guid id)
        {
           var model= context.Categories.Where(m => m.CategoryID == id).FirstOrDefault();
           if (model == null)
               return null;
           else
               return context.Categories.Remove(model);
        }

        public IList<Category> GetAllData()
        {
            return context.Categories.ToList();
        }

        public Category GetEntityById(Guid id)
        {
            return context.Categories.Where(m => m.CategoryID == id).FirstOrDefault();
        }

        public IList<Category> GetPageData(int pageIndex, int pageSize, Category entity, out int total)
        {
            throw new NotImplementedException();
        }
    }
}
