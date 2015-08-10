using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAF.SystemEntity
{
    public class sysOrganization : Entity<sysOrganization>
    {
        protected override void OnInit()
        {
            base.OnInit();
            this.TableName = "sysOrganization";
            this.IdenGroup = "sysOrganization";
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
        public int ParentId
        {
            get { return base.GetFieldValue<int>(P => P.ParentId); }
            set { base.SetFieldValue(P => P.ParentId, value); }
        }

        public string Code
        {
            get { return base.GetFieldValue<string>(P => P.Code); }
            set { base.SetFieldValue(P => P.Code, value); }
        }

        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(p => p.IsActive); }
            set { base.SetFieldValue(p => p.IsActive, value); }
        }

        public string Remark
        {
            get { return base.GetFieldValue<string>(p => p.Remark); }
            set { base.SetFieldValue(p => p.Remark, value); }
        }

    }
}
