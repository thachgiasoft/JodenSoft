using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Entity
{
    public class sysAppConfig : Entity<sysAppConfig>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysAppConfig";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public int UserId
        {
            get { return base.GetFieldValue<int>(P => P.UserId); }
            set { base.SetFieldValue(P => P.UserId, value); }
        }

        public string AppConfig
        {
            get { return base.GetFieldValue<string>(P => P.AppConfig); }
            set { base.SetFieldValue(P => P.AppConfig, value); }
        }

    }
}
