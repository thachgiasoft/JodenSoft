using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace myPortal.Model
{
    /// <summary>
    /// saRoleMenu
    /// </summary>	
    public class saRoleMenuInfo
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
        private int _iroleid;
        /// <summary>
        /// iRoleId
        /// </summary>	
        public int iRoleId
        {
            get { return _iroleid; }
            set { _iroleid = value; }
        }
        private int _imenuid;
        /// <summary>
        /// iMenuId
        /// </summary>	
        public int iMenuId
        {
            get { return _imenuid; }
            set { _imenuid = value; }
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
            get { return "saRoleMenu"; }
        }
        #endregion

    }
}