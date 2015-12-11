using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.Model;

namespace myPortal.IDAL
{
    /// <summary>
    /// saRole接口层
    /// </summary>
    public interface IsaRole
    {
        /// <summary>
        /// 获取所有角色信息
        /// </summary>
        /// <returns>角色信息列表</returns>
        IList<saRoleInfo> GetAllRole();
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="iRoleIds">角色ID数组</param>
        void Delete(string[] iRoleIds);
        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <param name="iMenuIds">角色所拥有的菜单列表</param>
        void Update(saRoleInfo role, string iMenuIds);
        /// <summary>
        /// 新建角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <param name="iMenuIds">角色所拥有的菜单列表</param>
        void Create(saRoleInfo role, string iMenuIds);
        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="iRoleId">角色ID</param>
        /// <returns>菜单列表</returns>
        IList<saMenuInfo> GetMenuByRoleId(int iRoleId);

        /// <summary>
        /// 获取上级组织所有的角色
        /// </summary>
        /// <param name="iOrganizationId">组织ID</param>
        /// <returns>角色列表</returns>
        IList<saRoleInfo> GetParentOrgRole();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IList<saRoleInfo> GetPageList(QueryRoleParams param);
    }
}
