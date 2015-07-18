using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.CommonConfig.Entity
{
    public class sysCommonBillConfig : Entity<sysCommonBillConfig>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysCommonBillConfig";
            this.IdenGroup = "sysCommonBillConfig";
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

        public string Config
        {
            get { return base.GetFieldValue<string>(P => P.Config); }
            set { base.SetFieldValue(P => P.Config, value); }
        }

    }
}
