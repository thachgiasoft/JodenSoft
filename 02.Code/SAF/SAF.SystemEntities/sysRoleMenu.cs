using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysRoleMenu : Entity<sysRoleMenu>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysRoleMenu";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }


        public int RoleId
        {
            get { return base.GetFieldValue<int>(P => P.RoleId); }
            set { base.SetFieldValue(P => P.RoleId, value); }
        }

        public int MenuId
        {
            get { return base.GetFieldValue<int>(P => P.MenuId); }
            set { base.SetFieldValue(P => P.MenuId, value); }
        }

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
    }
}
