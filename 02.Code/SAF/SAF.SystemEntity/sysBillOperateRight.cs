using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntity
{
    public class sysBillOperateRight : Entity<sysBillOperateRight>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysBillOperateRight";
            this.IdenGroup = "sysBillOperateRight";
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

        public bool ExtendRight1
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRight1); }
            set { base.SetFieldValue(P => P.ExtendRight1, value); }
        }

        public bool ExtendRight2
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRight2); }
            set { base.SetFieldValue(P => P.ExtendRight2, value); }
        }

        public bool ExtendRight3
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRight3); }
            set { base.SetFieldValue(P => P.ExtendRight3, value); }
        }

        public bool ExtendRight4
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRight4); }
            set { base.SetFieldValue(P => P.ExtendRight4, value); }
        }

        public bool ExtendRight5
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRight5); }
            set { base.SetFieldValue(P => P.ExtendRight5, value); }
        }

        public bool ExtendRight6
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRight6); }
            set { base.SetFieldValue(P => P.ExtendRight6, value); }
        }

        public bool ExtendRight7
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRight7); }
            set { base.SetFieldValue(P => P.ExtendRight7, value); }
        }

        public bool ExtendRight8
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRight8); }
            set { base.SetFieldValue(P => P.ExtendRight8, value); }
        }

        public bool ExtendRight9
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRight9); }
            set { base.SetFieldValue(P => P.ExtendRight9, value); }
        }

        public bool ExtendRight10
        {
            get { return base.GetFieldValue<bool>(P => P.ExtendRight10); }
            set { base.SetFieldValue(P => P.ExtendRight10, value); }
        }

        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(P => P.IsActive); }
            set { base.SetFieldValue(P => P.IsActive, value); }
        } 

    }
}
