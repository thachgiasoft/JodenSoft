using SAF.Foundation;
using SAF.Foundation.ComponentModel;
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
    public class Session
    {
        #region Machine Properties
        /// <summary>
        /// 机器名
        /// </summary>
        public string MachineName { get; private set; }
        /// <summary>
        /// 机器用户
        /// </summary>
        public string MachineUser { get; private set; }
        /// <summary>
        /// 机器码
        /// </summary>
        public string MachineCode { get; private set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public string ProductId { get; private set; }
        #endregion

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string Encrypt(string value)
        {
            string retValue = string.Empty;
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] retByte = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
                for (int i = 0; i < retByte.Length; i++)
                {
                    retValue += retByte[i].ToString("X").PadLeft(2, '0');
                }
                return new Guid(retValue).ToString("D").ToUpper();
            }
        }

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

        #endregion

        private Session()
        {
            this.MachineName = Environment.MachineName;
            this.MachineUser = Environment.UserName;
            this.MachineCode = HardwareInfo.GetHardwareId();
            this.ProductId = Encrypt("{0}-{1}".FormatEx(this.MachineCode, AssemblyInfoHelper.ProductName));
        }

        #region Session Singleton

        private static object _lockObj = new object();
        private static Session _Session = null;
        public static Session Current
        {
            get
            {
                if (_Session == null)
                {
                    lock (_lockObj)
                    {
                        if (_Session == null)
                            _Session = new Session();
                    }
                }
                return _Session;
            }
        }
        #endregion

        public void Assign(IEntityBase entity)
        {
            if (entity == null)
            {
                this.Clear();
                return;
            }
            if (entity.FieldIsExists("Iden") && !entity.FieldIsNull("Iden"))
                this.UserId = entity.GetFieldValue<int>("Iden");

            if (entity.FieldIsExists("UserName") && !entity.FieldIsNull("UserName"))
                this.UserName = entity.GetFieldValue<string>("UserName");

            if (entity.FieldIsExists("Password") && !entity.FieldIsNull("Password"))
                this.Password = entity.GetFieldValue<string>("Password");

            if (entity.FieldIsExists("UserFullName") && !entity.FieldIsNull("UserFullName"))
                this.UserFullName = entity.GetFieldValue<string>("UserFullName");

            if (entity.FieldIsExists("Email") && !entity.FieldIsNull("Email"))
                this.Email = entity.GetFieldValue<string>("Email");

            if (entity.FieldIsExists("TelephoneNo") && !entity.FieldIsNull("TelephoneNo"))
                this.TelephoneNo = entity.GetFieldValue<string>("TelephoneNo");

            if (entity.FieldIsExists("UserImage") && !entity.FieldIsNull("UserImage"))
            {
                var bytes = entity.GetFieldValue<byte[]>("UserImage");
                this.UserImage = new Bitmap(new MemoryStream(bytes));
            }
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
        }

        public bool IsInvalid
        {
            get
            {
                return this.UserId == -1;
            }
        }
    }
}
