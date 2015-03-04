using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yun.shop.domain;

namespace yun.shop.entityframework
{
    public class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
      
        protected override void Seed(ShopContext context)
        {
         
            Category model = new Category()
            {
                CategoryID = Guid.NewGuid(),
                CategoryName = "全部分类",
                ParentCategory = new Category()
                {
                    CategoryID = new Guid(),
                    CategoryName = "全部分类"
                },
                Children = new List<Category>() { 
                    new Category(){ CategoryID=Guid.NewGuid(), CategoryName="数码产品"},
                    new Category(){ CategoryID=Guid.NewGuid(), CategoryName="生活百货"},
                   }
            };
            //context.Categories.Add(model);
            //context.SaveChanges();

        }
    }
}
