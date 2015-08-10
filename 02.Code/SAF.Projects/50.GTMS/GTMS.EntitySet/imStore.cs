using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTMS.EntitySet
{
    public class imStore : Entity<imStore>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "imStore";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string StoreName
        {
            get { return base.GetFieldValue<string>(P => P.StoreName); }
            set { base.SetFieldValue(P => P.StoreName, value); }
        }

        public string StoreNo
        {
            get { return base.GetFieldValue<string>(P => P.StoreNo); }
            set { base.SetFieldValue(P => P.StoreNo, value); }
        }

        public string StoreType
        {
            get { return base.GetFieldValue<string>(P => P.StoreType); }
            set { base.SetFieldValue(P => P.StoreType, value); }
        }

        public bool Usabled
        {
            get { return base.GetFieldValue<bool>(P => P.Usabled); }
            set { base.SetFieldValue(P => P.Usabled, value); }
        }



    }
}
