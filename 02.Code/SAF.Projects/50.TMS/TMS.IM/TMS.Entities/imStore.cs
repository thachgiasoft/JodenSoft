using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS.Entities
{
    public class imStore : Entity<imStore>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "imStore";
            this.PrimaryKey = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string sStoreName
        {
            get { return base.GetFieldValue<string>(P => P.sStoreName); }
            set { base.SetFieldValue(P => P.sStoreName, value); }
        }

        public string sStoreNo
        {
            get { return base.GetFieldValue<string>(P => P.sStoreNo); }
            set { base.SetFieldValue(P => P.sStoreNo, value); }
        }

        public string tCreatetime
        {
            get { return base.GetFieldValue<string>(P => P.tCreatetime); }
            set { base.SetFieldValue(P => P.tCreatetime, value); }
        }


        public string sCreator
        {
            get { return base.GetFieldValue<string>(P => P.sCreator); }
            set { base.SetFieldValue(P => P.sCreator, value); }
        }

        public bool bUsable
        {
            get { return base.GetFieldValue<bool>(P => P.bUsable); }
            set { base.SetFieldValue(P => P.bUsable, value); }
        }
        
    }

    public class imStoreInOutType : Entity<imStoreInOutType>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "imStore";
            this.PrimaryKey = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string sStoreInOutName
        {
            get { return base.GetFieldValue<string>(P => P.sStoreInOutName); }
            set { base.SetFieldValue(P => P.sStoreInOutName, value); }
        }

        public string sStoreInOutType
        {
            get { return base.GetFieldValue<string>(P => P.sStoreInOutType); }
            set { base.SetFieldValue(P => P.sStoreInOutType, value); }
        }

        public string tCreatetime
        {
            get { return base.GetFieldValue<string>(P => P.tCreatetime); }
            set { base.SetFieldValue(P => P.tCreatetime, value); }
        }


        public string sCreator
        {
            get { return base.GetFieldValue<string>(P => P.sCreator); }
            set { base.SetFieldValue(P => P.sCreator, value); }
        }

        public bool bUsable
        {
            get { return base.GetFieldValue<bool>(P => P.bUsable); }
            set { base.SetFieldValue(P => P.bUsable, value); }
        }

    }
}
