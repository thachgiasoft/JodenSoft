using SAF.Foundation;
using SAF.Framework.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.ViewModel
{
    public class BaseViewViewModel : IBaseViewViewModel
    {
        private EventHandlerList _Events = new EventHandlerList();
        /// <summary>
        /// 获取附加到此 ViewModel 的事件处理程序的列表
        /// </summary>
        protected EventHandlerList Events
        {
            get
            {
                return _Events;
            }
        }

        private static readonly object EventEditStatusChanged;

        static BaseViewViewModel()
        {
            EventEditStatusChanged = new object();
        }

        /// <summary>
        /// 
        /// </summary>
        public int UniqueId { get; set; }

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
                OnEditStatusChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler EditStatusChanged
        {
            add { Events.AddHandler(BaseViewViewModel.EventEditStatusChanged, value); }
            remove { Events.RemoveHandler(BaseViewViewModel.EventEditStatusChanged, value); }
        }

        protected void OnEditStatusChanged()
        {
            var handler = (EventHandler)Events[BaseViewViewModel.EventEditStatusChanged];
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
