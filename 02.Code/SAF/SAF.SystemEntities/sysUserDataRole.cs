using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysUserDataRole : Entity<sysUserDataRole>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysUserDataRole";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public int UserId
        {
            get { return base.GetFieldValue<int>(P => P.UserId); }
            set { base.SetFieldValue(P => P.UserId, value); }
        }

        public int OrganizationId
        {
            get { return base.GetFieldValue<int>(P => P.OrganizationId); }
            set { base.SetFieldValue(P => P.OrganizationId, value); }
        }

        public int DataRoleId
        {
            get { return base.GetFieldValue<int>(P => P.DataRoleId); }
            set { base.SetFieldValue(P => P.DataRoleId, value); }
        }

    }
}
