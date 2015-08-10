using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntity
{
    public class sysRole : Entity<sysRole>
    {
        protected override void OnInit()
        {
            base.OnInit();
            this.TableName = "sysRole";
            this.IdenGroup = "sysRole";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }
        public string Name
        {
            get { return base.GetFieldValue<string>(p => p.Name); }
            set { base.SetFieldValue(p => p.Name, value); }
        }
        public string Remark
        {
            get { return base.GetFieldValue<string>(p => p.Remark); }
            set { base.SetFieldValue(p => p.Remark, value); }
        }
        public bool IsSystem
        {
            get { return base.GetFieldValue<bool>(p => p.IsSystem); }
            set { base.SetFieldValue(p => p.IsSystem, value); }
        }
        public bool IsDeleted
        {
            get { return base.GetFieldValue<bool>(p => p.IsDeleted); }
            set { base.SetFieldValue(p => p.IsDeleted, value); }
        }
        public bool IsAdministrator
        {
            get { return base.GetFieldValue<bool>(p => p.IsAdministrator); }
            set { base.SetFieldValue(p => p.IsAdministrator, value); }
        }
       
    }
}
