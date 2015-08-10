using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntity
{
    public class sysRoleMenu : Entity<sysRoleMenu>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysRoleMenu";
            this.IdenGroup = "sysRoleMenu";
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

       
    }
}
