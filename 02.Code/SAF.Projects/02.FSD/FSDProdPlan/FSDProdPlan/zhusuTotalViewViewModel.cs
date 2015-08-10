using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;

namespace FSDProdPlan
{
    public class zhusuTotalViewViewModel : SingleViewViewModel<QueryEntity, QueryEntity>
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
