using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using System.Configuration;
using SAF.Foundation.Security;
using System.Data.SqlClient;
using SAF.Foundation.ComponentModel;

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

            if (connectionName.Equals(ConfigContext.DefaultConnection, StringComparison.CurrentCultureIgnoreCase))
            {
                return CreateDatabase();
            }
            else
            {
                throw new ApplicationException("不存在名称为'{0}'的数据库连接字符串,请使用默认连接.".FormatEx(connectionName));
            }
        }

        /// <summary>
        /// 获取系统默认的数据库连接
        /// <para>此连接配置在app.config文件中,名称必须为:DefaultDatabase</para>
        /// </summary>
        /// <returns></returns>
        public static Database CreateDatabase()
        {
            var connectionConfig = ConfigurationManager.ConnectionStrings[ConfigContext.DefaultConnection];
            if (connectionConfig == null)
                throw new ConfigurationErrorsException(String.Format("Database name not found in config file ('{0}')", ConfigContext.DefaultConnection));

            string connectionString = ConfigurationManager.ConnectionStrings[ConfigContext.DefaultConnection].ConnectionString;
            if (connectionString.IsEmpty())
                throw new ConfigurationErrorsException(String.Format("The connection string of ('{0}') is null or empty.", ConfigContext.DefaultConnection));

            string provider = ConfigurationManager.ConnectionStrings[ConfigContext.DefaultConnection].ProviderName;
            if (provider.IsEmpty())
            {
                provider = "System.Data.SqlClient";
            }

            try
            {
                connectionString = ApplicationConfig.DecryptConnectionString(connectionString);
            }
            catch (Exception ex)
            {
                throw new CoreException("系统默认连接字符串不合法,可能未加密.", ex);
            }

            if (provider.Equals("System.Data.SqlClient", StringComparison.InvariantCultureIgnoreCase))
                return new SqlDatabase(connectionString);
            else
                return new SqlDatabase(connectionString);
        }
    }
}
