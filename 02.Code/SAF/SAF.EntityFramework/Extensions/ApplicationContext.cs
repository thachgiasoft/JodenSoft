using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;

namespace SAF.EntityFramework
{
    /// <summary>
    /// Provides consistent context information between the client
    /// and server DataPortal objects. 
    /// </summary>
    public static class ConfigContext
    {
        #region Config Settings

        private static string _dataPortalProxy;
        /// <summary>
        /// Gets or sets the full type name (or 'Local') of
        /// the data portal proxy object to be used when
        /// communicating with the data portal server.
        /// </summary>
        public static string DataPortalProxy
        {
            get
            {
                if (string.IsNullOrEmpty(_dataPortalProxy))
                {
                    _dataPortalProxy = ConfigurationManager.AppSettings["DataPortalProxy"];
                    if (string.IsNullOrEmpty(_dataPortalProxy))
                        _dataPortalProxy = "Local";
                }
                return _dataPortalProxy;
            }
            set
            {
                _dataPortalProxy = value;
            }
        }
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

        private static string _dataPortalUrl = null;
        /// <summary>
        /// Gets or sets the data portal URL string.
        /// If not set on Get will read CslaDataPortalUrl from config file. 
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


    }
}
