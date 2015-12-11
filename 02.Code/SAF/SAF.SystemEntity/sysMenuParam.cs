using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.SystemEntity
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

        public string Category
        {
            get { return base.GetFieldValue<string>(P => P.Category); }
            set
            {
                if (value.IsEmpty())
                    base.SetFieldValue(p => p.Category, "通用配置");
                else
                    base.SetFieldValue(P => P.Category, value);
            }
        }

        public int ControlType
        {
            get { return base.GetFieldValue<int>(P => P.ControlType); }
            set { base.SetFieldValue(P => P.ControlType, value); }
        }

        public object Value
        {
            get { return base.GetFieldValue<object>(P => P.Value); }
            set { base.SetFieldValue(P => P.Value, value); }
        }

        public string ValueAlias
        {
            get { return base.GetFieldValue<string>(P => P.ValueAlias); }
            set { base.SetFieldValue(P => P.ValueAlias, value); }
        }


        public string Description
        {
            get { return base.GetFieldValue<string>(P => P.Description); }
            set { base.SetFieldValue(P => P.Description, value); }
        }

    }
}
