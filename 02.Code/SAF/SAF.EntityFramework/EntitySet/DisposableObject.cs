using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DisposableObject : MarshalByRefObject, IDisposable
    {
        #region IDisposable Support

        private static readonly object EventDisposed = new object();
        private EventHandlerList events;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Disposed
        {
            add
            {
                this.Events.AddHandler(DisposableObject.EventDisposed, value);
            }
            remove
            {
                this.Events.RemoveHandler(DisposableObject.EventDisposed, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected EventHandlerList Events
        {
            get
            {
                if (this.events == null)
                {
                    this.events = new EventHandlerList();
                }
                return this.events;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                bool flag = false;
                try
                {
                    Monitor.Enter(this, ref flag);
                    if (this.events != null)
                    {
                        EventHandler eventHandler = (EventHandler)this.events[DisposableObject.EventDisposed];
                        if (eventHandler != null)
                        {
                            eventHandler(this, EventArgs.Empty);
                        }
                    }
                }
                finally
                {
                    if (flag)
                    {
                        Monitor.Exit(this);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        ~DisposableObject()
        {
            Dispose(false);
        }

        #endregion
    }
}
