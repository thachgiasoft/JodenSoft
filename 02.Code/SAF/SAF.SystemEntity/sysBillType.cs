using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntity
{
    public class sysBillType : Entity<sysBillType>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysBillType";
            this.IdenGroup = "sysBillType";
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

        public string Remark
        {
            get { return base.GetFieldValue<string>(P => P.Remark); }
            set { base.SetFieldValue(P => P.Remark, value); }
        }

        public bool IsActive
        {
            get { return base.GetFieldValue<bool>(P => P.IsActive); }
            set { base.SetFieldValue(P => P.IsActive, value); }
        }

        public bool IsSystem
        {
            get { return base.GetFieldValue<bool>(P => P.IsSystem); }
            set { base.SetFieldValue(P => P.IsSystem, value); }
        }

        public bool UseBillOperateRight
        {
            get { return base.GetFieldValue<bool>(P => P.UseBillOperateRight); }
            set { base.SetFieldValue(P => P.UseBillOperateRight, value); }
        }

        public bool UseBillDataRight
        {
            get { return base.GetFieldValue<bool>(P => P.UseBillDataRight); }
            set { base.SetFieldValue(P => P.UseBillDataRight, value); }
        }

        
    }
}
