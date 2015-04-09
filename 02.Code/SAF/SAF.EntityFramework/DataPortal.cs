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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        public static void LoadDataSet(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.LoadDataSet(connectionName, dataSet, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
        }

        public static void LoadDataSet(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.LoadDataSet(connectionName, dataSet, tableNames, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        public static void LoadDataSetByTransaction(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.LoadDataSetByTransaction(connectionName, dataSet, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
        }

        public static void LoadDataSetByTransaction(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.LoadDataSetByTransaction(connectionName, dataSet, tableNames, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
        }

        #endregion

        #region ExecuteDataset
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteDataset(connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data as DataSet;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static DataSet ExecuteDatasetByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteDatasetByTransaction(connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data as DataSet;
        }

        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteScalar(connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static object ExecuteScalarByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteScalarByTransaction(connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data;
        }

        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteNonQuery(connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data.To<int>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static int ExecuteNonQueryByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteNonQueryByTransaction(connectionName, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data.To<int>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlCommandObjects"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionName, List<SqlCommandObject> sqlCommandObjects)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteNonQuery(connectionName, sqlCommandObjects.ToArray());

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data.To<int>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlCommandObjects"></param>
        /// <returns></returns>
        public static int ExecuteNonQueryByTransaction(string connectionName, List<SqlCommandObject> sqlCommandObjects)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteNonQueryByTransaction(connectionName, sqlCommandObjects.ToArray());

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
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="pageInfo"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static DataSet ExecuteDatasetByPage(string connectionName, PageInfo pageInfo, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.ExecuteDatasetByPage(connectionName, pageInfo, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
            return result.Data as DataSet;
        }

        public static void LoadReportDataSet(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            OperationResult result = null;

            DataPortalClient.IDataPortalProxy proxy = GetDataPortalProxy();
            result = proxy.LoadReportDataSet(connectionName, dataSet, tableNames, commandText, parameterValues);

            if (!result.IsSucess)
                throw new Exception(result.Message);
        }
    }
}
