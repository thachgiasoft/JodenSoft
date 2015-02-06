using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSDProdPlan.NeiCai
{
    public class sMaterial : Entity<sMaterial>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sMaterial";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public string sMaterialNo
        {
            get { return base.GetFieldValue<string>(P => P.sMaterialNo); }
            set { base.SetFieldValue(P => P.sMaterialNo, value); }
        }
        public string sMaterialName
        {
            get { return base.GetFieldValue<string>(P => P.sMaterialName); }
            set { base.SetFieldValue(P => P.sMaterialName, value); }
        }
        public string state
        {
            get { return base.GetFieldValue<string>(P => P.state); }
            set { base.SetFieldValue(P => P.state, value); }
        }
    }
}
