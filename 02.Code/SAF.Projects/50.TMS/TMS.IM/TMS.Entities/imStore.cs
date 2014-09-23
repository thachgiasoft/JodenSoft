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
            this.PrimaryKeyName = "Iden";
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

        public bool bUsable
        {
            get { return base.GetFieldValue<bool>(P => P.bUsable); }
            set { base.SetFieldValue(P => P.bUsable, value); }
        }


        public string sCreator
        {
            get { return base.GetFieldValue<string>(p => p.sCreator); }
            set { base.SetFieldValue(p => p.sCreator, value); }
        }
        public DateTime? tCreatetime
        {
            get { return base.GetFieldValue<DateTime?>(p => p.tCreatetime, null); }
            set { base.SetFieldValue(p => p.tCreatetime, value); }
        }

        
    }

    public class imStoreInOutType : Entity<imStoreInOutType>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "imStoreInOutType";
            this.PrimaryKeyName = "Iden";
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

        public int iReceivePayType
        {
            get { return base.GetFieldValue<int>(P => P.iReceivePayType); }
            set { base.SetFieldValue(P => P.iReceivePayType, value); }
        }

        public int iAutoCreateType 
        {
            get { return base.GetFieldValue<int>(P => P.iAutoCreateType); }
            set { base.SetFieldValue(P => P.iAutoCreateType, value); }
        }
        
        public int? sCreator
        {
            get { return base.GetFieldValue<int?>(p => p.sCreator, null); }
            set { base.SetFieldValue(p => p.sCreator, value); }
        }
        public DateTime? tCreatetime
        {
            get { return base.GetFieldValue<DateTime?>(p => p.tCreatetime, null); }
            set { base.SetFieldValue(p => p.tCreatetime, value); }
        }

        public bool bUsable
        {
            get { return base.GetFieldValue<bool>(P => P.bUsable); }
            set { base.SetFieldValue(P => P.bUsable, value); }
        }

    }

    public class imInOutStockRoomOperationHdr : Entity<imInOutStockRoomOperationHdr>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "imInOutStockRoomOperationHdr";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }


        public string sBillNo
        {
            get { return base.GetFieldValue<string>(P => P.sBillNo); }
            set { base.SetFieldValue(P => P.sBillNo, value); }
        }

        public string sStatus
        {
            get { return base.GetFieldValue<string>(P => P.sStatus); }
            set { base.SetFieldValue(P => P.sStatus, value); }
        }

        public int iStoreInOutType
        {
            get { return base.GetFieldValue<int>(P => P.iStoreInOutType); }
            set { base.SetFieldValue(P => P.iStoreInOutType, value); }
        }
        public int iStoreID
        {
            get { return base.GetFieldValue<int>(P => P.iStoreID); }
            set { base.SetFieldValue(P => P.iStoreID, value); }
        }  
 
        public int iSourceDestStore
        {
            get { return base.GetFieldValue<int>(P => P.iSourceDestStore); }
            set { base.SetFieldValue(P => P.iSourceDestStore, value); }
        }  
        public DateTime tStoreInouttime
        {
            get { return base.GetFieldValue<DateTime>(P => P.tStoreInouttime); }
            set { base.SetFieldValue(P => P.tStoreInouttime, value); }
        }  
        public DateTime? tUpdatetime
        {
            get { return base.GetFieldValue<DateTime?>(p => p.tUpdatetime, null); }
            set { base.SetFieldValue(p => p.tUpdatetime, value); }
        }
        public DateTime? tAudittime
        {
            get { return base.GetFieldValue<DateTime?>(p => p.tAudittime, null); }
            set { base.SetFieldValue(p => p.tAudittime, value); }
        }

        public string sRemark
        {
            get { return base.GetFieldValue<string>(P => P.sRemark); }
            set { base.SetFieldValue(P => P.sRemark, value); }
        }
 
        public string sAuditMan
        {
            get { return base.GetFieldValue<string>(P => P.sAuditMan); }
            set { base.SetFieldValue(P => P.sAuditMan, value); }
        }

        public string sCreator
        {
            get { return base.GetFieldValue<string>(p => p.sCreator); }
            set { base.SetFieldValue(p => p.sCreator, value); }
        }
        public DateTime? tCreatetime
        {
            get { return base.GetFieldValue<DateTime?>(p => p.tCreatetime, null); }
            set { base.SetFieldValue(p => p.tCreatetime, value); }
        }

    }

    public class imInOutStockRoomOperationDtl : Entity<imInOutStockRoomOperationDtl>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "imInOutStockRoomOperationDtl";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string sRemark
        {
            get { return base.GetFieldValue<string>(P => P.sRemark); }
            set { base.SetFieldValue(P => P.sRemark, value); }
        }
        public string sLocation
        {
            get { return base.GetFieldValue<string>(P => P.sLocation); }
            set { base.SetFieldValue(P => P.sLocation, value); }
        }

        public string sUnit
        {
            get { return base.GetFieldValue<string>(P => P.sUnit); }
            set { base.SetFieldValue(P => P.sUnit, value); }
        }

        public decimal nQty
        {
            get { return base.GetFieldValue<decimal>(P => P.nQty); }
            set { base.SetFieldValue(P => P.nQty, value); }
        }

        public decimal nTaxPrice
        {
            get { return base.GetFieldValue<decimal>(P => P.nTaxPrice); }
            set { base.SetFieldValue(P => P.nTaxPrice, value); }
        }

        public decimal nTaxAmount
        {
            get { return base.GetFieldValue<decimal>(P => P.nTaxAmount); }
            set { base.SetFieldValue(P => P.nTaxAmount, value); }
        }

        public decimal nRate
        {
            get { return base.GetFieldValue<decimal>(P => P.nRate); }
            set { base.SetFieldValue(P => P.nRate, value); }
        }

        public decimal nDiscount
        {
            get { return base.GetFieldValue<decimal>(P => P.nDiscount); }
            set { base.SetFieldValue(P => P.nDiscount, value); }
        }

        public decimal nPkgQty
        {
            get { return base.GetFieldValue<decimal>(P => P.nPkgQty); }
            set { base.SetFieldValue(P => P.nPkgQty, value); }
        }

        public int HdrID
        {
            get { return base.GetFieldValue<int>(p => p.HdrID); }
            set { base.SetFieldValue(p => p.HdrID, value); }
        }
        public int iUnit
        {
            get { return base.GetFieldValue<int>(p => p.iUnit); }
            set { base.SetFieldValue(p => p.iUnit, value); }
        }

    }
}
