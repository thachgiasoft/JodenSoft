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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        OperationResult LoadDataSet(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        OperationResult LoadDataSetByTransaction(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        OperationResult ExecuteDataset(string connectionName, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        OperationResult ExecuteDatasetByTransaction(string connectionName, string commandText, params object[] parameterValues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        OperationResult ExecuteScalar(string connectionName, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        OperationResult ExecuteScalarByTransaction(string connectionName, string commandText, params object[] parameterValues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        OperationResult ExecuteNonQuery(string connectionName, string commandText, params object[] parameterValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        OperationResult ExecuteNonQueryByTransaction(string connectionName, string commandText, params object[] parameterValues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlCommandObjects"></param>
        /// <returns></returns>
        OperationResult ExecuteNonQueryByTransaction(string connectionName, SqlCommandObject[] sqlCommandObjects);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlCommandObjects"></param>
        /// <returns></returns>
        OperationResult ExecuteNonQuery(string connectionName, SqlCommandObject[] sqlCommandObjects);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="pageInfo"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        OperationResult ExecuteDatasetByPage(string connectionName, PageInfo pageInfo, string commandText, object[] parameterValues);
    }
}
