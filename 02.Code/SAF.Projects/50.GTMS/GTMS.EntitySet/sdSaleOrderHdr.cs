using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTMS.EntitySet
{
    public class sdSaleOrderHdr : Entity<sdSaleOrderHdr>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sdSaleOrderHdr";
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

        public int CustomerId
        {
            get { return base.GetFieldValue<int>(P => P.CustomerId); }
            set { base.SetFieldValue(P => P.CustomerId, value); }
        }


        public DateTime ReceivedDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.ReceivedDate); }
            set { base.SetFieldValue(P => P.ReceivedDate, value); }
        }

        public decimal Amount
        {
            get { return base.GetFieldValue<decimal>(P => P.Amount); }
            set { base.SetFieldValue(P => P.Amount, value); }
        }

        public decimal Imprest
        {
            get { return base.GetFieldValue<decimal>(P => P.Imprest); }
            set { base.SetFieldValue(P => P.Imprest, value); }
        }

        public decimal DiscountAmount
        {
            get { return base.GetFieldValue<decimal>(P => P.DiscountAmount); }
            set { base.SetFieldValue(P => P.DiscountAmount, value); }
        }

        public decimal AdditionalAmount
        {
            get { return base.GetFieldValue<decimal>(P => P.AdditionalAmount); }
            set { base.SetFieldValue(P => P.AdditionalAmount, value); }
        }

        public int SalesId
        {
            get { return base.GetFieldValue<int>(P => P.SalesId); }
            set { base.SetFieldValue(P => P.SalesId, value); }
        }
        public int FollowerId
        {
            get { return base.GetFieldValue<int>(P => P.FollowerId); }
            set { base.SetFieldValue(P => P.FollowerId, value); }
        }

        public DateTime AuditTime
        {
            get { return base.GetFieldValue<DateTime>(P => P.AuditTime); }
            set { base.SetFieldValue(P => P.AuditTime, value); }
        }

        public decimal Qty
        {
            get { return base.GetFieldValue<decimal>(P => P.Qty); }
            set { base.SetFieldValue(P => P.Qty, value); }
        }
        public decimal ExchangeRate
        {
            get { return base.GetFieldValue<decimal>(P => P.ExchangeRate); }
            set { base.SetFieldValue(P => P.ExchangeRate, value); }
        }

        public int FinallyCustomerId
        {
            get { return base.GetFieldValue<int>(P => P.FinallyCustomerId); }
            set { base.SetFieldValue(P => P.FinallyCustomerId, value); }
        }

        public DateTime DeliveryDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.DeliveryDate); }
            set { base.SetFieldValue(P => P.DeliveryDate, value); }
        }
        public string CustomerOrderNo
        {
            get { return base.GetFieldValue<string>(P => P.CustomerOrderNo); }
            set { base.SetFieldValue(P => P.CustomerOrderNo, value); }
        }

        public string OrderType
        {
            get { return base.GetFieldValue<string>(P => P.OrderType); }
            set { base.SetFieldValue(P => P.OrderType, value); }
        }

        public string BalanceType
        {
            get { return base.GetFieldValue<string>(P => P.BalanceType); }
            set { base.SetFieldValue(P => P.BalanceType, value); }
        }
        public string TradeMode
        {
            get { return base.GetFieldValue<string>(P => P.TradeMode); }
            set { base.SetFieldValue(P => P.TradeMode, value); }
        }

        public string PaymentMode
        {
            get { return base.GetFieldValue<string>(P => P.PaymentMode); }
            set { base.SetFieldValue(P => P.PaymentMode, value); }
        }

        public decimal OverPercent
        {
            get { return base.GetFieldValue<decimal>(P => P.OverPercent); }
            set { base.SetFieldValue(P => P.OverPercent, value); }
        }

        public decimal ShortPercent
        {
            get { return base.GetFieldValue<decimal>(P => P.ShortPercent); }
            set { base.SetFieldValue(P => P.ShortPercent, value); }
        }

        public string Currency
        {
            get { return base.GetFieldValue<string>(P => P.Currency); }
            set { base.SetFieldValue(P => P.Currency, value); }
        }


        public string AuditMan
        {
            get { return base.GetFieldValue<string>(P => P.AuditMan); }
            set { base.SetFieldValue(P => P.AuditMan, value); }
        }

        public string Remark
        {
            get { return base.GetFieldValue<string>(P => P.Remark); }
            set { base.SetFieldValue(P => P.Remark, value); }
        }

        public bool Tax
        {
            get { return base.GetFieldValue<bool>(P => P.Tax); }
            set { base.SetFieldValue(P => P.Tax, value); }
        }

        public bool Usabled
        {
            get { return base.GetFieldValue<bool>(P => P.Usabled); }
            set { base.SetFieldValue(P => P.Usabled, value); }
        }

        //TODO:添加其他字段



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
