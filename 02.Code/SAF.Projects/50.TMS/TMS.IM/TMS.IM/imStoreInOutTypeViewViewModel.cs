using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using TMS.Entities;
using SAF.EntityFramework;
using SAF.Foundation;
using SAF.Foundation.ServiceModel;

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
           // e.CurrentEntity.ic = Session.Current.UserName;
            e.CurrentEntity.bUsable = true;
        }

        protected override void OnQueryChild(object key)
        {
            //base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT * FROM imStoreInOutType A WITH(NOLOCK) WHERE Iden=:Iden",key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            //base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sStoreInOutName", "出库类型"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sStoreInOutType", "出入库方向"));
        }

        protected override bool OnAllowDelete()
        {
            var canDelete = true;
            var StoreType = string.Empty;
            //todo{仓库使用后不允许删除}
            
            if (!canDelete)
            {
                MessageService.ShowError("仓库出入库类型{0},不允许删除!".FormatEx(StoreType));
            }

            return canDelete;
        }

       


    }
}
