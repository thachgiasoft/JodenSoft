using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class PageInfo : INotifyPropertyChanged
    {
        private int _PageIndex = 0;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int PageIndex
        {
            get { return _PageIndex <= 0 ? 1 : _PageIndex; }
            set
            {
                _PageIndex = value;
                FirePropertyChanged("PageIndex");
            }
        }

        private int _PageSize = 0;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int PageSize
        {
            get { return _PageSize <= 0 ? 0 : _PageSize; }
            set
            {
                _PageSize = value;
                FirePropertyChanged("PageSize");
            }
        }
        private int _TotalPageCount = 1;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int TotalPageCount
        {
            get { return _TotalPageCount <= 0 ? 1 : _TotalPageCount; }
            set { _TotalPageCount = value; FirePropertyChanged("TotalPageCount"); }
        }

        private int _TotalRecordCount = 0;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int TotalRecordCount
        {
            get { return _TotalRecordCount <= 0 ? 0 : _TotalRecordCount; }
            set
            {
                _TotalRecordCount = value;
                FirePropertyChanged("TotalRecordCount");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
