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

            this.TableName = "sdOrder";
            this.IdenGroup = "sdOrder";
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

        public int OrganizationId
        {
            get { return base.GetFieldValue<int>(P => P.OrganizationId); }
            set { base.SetFieldValue(P => P.OrganizationId, value); }
        }

        public int Remark
        {
            get { return base.GetFieldValue<int>(P => P.Remark); }
            set { base.SetFieldValue(P => P.Remark, value); }
        }

    }
}
