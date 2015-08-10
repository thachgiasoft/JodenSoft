using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JNHT_ProdSys
{
    public class bomMeterial : Entity<bomMeterial>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "bomMeterial";
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
        public string BomChildName
        {
            get { return base.GetFieldValue<string>(P => P.BomChildName); }
            set { base.SetFieldValue(P => P.BomChildName, value); }
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
        public string ShopSign
        {
            get { return base.GetFieldValue<string>(P => P.ShopSign); }
            set { base.SetFieldValue(P => P.ShopSign, value); }
        }
        public string Invstd
        {
            get { return base.GetFieldValue<string>(P => P.Invstd); }
            set { base.SetFieldValue(P => P.Invstd, value); }
        }
        public string FeedStd
        {
            get { return base.GetFieldValue<string>(P => P.FeedStd); }
            set { base.SetFieldValue(P => P.FeedStd, value); }
        }
        public decimal SingleNum
        {
            get { return base.GetFieldValue<decimal>(P => P.SingleNum); }
            set { base.SetFieldValue(P => P.SingleNum, value); }
        }
        public decimal Weight
        {
            get { return base.GetFieldValue<decimal>(P => P.Weight); }
            set { base.SetFieldValue(P => P.Weight, value); }
        }
        public decimal OneMakeNum
        {
            get { return base.GetFieldValue<decimal>(P => P.OneMakeNum); }
            set { base.SetFieldValue(P => P.OneMakeNum, value); }
        }
        public decimal SingleQty
        {
            get { return base.GetFieldValue<decimal>(P => P.SingleQty); }
            set { base.SetFieldValue(P => P.SingleQty, value); }
        }
        public string CComUnitCode
        {
            get { return base.GetFieldValue<string>(P => P.CComUnitCode); }
            set { base.SetFieldValue(P => P.CComUnitCode, value); }
        }
        public decimal ProcQty
        {
            get { return base.GetFieldValue<decimal>(P => P.ProcQty); }
            set { base.SetFieldValue(P => P.ProcQty, value); }
        }
        public decimal NetWeight
        {
            get { return base.GetFieldValue<decimal>(P => P.NetWeight); }
            set { base.SetFieldValue(P => P.NetWeight, value); }
        }
        public decimal MaterialRate
        {
            get { return base.GetFieldValue<decimal>(P => P.MaterialRate); }
            set { base.SetFieldValue(P => P.MaterialRate, value); }
        }
        public string Production
        {
            get { return base.GetFieldValue<string>(P => P.Production); }
            set { base.SetFieldValue(P => P.Production, value); }
        }
        public string Mark2
        {
            get { return base.GetFieldValue<string>(P => P.Mark2); }
            set { base.SetFieldValue(P => P.Mark2, value); }
        }
        public decimal Proportion
        {
            get { return base.GetFieldValue<decimal>(P => P.Proportion); }
            set { base.SetFieldValue(P => P.Proportion, value); }
        }
        public decimal PartNetWeight
        {
            get { return base.GetFieldValue<decimal>(P => P.PartNetWeight); }
            set { base.SetFieldValue(P => P.PartNetWeight, value); }
        }
        public string OpDep
        {
            get { return base.GetFieldValue<string>(P => P.OpDep); }
            set { base.SetFieldValue(P => P.OpDep, value); }
        }

        public string define1
        {
            get { return base.GetFieldValue<string>(P => P.define1); }
            set { base.SetFieldValue(P => P.define1, value); }
        }
        public string define2
        {
            get { return base.GetFieldValue<string>(P => P.define2); }
            set { base.SetFieldValue(P => P.define2, value); }
        }
        public string define3
        {
            get { return base.GetFieldValue<string>(P => P.define3); }
            set { base.SetFieldValue(P => P.define3, value); }
        }
        public string define4
        {
            get { return base.GetFieldValue<string>(P => P.define4); }
            set { base.SetFieldValue(P => P.define4, value); }
        }
        public string define5
        {
            get { return base.GetFieldValue<string>(P => P.define5); }
            set { base.SetFieldValue(P => P.define5, value); }
        }
        public string define6
        {
            get { return base.GetFieldValue<string>(P => P.define6); }
            set { base.SetFieldValue(P => P.define6, value); }
        }
        public string define7
        {
            get { return base.GetFieldValue<string>(P => P.define7); }
            set { base.SetFieldValue(P => P.define7, value); }
        }
        public string define8
        {
            get { return base.GetFieldValue<string>(P => P.define8); }
            set { base.SetFieldValue(P => P.define8, value); }
        }
        public string define9
        {
            get { return base.GetFieldValue<string>(P => P.define9); }
            set { base.SetFieldValue(P => P.define9, value); }
        }
        public string define10
        {
            get { return base.GetFieldValue<string>(P => P.define10); }
            set { base.SetFieldValue(P => P.define10, value); }
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
        public int VersionNumber
        {
            get { return base.GetFieldValue<int>(p => p.VersionNumber, 0); }
        }

        #endregion
    }
}
