using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 系统级会话信息
    /// </summary>
    [Serializable]
    public static class Session
    {
        public static UserInfo UserInfo { get; private set; }
        public static MachineInfo MachineInfo { get; private set; }

        private static string _ProductCode = string.Empty;
        public static string ProductCode
        {
            get
            {
                if (_ProductCode.IsEmpty())
                    _ProductCode = MD5Helper.Hash("{0}-[{1}]".FormatEx(MachineInfo.MachineCode, AssemblyInfoHelper.ProductName), true);
                return _ProductCode;
            }
        }

        static Session()
        {
            UserInfo = new UserInfo();
            MachineInfo = new MachineInfo();
        }

        public static bool IsInvalid
        {
            get
            {
                return UserInfo == null || UserInfo.UserId == -1;
            }
        }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        #region properties

        /// <summary>
        /// 用户Iden
        /// </summary>
        public int UserId { get; private set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; private set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserFullName { get; private set; }
        /// <summary>
        /// 用户邮件
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string TelephoneNo { get; private set; }
        /// <summary>
        /// 用户图片
        /// </summary>
        public Image UserImage { get; private set; }
        /// <summary>
        /// 用户签名图片
        /// </summary>
        public Image UserSignImage { get; private set; }

        #endregion

        public UserInfo()
        {
            this.Clear();
        }

        public void Assign(IEntityBase entity)
        {
            if (entity == null)
            {
                this.Clear();
                return;
            }
            if (entity.FieldIsExists("Iden"))
                this.UserId = entity.GetFieldValue<int>("Iden", -1);

            if (entity.FieldIsExists("UserName"))
                this.UserName = entity.GetFieldValue<string>("UserName", string.Empty);

            if (entity.FieldIsExists("Password"))
                this.Password = entity.GetFieldValue<string>("Password", string.Empty);

            if (entity.FieldIsExists("UserFullName"))
                this.UserFullName = entity.GetFieldValue<string>("UserFullName", string.Empty);

            if (entity.FieldIsExists("Email"))
                this.Email = entity.GetFieldValue<string>("Email", string.Empty);

            if (entity.FieldIsExists("TelephoneNo"))
                this.TelephoneNo = entity.GetFieldValue<string>("TelephoneNo", string.Empty);

            this.UserImage = null;
            if (entity.FieldIsExists("UserImage") && !entity.FieldIsNull("UserImage"))
                this.UserImage = new Bitmap(new MemoryStream(entity.GetFieldValue<byte[]>("UserImage")));

            this.UserSignImage = null;
            if (entity.FieldIsExists("UserSignImage") && !entity.FieldIsNull("UserSignImage"))
                this.UserSignImage = new Bitmap(new MemoryStream(entity.GetFieldValue<byte[]>("UserSignImage")));

        }

        public void Clear()
        {
            this.UserId = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.UserFullName = string.Empty;
            this.Email = string.Empty;
            this.TelephoneNo = string.Empty;
            this.UserImage = null;
            this.UserSignImage = null;
        }

        public void RetriveImage()
        {
            var es = new EntitySet<sysUser>();
            es.Query("SELECT Iden,UserImage,UserSignImage FROM dbo.sysUser where Iden=:Iden", this.UserId);
            if (es.Count <= 0)
                Clear();
            else
                this.Assign(es[0]);
        }

        public void Retrive()
        {
            var es = new EntitySet<sysUser>();
            es.Query("SELECT * FROM dbo.sysUser where Iden=:Iden", this.UserId);
            if (es.Count <= 0)
                Clear();
            else
                this.Assign(es[0]);
        }
    }
}
