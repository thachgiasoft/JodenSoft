using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysMenu : Entity<sysMenu>
    {
        protected override void OnInit()
        {
            base.OnInit();
            this.DbTableName = "sysMenu";
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
        public int ParentId
        {
            get { return base.GetFieldValue<int>(P => P.ParentId); }
            set { base.SetFieldValue(P => P.ParentId, value); }
        }
        public int? BusinessViewId
        {
            get { return base.GetFieldValue<int?>(P => P.BusinessViewId); }
            set { base.SetFieldValue(P => P.BusinessViewId, value); }
        }
        public int MenuOrder
        {
            get { return base.GetFieldValue<int>(P => P.MenuOrder); }
            set { base.SetFieldValue(P => P.MenuOrder, value); }
        }
        public string Remark
        {
            get { return base.GetFieldValue<string>(p => p.Remark); }
            set { base.SetFieldValue(p => p.Remark, value); }
        }
        public bool IsSystem
        {
            get { return base.GetFieldValue<bool>(p => p.IsSystem); }
            set { base.SetFieldValue(p => p.IsSystem, value); }
        }
        public bool IsAutoOpen
        {
            get { return base.GetFieldValue<bool>(p => p.IsAutoOpen); }
            set { base.SetFieldValue(p => p.IsAutoOpen, value); }
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
        public int VersionNumber
        {
            get { return base.GetFieldValue<int>(p => p.VersionNumber, 0); }
        }


    }
}
