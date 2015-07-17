using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.ComponentModel;
using SAF.EntityFramework.Server.Hosts;
using SAF.Foundation;
using SAF.EntityFramework.Server;

namespace SAF.EntityFramework
{
    /// <summary>
    /// This is the client-side DataPortal
    /// </summary>
    public class DataPortal
    {
        private DataPortal() { }

        public static string ServiceName
        {
            get { return ConfigContext.ServiceName; }
        }

        #region DataPortal Proxy

        private static DataPortalClient.IDataPortalProxyFactory _dataProxyFactory;

        private static DataPortalClient.IDataPortalProxy GetDataPortalProxy()
        {
            if (_dataProxyFactory == null)
            {
                _dataProxyFactory = new DataPortalClient.DefaultPortalProxyFactory();
            }
            return _dataProxyFactory.Create();
        }

        #endregion

        #region LoadDataSet

        public static void LoadDataSet(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.LoadDataSet(ServiceName, connectionName, dataSet, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
        }

        public static void LoadDataSet(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.LoadDataSet(ServiceName, connectionName, dataSet, tableNames, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
        }

        public static void LoadDataSetByTransaction(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.LoadDataSetByTransaction(ServiceName, connectionName, dataSet, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
        }

        public static void LoadDataSetByTransaction(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.LoadDataSetByTransaction(ServiceName, connectionName, dataSet, tableNames, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
        }

        #endregion

        #region ExecuteDataset

        public static DataSet ExecuteDataset(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteDataset(ServiceName, connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data as DataSet;
        }

        public static DataSet ExecuteDatasetByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteDatasetByTransaction(ServiceName, connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data as DataSet;
        }

        #endregion

        #region ExecuteScalar

        public static object ExecuteScalar(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteScalar(ServiceName, connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data;
        }

        public static object ExecuteScalarByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteScalarByTransaction(ServiceName, connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data;
        }

        #endregion

        #region ExecuteNonQuery

        public static int ExecuteNonQuery(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteNonQuery(ServiceName, connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data.To<int>();
        }

        public static int ExecuteNonQueryByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteNonQueryByTransaction(ServiceName, connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data.To<int>();
        }

        public static int ExecuteNonQuery(string connectionName, List<SqlCommandObject> sqlCommandObjects)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteNonQuery(ServiceName, connectionName, sqlCommandObjects.ToArray());

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data.To<int>();
        }

        public static int ExecuteNonQueryByTransaction(string connectionName, List<SqlCommandObject> sqlCommandObjects)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteNonQueryByTransaction(ServiceName, connectionName, sqlCommandObjects.ToArray());

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data.To<int>();
        }

        #endregion

        /// <summary>
        /// 数据库当前时间
        /// </summary>
        public static DateTime Now
        {
            get
            {
                return Convert.ToDateTime(DataPortal.ExecuteScalar(ConfigContext.DefaultConnection, "SELECT GetDate()"));
            }
        }
        /// <summary>
        /// 判断表在数据库中是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static bool TableIsExists(string connectionName, string tableName)
        {
            var obj = DataPortal.ExecuteScalar(connectionName,
                    @" SELECT Iden=id
                        FROM dbo.sysobjects WITH(NOLOCK)
                        WHERE id = OBJECT_ID(N'{0}') AND OBJECTPROPERTY(id, N'IsTable') = 1", tableName);
            return !(obj == null);
        }

        public static DataSet ExecuteDatasetByPage(string connectionName, PageInfo pageInfo, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteDatasetByPage(ServiceName, connectionName, pageInfo, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data as DataSet;
        }

        public static void LoadReportDataSet(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.LoadReportDataSet(ServiceName, connectionName, dataSet, tableNames, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
        }
    }
}
