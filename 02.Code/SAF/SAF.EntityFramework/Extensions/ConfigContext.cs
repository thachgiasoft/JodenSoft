using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;
using SAF.Foundation.Security;

namespace SAF.EntityFramework
{
    /// <summary>
    /// Provides consistent context information between the client
    /// and server DataPortal objects. 
    /// </summary>
    public static class ConfigContext
    {
        #region Config Settings

        /// <summary>
        /// 
        /// </summary>
        public static int DefaultPageSize
        {
            get
            {
                var pageSize = ConfigurationManager.AppSettings["DefaultPageSize"];
                if (!string.IsNullOrEmpty(pageSize))
                {
                    return Convert.ToInt32(pageSize);
                }
                return 50;
            }
        }

        /// <summary>
        /// 默认的数据库连接
        /// </summary>
        public static string DefaultConnection
        {
            get
            {
                var conName = ConfigurationManager.AppSettings["DefaultConnection"];
                if (!string.IsNullOrEmpty(conName))
                {
                    return conName.ToString();
                }
                return "Default";
            }
        }
        /// <summary>
        /// 数据服务名称
        /// </summary>
        public static string ServiceName
        {
            get
            {
                var serviceName = ConfigurationManager.AppSettings["ServiceName"];
                if (!string.IsNullOrEmpty(serviceName))
                {
                    return serviceName.ToString();
                }
                return "SAF";
            }
        }

        private static string _dataPortalUrl = null;
        /// <summary>
        /// Gets or sets the data portal URL string.
        /// If not set on Get will read DataPortalUrl from config file. 
        /// </summary>
        /// <value>The data portal URL string.</value>
        public static string DataPortalUrlString
        {
            get
            {
                if (_dataPortalUrl == null)
                {
                    _dataPortalUrl = ConfigurationManager.AppSettings["DataPortalUrl"];
                }
                return _dataPortalUrl;
            }
            set
            {
                _dataPortalUrl = value;
            }
        }

        /// <summary>
        /// Returns the URL for the DataPortal server.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public static Uri DataPortalUrl
        {
            get { return new Uri(DataPortalUrlString); }
        }

        #endregion

        public static string DefaultPassword
        {
            get
            {
                var password = ConfigurationManager.AppSettings["DefaultPassword"];
                if (!string.IsNullOrEmpty(password))
                {
                    return SHA1Helper.Hash(password.ToString());
                }
                return SHA1Helper.Hash("1");
            }
        }
    }
}
