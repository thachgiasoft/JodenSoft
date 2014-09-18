using SAF.EntityFramework;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.Security;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;

namespace SAF.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public class FormMembershipProvider : MembershipProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var users = new EntitySet<sysUser>();
            users.Query("select Iden, Password from sysUser with(nolock) where UserName=:UserName", username);
            if (users.Count <= 0 || !users.CurrentEntity.Password.Equals(oldPassword, StringComparison.InvariantCulture))
                return false;
            users.CurrentEntity.Password = newPassword;
            users.SaveChanges();
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="newPasswordQuestion"></param>
        /// <param name="newPasswordAnswer"></param>
        /// <returns></returns>
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="passwordQuestion"></param>
        /// <param name="passwordAnswer"></param>
        /// <param name="isApproved"></param>
        /// <param name="providerUserKey"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="deleteAllRelatedData"></param>
        /// <returns></returns>
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public override bool EnablePasswordReset
        {
            get { return true; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailToMatch"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usernameToMatch"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userIsOnline"></param>
        /// <returns></returns>
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerUserKey"></param>
        /// <param name="userIsOnline"></param>
        /// <returns></returns>
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public override int MaxInvalidPasswordAttempts
        {
            get { return 3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override int MinRequiredPasswordLength
        {
            get { return 1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override int PasswordAttemptWindow
        {
            get { return 0; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Hashed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override string PasswordStrengthRegularExpression
        {
            get { return string.Empty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override bool UnlockUser(string userName)
        {
            var users = new EntitySet<sysUser>();
            users.Query("select Iden,IsActive from sysUser with(nolock) where UserName=:UserName", userName);
            if (users.Count <= 0)
                return false;
            users.CurrentEntity.IsActive = true;
            users.SaveChanges();
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public override bool ValidateUser(string username, string password)
        {
            var users = new EntitySet<sysUser>();
            users.Query("select top 1 Iden,Password,IsActive,IsDeleted from sysUser with(nolock) where UserName=:UserName", username);
            if (users.Count <= 0
                || !users.CurrentEntity.Password.Equals(password, StringComparison.InvariantCulture)
                || !users.CurrentEntity.IsActive
                || users.CurrentEntity.IsDeleted)
                return false;
            return true;
        }
        /// <summary>
        /// 登录并设置Session的值
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Login(string username, string password, out string message)
        {
#if !DEBUG
            string code = RegInfoHelper.GetRegInfo();

            if (!RegisterHelper.Validate(code, Session.Current.ProductId))
            {
                if (fmRegister.ShowRegister() != DialogResult.OK)
                {
                    message = string.Format("系统尚未注册激活!{0}请联系系统供应商获取注册码.", Environment.NewLine);
                    return false;
                }
            }
            else
            {
                RegInfoHelper.UpdateLastTime();
            }
#endif
            const string sql = @"
select top 1 Iden, UserName, UserFullName, Password, Email, TelephoneNo, UserImage, IsActive, IsDeleted, IsSystem 
from sysUser with(nolock) 
where UserName=:UserName
";
            var users = new EntitySet<sysUser>();
            users.Query(sql, username);
            if (users.Count <= 0)
            {
                message = "用户不存在.";
                return false;
            }
            if (!users.CurrentEntity.Password.Equals(password, StringComparison.InvariantCulture))
            {
                message = "用户密码错误.";
                return false;
            }
            if (!users.CurrentEntity.IsActive)
            {
                message = "用户已被禁用.";
                return false;
            }
            if (users.CurrentEntity.IsDeleted)
            {
                message = "用户已被删除.";
                return false;
            }

            Session.Current.Assign(users.CurrentEntity);

            message = string.Empty;
            return true;
        }
    }
}
