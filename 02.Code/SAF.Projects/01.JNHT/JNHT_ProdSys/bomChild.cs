using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JNHT_ProdSys
{
    public class bomChild : Entity<bomChild>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "bomChild";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public string BomId
        {
            get { return base.GetFieldValue<string>(P => P.BomId); }
            set { base.SetFieldValue(P => P.BomId, value); }
        }

        public string BomChildId
        {
            get { return base.GetFieldValue<string>(P => P.BomChildId); }
            set { base.SetFieldValue(P => P.BomChildId, value); }
        }

        public string CInvCode
        {
            get { return base.GetFieldValue<string>(P => P.CInvCode); }
            set { base.SetFieldValue(P => P.CInvCode, value); }
        }

        public string CInvName
        {
            get { return base.GetFieldValue<string>(P => P.CInvName); }
            set { base.SetFieldValue(P => P.CInvName, value); }
        }

        public string NoPicCode
        {
            get { return base.GetFieldValue<string>(P => P.NoPicCode); }
            set { base.SetFieldValue(P => P.NoPicCode, value); }
        }

        public string NoPicName
        {
            get { return base.GetFieldValue<string>(P => P.NoPicName); }
            set { base.SetFieldValue(P => P.NoPicName, value); }
        }
        public string CComUnitCode
        {
            get { return base.GetFieldValue<string>(P => P.CComUnitCode); }
            set { base.SetFieldValue(P => P.CComUnitCode, value); }
        }

        public decimal SingleQty
        {
            get { return base.GetFieldValue<decimal>(P => P.SingleQty); }
            set { base.SetFieldValue(P => P.SingleQty, value); }
        }
        public decimal ProcQty
        {
            get { return base.GetFieldValue<decimal>(P => P.ProcQty); }
            set { base.SetFieldValue(P => P.ProcQty, value); }
        }

        public string FeedStd
        {
            get { return base.GetFieldValue<string>(P => P.FeedStd); }
            set { base.SetFieldValue(P => P.FeedStd, value); }
        }

        public string OpDep
        {
            get { return base.GetFieldValue<string>(P => P.OpDep); }
            set { base.SetFieldValue(P => P.OpDep, value); }
        }


        public DateTime RelsDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.RelsDate); }
            set { base.SetFieldValue(P => P.RelsDate, value); }
        }

        public int RelsUser
        {
            get { return base.GetFieldValue<int>(P => P.RelsUser); }
            set { base.SetFieldValue(P => P.RelsUser, value); }
        }

        public string ReMark
        {
            get { return base.GetFieldValue<string>(P => P.ReMark); }
            set { base.SetFieldValue(P => P.ReMark, value); }
        }

        public string EditStatus
        {
            get { return base.GetFieldValue<string>(P => P.EditStatus); }
            set { base.SetFieldValue(P => P.EditStatus, value); }
        }
        public string Cdefine1
        {
            get { return base.GetFieldValue<string>(P => P.Cdefine1); }
            set { base.SetFieldValue(P => P.Cdefine1, value); }
        }

        public string Cdefine2
        {
            get { return base.GetFieldValue<string>(P => P.Cdefine2); }
            set { base.SetFieldValue(P => P.Cdefine2, value); }
        }

        public string Cdefine3
        {
            get { return base.GetFieldValue<string>(P => P.Cdefine3); }
            set { base.SetFieldValue(P => P.Cdefine3, value); }
        }
        public int? Cdefine4
        {
            get { return base.GetFieldValue<int?>(P => P.Cdefine4); }
            set { base.SetFieldValue(P => P.Cdefine4, value); }
        }
        public int? Cdefine5
        {
            get { return base.GetFieldValue<int?>(P => P.Cdefine5); }
            set { base.SetFieldValue(P => P.Cdefine5, value); }
        }
        public int? CreatedBy
        {
            get { return base.GetFieldValue<int?>(p => p.CreatedBy, null); }
            set { base.SetFieldValue(p => p.CreatedBy, value); }
        }
        public DateTime? CreatedOn
        {
            get { return base.GetFieldValue<DateTime?>(p => p.CreatedOn, null); }
            set { base.SetFieldValue(p => p.CreatedOn, value); }
        }

        public DateTime? ModifiedBy
        {
            get { return base.GetFieldValue<DateTime?>(p => p.ModifiedBy, null); }
            set { base.SetFieldValue(p => p.ModifiedBy, value); }
        }
        public DateTime? ModifiedOn
        {
            get { return base.GetFieldValue<DateTime?>(p => p.ModifiedOn, null); }
            set { base.SetFieldValue(p => p.ModifiedOn, value); }
        }
        public int VersionNumber
        {
            get { return base.GetFieldValue<int>(p => p.VersionNumber, 0); }
        }
    }
}
