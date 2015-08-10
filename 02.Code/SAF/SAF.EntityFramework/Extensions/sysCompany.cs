using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    public class sysCompany : Entity<sysCompany>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysCompany";
            this.IdenGroup = "sysCompany";
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

        public byte[] SplashImage
        {
            get { return base.GetFieldValue<byte[]>(p => p.SplashImage, null); }
            set { base.SetFieldValue(p => p.SplashImage, value); }
        }

    }
}
