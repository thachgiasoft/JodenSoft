using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntity
{
    public class sysBusinessViewParam : Entity<sysBusinessViewParam>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysBusinessViewParam";
            this.IdenGroup = "sysBusinessViewParam";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public int BusinessViewId
        {
            get { return base.GetFieldValue<int>(P => P.BusinessViewId); }
            set { base.SetFieldValue(P => P.BusinessViewId, value); }
        }

        public string Name
        {
            get { return base.GetFieldValue<string>(P => P.Name); }
            set { base.SetFieldValue(P => P.Name, value); }
        }

        public string Description
        {
            get { return base.GetFieldValue<string>(P => P.Description); }
            set { base.SetFieldValue(P => P.Description, value); }
        }

        
    }
}
