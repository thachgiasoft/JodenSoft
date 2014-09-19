using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using TMS.Entities;
using SAF.EntityFramework;
using SAF.Foundation;

namespace TMS.IM
{
    public class imStoreInOutTypeViewViewModel : SingleViewViewModel<imStoreInOutType, imStoreInOutType>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            //base.OnQuery(sCondition, parameterValues);
            this.IndexEntitySet.Query("SELECT * FROM imStoreInOutType A WITH(NOLOCK) WHERE ({0})".FormatEx(sCondition));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;     
        }

        protected override void OnInit()
        {
            base.OnInit();
        }

        void MainEntitySet_AfterAdd(object sender, SAF.EntityFramework.EntitySetAddEventArgs<imStoreInOutType> e)
        {
            //throw new NotImplementedException();
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.sCreator = Session.Current.UserName;
            e.CurrentEntity.bUsable = true;
        }

        protected override void OnQueryChild(object key)
        {
            //base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT * FROM imStoreInOutType A WITH(NOLOCK) WHERE iIden=:iIden",key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            //base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sStoreInOutName", "出库类型"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sStoreInOutType", "出入库方向"));
        }


    }
}
