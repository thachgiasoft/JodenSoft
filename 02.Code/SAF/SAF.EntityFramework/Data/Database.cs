using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using SAF.Foundation;
using System.Data;
using System.Globalization;
using SAF.EntityFramework.Properties;
using System.Text.RegularExpressions;
using SAF.EntityFramework.Server;
using SAF.Foundation.Security;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Database
    {
        private static object _lock = new object();
        private readonly string connectionString;
        private readonly DbProviderFactory dbProviderFactory;

        protected Database(string connectionString, DbProviderFactory dbProviderFactory)
        {
            if (connectionString.IsEmpty())
                throw new ArgumentNullException("connectionString");

            this.connectionString = connectionString;
            this.dbProviderFactory = dbProviderFactory;
        }

        #region Common Methods

        protected virtual int UserParametersStartIndex()
        {
            return 0;
        }

        protected virtual string BuildParameterName(string name)
        {
            return name.IsEmpty() ? string.Empty : name.Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected DbDataAdapter GetDataAdapter()
        {
            DbDataAdapter adapter = this.dbProviderFactory.CreateDataAdapter();
            return adapter;
        }

        #endregion

        #region CreateConnection
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbConnection CreateConnection()
        {
            DbConnection newConnection = this.dbProviderFactory.CreateConnection();
            newConnection.ConnectionString = this.connectionString.ToString();
            return newConnection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbConnection GetNewOpenConnection()
        {
            DbConnection connection = null;
            try
            {
                try
                {
                    connection = this.CreateConnection();
                    connection.Open();
                }
                catch
                {
                    throw;
                }
            }
            catch
            {
                if (connection != null)
                {
                    connection.Close();
                }
                throw;
            }
            return connection;
        }

        #endregion

        #region AddParameter

        private void AddParameter(DbCommand command, string name, DbType dbType, int size, ParameterDirection direction, bool nullable, object value)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            DbParameter parameter = this.CreateParameter(name, dbType, size, direction, nullable, value);
            command.Parameters.Add(parameter);
        }

        private void AddParameter(DbCommand command, string name, DbType dbType, ParameterDirection direction, object value)
        {
            this.AddParameter(command, name, dbType, 0, direction, false, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        public void AddInParameter(DbCommand command, string name, DbType dbType, object value)
        {
            this.AddParameter(command, name, dbType, ParameterDirection.Input, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        public void AddOutParameter(DbCommand command, string name, DbType dbType, int size)
        {
            this.AddParameter(command, name, dbType, size, ParameterDirection.Output, true, DBNull.Value);
        }

        #endregion

        #region Parameters

        private DbParameter CreateParameter(string name, DbType dbType, int size, ParameterDirection direction, bool nullable, object value)
        {
            DbParameter param = this.CreateParameter(name, dbType, value);
            param.DbType = dbType;
            param.Size = size;
            param.Direction = direction;
            param.IsNullable = nullable;
            return param;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, DbType dbType, object value)
        {
            DbParameter param = this.dbProviderFactory.CreateParameter();
            param.ParameterName = this.BuildParameterName(name);
            param.DbType = dbType;
            param.Value = value ?? DBNull.Value;
            return param;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value)
        {
            DbParameter param = this.dbProviderFactory.CreateParameter();
            param.ParameterName = this.BuildParameterName(name);
            param.Value = value ?? DBNull.Value;
            return param;
        }

        public virtual void AssignParameters(DbCommand command, object[] parameterValues)
        {
            this.ParseParameters(command);
            if (SameNumberOfParametersAndValues(command, parameterValues) == false)
            {
                throw new InvalidOperationException("values的元素数目和Sql语句不匹配");
            }

            AssignParameterValues(command, parameterValues);
        }

        private void AssignParameterValues(DbCommand command, object[] values)
        {
            int parameterIndexShift = UserParametersStartIndex(); // DONE magic number, depends on the database
            for (int i = 0; i < values.Length; i++)
            {
                IDataParameter parameter = command.Parameters[i + parameterIndexShift];
                SetParameterValue(command, parameter.ParameterName, values[i]);
            }
        }

        public virtual void SetParameterValue(DbCommand command, string parameterName, object value)
        {
            if (command == null) throw new ArgumentNullException("command");

            command.Parameters[BuildParameterName(parameterName)].Value = value ?? DBNull.Value;
        }

        protected virtual bool SameNumberOfParametersAndValues(DbCommand command, object[] values)
        {
            int numberOfParametersToStoredProcedure = command.Parameters.Count;
            int numberOfValuesProvidedForStoredProcedure = values.Length;
            return numberOfParametersToStoredProcedure == numberOfValuesProvidedForStoredProcedure;
        }

        private void ParseParameters(DbCommand command)
        {
            if (command == null) throw new ArgumentNullException("command");

            List<string> result = new List<string>();
            Regex paramReg = new Regex(@"[^@:](?<p>:\w+)");
            MatchCollection matches = paramReg.Matches(String.Concat(command.CommandText, " "));
            foreach (Match m in matches)
            {
                var param = m.Groups["p"].Value;
                if (!result.Any(p => p.Equals(param, StringComparison.CurrentCultureIgnoreCase)))
                    result.Add(param);
            }

            string cmdText = command.CommandText.Replace(":", this.BuildParameterName("p_"));
            for (int i = 0; i < result.Count; i++)
            {
                var paramName = this.BuildParameterName("p_" + result[i].Remove(0, 1));
                command.Parameters.Add(this.CreateParameter(paramName, null));
            }
            command.CommandText = cmdText;
        }

        #endregion

        #region GetCommand

        private DbCommand CreateCommandByCommandType(CommandType commandType, string commandText)
        {
            DbCommand command = this.dbProviderFactory.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;
            return command;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public DbCommand GetSqlStringCommand(string commandText, params object[] parameterValues)
        {
            if (commandText.IsEmpty())
            {
                throw new ArgumentException("commandText");
            }
            var command = this.CreateCommandByCommandType(CommandType.Text, commandText);
            this.AssignParameters(command, parameterValues);
            return command;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DbCommand GetSqlStringCommandFromSqlCommandObject(Server.SqlCommandObject cmdObj)
        {
            if (cmdObj == null)
                throw new ArgumentNullException("cmdObj");
            if (cmdObj.CommandText.IsEmpty())
            {
                throw new ArgumentException("commandText");
            }
            var command = this.CreateCommandByCommandType(CommandType.Text, cmdObj.CommandText);

            if (cmdObj.Parameters != null)
            {
                foreach (var item in cmdObj.Parameters)
                {
                    command.Parameters.Add(this.CreateParameter(item.Name, item.DataType, item.Value));
                }
            }
            else if (cmdObj.ParameterValues != null)
            {
                AssignParameters(command, cmdObj.ParameterValues);
            }
            return command;
        }

        #endregion

        #region Execute Command

        private void DoLoadDataSet(IDbCommand command, DataSet dataSet, string[] tableNames)
        {
            if (tableNames == null)
            {
                throw new ArgumentNullException("tableNames");
            }
            if (tableNames.Length == 0)
            {
                throw new ArgumentException("tableNames长度不能为空.");
            }
            for (int i = 0; i < tableNames.Length; i++)
            {
                if (string.IsNullOrEmpty(tableNames[i]))
                {
                    throw new ArgumentException("tableNames[" + i + "]为空.");
                }
            }
            using (DbDataAdapter adapter = this.GetDataAdapter())
            {
                ((IDbDataAdapter)adapter).SelectCommand = command;
                try
                {
                    string systemCreatedTableNameRoot = "Table";
                    for (int j = 0; j < tableNames.Length; j++)
                    {
                        string systemCreatedTableName = (j == 0) ? systemCreatedTableNameRoot : (systemCreatedTableNameRoot + j);
                        adapter.TableMappings.Add(systemCreatedTableName, tableNames[j]);
                    }
                    adapter.Fill(dataSet);
                }
                catch
                {
                    throw;
                }
            }
        }

        private int DoExecuteNonQuery(DbCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            int result;
            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                result = rowsAffected;
            }
            catch
            {
                throw;
            }
            return result;
        }

        private object DoExecuteScalar(IDbCommand command)
        {
            object result;
            try
            {
                object returnValue = command.ExecuteScalar();
                result = returnValue;
            }
            catch
            {
                throw;
            }
            return result;
        }

        #endregion

        #region PrepareCommand

        private static void PrepareCommand(DbCommand command, DbConnection connection)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            command.Connection = connection;
        }

        private static void PrepareCommand(DbCommand command, DbTransaction transaction)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            Database.PrepareCommand(command, transaction.Connection);
            command.Transaction = transaction;
        }

        #endregion

        #region LoadDataSet
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dataSet"></param>
        public void LoadDataSet(DbCommand command, DataSet dataSet)
        {
            this.LoadDataSet(command, dataSet, new string[]
			{
				"Table"
			});
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dataSet"></param>
        /// <param name="transaction"></param>
        public void LoadDataSet(DbCommand command, DataSet dataSet, DbTransaction transaction)
        {
            this.LoadDataSet(command, dataSet, new string[]
			{
				"Table"
			}, transaction);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        public void LoadDataSet(DbCommand command, DataSet dataSet, string tableName)
        {
            this.LoadDataSet(command, dataSet, new string[] { tableName });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        /// <param name="transaction"></param>
        public void LoadDataSet(DbCommand command, DataSet dataSet, string tableName, DbTransaction transaction)
        {
            this.LoadDataSet(command, dataSet, new string[] { tableName }, transaction);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        public void LoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames)
        {
            using (var con = this.GetNewOpenConnection())
            {
                Database.PrepareCommand(command, con);
                this.DoLoadDataSet(command, dataSet, tableNames);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        /// <param name="transaction"></param>
        public void LoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames, DbTransaction transaction)
        {
            Database.PrepareCommand(command, transaction);
            this.DoLoadDataSet(command, dataSet, tableNames);
        }

        #endregion

        #region ExecuteDataSet
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string query, params object[] parameterValues)
        {
            DataSet result;
            using (DbCommand command = this.GetSqlStringCommand(query, parameterValues))
            {
                result = this.ExecuteDataSet(command);
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbCommand command)
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            this.LoadDataSet(command, dataSet, "Table");
            return dataSet;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbCommand command, DbTransaction transaction)
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            this.LoadDataSet(command, dataSet, "Table", transaction);
            return dataSet;
        }

        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string query, params object[] parameterValues)
        {
            int result;
            using (DbCommand command = this.GetSqlStringCommand(query, parameterValues))
            {
                result = this.ExecuteNonQuery(command);
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbCommand command)
        {
            int result;
            using (var con = this.GetNewOpenConnection())
            {
                Database.PrepareCommand(command, con);
                result = this.DoExecuteNonQuery(command);
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbCommand command, DbTransaction transaction)
        {
            Database.PrepareCommand(command, transaction);
            return this.DoExecuteNonQuery(command);
        }

        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public object ExecuteScalar(string query, params object[] parameterValues)
        {
            using (DbCommand command = this.GetSqlStringCommand(query, parameterValues))
            {
                return this.ExecuteScalar(command);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            using (var con = this.GetNewOpenConnection())
            {
                Database.PrepareCommand(command, con);
                return this.DoExecuteScalar(command);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand command, DbTransaction transaction)
        {
            Database.PrepareCommand(command, transaction);
            return this.DoExecuteScalar(command);
        }

        #endregion

        internal DataSet ExecuteDatasetByPage(DbCommand command, PageInfo pageInfo)
        {
            string commandText = command.CommandText;
            try
            {
                foreach (DbParameter param in command.Parameters)
                {
                    string name = param.ParameterName;
                    commandText = commandText.Replace(name, (param.Value == null || param.Value == DBNull.Value) ? "NULL" : "'{0}'".FormatEx(param.Value));
                }
                command.Parameters.Clear();
                command.CommandText = "sysPageQuery";
                command.CommandType = CommandType.StoredProcedure;
                AddInParameter(command, "@CommandText", DbType.String, commandText);
                AddInParameter(command, "@PageSize", DbType.Int32, pageInfo.PageSize);
                AddInParameter(command, "@CurrPage", DbType.Int32, pageInfo.PageIndex);
                DataSet dataSet = new DataSet();
                dataSet.Locale = CultureInfo.InvariantCulture;
                this.LoadDataSet(command, dataSet, "Table");
                var dt = dataSet.Tables[1];
                pageInfo.PageSize = Convert.ToInt32(dt.Rows[0]["PageSize"]);
                pageInfo.PageIndex = Convert.ToInt32(dt.Rows[0]["CurrPage"]);
                pageInfo.TotalPageCount = Convert.ToInt32(dt.Rows[0]["TotalPage"]);
                pageInfo.TotalRecordCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                dataSet.Tables.RemoveAt(0);
                dataSet.Tables.RemoveAt(0);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("出错脚本:" + Environment.NewLine + commandText, ex);
            }
        }
    }

}
