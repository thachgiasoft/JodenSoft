using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.EntityFramework;
using System.Data;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class sysUser : Entity<sysUser>
    {
        public sysUser()
        {
            this.DbTableName = "sysUser";
            this.PrimaryKey = "Iden";
        }
        /// <summary>
        /// 用户Iden
        /// </summary>
        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return base.GetFieldValue<string>(p => p.UserName); }
            set { base.SetFieldValue(p => p.UserName, value); }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserFullName
        {
            get { return base.GetFieldValue<string>(p => p.UserFullName); }
            set { base.SetFieldValue(p => p.UserFullName, value); }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return base.GetFieldValue<string>(p => p.Password); }
            set
            {
                base.SetFieldValue(p => p.Password, value);
            }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return base.GetFieldValue<string>(p => p.Email); }
            set { base.SetFieldValue(p => p.Email, value); }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string TelephoneNo
        {
            get { return base.GetFieldValue<string>(p => p.TelephoneNo); }
            set { base.SetFieldValue(p => p.TelephoneNo, value); }
        }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(p => p.IsActive); }
            set { base.SetFieldValue(p => p.IsActive, value); }
        }
        /// <summary>
        /// 删除标志
        /// </summary>
        public bool IsDeleted
        {
            get { return base.GetFieldValue<bool>(p => p.IsDeleted); }
            set { base.SetFieldValue(p => p.IsDeleted, value); }
        }
        /// <summary>
        /// 是否系统用户
        /// </summary>
        public bool IsSystem
        {
            get { return base.GetFieldValue<bool>(p => p.IsSystem); }
            set { base.SetFieldValue(p => p.IsSystem, value); }
        }
        /// <summary>
        /// 用户图片
        /// </summary>
        public byte[] UserImage
        {
            get { return base.GetFieldValue<byte[]>(p => p.UserImage, null); }
            set { base.SetFieldValue(p => p.UserImage, value); }
        }
        /// <summary>
        /// 用户签名图片
        /// </summary>
        public byte[] UserSignImage
        {
            get { return base.GetFieldValue<byte[]>(p => p.UserSignImage, null); }
            set { base.SetFieldValue(p => p.UserSignImage, value); }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public bool Remark
        {
            get { return base.GetFieldValue<bool>(p => p.Remark); }
            set { base.SetFieldValue(p => p.Remark, value); }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreatedBy
        {
            get { return base.GetFieldValue<int?>(p => p.CreatedBy, null); }
            set { base.SetFieldValue(p => p.CreatedBy, value); }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedOn
        {
            get { return base.GetFieldValue<DateTime?>(p => p.CreatedOn, null); }
            set { base.SetFieldValue(p => p.CreatedOn, value); }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public DateTime? ModifiedBy
        {
            get { return base.GetFieldValue<DateTime?>(p => p.ModifiedBy, null); }
            set { base.SetFieldValue(p => p.ModifiedBy, value); }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedOn
        {
            get { return base.GetFieldValue<DateTime?>(p => p.ModifiedOn, null); }
            set { base.SetFieldValue(p => p.ModifiedOn, value); }
        }
        /// <summary>
        /// 数据版本号
        /// </summary>
        public int VersionNumber
        {
            get { return base.GetFieldValue<int>(p => p.VersionNumber, 0); }
        }
    }
}
