using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yun.shop.domain;

namespace yun.shop.domainMap
{
    /// <summary>
    /// 标准基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public  class StandardEntityTypeConfiguration<TEntity> : 
        EntityTypeConfiguration<TEntity> where TEntity : BaseStandardEntity
    {
        public StandardEntityTypeConfiguration()
        {
          
            Property(m => m.CreateDate);
            Property(m=>m.Creater).IsRequired();

        }
    }
}
