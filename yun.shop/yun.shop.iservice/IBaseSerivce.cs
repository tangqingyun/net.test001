using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yun.shop.iservice
{
    public interface IBaseSerivce<TEntity,TId>
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        TEntity AddEntity(TEntity entity);
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        TEntity UpdateEntity(TEntity entity);
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        TEntity DeleteEntity(TId id);
        /// <summary>
        /// 获得所有数据
        /// </summary>
        /// <returns>对象集合</returns>
        IList<TEntity> GetAllData();
        /// <summary>
        /// 根据主键获得对象实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetEntityById(TId id);
        /// <summary>
        /// 获得分页数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="entity">对象实体</param>
        /// <param name="total">总记录数</param>
        /// <returns></returns>
        IList<TEntity> GetPageData(int pageIndex, int pageSize, TEntity entity, out int total);
    }
}
