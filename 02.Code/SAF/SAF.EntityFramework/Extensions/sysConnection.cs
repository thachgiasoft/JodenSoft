using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 数据连接信息
    /// </summary>
    public class sysConnection : Entity<sysConnection>
    {
        public sysConnection()
        {
            DbTableName = "sysConnection";
            PrimaryKeyName = "Iden";
        }
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Iden
        {
            get { return base.GetFieldValue<Guid>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }
        /// <summary>
        /// 数据连接名称
        /// </summary>
        public string Name
        {
            get { return base.GetFieldValue<string>(p => p.Name); }
            set { base.SetFieldValue(p => p.Name, value); }
        }
        /// <summary>
        /// 数据连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return base.GetFieldValue<string>(p => p.ConnectionString); }
            set { base.SetFieldValue(p => p.ConnectionString, value); }
        }
        /// <summary>
        /// 数据驱动名称
        /// </summary>
        public string ProviderName
        {
            get { return base.GetFieldValue<string>(p => p.ProviderName); }
            set { base.SetFieldValue(p => p.ProviderName, value); }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(p => p.IsActive); }
            set { base.SetFieldValue(p => p.IsActive, value); }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return base.GetFieldValue<string>(p => p.Remark); }
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
