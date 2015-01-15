using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;

namespace SAF.Test
{
    public class sdOrderViewViewModel : MasterDetailViewViewModel<sdOrder, sdOrder, sdOrderDtl>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            string sql = "SELECT Iden,OrderNo FROM dbo.sdOrder WITH(NOLOCK) WHERE ({0})".FormatEx(sCondition);
            this.IndexEntitySet.Query(sql);
        }

        protected override void OnQueryChild(object key)
        {
            string mainSql = @"
SELECT a.*,OrganiaztionName= b.Name
FROM dbo.sdOrder a WITH(NOLOCK)
LEFT JOIN dbo.sysOrganization b WITH(NOLOCK) ON a.OrganiaztionId=b.Iden
WHERE A.Iden=:Iden
ORDER BY A.Iden";
            this.MainEntitySet.Query(mainSql, key);

            string dtlSql = @"SELECT * FROM dbo.sdOrderDtl WHERE OrderId=:OrderId";
            this.DetailEntitySet.Query(dtlSql, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);

            queryConfig.QuickQuery.QueryFields.Add(new QueryField("OrderNo", "订单号"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
            this.DetailEntitySet.AfterAdd += DetailEntitySet_AfterAdd;
        }

        void DetailEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sdOrderDtl> e)
        {
            //子表的字段赋值
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.OrderId = this.MainEntitySet.CurrentEntity.Iden;
            e.CurrentEntity.Qty = 0;
        }

        void MainEntitySet_AfterAdd(object sender, EntityFramework.EntitySetAddEventArgs<sdOrder> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            //其他字段也可以在这里赋值
        }
    }
}
