using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JNHT_ProdSys
{
    public class jd_v_parentid : Entity<jd_v_parentid>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "jd_v_parentid";
            this.PrimaryKeyName = "Iden";
        }

        public long Iden
        {
            get { return base.GetFieldValue<long>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
        public string 产品代号
        {
            get { return base.GetFieldValue<string>(P => P.产品代号); }
            set { base.SetFieldValue(P => P.产品代号, value); }
        }

        public string 产品名称
        {
            get { return base.GetFieldValue<string>(P => P.产品名称); }
            set { base.SetFieldValue(P => P.产品名称, value); }
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
