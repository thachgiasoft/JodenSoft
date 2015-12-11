using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace myPortal.Model
{
    /// <summary>
    /// saMenu
    /// </summary>	
    public class saMenuInfo
    {

        private int _iiden;
        /// <summary>
        /// iIden
        /// </summary>	
        public int iIden
        {
            get { return _iiden; }
            set { _iiden = value; }
        }
        private string _sname;
        /// <summary>
        /// sName
        /// </summary>	
        public string sName
        {
            get { return _sname; }
            set { _sname = value; }
        }
        private int _iparent;
        /// <summary>
        /// iParent
        /// </summary>	
        public int iParent
        {
            get { return _iparent; }
            set { _iparent = value; }
        }
        private int _isort;
        /// <summary>
        /// iSort
        /// </summary>	
        public int iSort
        {
            get { return _isort; }
            set { _isort = value; }
        }
        private string _surl;
        /// <summary>
        /// sUrl
        /// </summary>	
        public string sUrl
        {
            get { return _surl; }
            set { _surl = value; }
        }
        private int _ilevel;
        /// <summary>
        /// iLevel
        /// </summary>	
        public int iLevel
        {
            get { return _ilevel; }
            set { _ilevel = value; }
        }
        private int _iopenmode;
        /// <summary>
        /// iOpenMode
        /// </summary>	
        public int iOpenMode
        {
            get { return _iopenmode; }
            set { _iopenmode = value; }
        }
        private int _icreator;
        /// <summary>
        /// iCreator
        /// </summary>	
        public int iCreator
        {
            get { return _icreator; }
            set { _icreator = value; }
        }
        #region Static Properties
        /// <summary>
        ///  TableName
        /// </summary>	
        public static string sTableName
        {
            get { return "saMenu"; }
        }
        #endregion

    }
}