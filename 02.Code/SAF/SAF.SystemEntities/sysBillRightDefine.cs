using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysBillRightDefine : Entity<sysBillRightDefine>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysBillRightDefine";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public int BillTypeId
        {
            get { return base.GetFieldValue<int>(P => P.BillTypeId); }
            set { base.SetFieldValue(P => P.BillTypeId, value); }
        }

        public string FieldName
        {
            get { return base.GetFieldValue<string>(P => P.FieldName); }
            set { base.SetFieldValue(P => P.FieldName, value); }
        }

        public string Caption
        {
            get { return base.GetFieldValue<string>(P => P.Caption); }
            set { base.SetFieldValue(P => P.Caption, value); }
        }

        public string Remark
        {
            get { return base.GetFieldValue<string>(P => P.Remark); }
            set { base.SetFieldValue(P => P.Remark, value); }
        }

        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(P => P.IsActive); }
            set { base.SetFieldValue(P => P.IsActive, value); }
        }

        public bool IsSystem
        {
            get { return base.GetFieldValue<bool>(P => P.IsSystem); }
            set { base.SetFieldValue(P => P.IsSystem, value); }
        }

        #region 创建人&创建时间&修改人&修改时间&版本号

        public int? CreatedBy
        {
            get { return base.GetFieldValue<int?>(p => p.CreatedBy, null); }
            set { base.SetFieldValue(p => p.CreatedBy, value); }
        }
        public DateTime? CreatedOn
        {
            get { return base.GetFieldValue<DateTime?>(p => p.CreatedOn, null); }
            set { base.SetFieldValue(p => p.CreatedOn, value); }
        }

        public int? ModifiedBy
        {
            get { return base.GetFieldValue<int?>(p => p.ModifiedBy, null); }
            set { base.SetFieldValue(p => p.ModifiedBy, value); }
        }
        public DateTime? ModifiedOn
        {
            get { return base.GetFieldValue<DateTime?>(p => p.ModifiedOn, null); }
            set { base.SetFieldValue(p => p.ModifiedOn, value); }
        }
        public int VersionNumber
        {
            get { return base.GetFieldValue<int>(p => p.VersionNumber, 0); }
        }

        #endregion
    }
}
