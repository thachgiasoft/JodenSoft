using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using System.Configuration;
using SAF.Foundation.Security;
using System.Data.SqlClient;
using SAF.Foundation.ComponentModel;
using SAF.EntityFramework.Config;

namespace SAF.EntityFramework
{
    public static class DatabaseFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static Database CreateDatabase(string serviceName, string connectionName)
        {
            if (connectionName.IsEmpty())
                throw new ArgumentNullException("connectionName");

            string connectionString = string.Empty;

            string proxyTypeName = ConfigContext.DataPortalProxy;

            if (proxyTypeName.Equals("local", StringComparison.CurrentCultureIgnoreCase))
            {
                var connectionConfig = ConfigurationManager.ConnectionStrings[connectionName];
                if (connectionConfig == null)
                    throw new ConfigurationErrorsException(String.Format("Database name not found in config file ('{0}')", connectionName));

                connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                if (connectionString.IsEmpty())
                    throw new ConfigurationErrorsException(String.Format("The connection string of ('{0}') is null or empty.", connectionName));
            }
            else
            {
                var service = DataServiceConfigCollection.Current.FirstOrDefault(p => p.ServiceName.Equals(serviceName, StringComparison.CurrentCultureIgnoreCase));
                if (service == null)
                    throw new Exception("服务端配置文件中不存在名称为\"{0}\"的服务.".FormatWith(serviceName));

                var connection = service.ConnectionStringConfigs.FirstOrDefault(p => p.Name.Equals(connectionName, StringComparison.CurrentCultureIgnoreCase));
                if (connection == null)
                    throw new Exception("服务\"{0}\"中不存在名称为\"{1}\"的连接配置.".FormatWith(serviceName, connectionName));

                connectionString = connection.ConnectionString;
            }

            try
            {
                connectionString = ApplicationConfig.DecryptConnectionString(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("服务\"{0}\"中名称为\"{1}\"的连接配置格式错误.{2}{3}".FormatWith(serviceName, connectionName, Environment.NewLine, ex.Message));
            }

            return new SqlDatabase(connectionString);
        }

    }
}
