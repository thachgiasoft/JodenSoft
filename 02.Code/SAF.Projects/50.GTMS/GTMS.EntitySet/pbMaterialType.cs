﻿using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTMS.EntitySet
{
    public class pbMaterialType : Entity<pbMaterialType>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "pbMaterialType";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public int MaterialTypeId
        {
            get { return base.GetFieldValue<int>(P => P.MaterialTypeId); }
            set { base.SetFieldValue(P => P.MaterialTypeId, value); }
        }

        public string MaterialTypeCode
        {
            get { return base.GetFieldValue<string>(P => P.MaterialTypeCode); }
            set { base.SetFieldValue(P => P.MaterialTypeCode, value); }
        }

        public string MaterialTypeName
        {
            get { return base.GetFieldValue<string>(P => P.MaterialTypeName); }
            set { base.SetFieldValue(P => P.MaterialTypeName, value); }
        }

        public string sDescription
        {
            get { return base.GetFieldValue<string>(P => P.sDescription); }
            set { base.SetFieldValue(P => P.sDescription, value); }
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
