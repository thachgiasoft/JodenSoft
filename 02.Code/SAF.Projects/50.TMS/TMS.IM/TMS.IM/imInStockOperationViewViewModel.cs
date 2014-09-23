using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using TMS.Entities;
using SAF.EntityFramework;
using SAF.Foundation;

namespace TMS.IM
{
    public class imInStockOperationViewViewModel : MasterDetailViewViewModel<imInOutStockRoomOperationHdr, imInOutStockRoomOperationHdr, imInOutStockRoomOperationDtl>
    {
        public imInStockOperationView View { get; set; }
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
            this.DetailEntitySet.AfterAdd += DetailEntitySet_AfterAdd;
        }

        void DetailEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<imInOutStockRoomOperationDtl> e)
        {
            //throw new System.NotImplementedException();
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<imInOutStockRoomOperationHdr> e)
        {
            //throw new System.NotImplementedException();
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.sCreator = Session.Current.UserName;
            e.CurrentEntity.sBillNo = BillNoGenerator.NewBillNo(29,true,"","");
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sBillNo", "单据编号"));
        }

 

    }
}
