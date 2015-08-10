using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JNHT_ProdSys
{
    public class jd_v_inventory : Entity<jd_v_inventory>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "jd_v_inventory";
            this.PrimaryKeyName = "Iden";
        }

        public long Iden
        {
            get { return base.GetFieldValue<long>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public string 存货编码
        {
            get { return base.GetFieldValue<string>(P => P.存货编码); }
            set { base.SetFieldValue(P => P.存货编码, value); }
        }

        public string  存货名称
        {
            get { return base.GetFieldValue<string>(P => P.存货名称); }
            set { base.SetFieldValue(P => P.存货名称, value); }
        }

        public string 存货名称2
        {
            get { return base.GetFieldValue<string>(P => P.存货名称2); }
            set { base.SetFieldValue(P => P.存货名称2, value); }
        }
        public string 单位
        {
            get { return base.GetFieldValue<string>(P => P.单位); }
            set { base.SetFieldValue(P => P.单位, value); }
        }

        public decimal 现存量
        {
            get { return base.GetFieldValue<decimal>(P => P.现存量); }
            set { base.SetFieldValue(P => P.现存量, value); }
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

        public DateTime? ModifiedBy
        {
            get { return base.GetFieldValue<DateTime?>(p => p.ModifiedBy, null); }
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
