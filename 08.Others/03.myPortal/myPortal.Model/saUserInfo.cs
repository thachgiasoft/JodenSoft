using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace myPortal.Model
{
    /// <summary>
    /// saUser
    /// </summary>	
    public partial class saUserInfo
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
        private string _suserno;
        /// <summary>
        /// sUserNo
        /// </summary>	
        public string sUserNo
        {
            get { return _suserno; }
            set { _suserno = value; }
        }
        private string _susername;
        /// <summary>
        /// sUserName
        /// </summary>	
        public string sUserName
        {
            get { return _susername; }
            set { _susername = value; }
        }
        private string _spassword;
        /// <summary>
        /// sPassword
        /// </summary>	
        public string sPassword
        {
            get { return _spassword; }
            set { _spassword = value; }
        }
        private string _semail;
        /// <summary>
        /// sEmail
        /// </summary>	
        public string sEmail
        {
            get { return _semail; }
            set { _semail = value; }
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

        private bool _bUsable;
        /// <summary>
        /// bUsable
        /// </summary>	
        public bool bUsable
        {
            get { return _bUsable; }
            set { _bUsable = value; }
        }

        #region Static Properties
        /// <summary>
        ///  TableName
        /// </summary>	
        public static string sTableName
        {
            get { return "saUser"; }
        }
        #endregion


        public bool bIsSystem { get; set; }
    }
}