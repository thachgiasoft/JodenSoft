using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.EntityFramework.Server.Hosts;
using System.ServiceModel;
using System.Data.Common;
using System.Data;
using SAF.EntityFramework.Server;

namespace SAF.EntityFramework.DataPortalClient
{
    /// <summary>
    /// WCF数据库访问代理
    /// </summary>
    public class WcfProxy : IDataPortalProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsServerRemote
        {
            get { return true; }
        }

        #region IDataPortalServer Members

        private string _endPoint = "WcfDataPortal";
        /// <summary>
        /// 
        /// </summary>
        protected string EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual ChannelFactory<IWcfPortal> GetChannelFactory()
        {
            // if dataportal url is specified use this with default wsHttBinding
            if (!string.IsNullOrEmpty(ConfigContext.DataPortalUrlString))
            {
                var binding = new WSHttpBinding()
                {
                    MaxReceivedMessageSize = int.MaxValue,
                    MaxBufferPoolSize = int.MaxValue,
                    CloseTimeout = new TimeSpan(0, 10, 0),
                    ReceiveTimeout = new TimeSpan(0, 20, 0),
                    SendTimeout = new TimeSpan(0, 20, 0),
                    ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
                    {
                        MaxBytesPerRead = int.MaxValue,
                        MaxDepth = int.MaxValue,
                        MaxArrayLength = int.MaxValue,
                        MaxStringContentLength = int.MaxValue,
                        MaxNameTableCharCount = int.MaxValue
                    },
                    Security = new WSHttpSecurity() { Mode = SecurityMode.None }
                };
                return new ChannelFactory<IWcfPortal>(binding, new EndpointAddress(ConfigContext.DataPortalUrl));
            }

            // else return a channelfactory that uses the endpoint configuration in app.config/web.config
            return new ChannelFactory<IWcfPortal>(EndPoint);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cf"></param>
        /// <returns></returns>
        protected virtual IWcfPortal GetProxy(ChannelFactory<IWcfPortal> cf)
        {
            return cf.CreateChannel();
        }

        #endregion
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
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.LoadDataSet(connectionName, dataSet, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
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
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.LoadDataSetByTransaction(connectionName, dataSet, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
        }

        public OperationResult LoadDataSet(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.LoadDataSet(connectionName, dataSet, tableNames, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
        }

        public OperationResult LoadDataSetByTransaction(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.LoadDataSetByTransaction(connectionName, dataSet, tableNames, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
        }

        public OperationResult LoadReportDataSet(string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.LoadReportDataSet(connectionName, dataSet, tableNames, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
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
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.ExecuteDataset(connectionName, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
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
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.ExecuteDatasetByTransaction(connectionName, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
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
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.ExecuteScalar(connectionName, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
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
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.ExecuteScalarByTransaction(connectionName, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
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
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.ExecuteNonQuery(connectionName, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
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
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.ExecuteNonQueryByTransaction(connectionName, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlScripts"></param>
        /// <returns></returns>
        public OperationResult ExecuteNonQuery(string connectionName, SqlCommandObject[] sqlScripts)
        {
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.ExecuteNonQuery(connectionName, sqlScripts.ToArray());
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlScripts"></param>
        /// <returns></returns>
        public OperationResult ExecuteNonQueryByTransaction(string connectionName, SqlCommandObject[] sqlScripts)
        {
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.ExecuteNonQueryByTransaction(connectionName, sqlScripts);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
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
            ChannelFactory<IWcfPortal> cf = GetChannelFactory();
            IWcfPortal svr = GetProxy(cf);
            OperationResult result = null;
            try
            {
                result = svr.ExecuteDatasetByPage(connectionName, pageInfo, commandText, parameterValues);
                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw;
            }
            return result;
        }


    }
}
