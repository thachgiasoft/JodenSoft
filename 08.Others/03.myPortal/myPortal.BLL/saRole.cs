using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using myPortal.Model;
using myPortal.Cache;

namespace myPortal.BLL
{
    public class saRole
    {
        private static readonly IsaRole dal = DALFactory.DataAccess.CreatesaRole();

        #region 单例

        private saRole() { }

        private static saRole _curr = null;
        private static object _obj = new object();
        public static saRole Current
        {
            get
            {
                if (_curr == null)
                {
                    lock (_obj)
                    {
                        if (_curr == null)
                            _curr = new saRole();
                    }
                }
                return _curr;
            }
        }

        #endregion

        public IList<saRoleInfo> GetAllRole()
        {
            return dal.GetAllRole( );
        }

        public IList<saRoleInfo> GetParentOrgRole()
        {
            return dal.GetParentOrgRole();
        }

        public void DeleteRole(string[] iRoleIds)
        {
            dal.Delete(iRoleIds);
            CacheService.Current.RemoveObject(CacheKey.DicRole);
        }

        public saRoleInfo GetRole(int iRoleId)
        {
            var obj = this.GetAllRole();
            return obj.FirstOrDefault(p => p.iIden == iRoleId);
        }

        public void UpdateRole(saRoleInfo role, string iMenuIds)
        {
            dal.Update(role, iMenuIds);
            CacheService.Current.RemoveObject(CacheKey.DicRole);
        }

        public void CreateRole(saRoleInfo role, string iMenuIds)
        {
            dal.Create(role, iMenuIds);
            CacheService.Current.RemoveObject(CacheKey.DicRole);
        }

        public IList<saMenuInfo> GetMenuByRoleId(int iRoleId)
        {
            return dal.GetMenuByRoleId(iRoleId);
        }

        public IList<saRoleInfo> GetPageList(QueryRoleParams param)
        {
            return dal.GetPageList(param);
        }
    }
}
