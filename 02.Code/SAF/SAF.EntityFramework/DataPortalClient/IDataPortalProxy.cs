using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.EntityFramework.Server;

namespace SAF.EntityFramework.DataPortalClient
{
    /// <summary>
    /// Interface implemented by client-side 
    /// data portal proxy objects.
    /// </summary>
    public interface IDataPortalProxy : IDataPortalServer
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsServerRemote { get; }
    }
}
