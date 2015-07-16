using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Test
{
    public class sdOrderDtl : Entity<sdOrderDtl>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sdOrderDtl";
            this.IdenGroup = "sdOrderDtl";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public int OrderId
        {
            get { return base.GetFieldValue<int>(P => P.OrderId); }
            set { base.SetFieldValue(P => P.OrderId, value); }
        }

        public decimal Qty
        {
            get { return base.GetFieldValue<decimal>(P => P.Qty); }
            set { base.SetFieldValue(P => P.Qty, value); }
        }


    }
}
