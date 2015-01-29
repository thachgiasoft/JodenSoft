using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSDProdPlan
{
    public class emModel : Entity<emModel>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "emModel";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段

        public Guid uGuid
        {
            get { return base.GetFieldValue<Guid>(P => P.uGuid); }
            set { base.SetFieldValue(P => P.uGuid, value); }
        }


        public string sEquipmentModelNo
        {
            get { return base.GetFieldValue<string>(P => P.sEquipmentModelNo); }
            set { base.SetFieldValue(P => P.sEquipmentModelNo, value); }
        }
        public string sEquipmentModelName
        {
            get { return base.GetFieldValue<string>(P => P.sEquipmentModelName); }
            set { base.SetFieldValue(P => P.sEquipmentModelName, value); }
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
