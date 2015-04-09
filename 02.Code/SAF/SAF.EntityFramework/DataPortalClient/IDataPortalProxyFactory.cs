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

    }
}
