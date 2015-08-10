using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation.Reflection;

namespace SAF.EntityFramework.DataPortalClient
{
    internal class DefaultPortalProxyFactory : IDataPortalProxyFactory
    {
        /// <summary>
        /// Creates the DataPortalProxy to use for DataPortal call on the objectType.
        /// </summary>
        /// <returns></returns>
        public IDataPortalProxy Create()
        {
            string proxyTypeName = ConfigContext.DataPortalProxy;
            if (proxyTypeName.Equals("Local", StringComparison.CurrentCultureIgnoreCase))
                return new SAF.EntityFramework.DataPortalClient.LocalProxy();
            else
                return new SAF.EntityFramework.DataPortalClient.WcfProxy();
        }

    }
}
