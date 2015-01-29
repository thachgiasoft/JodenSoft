using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSDProdPlan
{
    public class jdMoorder : Entity<jdMoorder>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "jdMoorder";
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
        public string sEquipmentModelName
        {
            get { return base.GetFieldValue<string>(P => P.sEquipmentModelName); }
            set { base.SetFieldValue(P => P.sEquipmentModelName, value); }
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

        public Guid uemEquipmentModelGUID
        {
            get { return base.GetFieldValue<Guid>(P => P.uemEquipmentModelGUID); }
            set { base.SetFieldValue(P => P.uemEquipmentModelGUID, value); }
        }
        public string sBillNO
        {
            get { return base.GetFieldValue<string>(P => P.sBillNO); }
            set { base.SetFieldValue(P => P.sBillNO, value); }
        }
        
            public decimal nCapacity
        {
            get { return base.GetFieldValue<decimal>(P => P.nCapacity); }
            set { base.SetFieldValue(P => P.nCapacity, value); }
        }
            public string state
            {
                get { return base.GetFieldValue<string>(P => P.state); }
                set { base.SetFieldValue(P => P.state, value); }
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
