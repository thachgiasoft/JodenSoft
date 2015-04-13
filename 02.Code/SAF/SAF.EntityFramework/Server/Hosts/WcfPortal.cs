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
        public OperationResult LoadDataSet(string serviceName, string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.LoadDataSet(serviceName, connectionName, dataSet, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult LoadDataSet(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.LoadDataSet(serviceName, connectionName, dataSet, tableNames, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult LoadDataSetByTransaction(string serviceName, string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.LoadDataSetByTransaction(serviceName, connectionName, dataSet, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult LoadDataSetByTransaction(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.LoadDataSetByTransaction(serviceName, connectionName, dataSet, tableNames, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult LoadReportDataSet(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.LoadReportDataSet(serviceName, connectionName, dataSet, tableNames, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult ExecuteDataset(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteDataset(serviceName, connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult ExecuteDatasetByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteDatasetByTransaction(serviceName, connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult ExecuteScalar(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteScalar(serviceName, connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult ExecuteScalarByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteScalarByTransaction(serviceName, connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult ExecuteNonQuery(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteNonQuery(serviceName, connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult ExecuteNonQueryByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteNonQueryByTransaction(serviceName, connectionName, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult ExecuteNonQuery(string serviceName, string connectionName, SqlCommandObject[] sqlScripts)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteNonQuery(serviceName, connectionName, sqlScripts);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult ExecuteNonQueryByTransaction(string serviceName, string connectionName, SqlCommandObject[] sqlScripts)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteNonQueryByTransaction(serviceName, connectionName, sqlScripts);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }

        public OperationResult ExecuteDatasetByPage(string serviceName, string connectionName, PageInfo pageInfo, string commandText, object[] parameterValues)
        {
            try
            {
                DataPortal portal = new DataPortal();
                return portal.ExecuteDatasetByPage(serviceName, connectionName, pageInfo, commandText, parameterValues);
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.Message };
            }
        }
    }
}
