using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntities;

namespace SAF.SystemModule
{
    public class sysMenuSelectorViewModel : SingleViewViewModel<sysMenu, sysMenu>
    {
        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            this.IndexEntitySet.PageSize = 0;

            
        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            string sql = @"SELECT Iden,Name,ParentId,BusinessViewId 
                           FROM dbo.sysMenu WITH(NOLOCK) 
                           ORDER BY ParentId ,MenuOrder";
            this.IndexEntitySet.Query(sql);
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
