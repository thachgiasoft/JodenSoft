using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SAF.Foundation.ComponentModel
{
    /// <summary>
    /// Base class for items that support property notification.
    /// </summary>
    /// <remarks>
    /// This class provides basic support for implementing the <see cref="T:System.ComponentModel.INotifyPropertyChanged" /> interface and for
    /// marshalling execution to the UI thread.
    /// </remarks>
    [System.Serializable]
    public abstract class NotificationObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>        
        [field: System.NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// Raises this object's PropertyChanged event for each of the properties.
        /// </summary>
        /// <param name="propertyNames">The properties that have a new value.</param>
        protected void RaisePropertyChanged(params string[] propertyNames)
        {
            if (propertyNames == null)
            {
                throw new System.ArgumentNullException("propertyNames");
            }
            for (int i = 0; i < propertyNames.Length; i++)
            {
                string name = propertyNames[i];
                this.RaisePropertyChanged(name);
            }
        }
        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that has a new value</typeparam>
        /// <param name="propertyExpression">A Lambda expression representing the property that has a new value.</param>
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName<T>(propertyExpression);
            this.RaisePropertyChanged(propertyName);
        }
    }
}
