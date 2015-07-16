using SAF.EntityFramework;
using SAF.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDM.Entity
{
    public class sysRegistrationInfo : Entity<sysRegistrationInfo>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysRegistrationInfo";
            this.IdenGroup = "sysRegistrationInfo";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public int CustomerId
        {
            get { return base.GetFieldValue<int>(P => P.CustomerId); }
            set { base.SetFieldValue(P => P.CustomerId, value); }
        }

        public string MachineName
        {
            get { return base.GetFieldValue<string>(P => P.MachineName); }
            set { base.SetFieldValue(P => P.MachineName, value); }
        }

        public string MachineCode
        {
            get { return base.GetFieldValue<string>(P => P.MachineCode); }
            set { base.SetFieldValue(P => P.MachineCode, value); }
        }

        public ApplicationVersion Version
        {
            get { return (ApplicationVersion)base.GetFieldValue<int>(P => P.Version); }
            set { base.SetFieldValue(P => P.Version, (int)value); }
        }

        public DateTime RegistrationDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.RegistrationDate); }
            set { base.SetFieldValue(P => P.RegistrationDate, value); }
        }

        public DateTime ExpiredDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.ExpiredDate); }
            set { base.SetFieldValue(P => P.ExpiredDate, value); }
        }

        public int OnLineLimit
        {
            get { return base.GetFieldValue<int>(P => P.OnLineLimit); }
            set { base.SetFieldValue(P => P.OnLineLimit, value); }
        }

        public bool IsDeleted
        {
            get { return base.GetFieldValue<bool>(P => P.IsDeleted); }
            set { base.SetFieldValue(P => P.IsDeleted, value); }
        }

        public string ActivationResponse
        {
            get { return base.GetFieldValue<string>(P => P.ActivationResponse); }
            set { base.SetFieldValue(P => P.ActivationResponse, value); }
        }
    }
}
