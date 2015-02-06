using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.CommonBill.Entities
{
    public class sysCommonBillConfig : Entity<sysCommonBillConfig>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysCommonBillConfig";
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

        public CommonBillLayout Layout
        {
            get { return (CommonBillLayout)base.GetFieldValue<int>(P => P.Layout); }
            set { base.SetFieldValue(P => P.Layout, (int)value); }
        }

        public string Config
        {
            get { return base.GetFieldValue<string>(P => P.Config); }
            set { base.SetFieldValue(P => P.Config, value); }
        }

    }
}
