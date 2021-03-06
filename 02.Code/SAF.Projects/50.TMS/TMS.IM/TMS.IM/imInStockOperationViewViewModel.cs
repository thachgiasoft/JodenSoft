﻿using SAF.Framework.ViewModel;
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
            this.IndexEntitySet.Query("SELECT * FROM imInOutStockRoomOperationHdr A WITH(NOLOCK) WHERE ({0})".FormatEx(sCondition));
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
            e.CurrentEntity.HdrID = this.MainEntitySet.CurrentEntity.Iden;
            
                        
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<imInOutStockRoomOperationHdr> e)
        {
            //throw new System.NotImplementedException();
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.sCreator = Session.Current.UserName;
            e.CurrentEntity.sBillNo=BillNoGenerator.NewBillNo("sStoreInNo", "I+2");
            //e.CurrentEntity.sBillNo = BillNoGenerator.NewBillNo(27, true, "[RO]+[2位年]+[2位月]+[2位日]+[4位流水号]", "[RO]+[2位年]+[2位月]+[2位日]+[4位流水号]");
            e.CurrentEntity.sStatus = "正常";
            e.CurrentEntity.iStoreID = 0;
            e.CurrentEntity.iStoreInOutType = 0;       
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT *FROM dbo.imInOutStockRoomOperationHdr A WITH(NOLOCK) WHERE Iden=:Iden", key);
            this.DetailEntitySet.Query("SELECT * FROM dbo.imInOutStockRoomOperationDtl A WITH(NOLOCK) WHERE HdrID=:HdrID", key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sBillNo", "单据编号"));
        }

 

    }
}
