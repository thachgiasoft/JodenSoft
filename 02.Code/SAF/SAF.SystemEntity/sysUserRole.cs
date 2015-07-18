using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysUserRole : Entity<sysUserRole>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysUserRole";
            this.IdenGroup = "sysUserRole";
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

        public int RoleId
        {
            get { return base.GetFieldValue<int>(P => P.RoleId); }
            set { base.SetFieldValue(P => P.RoleId, value); }
        }
      
    }
}
