using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.Model;

namespace myPortal.IDAL
{
    /// <summary>
    /// saMenu接口层
    /// </summary>
    public interface IsaMenu
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        /// <param name="iOrganizationId">组织ID</param>
        /// <returns>菜单列表</returns>
        IList<saMenuInfo> GetMenus(int iUserId);
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns>菜单列表</returns>
        IList<saMenuInfo> GetAllMenus();
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="ids">菜单ID数组</param>
        void Delete(string[] ids);
        /// <summary>
        /// 获取子菜单项
        /// </summary>
        /// <param name="iMenuId">菜单ID</param>
        /// <returns>子菜单列表</returns>
        IList<saMenuInfo> GetChildMenus(int iMenuId);
        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <param name="iMenuId">菜单ID</param>
        /// <returns>菜单信息</returns>
        saMenuInfo GetMenu(int iMenuId);
        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="menu">菜单实体</param>
        void Update(saMenuInfo menu);
        /// <summary>
        /// 新建菜单
        /// </summary>
        /// <param name="menu">菜单实体</param>
        void Create(saMenuInfo menu);
    }
}
