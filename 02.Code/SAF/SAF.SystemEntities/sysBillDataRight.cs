﻿using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysBillDataRight : Entity<sysBillDataRight>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysBillDataRight";
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

        public int QueryRight
        {
            get { return base.GetFieldValue<int>(P => P.QueryRight); }
            set { base.SetFieldValue(P => P.QueryRight, value); }
        }

        public int UpdateRight
        {
            get { return base.GetFieldValue<int>(P => P.UpdateRight); }
            set { base.SetFieldValue(P => P.UpdateRight, value); }
        }

        public int DeleteRight
        {
            get { return base.GetFieldValue<int>(P => P.DeleteRight); }
            set { base.SetFieldValue(P => P.DeleteRight, value); }
        }

        public int AuditRight
        {
            get { return base.GetFieldValue<int>(P => P.AuditRight); }
            set { base.SetFieldValue(P => P.AuditRight, value); }
        }

        public int PrintRight
        {
            get { return base.GetFieldValue<int>(P => P.PrintRight); }
            set { base.SetFieldValue(P => P.PrintRight, value); }
        }

        public int ExtendRight1
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRight1); }
            set { base.SetFieldValue(P => P.ExtendRight1, value); }
        }

        public int ExtendRigth2
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRigth2); }
            set { base.SetFieldValue(P => P.ExtendRigth2, value); }
        }

        public int ExtendRigth3
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRigth3); }
            set { base.SetFieldValue(P => P.ExtendRigth3, value); }
        }

        public int ExtendRigth4
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRigth4); }
            set { base.SetFieldValue(P => P.ExtendRigth4, value); }
        }

        public int ExtendRigth5
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRigth5); }
            set { base.SetFieldValue(P => P.ExtendRigth5, value); }
        }

        public int ExtendRigth6
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRigth6); }
            set { base.SetFieldValue(P => P.ExtendRigth6, value); }
        }

        public int ExtendRigth7
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRigth7); }
            set { base.SetFieldValue(P => P.ExtendRigth7, value); }
        }

        public int ExtendRigth8
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRigth8); }
            set { base.SetFieldValue(P => P.ExtendRigth8, value); }
        }

        public int ExtendRigth9
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRigth9); }
            set { base.SetFieldValue(P => P.ExtendRigth9, value); }
        }

        public int ExtendRigth10
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRigth10); }
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
        public int VersionNumber
        {
            get { return base.GetFieldValue<int>(p => p.VersionNumber, 0); }
        }

        #endregion
    }
}
