﻿using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Entities
{
    public class sysRegInfo : Entity<sysRegInfo>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysRegInfo";
            this.PrimaryKey = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string ProductId
        {
            get { return base.GetFieldValue<string>(P => P.ProductId); }
            set { base.SetFieldValue(P => P.ProductId, value); }
        }

        public string ComputerName
        {
            get { return base.GetFieldValue<string>(P => P.ComputerName); }
            set { base.SetFieldValue(P => P.ComputerName, value); }
        }

        public string ComputerUserName
        {
            get { return base.GetFieldValue<string>(P => P.ComputerUserName); }
            set { base.SetFieldValue(P => P.ComputerUserName, value); }
        }
        public string RegInfo
        {
            get { return base.GetFieldValue<string>(P => P.RegInfo); }
            set { base.SetFieldValue(P => P.RegInfo, value); }
        }
        public DateTime LastLoginTime
        {
            get { return base.GetFieldValue<DateTime>(P => P.LastLoginTime); }
            set { base.SetFieldValue(P => P.LastLoginTime, value); }
        }
        public string Remark
        {
            get { return base.GetFieldValue<string>(P => P.Remark); }
            set { base.SetFieldValue(P => P.Remark, value); }
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

        public DateTime? ModifiedBy
        {
            get { return base.GetFieldValue<DateTime?>(p => p.ModifiedBy, null); }
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
    }
}
