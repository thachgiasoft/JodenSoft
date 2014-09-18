using SAF.Foundation;
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
        EditStatus EditStatus { get; }
        /// <summary>
        /// 
        /// </summary>
        event EventHandler EditStatusChanged;
    }
}
