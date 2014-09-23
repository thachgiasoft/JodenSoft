using SAF.Foundation;
using SAF.Framework.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.ViewModel
{
    public class BaseViewViewModel : IBaseViewViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int UniqueId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BaseView View { get; set; }

        private EditStatus _editStatus = EditStatus.Browse;
        /// <summary>
        /// 
        /// </summary>
        public EditStatus EditStatus
        {
            get { return _editStatus; }
            set
            {
                _editStatus = value;
                FireEditStatusChangedEvent();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler EditStatusChanged;

        private void FireEditStatusChangedEvent()
        {
            var handler = EditStatusChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
