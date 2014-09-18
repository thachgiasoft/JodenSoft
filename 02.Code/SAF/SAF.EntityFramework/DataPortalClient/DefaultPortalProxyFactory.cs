using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation.Reflection;

namespace SAF.EntityFramework.DataPortalClient
{
    internal class DefaultPortalProxyFactory : IDataPortalProxyFactory
    {
        private static Type _proxyType;

        /// <summary>
        /// Creates the DataPortalProxy to use for DataPortal call on the objectType.
        /// </summary>
        /// <returns></returns>
        public IDataPortalProxy Create()
        {
            if (_proxyType == null)
            {
                string proxyTypeName = ConfigContext.DataPortalProxy;
                if (proxyTypeName.Equals("Local", StringComparison.CurrentCultureIgnoreCase))
                    _proxyType = typeof(LocalProxy);
                else
                    _proxyType = Type.GetType(proxyTypeName, true, true);
            }
            return (IDataPortalProxy)MethodCaller.CreateInstance(_proxyType);
        }

        /// <summary>
        /// Resets the data portal proxy type, so the
        /// next data portal call will reload the proxy
        /// type based on current configuration values.
        /// </summary>
        public void ResetProxyType()
        {
            _proxyType = null;
        }
    }
}
