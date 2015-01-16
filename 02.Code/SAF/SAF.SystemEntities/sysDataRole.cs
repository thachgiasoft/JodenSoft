using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysDataRole : Entity<sysDataRole>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysDataRole";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string Name
        {
            get { return base.GetFieldValue<string>(P => P.Name); }
            set { base.SetFieldValue(P => P.Name, value); }
        }

        public bool IsSystem
        {
            get { return base.GetFieldValue<bool>(P => P.IsSystem); }
            set { base.SetFieldValue(P => P.IsSystem, value); }
        }

        public bool IsDeleted
        {
            get { return base.GetFieldValue<bool>(P => P.IsDeleted); }
            set { base.SetFieldValue(P => P.IsDeleted, value); }
        }

        public string Remark
        {
            get { return base.GetFieldValue<string>(P => P.Remark); }
            set { base.SetFieldValue(P => P.Remark, value); }
        }

    }
}
