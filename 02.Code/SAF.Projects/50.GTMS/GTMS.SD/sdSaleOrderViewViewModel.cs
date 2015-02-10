using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using SAF.Foundation;
using GTMS.EntitySet;

namespace GTMS.SD
{
    public class sdSaleOrderViewViewModel : MasterDetailViewViewModel<sdSaleOrderHdr, sdSaleOrderHdr, sdSaleOrderDtl>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
           // base.OnQuery(sCondition, parameterValues);
            this.IndexEntitySet.Query(@"SELECT A.*,B.CustomerName
FROM dbo.sdSaleOrderHdr A WITH(NOLOCK) 
LEFT JOIN pbCustomer B WITH(NOLOCK) ON A.CustomerId=B.Iden WHERE {0} ".FormatEx(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            //base.OnQueryChild(key);
            this.MainEntitySet.Query(@"SELECT A.*,B.CustomerName
FROM dbo.sdSaleOrderHdr A WITH(NOLOCK) 
LEFT JOIN pbCustomer B WITH(NOLOCK) ON A.CustomerId=B.Iden WHERE A.Iden=:Iden ",key);
            this.DetailEntitySet.Query(@"SELECT * FROM dbo.sdSaleOrderDtl WITH(NOLOCK) WHERE HdrId=:HdrId  ",key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField() { Caption = "订单编号", FieldName = "OrderNo", IsDefault = true });
            queryConfig.QuickQuery.QueryFields.Add(new QueryField() { Caption = "客户编号", FieldName = "CustomerID" });
  
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
            DetailEntitySet.AfterAdd += DetailEntitySet_AfterAdd;
        }

        void DetailEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sdSaleOrderDtl> e)
        {
            //throw new NotImplementedException();
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.HdrId = MainEntitySet.CurrentEntity.Iden;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sdSaleOrderHdr> e)
        {
               // throw new NotImplementedException();
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.Qty = 0;
            e.CurrentEntity.Amount = 0;
            e.CurrentEntity.OrderNo = BillNoGenerator.NewBillNo("sdOrderNo",0);
        }
    }
}
