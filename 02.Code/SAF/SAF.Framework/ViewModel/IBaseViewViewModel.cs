using SAF.Foundation;
using SAF.Framework.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.ViewModel
{
    public interface IBaseViewViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        int UniqueId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        EditState EditState { get; }
        /// <summary>
        /// 
        /// </summary>
        event EventHandler EditStatusChanged;
    }
}
