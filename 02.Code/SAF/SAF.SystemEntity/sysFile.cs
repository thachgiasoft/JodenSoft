using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAF.SystemEntity
{
    public class sysFile : Entity<sysFile>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysFile";
            this.IdenGroup = "sysFile";
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

        public bool IsSystem
        {
            get { return base.GetFieldValue<bool>(p => p.IsSystem); }
            set { base.SetFieldValue(p => p.IsSystem, value); }
        }
    }
}
