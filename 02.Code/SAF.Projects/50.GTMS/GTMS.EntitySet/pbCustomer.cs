using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTMS.EntitySet
{
    public class pbCustomer : Entity<pbCustomer>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "pbCustomer";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public string CustomerNo
        {
            get { return base.GetFieldValue<string>(P => P.CustomerNo); }
            set { base.SetFieldValue(P => P.CustomerNo, value); }
        }

        public string CustomerName
        {
            get { return base.GetFieldValue<string>(P => P.CustomerName); }
            set { base.SetFieldValue(P => P.CustomerName, value); }
        }
        public string CustomerFullName
        {
            get { return base.GetFieldValue<string>(P => P.CustomerFullName); }
            set { base.SetFieldValue(P => P.CustomerFullName, value); }
        }
        public string CustomerType
        {
            get { return base.GetFieldValue<string>(P => P.CustomerType); }
            set { base.SetFieldValue(P => P.CustomerType, value); }
        }
        public string CustomerLeave
        {
            get { return base.GetFieldValue<string>(P => P.CustomerLeave); }
            set { base.SetFieldValue(P => P.CustomerLeave, value); }
        }
        public string BankName
        {
            get { return base.GetFieldValue<string>(P => P.BankName); }
            set { base.SetFieldValue(P => P.BankName, value); }
        }

        public string CreditLevel
        {
            get { return base.GetFieldValue<string>(P => P.CreditLevel); }
            set { base.SetFieldValue(P => P.CreditLevel, value); }
        }

        public string Adress
        {
            get { return base.GetFieldValue<string>(P => P.Adress); }
            set { base.SetFieldValue(P => P.Adress, value); }
        }
        public string TaxNo
        {
            get { return base.GetFieldValue<string>(P => P.TaxNo); }
            set { base.SetFieldValue(P => P.TaxNo, value); }
        }
        public string TelePhone
        {
            get { return base.GetFieldValue<string>(P => P.TelePhone); }
            set { base.SetFieldValue(P => P.TelePhone, value); }
        }
        public string LinkMan
        {
            get { return base.GetFieldValue<string>(P => P.LinkMan); }
            set { base.SetFieldValue(P => P.LinkMan, value); }
        }
        public string LinkPhone
        {
            get { return base.GetFieldValue<string>(P => P.LinkPhone); }
            set { base.SetFieldValue(P => P.LinkPhone, value); }
        }
        public string CreditAmount
        {
            get { return base.GetFieldValue<string>(P => P.CreditAmount); }
            set { base.SetFieldValue(P => P.CreditAmount, value); }
        }
        public string MaterialIdList
        {
            get { return base.GetFieldValue<string>(P => P.MaterialIdList); }
            set { base.SetFieldValue(P => P.MaterialIdList, value); }
        }
        public bool Usabled
        {
            get { return base.GetFieldValue<bool>(P => P.Usabled); }
            set { base.SetFieldValue(P => P.Usabled, value); }
        }

        #region 创建人&创建时间&修改人&修改时间&版本号

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

        public int? ModifiedBy
        {
            get { return base.GetFieldValue<int?>(p => p.ModifiedBy, null); }
            set { base.SetFieldValue(p => p.ModifiedBy, value); }
        }

        public DateTime? ModifiedOn
        {
            get { return base.GetFieldValue<DateTime?>(p => p.ModifiedOn, null); }
            set { base.SetFieldValue(p => p.ModifiedOn, value); }
        }

        public VersionNumber VersionNumber
        {
            get { return new VersionNumber(base.GetFieldValue<byte[]>(p => p.VersionNumber)); }
        }

        #endregion
    }
}
