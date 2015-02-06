using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntities;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using SAF.EntityFramework;

namespace SAF.CommonConfig
{
    public class sysCommonBillViewViewModel : MasterDetailViewViewModel<QueryEntity, QueryEntity, QueryEntity>
    {
        public sysCommonBillView View { get; set; }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            if (!View.CommonBillConfig.IndexEntitySetConfig.SqlScript.IsEmpty())
                IndexEntitySet.Query(View.CommonBillConfig.IndexEntitySetConfig.SqlScript);
        }

        protected override void OnQueryChild(object key)
        {
            if (!View.CommonBillConfig.MainEntitySetConfig.SqlScript.IsEmpty())
                this.MainEntitySet.Query(View.CommonBillConfig.MainEntitySetConfig.SqlScript, key);

            for (int i = 0; i < View.dtlEntitys.Count; i++)
            {
                var config = View.CommonBillConfig.DetailEntitySetConfigs[i];
                if (!config.SqlScript.IsEmpty())
                {
                    View.dtlEntitys[i].Query(config.SqlScript, key);
                }
            }
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery = View.CommonBillConfig.QueryConfig.QuickQuery;
        }
    }
}
