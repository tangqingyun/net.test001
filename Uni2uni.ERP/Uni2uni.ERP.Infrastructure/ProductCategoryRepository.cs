using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.IInfrastructure;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Resource.Attribute;
using NHibernate.Linq;
using Uni2uni.ERP.Domain;
using Uni2uni.ERP.Domain.Parameters;

namespace Uni2uni.ERP.Infrastructure
{
    [Database( DatabaseEnum=EnumDatabase.NHibernateDB)]
    public class ProductCategoryRepository :BaseRepository, IProductCategoryRepository
    {

        #region Constructor
        public ProductCategoryRepository()
        {

        } 
        #endregion

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="serach"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IList<ProductCategory> GetPageData(int pageIndex,int pageSize,ProductCategoryParam serach,out int total)
        {
            total = 0;
            var qv = Session.Query<ProductCategory>();
            if (serach != null)
            {
                return qv.ToList();
            }
            if (!string.IsNullOrWhiteSpace(serach.CategoryName))
            {
                qv = qv.Where(x=>x.CategoryName==serach.CategoryName);
            }
            var list= qv.ToList();
            total = list.Count();
            return list;
        }

     
    }
}
