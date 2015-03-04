using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using System.Linq;
using System.Text;

namespace QCMS.Framework
{
    /// <summary>
    /// ADO.NET数据库操作帮助类
    /// </summary>
    public class DatabaseHelper
    {
        private readonly string connectionName;
        private DbProviderFactory dbProviderFactory;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionName">连接字符串名称</param>
        public DatabaseHelper(string connectionName)
            : this(connectionName, SqlClientFactory.Instance)
        {
           
        }

        private DatabaseHelper(string connectionName, DbProviderFactory dbProviderFactory)
        {
            string errorMsg = string.Empty;
            if (ConfigurationManager.ConnectionStrings.Count == 0)
                errorMsg = "请在web.config中设置connectionString节点的连接字符串";
            try
            {
                this.connectionName = ConfigurationManager.ConnectionStrings[connectionName].ToString();
                this.dbProviderFactory = dbProviderFactory;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="sql">sql字符串</param>
        /// <param name="commandType">解释命令字符串</param>
        /// <param name="listParms">参数</param>
        /// <returns></returns>
        public T GetData<T>(string sql, CommandType commandType, IList<DbParameter> listParms)
        {
            T t;
            using (DbConnection connection = this.CreateConnection())
            {
                connection.Open();
                using (DbCommand dbCommand = this.GetDbCommand(connection, sql, commandType, listParms))
                {
                    try
                    {
                        t = GetExecuteResult.GetSingleDataReader<T>(dbCommand);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    dbCommand.Parameters.Clear();
                }
                connection.Close();
            }
            return t;
        }
        /// <summary>
        /// 获取List集合
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="sql">sql字符串</param>
        /// <param name="commandType">解释命令字符串</param>
        /// <param name="listParms">参数</param>
        /// <returns></returns>
        public IList<T> GetListData<T>(string sql, CommandType commandType, IList<DbParameter> listParms)
        {
            IList<T> list;
            using (DbConnection connection = this.CreateConnection())
            {
                connection.Open();
                using (DbCommand dbCommand = this.GetDbCommand(connection, sql, commandType, listParms))
                {
                    try
                    {
                        list = GetExecuteResult.GetDataReader<T>(dbCommand);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    dbCommand.Parameters.Clear();
                }
                connection.Close();
            }
            return list;
        }
        /// <summary>
        /// 获取单行单列
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <param name="commandType">解释命令字符串</param>
        /// <param name="listParms">参数</param>
        /// <returns></returns>
        public object GetScalar(string sql, CommandType commandType, IList<DbParameter> listParms)
        {
            object o;
            using (DbConnection connection = this.CreateConnection())
            {
                connection.Open();
                using (DbCommand dbCommand = this.GetDbCommand(connection, sql, commandType, listParms))
                {
                    try
                    {
                        o = GetExecuteResult.GetScalar(dbCommand);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    dbCommand.Parameters.Clear();
                }
                connection.Close();
            }
            return o;
        }
        /// <summary>
        /// 获取bool值
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <param name="commandType">解释命令字符串</param>
        /// <param name="listParms">参数</param>
        /// <returns></returns>
        public bool GetExecuteBool(string sql, CommandType commandType, IList<DbParameter> listParms)
        {
            bool bol;
            using (DbConnection connection = this.CreateConnection())
            {
                connection.Open();
                using (DbCommand dbCommand = this.GetDbCommand(connection, sql, commandType, listParms))
                {
                    try
                    {
                        bol = GetExecuteResult.GetExecuteBool(dbCommand);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    dbCommand.Parameters.Clear();
                }
                connection.Close();
            }
            return bol;
        }
        /// <summary>
        /// 执行增、删、改
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <param name="commandType">解释命令字符串</param>
        /// <param name="listParms">参数</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, CommandType commandType, IList<DbParameter> listParms)
        {
            int n;
            using (DbConnection connection = this.CreateConnection())
            {
                connection.Open();
                using (DbCommand dbCommand = this.GetDbCommand(connection, sql, commandType, listParms))
                {
                    try
                    {
                        n = GetExecuteResult.GetNonQuery(dbCommand);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    dbCommand.Parameters.Clear();
                }
                connection.Close();
            }
            return n;
        }
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <param name="commandType">解释命令字符串</param>
        /// <param name="listParms">参数</param>
        /// <returns></returns>
        public DataSet GetDataSet(string sql, CommandType commandType, IList<DbParameter> listParms)
        {
            DataSet ds;
            using (DbConnection connection = this.CreateConnection())
            {
                using (DbCommand dbCommand = this.GetDbCommand(connection, sql, commandType, listParms))
                {
                    try
                    {
                        ds = GetExecuteResult.GetDataSet(dbCommand, dbProviderFactory);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    dbCommand.Parameters.Clear();
                }
                connection.Close();
            }
            return ds;
        }
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <param name="commandType">解释命令字符串</param>
        /// <param name="listParms">参数</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, CommandType commandType, IList<DbParameter> listParms)
        {
            DataTable dt = null;
            try
            {
                using (DbConnection connection = this.CreateConnection())
                {
                    connection.Open();
                    using (DbCommand dbCommand = this.GetDbCommand(connection, sql, commandType,
                        listParms))
                    {
                        DbDataAdapter da = new SqlDataAdapter();
                        dt = GetExecuteResult.GetDataTable(dbCommand, dbProviderFactory);
                        dbCommand.Parameters.Clear();
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return dt;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="dic">SQL字典</param>
        /// <param name="commandType">解释命令字符串</param>
        /// <returns></returns>
        public bool ExecuteTransation(IDictionary<string, IList<DbParameter>> dic,CommandType commandType)
        {
            using (DbConnection conn = this.CreateConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    if (dic.Count == 0) return false;
                    try
                    {
                        foreach (var item in dic)
                        {
                            using (DbCommand cmd = this.GetDbCommand(trans.Connection, item.Key, commandType, item.Value))
                            {
                                cmd.Connection = conn;
                                cmd.Transaction = trans;
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                        }
                        trans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return false;
                        throw;
                    }
                }
               
            }

        }

        #region - 公共方法

        private DbCommand GetDbCommand(DbConnection dbConnection, string commandText,
         CommandType commandType, IList<DbParameter> ListDataParameter)
        {
            DbCommand dbCommand = this.dbProviderFactory.CreateCommand();
            dbCommand.CommandType = commandType;
            dbCommand.CommandText = commandText;
            SetParameter(ListDataParameter, dbCommand);
            dbCommand.Connection = dbConnection;
            dbCommand.CommandTimeout = 0;
            return dbCommand;
        }

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        private DbConnection CreateConnection()
        {
            DbConnection newConnection = this.dbProviderFactory.CreateConnection();
            newConnection.ConnectionString = this.connectionName;
            return newConnection;
        }

        //设置参数
        private void SetParameter(IList<DbParameter> ListDataParameter, DbCommand dbCommand)
        {
            if (ListDataParameter != null && ListDataParameter.Count > 0)
            {
                foreach (DbParameter dbParameter in ListDataParameter)
                {
                    if ((dbParameter.Direction == ParameterDirection.InputOutput || dbParameter.Direction == ParameterDirection.Input) &&
                       (dbParameter.Value == null))
                    {
                        dbParameter.Value = DBNull.Value;
                    }
                    dbCommand.Parameters.Add(dbParameter);
                }
            }
        }
        #endregion

    }

    #region 获取执行结果类
    /// <summary>
    /// 获取执行结果类
    /// </summary>
    internal class GetExecuteResult
    {
        public static IList<T> GetDataReader<T>(DbCommand dbCommand)
        {
            IList<T> iList = new List<T>();
            if (dbCommand != null)
            {
                using (IDataReader dr = dbCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        iList.Add(ReflectHelper.PopulateChangeFromIDataReader<T>(dr));
                    }
                    dr.Close();
                }
            }
            return iList;
        }

        public static T GetSingleDataReader<T>(DbCommand dbCommand)
        {
            T t = Activator.CreateInstance<T>();
            if (dbCommand != null)
            {
                IDataReader dr = dbCommand.ExecuteReader();
                if (dr.Read())
                {
                    t = ReflectHelper.PopulateChangeFromIDataReader<T>(dr);
                }
                dr.Close();
            }
            return t;
        }

        public static object GetScalar(DbCommand dbCommand)
        {
            return (dbCommand != null) ? dbCommand.ExecuteScalar() : null;
        }

        public static int GetNonQuery(DbCommand dbCommand)
        {
            return (dbCommand != null) ? dbCommand.ExecuteNonQuery() : 0;
        }

        public static bool GetExecuteBool(DbCommand dbCommand)
        {
            return (GetNonQuery(dbCommand) != 0) ? true : false;
        }

        public static bool GetValueConvertBool(DbCommand dbCommand)
        {
            int ReturnIntValue = 0;
            Int32.TryParse(GetScalar(dbCommand).ToString(), out ReturnIntValue);
            return (ReturnIntValue != 0) ? true : false;
        }

        public static DataSet GetDataSet(DbCommand dbCommand, DbProviderFactory dbProviderFactory)
        {
            DataSet dataSet = new DataSet();
            if (dbCommand != null)
            {
                using (DbDataAdapter adapter = dbProviderFactory.CreateDataAdapter())
                {
                    ((IDbDataAdapter)adapter).SelectCommand = dbCommand;
                    adapter.Fill(dataSet);
                }
            }
            return dataSet;
        }

        public static DataTable GetDataTable(DbCommand dbCommand, DbProviderFactory dbProviderFactory)
        {
            DataSet dataSet = new DataSet();
            if (dbCommand != null)
            {
                using (DbDataAdapter adapter = dbProviderFactory.CreateDataAdapter())
                {
                    ((IDbDataAdapter)adapter).SelectCommand = dbCommand;
                    adapter.Fill(dataSet);
                }
            }
            return dataSet.Tables[0];
        }

    }  
    #endregion

}
