using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Reflection;

namespace SAF.EntityFramework.Server.Hosts
{
    /// <summary>
    /// Defines the service contract for the WCF data
    /// portal.
    /// </summary>
    [ServiceContract(Namespace = "http://www.saf.com/2014/WcfPortal")]
    public interface IWcfPortal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "LoadDataSet")]
        OperationResult LoadDataSet(string serviceName, string connectionName, DataSet dataSet, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "LoadDataSetByTableNames")]
        OperationResult LoadDataSet(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "LoadDataSetByTransaction")]
        OperationResult LoadDataSetByTransaction(string serviceName, string connectionName, DataSet dataSet, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "LoadDataSetByTableNamesAndTransaction")]
        OperationResult LoadDataSetByTransaction(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "LoadReportDataSet")]
        OperationResult LoadReportDataSet(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "ExecuteDataset")]
        OperationResult ExecuteDataset(string serviceName, string connectionName, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "ExecuteDatasetByTransaction")]
        OperationResult ExecuteDatasetByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "ExecuteScalar")]
        OperationResult ExecuteScalar(string serviceName, string connectionName, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "ExecuteScalarByTransaction")]
        OperationResult ExecuteScalarByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "ExecuteNonQuery")]
        OperationResult ExecuteNonQuery(string serviceName, string connectionName, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "ExecuteNonQueryByTransaction")]
        OperationResult ExecuteNonQueryByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlScrips"></param>
        /// <returns></returns>
        [OperationContract(Name = "ExecuteSqlCommandObjectNonQueryByTransaction")]
        OperationResult ExecuteNonQueryByTransaction(string serviceName, string connectionName, SqlCommandObject[] sqlScrips);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlScripts"></param>
        /// <returns></returns>
        [OperationContract(Name = "ExecuteSqlCommandObjectNonQuery")]
        OperationResult ExecuteNonQuery(string serviceName, string connectionName, SqlCommandObject[] sqlScripts);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="pageInfo"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        [OperationContract(Name = "ExecuteDatasetByPage")]
        OperationResult ExecuteDatasetByPage(string serviceName, string connectionName, PageInfo pageInfo, string commandText, object[] parameterValues);
    }
}
