using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace myPortal.Model
{
    /// <summary>
    /// saUserRoleInfo
    /// </summary>	
    public class saUserRoleInfo
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
        private int _iuserid;
        /// <summary>
        /// iUserId
        /// </summary>	
        public int iUserId
        {
            get { return _iuserid; }
            set { _iuserid = value; }
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

        #region Static Properties
        /// <summary>
        ///  TableName
        /// </summary>	
        public static string sTableName
        {
            get { return "saUserRole"; }
        }
        #endregion

    }
}