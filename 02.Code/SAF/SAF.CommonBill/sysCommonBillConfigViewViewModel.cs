using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntities;
using SAF.EntityFramework;

namespace SAF.CommonConfig
{
    public class sysCommonBillConfigViewViewModel : MasterDetailViewViewModel<sdOrder, sdOrder, sdOrderDtl>
    {

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            this.IndexEntitySet.Query("select * from sdOrder");
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);

            this.MainEntitySet.Query("select * from sdOrder where iden=:iden", key);
            this.DetailEntitySet.Query("select * from sdOrderDtl where orderId=:orderId", key);
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
            this.DetailEntitySet.AfterAdd += DetailEntitySet_AfterAdd;
        }

        void DetailEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sdOrderDtl> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.OrderId = this.MainEntitySet.CurrentEntity.Iden;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sdOrder> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
        }
    }
}
