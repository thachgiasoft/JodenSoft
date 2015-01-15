using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSDProdPlan
{
    public class sysBillNoFormula : Entity<sysBillNoFormula>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysBillNoFormula";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public string BillNoType
        {
            get { return base.GetFieldValue<string>(P => P.BillNoType); }
            set { base.SetFieldValue(P => P.BillNoType, value); }
        }
        public string ResetType
        {
            get { return base.GetFieldValue<string>(P => P.ResetType); }
            set { base.SetFieldValue(P => P.ResetType, value); }
        }
        public string Separator
        {
            get { return base.GetFieldValue<string>(P => P.Separator); }
            set { base.SetFieldValue(P => P.Separator, value); }
        }
        public string Prefix
        {
            get { return base.GetFieldValue<string>(P => P.Prefix); }
            set { base.SetFieldValue(P => P.Prefix, value); }
        }
        public string YearFormat
        {
            get { return base.GetFieldValue<string>(P => P.YearFormat); }
            set { base.SetFieldValue(P => P.YearFormat, value); }
        }
        public string MonthFormat
        {
            get { return base.GetFieldValue<string>(P => P.MonthFormat); }
            set { base.SetFieldValue(P => P.MonthFormat, value); }
        }
        public string DayFormat
        {
            get { return base.GetFieldValue<string>(P => P.DayFormat); }
            set { base.SetFieldValue(P => P.DayFormat, value); }
        }
        public string Midfix
        {
            get { return base.GetFieldValue<string>(P => P.Midfix); }
            set { base.SetFieldValue(P => P.Midfix, value); }
        }
        public int CurrentIden
        {
            get { return base.GetFieldValue<int>(P => P.CurrentIden); }
            set { base.SetFieldValue(P => P.CurrentIden, value); }
        }
        public int IdenLength
        {
            get { return base.GetFieldValue<int>(P => P.IdenLength); }
            set { base.SetFieldValue(P => P.IdenLength, value); }
        }
        public DateTime CurrentDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.CurrentDate); }
            set { base.SetFieldValue(P => P.CurrentDate, value); }
        }
        public string Suffix
        {
            get { return base.GetFieldValue<string>(P => P.Suffix); }
            set { base.SetFieldValue(P => P.Suffix, value); }
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
