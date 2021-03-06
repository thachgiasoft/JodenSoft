﻿using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Entity
{
    public class sysReport : Entity<sysReport>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysReport";
            this.IdenGroup = "sysReport";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string Name
        {
            get { return base.GetFieldValue<string>(P => P.Name); }
            set { base.SetFieldValue(P => P.Name, value); }
        }

        public int ParentId
        {
            get { return base.GetFieldValue<int>(P => P.ParentId, 0); }
            set { base.SetFieldValue(P => P.ParentId, value); }
        }

        public int NodeType
        {
            get { return base.GetFieldValue<int>(P => P.NodeType, 0); }
            set { base.SetFieldValue(P => P.NodeType, value); }
        }

        public string SqlScript
        {
            get { return base.GetFieldValue<string>(P => P.SqlScript); }
            set { base.SetFieldValue(P => P.SqlScript, value); }
        }

        public string DataSetAlias
        {
            get { return base.GetFieldValue<string>(P => P.DataSetAlias); }
            set { base.SetFieldValue(P => P.DataSetAlias, value); }
        }

        public string ParamList
        {
            get { return base.GetFieldValue<string>(P => P.ParamList); }
            set { base.SetFieldValue(P => P.ParamList, value); }
        }

        public string ParamValueList
        {
            get { return base.GetFieldValue<string>(P => P.ParamValueList); }
            set { base.SetFieldValue(P => P.ParamValueList, value); }
        }

        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(P => P.IsActive); }
            set { base.SetFieldValue(P => P.IsActive, value); }
        }
    }
}
