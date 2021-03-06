﻿using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSDProdPlan
{
    public class jdRecourse : Entity<jdRecourse>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "jdRecourse";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public string InvCode
        {
            get { return base.GetFieldValue<string>(P => P.InvCode); }
            set { base.SetFieldValue(P => P.InvCode, value); }
        }
        public string InvName
        {
            get { return base.GetFieldValue<string>(P => P.InvName); }
            set { base.SetFieldValue(P => P.InvName, value); }
        }
        public string Recourse
        {
            get { return base.GetFieldValue<string>(P => P.Recourse); }
            set { base.SetFieldValue(P => P.Recourse, value); }
        }
        public int Cycle
        {
            get { return base.GetFieldValue<int>(P => P.Cycle); }
            set { base.SetFieldValue(P => P.Cycle, value); }
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
