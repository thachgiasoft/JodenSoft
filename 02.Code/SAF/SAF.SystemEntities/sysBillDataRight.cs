using SAF.EntityFramework;
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

            this.TableName = "sysBillDataRight";
            this.IdenGroup = "sysBillDataRight";
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

        public int ExtendRight2
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRight2); }
            set { base.SetFieldValue(P => P.ExtendRight2, value); }
        }

        public int ExtendRight3
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRight3); }
            set { base.SetFieldValue(P => P.ExtendRight3, value); }
        }

        public int ExtendRight4
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRight4); }
            set { base.SetFieldValue(P => P.ExtendRight4, value); }
        }

        public int ExtendRight5
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRight5); }
            set { base.SetFieldValue(P => P.ExtendRight5, value); }
        }

        public int ExtendRight6
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRight6); }
            set { base.SetFieldValue(P => P.ExtendRight6, value); }
        }

        public int ExtendRight7
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRight7); }
            set { base.SetFieldValue(P => P.ExtendRight7, value); }
        }

        public int ExtendRight8
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRight8); }
            set { base.SetFieldValue(P => P.ExtendRight8, value); }
        }

        public int ExtendRight9
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRight9); }
            set { base.SetFieldValue(P => P.ExtendRight9, value); }
        }

        public int ExtendRight10
        {
            get { return base.GetFieldValue<int>(P => P.ExtendRight10); }
            set { base.SetFieldValue(P => P.ExtendRight10, value); }
        }

        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(P => P.IsActive); }
            set { base.SetFieldValue(P => P.IsActive, value); }
        }

      
    }
}
