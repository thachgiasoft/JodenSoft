using System;
using System.Data;
using System.Collections.Generic;
using myPortal.Model;

namespace myPortal.IDAL
{
    /// <summary>
    /// saUserRole接口层
    /// </summary>
    public interface IsaUserRole
    {
        /// <summary>
        /// 获取用户部门角色信息列表
        /// </summary>
        /// <param name="iOrgId">组织ID</param>
        /// <param name="iRoleId">角色ID</param>
        /// <param name="iUserId">用户ID</param>
        /// <returns></returns>
        IList<saUserRoleInfo> GetList(int iRoleId, int iUserId);
        /// <summary>
        /// 用户是否具有审批权限
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        /// <returns>有权限返回1，否则返回0</returns>
        int UserHasAuditRight(int iUserId);
    }
}