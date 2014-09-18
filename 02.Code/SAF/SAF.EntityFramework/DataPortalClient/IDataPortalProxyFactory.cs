using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework.DataPortalClient
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataPortalProxyFactory
    {
        /// <summary>
        /// Creates the DataPortalProxy to use for DataPortal.
        /// </summary>
        IDataPortalProxy Create();

        /// <summary>
        /// Resets the data portal proxy type, so the
        /// next data portal call will reload the proxy
        /// type based on current configuration values.
        /// </summary>
        void ResetProxyType();
    }
}
