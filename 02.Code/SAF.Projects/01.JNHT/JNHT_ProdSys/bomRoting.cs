using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JNHT_ProdSys
{
    public class bomRoting : Entity<bomRoting>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "bomRoting";
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

        public string BomChildId
        {
            get { return base.GetFieldValue<string>(P => P.BomChildId); }
            set { base.SetFieldValue(P => P.BomChildId, value); }
        }
        public string RotingId
        {
            get { return base.GetFieldValue<string>(P => P.RotingId); }
            set { base.SetFieldValue(P => P.RotingId, value); }
        }
        public string RotingName
        {
            get { return base.GetFieldValue<string>(P => P.RotingName); }
            set { base.SetFieldValue(P => P.RotingName, value); }
        }
        public string RotingDesc
        {
            get { return base.GetFieldValue<string>(P => P.RotingDesc); }
            set { base.SetFieldValue(P => P.RotingDesc, value); }
        }
        public string RotingProduction
        {
            get { return base.GetFieldValue<string>(P => P.RotingProduction); }
            set { base.SetFieldValue(P => P.RotingProduction, value); }
        }
        public string FZMeterial
        {
            get { return base.GetFieldValue<string>(P => P.FZMeterial); }
            set { base.SetFieldValue(P => P.FZMeterial, value); }
        }
        public decimal ZhunJie
        {
            get { return base.GetFieldValue<decimal>(P => P.ZhunJie); }
            set { base.SetFieldValue(P => P.ZhunJie, value); }
        }
        public decimal DanJian
        {
            get { return base.GetFieldValue<decimal>(P => P.DanJian); }
            set { base.SetFieldValue(P => P.DanJian, value); }
        }

        public string Production
        {
            get { return base.GetFieldValue<string>(P => P.Production); }
            set { base.SetFieldValue(P => P.Production, value); }
        }
        public string OpDep
        {
            get { return base.GetFieldValue<string>(P => P.OpDep); }
            set { base.SetFieldValue(P => P.OpDep, value); }
        }
        public string define1
        {
            get { return base.GetFieldValue<string>(P => P.define1); }
            set { base.SetFieldValue(P => P.define1, value); }
        }
        public string define2
        {
            get { return base.GetFieldValue<string>(P => P.define2); }
            set { base.SetFieldValue(P => P.define2, value); }
        }
        public string define3
        {
            get { return base.GetFieldValue<string>(P => P.define3); }
            set { base.SetFieldValue(P => P.define3, value); }
        }
        public string define4
        {
            get { return base.GetFieldValue<string>(P => P.define4); }
            set { base.SetFieldValue(P => P.define4, value); }
        }
        public string define5
        {
            get { return base.GetFieldValue<string>(P => P.define5); }
            set { base.SetFieldValue(P => P.define5, value); }
        }
        public string define6
        {
            get { return base.GetFieldValue<string>(P => P.define6); }
            set { base.SetFieldValue(P => P.define6, value); }
        }
        public string define7
        {
            get { return base.GetFieldValue<string>(P => P.define7); }
            set { base.SetFieldValue(P => P.define7, value); }
        }
        public string define8
        {
            get { return base.GetFieldValue<string>(P => P.define8); }
            set { base.SetFieldValue(P => P.define8, value); }
        }
        public string define9
        {
            get { return base.GetFieldValue<string>(P => P.define9); }
            set { base.SetFieldValue(P => P.define9, value); }
        }
        public string define10
        {
            get { return base.GetFieldValue<string>(P => P.define10); }
            set { base.SetFieldValue(P => P.define10, value); }
        }



        #region 创建人&创建时间&修改人&修改时间&版本号

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

        #endregion
    }
}
