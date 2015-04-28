using SAF.EntityFramework;
using SAF.Foundation;
using SAF.Framework.Entities;
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

        private static readonly object EventEditStateChanged;

        static BaseViewViewModel()
        {
            EventEditStateChanged = new object();
        }

        /// <summary>
        /// 
        /// </summary>
        public object UniqueId { get; set; }
        /// <summary>
        /// 单据ID
        /// </summary>
        public virtual int BillTypeId
        {
            get { return 0; }
        }

        private EditState _editState = EditState.Browse;
        /// <summary>
        /// 
        /// </summary>
        public EditState EditState
        {
            get { return _editState; }
            set
            {
                _editState = value;
                OnEditStateChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler EditStatusChanged
        {
            add { Events.AddHandler(BaseViewViewModel.EventEditStateChanged, value); }
            remove { Events.RemoveHandler(BaseViewViewModel.EventEditStateChanged, value); }
        }

        protected void OnEditStateChanged()
        {
            var handler = (EventHandler)Events[BaseViewViewModel.EventEditStateChanged];
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
