using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace myPortal.Model
{
    /// <summary>
    /// saBulletinType
    /// </summary>	
    public class saBulletinTypeInfo
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
        private int _isort;
        /// <summary>
        /// iSort
        /// </summary>	
        public int iSort
        {
            get { return _isort; }
            set { _isort = value; }
        }
        private bool _busable;
        /// <summary>
        /// bUsable
        /// </summary>	
        public bool bUsable
        {
            get { return _busable; }
            set { _busable = value; }
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
            get { return "saBulletinType"; }
        }
        #endregion


    }
}