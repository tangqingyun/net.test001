using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yun.shop.domain
{
    /// <summary>
    /// 产品分类
    /// </summary>
    public class Category : BaseStandardEntity
    {
        public Category()
        {
            base.SetAboutInfo();
        }
        public Guid CategoryID { set; get; }
        public string CategoryName { set; get; }

        /// <summary>
        /// 子类
        /// </summary>
        public virtual IList<Category> Children { set; get; }
        /// <summary>
        /// 父类
        /// </summary>
        public virtual Category ParentCategory { set; get; }
    }
}
