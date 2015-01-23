using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using SAF.Foundation;
using SAF.Foundation.ServiceModel;
using GTMS.EntitySet;


namespace GTMS.IM
{
    public class imStoreManageViewViewModel : SingleViewViewModel<imStore, imStore>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            //base.OnQuery(sCondition, parameterValues);
            this.IndexEntitySet.Query("SELECT * FROM imStore A WITH(NOLOCK) WHERE ({0})".FormatEx(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            //base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT * FROM imStore A WITH(NOLOCK) WHERE Iden=:Iden", key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
           // base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("StoreNo", "仓库编号"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("StoreName", "仓库名称"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("StoreType", "仓库类别"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<imStore> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.Usabled = true;
        }

  

    }
}
