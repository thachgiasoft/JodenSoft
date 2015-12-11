using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Data;
using System.Security.Cryptography;
using System.Configuration.Provider;
using System.Configuration;
using System.Collections.Specialized;
using System.Diagnostics;
using myPortal.Model;
using myPortal.Foundation;

namespace myPortal.BLL.Permission
{
    public class myMembershipProvider : MembershipProvider
    {
        private string appName = string.Empty;

        public override string ApplicationName
        {
            get
            {
                return appName;
            }
            set
            {
                appName = value;
            }
        }

        public override bool EnablePasswordReset
        {
            get { return true; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 10; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 10; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Hashed; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return string.Empty; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "cttMembershipProvider";

            base.Initialize(name, config);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public override bool ChangePassword(string uId, string oldPwd, string newPwd)
        {
            if (!ValidateUser(uId, oldPwd))
                return false;

            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(uId, newPwd, true);

            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("用户取消修改。");

            saUser.Current.ChangePassword(int.Parse(uId), EncodePassword(newPwd));
            return true;
        }

        public MembershipUser CreateUser(saUserInfo user, out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args =
                new ValidatePasswordEventArgs(user.iIden.ToString(), user.sPassword, true);

            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }
            saUserInfo tempuser = saUser.Current.GetUser(user.sUserNo);

            if (tempuser == null)
            {
                user.sPassword = EncodePassword(user.sPassword);
                try
                {
                    saUser.Current.CreateUser(user);
                    status = MembershipCreateStatus.Success;
                }
                catch
                {
                    status = MembershipCreateStatus.UserRejected;
                    throw;
                }
                return user;
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }

            return null;
        }

        public override bool DeleteUser(string uId, bool deleteAllRelatedData)
        {
            saUser.Current.DeleteUser(int.Parse(uId));
            return true;

        }

        /// <summary>
        /// 获取分页用户信息
        /// </summary>
        /// <param name="pageIndex">页码索引</param>
        /// <param name="pageSize">每页数据行数</param>
        /// <param name="totalRecords">始终返回0</param>
        /// <returns></returns>
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            totalRecords = 0;

            //using (IDataReader reader = DataBaseProvider.GetInstance().GetPagedUsers(pageIndex, pageSize, out totalRecords))
            //{
            //    while (reader.Read())
            //    {
            //        NGMembershipUser u = GetUserFromReader(reader);

            //        //整页传出用户时清空密码
            //        u.Password = string.Empty;
            //        users.Create(u);
            //    }

            //    reader.Close();
            //}

            return users;
        }

        public override int GetNumberOfUsersOnline()
        {
            //return DataBaseProvider.GetInstance().GetNumberOfUsersOnline(DateTime.Now.AddMinutes(-Membership.UserIsOnlineTimeWindow));
            return 1;
        }

        public saUserInfo GetUser(int iIden)
        {
            return saUser.Current.GetUser(iIden);
        }

        public override MembershipUser GetUser(string iIden, bool userIsOnline)
        {
            MembershipUser user = GetUser(int.Parse(iIden));

            if (user != null && userIsOnline)
            {
                if (user.LastActivityDate.AddMinutes(Membership.UserIsOnlineTimeWindow) < DateTime.Now)
                    return null;
            }
            return user;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="iIden"></param>
        /// <returns></returns>
        public string ResetPassword(string iIden)
        {
            if (!EnablePasswordReset)
            {
                throw new NotSupportedException("不允许重罡密码。");
            }
            string newPassword = string.Empty;
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(iIden, newPassword, true);

            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("重置被取消。");

            bool userExisits = true;
            bool isApproved = true;

            var user = saUser.Current.GetUser(int.Parse(iIden));
            if (user != null)
            {
                isApproved = true;
                newPassword = user.sUserNo;
            }
            else
                userExisits = false;

            if (!userExisits)
                throw new MembershipPasswordException("用户不存在");

            if (!isApproved)
                throw new MembershipPasswordException("被删除的用户不能重置。");

            saUser.Current.ChangePassword(int.Parse(iIden), EncodePassword(newPassword));
            return newPassword;
        }

        private string EncodePassword(string password)
        {
            string encodedPassword = password;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword =
                      Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    MD5 hash = MD5.Create();
                    encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    break;
                default:
                    throw new ProviderException("不支持的加密格式。");
            }

            return encodedPassword;
        }

        private string UnEncodePassword(string encodedPassword)
        {
            string password = encodedPassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    password =
                      Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("不支持哈希加密。");
                default:
                    throw new ProviderException("不支持加密方式。");
            }

            return password;
        }

        //
        // HexToByte
        //   Converts a hexadecimal string to a byte array. Used to convert encryption
        // key values from the configuration.
        //
        private byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public override bool UnlockUser(string iIden)
        {
            saUser.Current.DeleteUser(int.Parse(iIden));
            return true;
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="user"></param>
        public override void UpdateUser(MembershipUser user)
        {
            saUserInfo mu = user as saUserInfo;
            saUser.Current.UpdateUser(mu);
        }

        public void ChangePwd(MembershipUser user)
        {
            saUserInfo mu = user as saUserInfo;

            mu.sPassword = EncodePassword(mu.sPassword);
            saUser.Current.ChangePassword(mu.iIden, mu.sPassword);
        }

        public override bool ValidateUser(string uId, string password)
        {
            bool isValid = false;

            saUserInfo user = GetUser(int.Parse(uId));

            if (user != null)
            {
                if (CheckPassword(password, user.sPassword))
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        private bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = dbpassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(dbpassword);
                    break;
                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePassword(password);
                    break;
                default:
                    break;
            }

            if (pass1.Equals(pass2))
            {
                return true;
            }

            return false;
        }

        public saUserInfo GetUser(string sUserNo)
        {
            return saUser.Current.GetUser(sUserNo);
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }
    }
}
