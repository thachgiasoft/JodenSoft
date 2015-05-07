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

        public Server.OperationResult LoadDataSet(string serviceName, string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            return _portal.LoadDataSet(serviceName, connectionName, dataSet, commandText, parameterValues);
        }

        public Server.OperationResult LoadDataSetByTransaction(string serviceName, string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            return _portal.LoadDataSetByTransaction(serviceName, connectionName, dataSet, commandText, parameterValues);
        }

        public Server.OperationResult LoadDataSet(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            return _portal.LoadDataSet(serviceName, connectionName, dataSet, tableNames, commandText, parameterValues);
        }

        public Server.OperationResult LoadDataSetByTransaction(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            return _portal.LoadDataSetByTransaction(serviceName, connectionName, dataSet, tableNames, commandText, parameterValues);
        }

        public Server.OperationResult LoadReportDataSet(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            return _portal.LoadReportDataSet(serviceName, connectionName, dataSet, tableNames, commandText, parameterValues);
        }

        public Server.OperationResult ExecuteDataset(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteDataset(serviceName, connectionName, commandText, parameterValues);
        }

        public Server.OperationResult ExecuteDatasetByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteDatasetByTransaction(serviceName, connectionName, commandText, parameterValues);
        }

        public Server.OperationResult ExecuteScalar(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteScalar(serviceName, connectionName, commandText, parameterValues);
        }

        public Server.OperationResult ExecuteScalarByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteScalarByTransaction(serviceName, connectionName, commandText, parameterValues);
        }

        public Server.OperationResult ExecuteNonQuery(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteNonQuery(serviceName, connectionName, commandText, parameterValues);
        }

        public Server.OperationResult ExecuteNonQueryByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            return _portal.ExecuteNonQueryByTransaction(serviceName, connectionName, commandText, parameterValues);
        }

        public Server.OperationResult ExecuteNonQueryByTransaction(string serviceName, string connectionName, Server.SqlCommandObject[] sqlCommandObjects)
        {
            return _portal.ExecuteNonQueryByTransaction(serviceName, connectionName, sqlCommandObjects);
        }

        public Server.OperationResult ExecuteNonQuery(string serviceName, string connectionName, Server.SqlCommandObject[] sqlCommandObjects)
        {
            return _portal.ExecuteNonQuery(serviceName, connectionName, sqlCommandObjects);
        }

        public Server.OperationResult ExecuteDatasetByPage(string serviceName, string connectionName, PageInfo pageInfo, string commandText, object[] parameterValues)
        {
            return _portal.ExecuteDatasetByPage(serviceName, connectionName, pageInfo, commandText, parameterValues);
        }


    }
}
