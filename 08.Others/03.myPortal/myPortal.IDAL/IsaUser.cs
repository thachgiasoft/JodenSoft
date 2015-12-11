using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.Model;
using System.Data;

namespace myPortal.IDAL
{
    /// <summary>
    /// saUser接口层
    /// </summary>
    public interface IsaUser
    {
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        /// <param name="newPwd">新密码</param>
        void ChangePassword(int iUserId, string newPwd);
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        /// <returns>用户信息</returns>
        saUserInfo GetUser(int iUserId);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        void Delete(int iUserId);
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户信息</param>
        void Update(saUserInfo user);
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns>用户列表</returns>
        IList<saUserInfo> GetAllUser();
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="iCompanyId">公司ID</param>
        /// <returns>用户列表</returns>
        IList<saUserInfo> GetAllUser(int iCompanyId);
        /// <summary>
        /// 新建用户
        /// </summary>
        /// <param name="user">用户信息</param>
        void Create(saUserInfo user);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="iUserIds">用户ID数组</param>
        void Delete(string[] iUserIds);

        /// <summary>
        /// 查询用户的分页数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DataTable GetPageList(QueryUserParams param);
    }
}
