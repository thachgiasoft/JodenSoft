﻿using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAF.SystemEntity
{

    public class sysBusinessView : Entity<sysBusinessView>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysBusinessView";
            this.IdenGroup = "sysBusinessView";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }
        public string ClassName
        {
            get { return base.GetFieldValue<string>(p => p.ClassName); }
            set { base.SetFieldValue(p => p.ClassName, value); }
        }

        public string Description
        {
            get { return base.GetFieldValue<string>(p => p.Description); }
            set { base.SetFieldValue(p => p.Description, value); }
        }

        public int FileId
        {
            get { return base.GetFieldValue<int>(P => P.FileId); }
            set { base.SetFieldValue(P => P.FileId, value); }
        }
        public string Remark
        {
            get { return base.GetFieldValue<string>(p => p.Remark); }
            set { base.SetFieldValue(p => p.Remark, value); }
        }
        public bool IsDeleted
        {
            get { return base.GetFieldValue<bool>(p => p.IsDeleted); }
            set { base.SetFieldValue(p => p.IsDeleted, value); }
        }
       
    }
}
