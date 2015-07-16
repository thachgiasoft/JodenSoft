using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Entities
{
    public class sysReportConfigFormat : Entity<sysReportConfigFormat>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysReportConfigFormat";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public int ReportConfigId
        {
            get { return base.GetFieldValue<int>(P => P.ReportConfigId); }
            set { base.SetFieldValue(P => P.ReportConfigId, value); }
        }

        public int RowNo
        {
            get { return base.GetFieldValue<int>(P => P.RowNo); }
            set { base.SetFieldValue(P => P.RowNo, value); }
        }

        public string Name
        {
            get { return base.GetFieldValue<string>(P => P.Name); }
            set { base.SetFieldValue(P => P.Name, value); }
        }

        public byte[] FormatData
        {
            get { return base.GetFieldValue<byte[]>(P => P.FormatData); }
            set { base.SetFieldValue(P => P.FormatData, value); }
        }

        public bool IsDefault
        {
            get { return base.GetFieldValue<bool>(P => P.IsDefault); }
            set { base.SetFieldValue(P => P.IsDefault, value); }
        }

        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(P => P.IsActive); }
            set { base.SetFieldValue(P => P.IsActive, value); }
        }


    }
}
