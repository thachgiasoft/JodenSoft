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

            var service = DataServiceConfigCollection.Current.FirstOrDefault(p => p.ServiceName == serviceName);
            if (service == null)
                throw new Exception("服务端配置文件中不存在名称为\"{0}\"的服务.".FormatEx(serviceName));

            var connection = service.ConnectionStringConfigs.FirstOrDefault(p => p.Name == connectionName);
            if (connection == null)
                throw new Exception("服务\"{0}\"中不存在名称为\"{1}\"的连接配置.".FormatEx(serviceName, connectionName));

            var connectionString = connection.ConnectionString;
            try
            {
                connectionString = ApplicationConfig.DecryptConnectionString(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("服务\"{0}\"中名称为\"{1}\"的连接配置格式错误.{2}{3}".FormatEx(serviceName, connectionName, Environment.NewLine, ex.Message));
            }

            return new SqlDatabase(connectionString);
        }

    }
}
