using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using SAF.Foundation;

namespace JNHT_ProdSys
{
    public class sctzViewViewModel : SingleViewViewModel<QueryEntity, QueryEntity>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT distinct Iden=0, BomId  from bomParent with(nolock) where ({0})".FormatEx(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            MainEntitySet.PageSize = 0;
            base.OnQueryChild(key);
           // var bomId = this.IndexEntitySet.CurrentEntity == null ? string.Empty : this.IndexEntitySet.CurrentEntity.BomId;
            //MainEntitySet.Query("exec jd_p_sctz  @bomid='0'");
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
        }
    }
}
