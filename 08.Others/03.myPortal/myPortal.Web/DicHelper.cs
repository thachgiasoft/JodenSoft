using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.Foundation.Extensions;
using myPortal.Cache;
using myPortal.BLL;
using myPortal.Model;

namespace myPortal.Web
{
    /// <summary>
    /// 字典帮助类
    /// </summary>
    public static class DicHelper
    {
        /// <summary>
        /// 返回角色名称
        /// </summary>
        /// <param name="sIden"></param>
        /// <returns></returns>
        public static string CalcRole(object sIden)
        {
            int iIden = 0;
            if (!int.TryParse(sIden.ToStringEx(), out iIden))
                return sIden.ToStringEx();
            IList<saRoleInfo> list = saRole.Current.GetAllRole();
            saRoleInfo info = list.FirstOrDefault(p => p.iIden == iIden);
            if (info != null)
                return info.sName;
            else
                return sIden.ToStringEx();
        }
        /// <summary>
        /// 返回用户名称
        /// </summary>
        /// <param name="sIden"></param>
        /// <returns></returns>
        public static string CalcUser(object sIden)
        {
            int iIden = 0;
            if (!int.TryParse(sIden.ToStringEx(), out iIden))
                return sIden.ToStringEx();
            IList<saUserInfo> list = saUser.Current.GetAllUser();
            saUserInfo info = list.FirstOrDefault(p => p.iIden == iIden);
            if (info != null)
                return info.sUserName;
            else
                return sIden.ToStringEx();
        }
        /// <summary>
        /// 计算用户状态
        /// </summary>
        /// <param name="sIden"></param>
        /// <returns></returns>
        public static string CalcUserStatus(object sIden)
        {
            int iIden = 0;
            if (!int.TryParse(sIden.ToStringEx(), out iIden))
                return sIden.ToStringEx();
            IList<saUserInfo> list = saUser.Current.GetAllUser();
            saUserInfo info = list.FirstOrDefault(p => p.iIden == iIden);
            if (info != null)
                return info.bUsable ? "" : " <span style='color: red;'>(已禁用)</span>";
            else
                return string.Empty;
        }

        /// <summary>
        /// 返回用户No
        /// </summary>
        /// <param name="sIden"></param>
        /// <returns></returns>
        public static string CalcUserNo(object iUserId)
        {
            int iIden = 0;
            if (!int.TryParse(iUserId.ToStringEx(), out iIden))
                return iUserId.ToStringEx();
            IList<saUserInfo> list = saUser.Current.GetAllUser();
            saUserInfo info = list.FirstOrDefault(p => p.iIden == iIden);
            if (info != null)
                return info.sUserNo;
            else
                return iUserId.ToStringEx();
        }
 
    }
}
