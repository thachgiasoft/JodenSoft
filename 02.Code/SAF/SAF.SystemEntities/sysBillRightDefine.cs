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

        public string RightType
        {
            get { return base.GetFieldValue<string>(P => P.RightType); }
            set { base.SetFieldValue(P => P.RightType, value); }
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

        
    }
}
