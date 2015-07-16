﻿using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysMenuParam : Entity<sysMenuParam>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysMenuParam";
            this.IdenGroup = "sysMenuParam";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public int MenuId
        {
            get { return base.GetFieldValue<int>(P => P.MenuId); }
            set { base.SetFieldValue(P => P.MenuId, value); }
        }

        public string Name
        {
            get { return base.GetFieldValue<string>(P => P.Name); }
            set { base.SetFieldValue(P => P.Name, value); }
        }

        public string Value
        {
            get { return base.GetFieldValue<string>(P => P.Value); }
            set { base.SetFieldValue(P => P.Value, value); }
        }

        public string Description
        {
            get { return base.GetFieldValue<string>(P => P.Description); }
            set { base.SetFieldValue(P => P.Description, value); }
        }

    }
}
