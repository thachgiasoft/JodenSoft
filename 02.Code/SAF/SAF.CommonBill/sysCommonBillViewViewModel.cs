using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntities;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;

namespace SAF.CommonBill
{
    public class sysCommonBillViewViewModel : MasterDetailViewViewModel<sysCommonBillConfig, sysCommonBillConfig, sysCommonBillConfig>
    {
        public CommonBillConfig QueryBillConfg(object key)
        {
            string sql = @"
SELECT a.Iden,a.Config,a.CreatedBy,a.CreatedOn,a.ModifiedBy,a.ModifiedOn,a.VersionNumber
FROM dbo.sysCommonBillConfig a WITH(NOLOCK)
WHERE Iden=:Iden";
            IndexEntitySet.Query(sql, key);

            if (IndexEntitySet.CurrentEntity == null || IndexEntitySet.CurrentEntity.Config.IsEmpty())
                return null;

            return XmlSerializerHelper.Deserialize<CommonBillConfig>(IndexEntitySet.CurrentEntity.Config);


        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {

        }

        protected override void OnQueryChild(object key)
        {

        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {

        }
    }
}
