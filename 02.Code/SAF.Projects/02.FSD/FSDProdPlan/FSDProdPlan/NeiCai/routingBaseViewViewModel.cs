using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;
namespace FSDProdPlan.NeiCai
{
    public class routingBaseViewViewModel : SingleViewViewModel<routingBase, routingBase>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT *  from routingBase with(nolock) where ({0})".FormatEx(sCondition));//
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT  *  FROM  routingBase where Iden='{0}'".FormatEx(key));
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Routingname", "工序名称"));
        }
        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, SAF.EntityFramework.EntitySetAddEventArgs<routingBase> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }
    }
}
