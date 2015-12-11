using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using myPortal.Model;

namespace myPortal.BLL
{
    public class saMenu
    {
        private static readonly IsaMenu dal = DALFactory.DataAccess.CreatesaMenu();

        #region 单例

        private saMenu() { }

        private static saMenu _curr = null;
        private static object _obj = new object();
        public static saMenu Current
        {
            get
            {
                if (_curr == null)
                {
                    lock (_obj)
                    {
                        if (_curr == null)
                            _curr = new saMenu();
                    }
                }
                return _curr;
            }
        }

        #endregion

        public IList<saMenuInfo> GetMenus(int iUserId)
        {
            return dal.GetMenus(iUserId);
        }

        public IList<saMenuInfo> GetAllMenus()
        {
            return dal.GetAllMenus();
        }

        public void DeleteMenus(string[] ids)
        {
            dal.Delete(ids);
        }

        public IList<saMenuInfo> GetChildMenus(int iMenuId)
        {
            return dal.GetChildMenus(iMenuId);
        }

        public saMenuInfo GetMenu(int iMenuId)
        {
            return dal.GetMenu(iMenuId);
        }

        public void UpdateMenu(saMenuInfo menu)
        {
            dal.Update(menu);
        }

        public void CreateMenu(saMenuInfo menu)
        {
            dal.Create(menu);
        }
    }
}
