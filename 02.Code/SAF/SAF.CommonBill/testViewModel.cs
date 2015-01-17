using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.CommonConfig.Entities;
using SAF.Framework.Controls.ViewConfig;

namespace SAF.CommonConfig
{
    public class testViewModel : MasterDetailViewViewModel<TIndexEntity, TMainEntity, TDetailEntity>
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
