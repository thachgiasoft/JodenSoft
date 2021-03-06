﻿using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSDProdPlan
{
    public class jdProdetail : Entity<jdProdetail>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "jdProdetail";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public string MoCode
        {
            get { return base.GetFieldValue<string>(P => P.MoCode); }
            set { base.SetFieldValue(P => P.MoCode, value); }
        }
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
        public string Resources
        {
            get { return base.GetFieldValue<string>(P => P.Resources); }
            set { base.SetFieldValue(P => P.Resources, value); }
        }
        public string ProCode
        {
            get { return base.GetFieldValue<string>(P => P.ProCode); }
            set { base.SetFieldValue(P => P.ProCode, value); }
        }
        public string ProName
        {
            get { return base.GetFieldValue<string>(P => P.ProName); }
            set { base.SetFieldValue(P => P.ProName, value); }
        }
        public int Resources_Qty
        {
            get { return base.GetFieldValue<int>(P => P.Resources_Qty); }
            set { base.SetFieldValue(P => P.Resources_Qty, value); }
        }
        public int Work_Time
        {
            get { return base.GetFieldValue<int>(P => P.Work_Time); }
            set { base.SetFieldValue(P => P.Work_Time, value); }
        }
        public DateTime StartDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.StartDate); }
            set { base.SetFieldValue(P => P.StartDate, value); }
        }
        public DateTime EndDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.EndDate); }
            set { base.SetFieldValue(P => P.EndDate, value); }
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
