using SAF.EntityFramework;
using SAF.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBusinessViewViewModel : IBaseViewViewModel
    {
        /// <summary>
        ///
        /// </summary>
        IExecuteCache ExecuteCache { get; }
    }
}
