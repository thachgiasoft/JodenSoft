using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysBillOperateRight : Entity<sysBillOperateRight>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysBillOperateRight";
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

        public int DataRoleId
        {
            get { return base.GetFieldValue<int>(P => P.DataRoleId); }
            set { base.SetFieldValue(P => P.DataRoleId, value); }
        }

        public bool AddNew
        {
            get { return base.GetFieldValue<bool>(P => P.AddNew); }
            set { base.SetFieldValue(P => P.AddNew, value); }
        }

        public bool ExtendRigth1
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRigth1); }
            set { base.SetFieldValue(P => P.ExtendRigth1, value); }
        }

        public bool ExtendRigth2
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRigth2); }
            set { base.SetFieldValue(P => P.ExtendRigth2, value); }
        }

        public bool ExtendRigth3
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRigth3); }
            set { base.SetFieldValue(P => P.ExtendRigth3, value); }
        }

        public bool ExtendRigth4
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRigth4); }
            set { base.SetFieldValue(P => P.ExtendRigth4, value); }
        }

        public bool ExtendRigth5
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRigth5); }
            set { base.SetFieldValue(P => P.ExtendRigth5, value); }
        }

        public bool ExtendRigth6
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRigth6); }
            set { base.SetFieldValue(P => P.ExtendRigth6, value); }
        }

        public bool ExtendRigth7
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRigth7); }
            set { base.SetFieldValue(P => P.ExtendRigth7, value); }
        }

        public bool ExtendRigth8
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRigth8); }
            set { base.SetFieldValue(P => P.ExtendRigth8, value); }
        }

        public bool ExtendRigth9
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRigth9); }
            set { base.SetFieldValue(P => P.ExtendRigth9, value); }
        }

        public bool ExtendRigth10
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRigth10); }
            set { base.SetFieldValue(P => P.ExtendRigth10, value); }
        }

        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(P => P.IsActive); }
            set { base.SetFieldValue(P => P.IsActive, value); }
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
        public VersionNumber VersionNumber
        {
            get { return new VersionNumber(base.GetFieldValue<byte[]>(p => p.VersionNumber)); }
        }

        #endregion
    }
}
