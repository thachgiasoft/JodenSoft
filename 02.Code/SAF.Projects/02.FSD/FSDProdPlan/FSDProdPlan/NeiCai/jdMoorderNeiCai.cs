using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSDProdPlan.NeiCai
{
    public class jdMoorderNeiCai : Entity<jdMoorderNeiCai>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "jdMoorderNeiCai";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public string sOrderNo
        {
            get { return base.GetFieldValue<string>(P => P.sOrderNo); }
            set { base.SetFieldValue(P => P.sOrderNo, value); }
        }
        public int sMaterialIden
        {
            get { return base.GetFieldValue<int>(P => P.sMaterialIden); }
            set { base.SetFieldValue(P => P.sMaterialIden, value); }
        }
        public string sMaterialNo
        {
            get { return base.GetFieldValue<string>(P => P.sMaterialNo); }
            set { base.SetFieldValue(P => P.sMaterialNo, value); }
        }
        public string sMaterialName
        {
            get { return base.GetFieldValue<string>(P => P.sMaterialName); }
            set { base.SetFieldValue(P => P.sMaterialName, value); }
        }
        public string sColorNo
        {
            get { return base.GetFieldValue<string>(P => P.sColorNo); }
            set { base.SetFieldValue(P => P.sColorNo, value); }
        }

        public DateTime dDeliveryDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.dDeliveryDate); }
            set { base.SetFieldValue(P => P.dDeliveryDate, value); }
        }


        public decimal nPlanQty
        {
            get { return base.GetFieldValue<decimal>(P => P.nPlanQty); }
            set { base.SetFieldValue(P => P.nPlanQty, value); }
        }

       

       
        public string state
        {
            get { return base.GetFieldValue<string>(P => P.state); }
            set { base.SetFieldValue(P => P.state, value); }
        }
        public string cDefine1
        {
            get { return base.GetFieldValue<string>(P => P.cDefine1); }
            set { base.SetFieldValue(P => P.cDefine1, value); }
        }
        public string cDefine2
        {
            get { return base.GetFieldValue<string>(P => P.cDefine2); }
            set { base.SetFieldValue(P => P.cDefine2, value); }
        }
        public string cDefine3
        {
            get { return base.GetFieldValue<string>(P => P.cDefine3); }
            set { base.SetFieldValue(P => P.cDefine3, value); }
        }
        public string cDefine4
        {
            get { return base.GetFieldValue<string>(P => P.cDefine4); }
            set { base.SetFieldValue(P => P.cDefine4, value); }
        }
        public decimal cDefine5
        {
            get { return base.GetFieldValue<decimal>(P => P.cDefine5); }
            set { base.SetFieldValue(P => P.cDefine5, value); }
        }
        public int cDefine6
        {
            get { return base.GetFieldValue<int>(P => P.cDefine6); }
            set { base.SetFieldValue(P => P.cDefine6, value); }
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
