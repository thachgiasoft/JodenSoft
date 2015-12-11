using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using myPortal.Foundation.Extensions;

namespace myPortal.BLL
{
    public class IdenGenerator
    {
        private static readonly IIdenGenerator dal = DALFactory.DataAccess.CreateIdenGenerator();

        #region Singleton

        private static object lockObj = new object();
        private static IdenGenerator _curr = null;

        public static IdenGenerator Current
        {
            get
            {
                if (_curr == null)
                {
                    lock (lockObj)
                    {
                        if (_curr == null)
                        {
                            _curr = new IdenGenerator();
                        }
                    }
                }
                return _curr;
            }
        }

        private IdenGenerator() { }

        #endregion

        public int NewIden(string sGroupName)
        {
            if (sGroupName.IsNullOrWhiteSpace())
                throw new ApplicationException("sGroupName不能为空。");
            return dal.NewIden(sGroupName);
        }


    }
}
