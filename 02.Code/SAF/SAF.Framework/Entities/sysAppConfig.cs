﻿using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Entities
{
    public class sysAppConfig : Entity<sysAppConfig>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysAppConfig";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public int UserId
        {
            get { return base.GetFieldValue<int>(P => P.UserId); }
            set { base.SetFieldValue(P => P.UserId, value); }
        }

        public string AppConfig
        {
            get { return base.GetFieldValue<string>(P => P.AppConfig); }
            set { base.SetFieldValue(P => P.AppConfig, value); }
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