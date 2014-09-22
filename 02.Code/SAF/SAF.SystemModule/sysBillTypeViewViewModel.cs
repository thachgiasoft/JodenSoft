using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntities;

namespace SAF.SystemModule
{
    public class sysBillTypeViewViewModel : MasterDetailViewViewModel<sysRole, sysRole, sysRole>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
        }
    }
}
