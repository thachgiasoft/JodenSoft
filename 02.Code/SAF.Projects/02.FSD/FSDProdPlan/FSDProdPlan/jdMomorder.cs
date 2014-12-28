using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSDProdPlan
{
    public class jdMomorder : Entity<jdMomorder>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "jdMomorder";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }
        
        //TODO:添加其他字段
        public string MoType
        {
            get { return base.GetFieldValue<string>(P => P.MoType); }
            set { base.SetFieldValue(P => P.MoType, value); }
        }
        public string MoCode
        {
            get { return base.GetFieldValue<string>(P => P.MoCode); }
            set { base.SetFieldValue(P => P.MoCode, value); }
        }
        public string InvCode
        {
            get { return base.GetFieldValue<string>(P => P.InvCode); }
            set { base.SetFieldValue(P => P.InvCode, value); }
        }
        public string InvName
        {
            get { return base.GetFieldValue<string>(P => P.InvName); }
            set { base.SetFieldValue(P => P.InvName, value); }
        }
        public int Qty
        {
            get { return base.GetFieldValue<int>(P => P.Qty); }
            set { base.SetFieldValue(P => P.Qty, value); }
        }
        public DateTime StartDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.StartDate); }
            set { base.SetFieldValue(P => P.StartDate, value); }
        }
        public DateTime EndDate
        {
            get { return base.GetFieldValue<DateTime>(P => P.EndDate); }
            set { base.SetFieldValue(P => P.EndDate, value); }
        }
        public int LineNumber
        {
            get { return base.GetFieldValue<int>(P => P.LineNumber); }
            set { base.SetFieldValue(P => P.LineNumber, value); }
        }
        public string State
        {
            get { return base.GetFieldValue<string>(P => P.State); }
            set { base.SetFieldValue(P => P.State, value); }
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
