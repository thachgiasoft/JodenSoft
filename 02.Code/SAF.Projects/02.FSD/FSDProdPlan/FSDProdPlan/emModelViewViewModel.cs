using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using SAF.Foundation;

namespace FSDProdPlan
{
    public class emModelViewViewModel : SingleViewViewModel<emModel, emModel>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT *  from emModel with(nolock) where ({0})".FormatEx(sCondition));//
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT  *  FROM  emModel where Iden='{0}'".FormatEx(key));
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sEquipmentNo", "机器编号"));
        }
        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, SAF.EntityFramework.EntitySetAddEventArgs<emModel> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.uGuid = Guid.NewGuid();
        }
    }
}
