using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSDProdPlan.NeiCai
{
    public class woRouting : Entity<woRouting>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "woRouting";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public int woIden
        {
            get { return base.GetFieldValue<int>(P => P.woIden); }
            set { base.SetFieldValue(P => P.woIden, value); }
        }
        public string sOrderNo
        {
            get { return base.GetFieldValue<string>(P => P.sOrderNo); }
            set { base.SetFieldValue(P => P.sOrderNo, value); }
        }

        public string sBillNO
        {
            get { return base.GetFieldValue<string>(P => P.sBillNO); }
            set { base.SetFieldValue(P => P.sBillNO, value); }
        }
        public int routingId
        {
            get { return base.GetFieldValue<int>(P => P.routingId); }
            set { base.SetFieldValue(P => P.routingId, value); }
        }
        public string routingName
        {
            get { return base.GetFieldValue<string>(P => P.routingName); }
            set { base.SetFieldValue(P => P.routingName, value); }
        }
        public Guid uGuid
        {
            get { return base.GetFieldValue<Guid>(P => P.uGuid); }
            set { base.SetFieldValue(P => P.uGuid, value); }
        }
        ////public Guid uEquipmentGuid
        ////{
        ////    get { return base.GetFieldValue<Guid>(P => P.uEquipmentGuid); }
        ////    set { base.SetFieldValue(P => P.uEquipmentGuid, value); }
        ////}

        ////public string sEquipmentNo
        ////{
        ////    get { return base.GetFieldValue<string>(P => P.sEquipmentNo); }
        ////    set { base.SetFieldValue(P => P.sEquipmentNo, value); }
        ////}


        //public int sMaterialIden
        //{
        //    get { return base.GetFieldValue<int>(P => P.sMaterialIden); }
        //    set { base.SetFieldValue(P => P.sMaterialIden, value); }
        //}

        public int banzhi
        {
            get { return base.GetFieldValue<int>(P => P.banzhi); }
            set { base.SetFieldValue(P => P.banzhi, value); }
        }
        public string routingState
        {
            get { return base.GetFieldValue<string>(P => P.routingState); }
            set { base.SetFieldValue(P => P.routingState, value); }
        }
        public Guid uemEquipmentModelGUID
        {
            get { return base.GetFieldValue<Guid>(P => P.uemEquipmentModelGUID); }
            set { base.SetFieldValue(P => P.uemEquipmentModelGUID, value); }
        }
        public string uemEquipmentModelNo
        {
            get { return base.GetFieldValue<string>(P => P.uemEquipmentModelNo); }
            set { base.SetFieldValue(P => P.uemEquipmentModelNo, value); }
        }
        public string uemEquipmentModelName
        {
            get { return base.GetFieldValue<string>(P => P.uemEquipmentModelName); }
            set { base.SetFieldValue(P => P.uemEquipmentModelName, value); }
        }
        public decimal nCapacity
        {
            get { return base.GetFieldValue<decimal>(P => P.nCapacity); }
            set { base.SetFieldValue(P => P.nCapacity, value); }
        }
        public int PersonQty
        {
            get { return base.GetFieldValue<int>(P => P.PersonQty); }
            set { base.SetFieldValue(P => P.PersonQty, value); }
        }
        public int BasePersonQty
        {
            get { return base.GetFieldValue<int>(P => P.BasePersonQty); }
            set { base.SetFieldValue(P => P.BasePersonQty, value); }
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
        public int OrganiaztionId
        {
            get { return base.GetFieldValue<int>(P => P.OrganiaztionId); }
            set { base.SetFieldValue(P => P.OrganiaztionId, value); }
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
