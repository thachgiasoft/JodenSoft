using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JNHT_ProdSys
{
    public class woOrder : Entity<woOrder>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "woOrder";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public string BomId
        {
            get { return base.GetFieldValue<string>(P => P.BomId); }
            set { base.SetFieldValue(P => P.BomId, value); }
        }

        public string WoCode
        {
            get { return base.GetFieldValue<string>(P => P.WoCode); }
            set { base.SetFieldValue(P => P.WoCode, value); }
        }

        public int WoVersion
        {
            get { return base.GetFieldValue<int>(P => P.WoVersion); }
            set { base.SetFieldValue(P => P.WoVersion, value); }
        }
        public string CParentId
        {
            get { return base.GetFieldValue<string>(P => P.CParentId); }
            set { base.SetFieldValue(P => P.CParentId, value); }
        }
        public string CParentName
        {
            get { return base.GetFieldValue<string>(P => P.CParentName); }
            set { base.SetFieldValue(P => P.CParentName, value); }
        }
        public decimal Qty
        {
            get { return base.GetFieldValue<decimal>(P => P.Qty); }
            set { base.SetFieldValue(P => P.Qty, value); }
        }
        public string IsClose
        {
            get { return base.GetFieldValue<string>(P => P.IsClose); }
            set { base.SetFieldValue(P => P.IsClose, value); }
        }
        public string Cdefine1
        {
            get { return base.GetFieldValue<string>(P => P.Cdefine1); }
            set { base.SetFieldValue(P => P.Cdefine1, value); }
        }
        public string Cdefine2
        {
            get { return base.GetFieldValue<string>(P => P.Cdefine2); }
            set { base.SetFieldValue(P => P.Cdefine2, value); }
        }
        public string Cdefine3
        {
            get { return base.GetFieldValue<string>(P => P.Cdefine3); }
            set { base.SetFieldValue(P => P.Cdefine3, value); }
        }
        public int Cdefine4
        {
            get { return base.GetFieldValue<int>(P => P.Cdefine4); }
            set { base.SetFieldValue(P => P.Cdefine4, value); }
        }

        public decimal Cdefine5
        {
            get { return base.GetFieldValue<decimal>(P => P.Cdefine5); }
            set { base.SetFieldValue(P => P.Cdefine5, value); }
        }

        public int OrganizationId
        {
            get { return base.GetFieldValue<int>(P => P.OrganizationId); }
            set { base.SetFieldValue(P => P.OrganizationId, value); }
        }
        //#region 创建人&创建时间&修改人&修改时间&版本号

        //public int? CreatedBy
        //{
        //    get { return base.GetFieldValue<int?>(p => p.CreatedBy, null); }
        //    set { base.SetFieldValue(p => p.CreatedBy, value); }
        //}
        //public DateTime? CreatedOn
        //{
        //    get { return base.GetFieldValue<DateTime?>(p => p.CreatedOn, null); }
        //    set { base.SetFieldValue(p => p.CreatedOn, value); }
        //}

        //public int? ModifiedBy
        //{
        //    get { return base.GetFieldValue<int?>(p => p.ModifiedBy, null); }
        //    set { base.SetFieldValue(p => p.ModifiedBy, value); }
        //}
        //public DateTime? ModifiedOn
        //{
        //    get { return base.GetFieldValue<DateTime?>(p => p.ModifiedOn, null); }
        //    set { base.SetFieldValue(p => p.ModifiedOn, value); }
        //}
        //public int VersionNumber
        //{
        //    get { return base.GetFieldValue<int>(p => p.VersionNumber, 0); }
        //}

        //#endregion
    }
}
