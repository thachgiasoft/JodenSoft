using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysTableColumn : Entity<sysTableColumn>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysTableColumn";
            this.PrimaryKey = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string TableName
        {
            get { return base.GetFieldValue<string>(P => P.TableName); }
            set { base.SetFieldValue(P => P.TableName, value); }
        }

        public string ColumnName
        {
            get { return base.GetFieldValue<string>(P => P.ColumnName); }
            set { base.SetFieldValue(P => P.ColumnName, value); }
        }

        public string InsertDefaultValue
        {
            get { return base.GetFieldValue<string>(P => P.InsertDefaultValue); }
            set { base.SetFieldValue(P => P.InsertDefaultValue, value); }
        }

        public string UpdateDefaultValue
        {
            get { return base.GetFieldValue<string>(P => P.UpdateDefaultValue); }
            set { base.SetFieldValue(P => P.UpdateDefaultValue, value); }
        }

        
    }
}
