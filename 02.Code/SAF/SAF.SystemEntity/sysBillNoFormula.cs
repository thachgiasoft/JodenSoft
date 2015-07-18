using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntity
{
    public class sysBillNoFormula : Entity<sysBillNoFormula>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysBillNoFormula";
            this.IdenGroup = "sysBillNoFormula";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

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

    }
}
