using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace SAF.EntityFramework.Server
{
    /// <summary>
    /// 服务端数据服务接口
    /// </summary>
    public interface IDataPortalServer
    {
        OperationResult LoadDataSet(string serviceName, string connectionName, DataSet dataSet, string commandText, params object[] parameterValues);

        OperationResult LoadDataSet(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues);

        OperationResult LoadDataSetByTransaction(string serviceName, string connectionName, DataSet dataSet, string commandText, params object[] parameterValues);

        OperationResult LoadDataSetByTransaction(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues);

        OperationResult LoadReportDataSet(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues);

        OperationResult ExecuteDataset(string serviceName, string connectionName, string commandText, params object[] parameterValues);

        OperationResult ExecuteDatasetByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues);

        OperationResult ExecuteScalar(string serviceName, string connectionName, string commandText, params object[] parameterValues);

        OperationResult ExecuteScalarByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues);

        OperationResult ExecuteNonQuery(string serviceName, string connectionName, string commandText, params object[] parameterValues);

        OperationResult ExecuteNonQueryByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues);

        OperationResult ExecuteNonQueryByTransaction(string serviceName, string connectionName, SqlCommandObject[] sqlCommandObjects);

        OperationResult ExecuteNonQuery(string serviceName, string connectionName, SqlCommandObject[] sqlCommandObjects);

        OperationResult ExecuteDatasetByPage(string serviceName, string connectionName, PageInfo pageInfo, string commandText, object[] parameterValues);
    }
}
