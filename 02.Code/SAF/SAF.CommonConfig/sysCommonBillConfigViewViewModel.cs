using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntities;
using SAF.EntityFramework;

namespace SAF.CommonConfig
{
    public class sysCommonBillConfigViewViewModel : MasterDetailViewViewModel<sysCommonBillHdr, sysCommonBillHdr, sysCommonBillHdrField>
    {
        private EntitySet<SAF.SystemEntities.sysUser> _user = null;

        public EntitySet<SAF.SystemEntities.sysUser> User
        {
            get
            {
                if (_user == null)
                    _user = new EntitySet<SystemEntities.sysUser>();
                return _user;
            }
        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            //base.OnQuery(sCondition, parameterValues);

            this.IndexEntitySet.Query("select * from sysCommonBillHdr");

            User.Query("select Iden, UserName from sysUser");

        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);

            this.MainEntitySet.Query("select * from sysCommonBillHdr");
            this.DetailEntitySet.Query("select * from sysCommonBillHdr");
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
        }
    }
}
