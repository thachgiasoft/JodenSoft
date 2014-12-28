using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysFile : Entity<sysFile>
    {
        protected override void OnInit()
        {
            base.OnInit();
            this.DbTableName = "sysFile";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }
        public string Name
        {
            get { return base.GetFieldValue<string>(p => p.Name); }
            set { base.SetFieldValue(p => p.Name, value); }
        }
        public string FileName
        {
            get { return base.GetFieldValue<string>(p => p.FileName); }
            set { base.SetFieldValue(p => p.FileName, value); }
        }

        public string FileVersion
        {
            get { return base.GetFieldValue<string>(p => p.FileVersion); }
            set { base.SetFieldValue(p => p.FileVersion, value); }
        }
        public string FileSize
        {
            get { return base.GetFieldValue<string>(p => p.FileSize); }
            set { base.SetFieldValue(p => p.FileSize, value); }
        }
        public byte[] FileData
        {
            get { return base.GetFieldValue<byte[]>(p => p.FileData); }
            set { base.SetFieldValue(p => p.FileData, value); }
        }
        public DateTime LastWriteTime
        {
            get { return base.GetFieldValue<DateTime>(p => p.LastWriteTime); }
            set { base.SetFieldValue(p => p.LastWriteTime, value); }
        }

        public string Remark
        {
            get { return base.GetFieldValue<string>(p => p.Remark); }
            set { base.SetFieldValue(p => p.Remark, value); }
        }

        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(p => p.IsActive); }
            set { base.SetFieldValue(p => p.IsActive, value); }
        }

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
    }
}
