using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using TMS.Entities;
using SAF.Foundation;
using SAF.EntityFramework;

namespace TMS.IM
{
    public class ImStoreViewViewModel : SingleViewViewModel<imStore, imStore>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            //base.OnQuery(sCondition, parameterValues);

            this.IndexEntitySet.Query("SELECT * FROM imStore where ({0})".FormatEx(sCondition));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;           
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<imStore> e)
        {
           // throw new NotImplementedException();
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.sCreator = Session.Current.UserName;
            e.CurrentEntity.bUsable = true;

        }


        protected override void OnQueryChild(object key)
        {
            //base.OnQueryChild(key);

            this.MainEntitySet.Query("select * from imStore WHERE Iden=:iden", key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
           // base.OnInitQueryConfig(queryConfig);

            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sStoreName", "名称"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sStoreNo", "编号"));
        }
    }
}
