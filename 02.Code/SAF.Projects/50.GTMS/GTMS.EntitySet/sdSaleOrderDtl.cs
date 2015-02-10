using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTMS.EntitySet
{
    public class sdSaleOrderDtl : Entity<sdSaleOrderDtl>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sdSaleOrderDtl";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }
        public int HdrId
        {
            get { return base.GetFieldValue<int>(P => P.HdrId); }
            set { base.SetFieldValue(P => P.HdrId, value); }
        }

        public int MaterialId
        {
            get { return base.GetFieldValue<int>(P => P.MaterialId); }
            set { base.SetFieldValue(P => P.MaterialId, value); }
        }

        public string MaterialNo
        {
            get { return base.GetFieldValue<string>(P => P.MaterialNo); }
            set { base.SetFieldValue(P => P.MaterialNo, value); }
        }
        public string MaterialName
        {
            get { return base.GetFieldValue<string>(P => P.MaterialName); }
            set { base.SetFieldValue(P => P.MaterialName, value); }
        }

        public decimal Qty
        {
            get { return base.GetFieldValue<decimal>(P => P.Qty); }
            set { base.SetFieldValue(P => P.Qty, value); }
        }

        public decimal Price
        {
            get { return base.GetFieldValue<decimal>(P => P.Price); }
            set { base.SetFieldValue(P => P.Price, value); }
        }
        public decimal Amount
        {
            get { return base.GetFieldValue<decimal>(P => P.Amount); }
            set { base.SetFieldValue(P => P.Amount, value); }
        }

        public string ColorLamp
        {
            get { return base.GetFieldValue<string>(P => P.ColorLamp); }
            set { base.SetFieldValue(P => P.ColorLamp, value); }
        }
        public string PatternNo
        {
            get { return base.GetFieldValue<string>(P => P.PatternNo); }
            set { base.SetFieldValue(P => P.PatternNo, value); }
        }
        public string ColorName
        {
            get { return base.GetFieldValue<string>(P => P.ColorName); }
            set { base.SetFieldValue(P => P.ColorName, value); }
        }
        public string FinishRemark
        {
            get { return base.GetFieldValue<string>(P => P.FinishRemark); }
            set { base.SetFieldValue(P => P.FinishRemark, value); }
        }
        public string sWeaveRemark
        {
            get { return base.GetFieldValue<string>(P => P.sWeaveRemark); }
            set { base.SetFieldValue(P => P.sWeaveRemark, value); }
        }
        public string ProduceInfo
        {
            get { return base.GetFieldValue<string>(P => P.ProduceInfo); }
            set { base.SetFieldValue(P => P.ProduceInfo, value); }
        }
        public string QualityRequest
        {
            get { return base.GetFieldValue<string>(P => P.QualityRequest); }
            set { base.SetFieldValue(P => P.QualityRequest, value); }
        }
        public string FinishingMethod
        {
            get { return base.GetFieldValue<string>(P => P.FinishingMethod); }
            set { base.SetFieldValue(P => P.FinishingMethod, value); }
        }
        public string TestStandard
        {
            get { return base.GetFieldValue<string>(P => P.TestStandard); }
            set { base.SetFieldValue(P => P.TestStandard, value); }
        }
        public string ColorStandard
        {
            get { return base.GetFieldValue<string>(P => P.ColorStandard); }
            set { base.SetFieldValue(P => P.ColorStandard, value); }
        }
        public string Remark
        {
            get { return base.GetFieldValue<string>(P => P.Remark); }
            set { base.SetFieldValue(P => P.Remark, value); }
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
