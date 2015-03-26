using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace SAF.EntityFramework.DataPortalClient
{
    /// <summary>
    /// 本地数据库访问代理
    /// </summary>
    public class LocalProxy : IDataPortalProxy
    {
        private Server.IDataPortalServer _portal = new Server.DataPortal();
        /// <summary>
        /// 
        /// </summary>
        public bool IsServerRemote
        {
            get { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public Server.OperationResult LoadDataSet(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            return _portal.LoadDataSet(connectionName, dataSet, commandText, parameterValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public Server.OperationResult LoadDataSetByTransaction(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            return _portal.LoadDataSetByTransaction(connectionName, dataSet, commandText, parameterValues);
        }

        public Server.OperationResult LoadDataSet(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            return _portal.LoadDataSet(connectionName, dataSet, tableNames, commandText, parameterValues);
        }

        public Server.OperationResult LoadDataSetByTransaction(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            return _portal.LoadDataSetByTransaction(connectionName, dataSet, tableNames, commandText, parameterValues);
        }

        public Server.OperationResult LoadReportDataSet(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            return _portal.LoadReportDataSet(connectionName, dataSet, tableNames, commandText, parameterValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public Server.OperationResult ExecuteDataset(string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteDataset(connectionName, commandText, parameterValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public Server.OperationResult ExecuteDatasetByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteDatasetByTransaction(connectionName, commandText, parameterValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public Server.OperationResult ExecuteScalar(string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteScalar(connectionName, commandText, parameterValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public Server.OperationResult ExecuteScalarByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteScalarByTransaction(connectionName, commandText, parameterValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public Server.OperationResult ExecuteNonQuery(string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteNonQuery(connectionName, commandText, parameterValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public Server.OperationResult ExecuteNonQueryByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteNonQueryByTransaction(connectionName, commandText, parameterValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlCommandObjects"></param>
        /// <returns></returns>
        public Server.OperationResult ExecuteNonQueryByTransaction(string connectionName, Server.SqlCommandObject[] sqlCommandObjects)
        {
            return _portal.ExecuteNonQueryByTransaction(connectionName, sqlCommandObjects);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlCommandObjects"></param>
        /// <returns></returns>
        public Server.OperationResult ExecuteNonQuery(string connectionName, Server.SqlCommandObject[] sqlCommandObjects)
        {
            return _portal.ExecuteNonQuery(connectionName, sqlCommandObjects);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="pageInfo"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public Server.OperationResult ExecuteDatasetByPage(string connectionName, PageInfo pageInfo, string commandText, object[] parameterValues)
        {
            return _portal.ExecuteDatasetByPage(connectionName, pageInfo, commandText, parameterValues);
        }


    }
}
