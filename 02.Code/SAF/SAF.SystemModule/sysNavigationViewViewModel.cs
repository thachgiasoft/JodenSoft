using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntities;

namespace SAF.SystemModule
{
    public class sysNavigationViewViewModel : SingleViewViewModel<sysMenuChart, sysMenuChart>
    {

        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            this.IndexEntitySet.PageSize = 0;
        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            this.IndexEntitySet.Query("select * from sysMenuChart with(nolock)");
        }

        protected override void OnQueryChild(object key)
        {

        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
        }
    }
}
