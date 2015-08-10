using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;

namespace FSDProdPlan
{
    public class jdRecourseViewViewModel : SingleViewViewModel<jdRecourse, jdRecourse>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT Iden,InvCode,InvName,Recourse,Cycle  from jdRecourse with(nolock) where ({0})".FormatEx(sCondition));//

        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT  Iden,InvCode,InvName,Recourse,Cycle  FROM  jdRecourse where Iden='{0}'".FormatEx(key));

        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("InvCode", "存货编码"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, SAF.EntityFramework.EntitySetAddEventArgs<jdRecourse> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }
    }
}
