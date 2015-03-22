using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSDProdPlan.NeiCai
{
    public class routingBase : Entity<routingBase>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "routingBase";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }
        public string Routingname
        {
            get { return base.GetFieldValue<string>(P => P.Routingname); }
            set { base.SetFieldValue(P => P.Routingname, value); }
        }
        public string cdefine1
        {
            get { return base.GetFieldValue<string>(P => P.cdefine1); }
            set { base.SetFieldValue(P => P.cdefine1, value); }
        }
        public string cdefine2
        {
            get { return base.GetFieldValue<string>(P => P.cdefine2); }
            set { base.SetFieldValue(P => P.cdefine2, value); }
        }

        //TODO:添加其他字段

    }
}
