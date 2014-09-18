using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;

namespace SAF.EntityFramework.Server.Hosts
{
    /// <summary>
    /// Exposes server-side DataPortal functionality
    /// through WCF.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfPortal : IWcfPortal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult LoadDataSet(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.LoadDataSet(connectionName, dataSet, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult LoadDataSetByTransaction(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.LoadDataSetByTransaction(connectionName, dataSet, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteDataset(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteDataset(connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteDatasetByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteDatasetByTransaction(connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteScalar(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteScalar(connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteScalarByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteScalarByTransaction(connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteNonQuery(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteNonQuery(connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteNonQueryByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteNonQueryByTransaction(connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlScripts"></param>
        /// <returns></returns>
        public OperationResult ExecuteNonQuery(string connectionName, SqlCommandObject[] sqlScripts)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteNonQuery(connectionName, sqlScripts);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlScripts"></param>
        /// <returns></returns>
        public OperationResult ExecuteNonQueryByTransaction(string connectionName, SqlCommandObject[] sqlScripts)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteNonQueryByTransaction(connectionName, sqlScripts);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
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
        public OperationResult ExecuteDatasetByPage(string connectionName, PageInfo pageInfo, string commandText, object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteDatasetByPage(connectionName, pageInfo, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }
    }
}
