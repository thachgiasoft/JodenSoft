using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls;
using SAF.Foundation;
using SAF.EntityFramework;

namespace SAF.Test
{
    public class sdOrderViewViewModel : MasterDetailViewViewModel<sdOrder, sdOrder, sdOrderDtl>
    {
        public override int BillTypeId
        {
            get
            {
                return 4;
            }
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            this.MainEntitySet.QueryBillRight(this.BillTypeId);
        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            var rightFilter = "/*QueryRight(a)*/";
            rightFilter = BillRight.CalcBillQueryRight(rightFilter, this.BillTypeId, Session.UserInfo.UserId);

            string sql = @"
--查询时要查出 CreatedBy,OrganizationId,OrganizationCode,三个字段缺一不可.
with result as
(           
SELECT A.*,OrganizationCode=[dbo].[sysGetOrganizationCode](a.OrganizationId)
FROM dbo.sdOrder a WITH(NOLOCK) 
)

SELECT Iden, OrderNo
FROM result A
WHERE ({0}){1}
".FormatWith(sCondition, rightFilter);
            this.IndexEntitySet.Query(sql);

        }

        protected override void OnQueryChild(object key)
        {
            string mainSql = @"
SELECT a.*,OrganizationName= b.Name,OrganizationCode=b.Code
FROM dbo.sdOrder a WITH(NOLOCK)
LEFT JOIN dbo.sysOrganization b WITH(NOLOCK) ON a.OrganizationId=b.Iden
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
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.OrderId = this.MainEntitySet.CurrentEntity.Iden;
            e.CurrentEntity.Qty = 0;
        }

        void MainEntitySet_AfterAdd(object sender, EntityFramework.EntitySetAddEventArgs<sdOrder> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            //其他字段也可以在这里赋值
        }
    }
}
