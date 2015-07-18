using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntity;
using SAF.Foundation;
using SAF.EntityFramework;

namespace SAF.SystemModule
{
    public class sysMenuChartViewViewModel : SingleViewViewModel<sysMenuChart, sysMenuChart>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            string sql = "SELECT Iden,Name FROM dbo.sysMenuChart with(nolock) where ({0})".FormatEx(sCondition);
            this.IndexEntitySet.Query(sql);
        }

        protected override void OnQueryChild(object key)
        {
            string sql = "SELECT Iden, Name, Remark, FileData, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, VersionNumber FROM dbo.sysMenuChart with(nolock) where Iden=:Iden";
            this.MainEntitySet.Query(sql, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Name", "名称"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntityFramework.EntitySetAddEventArgs<sysMenuChart> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.FileData = null;
        }
    }
}
