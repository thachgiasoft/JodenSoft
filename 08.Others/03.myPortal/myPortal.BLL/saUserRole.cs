using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;

namespace myPortal.BLL
{
    public class saUserRole
    {
        private static readonly IsaUserRole dal = DALFactory.DataAccess.CreatesaUserRole();

        #region 单例

        private saUserRole() { }

        private static saUserRole _curr = null;
        private static object _obj = new object();
        public static saUserRole Current
        {
            get
            {
                if (_curr == null)
                {
                    lock (_obj)
                    {
                        if (_curr == null)
                            _curr = new saUserRole();
                    }
                }
                return _curr;
            }
        }

        #endregion

        public IList<Model.saUserRoleInfo> GetList( int iRoleId, int iUserId)
        {
            return dal.GetList(iRoleId, iUserId);
        }

        public int UserHasAuditRight(int iUserId)
        {
            return dal.UserHasAuditRight(iUserId);
        }
    }
}
