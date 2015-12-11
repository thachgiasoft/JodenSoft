using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using myPortal.Model;
using myPortal.Foundation.Extensions;
using myPortal.Cache;
using System.Data;

namespace myPortal.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class saUser
    {
        private static readonly IsaUser dal = DALFactory.DataAccess.CreatesaUser();

        #region 单例

        private saUser() { }

        private static saUser _curr = null;
        private static object _obj = new object();
        public static saUser Current
        {
            get
            {
                if (_curr == null)
                {
                    lock (_obj)
                    {
                        if (_curr == null)
                            _curr = new saUser();
                    }
                }
                return _curr;
            }
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="newPwd"></param>
        public void ChangePassword(int uId, string newPwd)
        {
            if (newPwd.IsNullOrWhiteSpace())
                throw new ApplicationException("密码不能为空。");
            dal.ChangePassword(uId, newPwd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iIden"></param>
        /// <returns></returns>
        public saUserInfo GetUser(int iIden)
        {
            return dal.GetUser(iIden);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iIden"></param>
        public void DeleteUser(int iIden)
        {
            dal.Delete(iIden);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(saUserInfo user)
        {
            if (user == null)
                throw new ApplicationException("用户不能为空。");
            dal.Update(user);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sUserNo"></param>
        /// <param name="iCompanyId"></param>
        /// <returns></returns>
        public saUserInfo GetUser(string sUserNo)
        {
            if (sUserNo.IsNullOrWhiteSpace())
                throw new ApplicationException("用户名不能为空。");
            var obj = GetAllUser();
            return obj.FirstOrDefault(p => p.sUserNo.ToLower() == sUserNo.ToLower());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<saUserInfo> GetAllUser()
        {
            return dal.GetAllUser();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCompanyId"></param>
        /// <returns></returns>
        public IList<saUserInfo> GetAllUser(int iCompanyId)
        {
            return dal.GetAllUser(iCompanyId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(saUserInfo user)
        {
            dal.Create(user);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUserIds"></param>
        public void DeleteUser(string[] iUserIds)
        {
            dal.Delete(iUserIds);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable GetPageList(QueryUserParams param)
        {
            return dal.GetPageList(param);
        }
    }
}
