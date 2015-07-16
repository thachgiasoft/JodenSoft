using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDM.Entity
{
    public class sysCustomer : Entity<sysCustomer>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysCustomer";
            this.IdenGroup = "sysCustomer";
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

        public string Address
        {
            get { return base.GetFieldValue<string>(P => P.Address); }
            set { base.SetFieldValue(P => P.Address, value); }
        }

        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(P => P.IsActive); }
            set { base.SetFieldValue(P => P.IsActive, value); }
        }

        public bool IsDeleted
        {
            get { return base.GetFieldValue<bool>(P => P.IsDeleted); }
            set { base.SetFieldValue(P => P.IsDeleted, value); }
        }
    }
}
