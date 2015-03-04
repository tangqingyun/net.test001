using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Common.ExtensionMethod;
using System.Data.SqlClient;
using NHibernate;


namespace Uni2uni.ERP.Infrastructure
{
    public abstract class BaseRepository
    {
        private readonly EnumDatabase _database;
        public BaseRepository()
        {
            _database = GetType().GetDatabase();
        }

        protected ISession Session 
        { 
            get {
                return Uni2uni.ERP.NHibernate.SessionManager.OpenCurrentSession(_database); 
            }
        }

        #region 基本操作

        /// <summary>
        /// 手动的事务回滚
        /// </summary>
        public void TransactionRollback()
        {
            if (Session.Transaction.IsActive
                && !Session.Transaction.WasCommitted
                && !Session.Transaction.WasRolledBack)
            {
                //事务中不使用Flush
                Session.Transaction.Rollback();
            }
        }
        #endregion

        #region Hql操作

        /// <summary>  
        /// 执行Hql的查询操作 
        /// </summary>  
        /// <param name="hql"></param>  
        /// <param name="hqlParamenters"></param>  
        /// <returns></returns>  
        protected IList<TT> ExecuteHqlQuery<TT>(string hql, IList<HqlParamenter> hqlParamenters)
        {
            var query = Session.CreateQuery(hql);
            SetHqlParamenter(query, hqlParamenters);
            return query.List<TT>();
        }

        /// <summary>  
        /// 执行Hql的更新、删除操作  
        /// </summary>  
        /// <param name="hql"></param>  
        /// <param name="hqlParamenters"></param>  
        /// <returns>返回执行记录数</returns>  
        protected int ExecuteHqlQuery_UpdateAndDelete(string hql, IList<HqlParamenter> hqlParamenters)
        {
            var query = Session.CreateQuery(hql);
            SetHqlParamenter(query, hqlParamenters);
            return query.ExecuteUpdate();
        }

        #endregion

        #region 基础方法

        /// <summary>
        /// 设置Hql参数
        /// </summary>
        /// <param name="query"></param>
        /// <param name="hqlParamenters"></param>
        protected void SetHqlParamenter(IQuery query, IList<HqlParamenter> hqlParamenters)
        {
            if (hqlParamenters == null) return;          
            foreach (var hqlParamenter in hqlParamenters)
            {
                if (hqlParamenter.ParameterName == null)
                {
                    throw new Exception("提交的参数未指定参数名称");
                }
                //if (hqlParamenter.ParameterType == null)
                //{
                //    throw new Exception("提交的参数未指定参数类型");
                //}
                if (hqlParamenter.Value == null && hqlParamenter.ValueList == null)
                {
                    throw new Exception("提交的参数未指定参数值");
                }
                if (hqlParamenter.ValueList != null)
                {
                   // query.SetParameterList(hqlParamenter.ParameterName, hqlParamenter.ValueList, hqlParamenter.ParameterType);
                }
                else
                {
                    
                   // query.SetParameter(hqlParamenter.ParameterName, hqlParamenter.Value, hqlParamenter.ParameterType);
                }
            }
        }
        /// <summary>
        /// Hql参数
        /// </summary>
        protected class HqlParamenter
        {
            /// <summary>
            /// 参数名，必需
            /// </summary>
            public string ParameterName { get; set; }
            /// <summary>
            /// 参数值，当Values为null时有效
            /// </summary>
            public object Value { get; set; }
            /// <summary>
            /// 参数值（多条）
            /// </summary>
            public IList<object> ValueList { get; set; }
            /// <summary>
            /// 参数类型，必需
            /// </summary>
            //public NHibernate.Type.IType ParameterType { get; set; }
        }

        #endregion

    }

    

}
