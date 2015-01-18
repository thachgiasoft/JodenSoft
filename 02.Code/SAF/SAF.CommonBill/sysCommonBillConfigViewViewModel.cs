using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;

namespace SAF.CommonBill
{
    public class sysCommonBillConfigViewViewModel : SingleViewViewModel<sysCommonBillConfig, sysCommonBillConfig>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            string sql = "SELECT a.Iden,a.Name FROM dbo.sysCommonBillConfig a WITH(NOLOCK) where ({0})".FormatEx(sCondition);
            this.IndexEntitySet.Query(sql);
        }

        protected override void OnQueryChild(object key)
        {
            string sql = "SELECT a.* FROM dbo.sysCommonBillConfig a WITH(NOLOCK) WHERE A.Iden=:Iden";
            this.MainEntitySet.Query(sql, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Name", "名称"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Iden", "序号"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntityFramework.EntitySetAddEventArgs<sysCommonBillConfig> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.Name = string.Empty;
            e.CurrentEntity.Config = string.Empty;
        }
    }
}
