using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Entities
{
    public class sysMyFavoriteMenu : Entity<sysMyFavoriteMenu>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "sysMyFavoriteMenu";
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

        public int UserId
        {
            get { return base.GetFieldValue<int>(P => P.UserId); }
            set { base.SetFieldValue(P => P.UserId, value); }
        }

        public int RowNumber
        {
            get { return base.GetFieldValue<int>(P => P.RowNumber); }
            set { base.SetFieldValue(P => P.RowNumber, value); }
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
        public VersionNumber VersionNumber
        {
            get { return new VersionNumber(base.GetFieldValue<byte[]>(p => p.VersionNumber)); }
        }

        #endregion
    }
}
