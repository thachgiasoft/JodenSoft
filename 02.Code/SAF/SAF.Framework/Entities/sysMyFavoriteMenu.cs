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

            this.TableName = "sysMyFavoriteMenu";
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

    }
}
