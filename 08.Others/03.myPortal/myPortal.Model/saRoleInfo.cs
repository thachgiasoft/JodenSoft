using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace myPortal.Model
{
    /// <summary>
    /// saRole
    /// </summary>	
    public class saRoleInfo
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

        private string _sremark;
        /// <summary>
        /// sRemark
        /// </summary>	
        public string sRemark
        {
            get { return _sremark; }
            set { _sremark = value; }
        }

        #region Static Properties
        /// <summary>
        ///  TableName
        /// </summary>	
        public static string sTableName
        {
            get { return "saRole"; }
        }
        #endregion


        public bool IsActive { get; set; }
        public bool bIsAdministrator { get; set; }
    }
}