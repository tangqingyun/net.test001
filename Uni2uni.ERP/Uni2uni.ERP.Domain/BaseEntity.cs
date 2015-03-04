using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.NHibernate;
using Uni2uni.ERP.Resource;
using Uni2uni.ERP.Common.ExtensionMethod;

namespace Uni2uni.ERP.Domain
{
     [Serializable]
    public abstract class BaseEntity
    {
        private readonly EnumDatabase keyDatabase;
        public BaseEntity()
        {
            keyDatabase = GetType().GetDatabase();
        }
        private ISession _session;
        private ISession Session
        {
            get
            {
                return _session
                    ?? (_session = SessionManager.OpenCurrentSession(keyDatabase));
            }
        }


        /// <summary>
        /// 获得实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        protected static T Get<T>(object id)
        {
            var key = (typeof(T)).GetDatabase();
            var session = SessionManager.OpenCurrentSession(key);
            var e = session.Get<T>(id);
            return e;
        }

        /// <summary>
        /// 从数据库中重取
        /// </summary>
        public virtual void Refresh()
        {
            Session.Refresh(this);
        }

        /// <summary>
        /// 保存（新增）或更新
        /// </summary>
        public virtual void SaveOrUpdate()
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                try
                {
                    Session.SaveOrUpdate(this);
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }

        }

        /// <summary>
        /// 保存（新增）
        /// </summary>
        public virtual void Save()
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                try
                {
                    Session.Save(this);
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        
        }

        /// <summary>
        /// 更新
        /// </summary>
        public virtual void Update()
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                try
                {
                    Session.Update(this);
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual void Delete()
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(this);
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual void Evict()
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                try
                {
                    Session.Evict(this);
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }

        }

        /// <summary>
        /// 提交
        /// </summary>
        public virtual void Flush()
        {
            if (!Session.Transaction.IsActive)
            {
                Session.Flush();
            }
        }


    }
}
