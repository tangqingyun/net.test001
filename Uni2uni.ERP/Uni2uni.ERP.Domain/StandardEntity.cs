using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uni2uni.ERP.Domain
{
    /// <summary>
    /// 数据实体基类
    /// </summary>
    /// <typeparam name="TId">主键类型</typeparam>
    [Serializable]
    public abstract class StandardEntity<TId>:BaseEntity
    {
        public virtual TId Id { set; get; }
      
        /// <summary>
        /// 创建者
        /// </summary>
        public virtual Guid Creater { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDate { set; get; }
        /// <summary>
        /// 最后更新者
        /// </summary>
        public virtual Guid Updater { set; get; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public virtual DateTime UpdateDate { set; get; }

        /// <summary>
        /// 创建相关信息
        /// </summary>
        protected void CreateAboutInfo()
        {
            this.Creater = Guid.Empty;
            this.CreateDate = DateTime.Now;
            LastUpdateAboutInfo();
        }
        /// <summary>
        /// 最后更新相关信息
        /// </summary>
        protected void LastUpdateAboutInfo()
        {
            this.Updater = Guid.Empty;
            this.UpdateDate = DateTime.Now;
        }

    }
}
