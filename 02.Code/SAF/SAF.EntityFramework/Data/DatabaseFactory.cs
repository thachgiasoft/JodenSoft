using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using System.Configuration;
using SAF.Foundation.Security;
using System.Data.SqlClient;

namespace SAF.EntityFramework
{
    public static class DatabaseFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static Database CreateDatabase(string connectionName)
        {
            if (connectionName.IsEmpty())
                throw new ArgumentNullException("connectionName");

            if (connectionName.Equals(ConfigContext.DefaultConnection, StringComparison.CurrentCultureIgnoreCase))
            {
                return CreateDatabase();
            }

            var ConList = CacheService.RetriveObject(CacheKey.sysConnectionString) as EntitySet<sysConnection>;
            if (ConList == null)
            {
                ConList = new EntitySet<sysConnection>();
                ConList.Query("select * from sysDatabase with(nolock)");
                if (ConList.Count <= 0)
                {
                    throw new Exception("sysDatabase表中未配置数据库连接字符串.");
                }
                CacheService.AddObject(CacheKey.sysConnectionString, ConList);
            }

            sysConnection db = ConList.FirstOrDefault(p => p.Name.Equals(connectionName, StringComparison.CurrentCultureIgnoreCase));
            if (db == null)
            {
                throw new Exception("sysDatabase表中未配置名称为{0}的数据库连接字符串.".FormatEx(connectionName));
            }

            string connectionString = db.ConnectionString;
            if (connectionString.IsEmpty())
                throw new Exception(String.Format("The connection string of ('{0}') is null or empty.", db.Name));

            try
            {
                connectionString = AESHelper.Decrypt(connectionString);
            }
            catch (Exception ex)
            {
                throw new CoreException("系统默认连接字符串不合法,可能未加密.", ex);
            }

            string provider = db.ProviderName;
            if (provider.IsEmpty())
            {
                provider = "System.Data.SqlClient";
            }

            if (provider.Equals("System.Data.SqlClient", StringComparison.InvariantCultureIgnoreCase))
                return new SqlDatabase(connectionString);
            else
                return new SqlDatabase(connectionString);
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
                connectionString = AESHelper.Decrypt(connectionString);
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
