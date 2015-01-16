using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysCommonBillDtlField : Entity<sysCommonBillDtlField>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysCommonBillDtlField";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段




       
    }
}
