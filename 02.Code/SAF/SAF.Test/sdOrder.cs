using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Test
{
    public class sdOrder : Entity<sdOrder>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sdOrder";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string OrderNo
        {
            get { return base.GetFieldValue<string>(P => P.OrderNo); }
            set { base.SetFieldValue(P => P.OrderNo, value); }
        }

        public int OrganiaztionId
        {
            get { return base.GetFieldValue<int>(P => P.OrganiaztionId); }
            set { base.SetFieldValue(P => P.OrganiaztionId, value); }
        }

        public int Remark
        {
            get { return base.GetFieldValue<int>(P => P.Remark); }
            set { base.SetFieldValue(P => P.Remark, value); }
        }

    }
}
