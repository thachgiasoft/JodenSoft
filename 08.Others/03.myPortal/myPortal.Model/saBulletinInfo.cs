using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace myPortal.Model
{
    /// <summary>
    /// saBulletin
    /// </summary>	
    public class saBulletinInfo
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
        private string _stitle;
        /// <summary>
        /// sTitle
        /// </summary>	
        public string sTitle
        {
            get { return _stitle; }
            set { _stitle = value; }
        }
        private string _scontent;
        /// <summary>
        /// sContent
        /// </summary>	
        public string sContent
        {
            get { return _scontent; }
            set { _scontent = value; }
        }

        private DateTime _tstarttime;
        /// <summary>
        /// tStartTime
        /// </summary>	
        public DateTime tStartTime
        {
            get { return _tstarttime; }
            set { _tstarttime = value; }
        }
        private DateTime _tendtime;
        /// <summary>
        /// tEndTime
        /// </summary>	
        public DateTime tEndTime
        {
            get { return _tendtime; }
            set { _tendtime = value; }
        }
        private int _ibulletintype;
        /// <summary>
        /// iBulletinType
        /// </summary>	
        public int iBulletinType
        {
            get { return _ibulletintype; }
            set { _ibulletintype = value; }
        }
        private int _ibulletinlevel;
        /// <summary>
        /// iBulletinLevel
        /// </summary>	
        public int iBulletinLevel
        {
            get { return _ibulletinlevel; }
            set { _ibulletinlevel = value; }
        }
        private DateTime _tcreatetime;
        /// <summary>
        /// tCreateTime
        /// </summary>	
        public DateTime tCreateTime
        {
            get { return _tcreatetime; }
            set { _tcreatetime = value; }
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
        private DateTime _tupdatetime;
        /// <summary>
        /// tUpdateTime
        /// </summary>	
        public DateTime tUpdateTime
        {
            get { return _tupdatetime; }
            set { _tupdatetime = value; }
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
        #region Static Properties
        /// <summary>
        ///  TableName
        /// </summary>	
        public static string sTableName
        {
            get { return "saBulletin"; }
        }
        #endregion

    }
}