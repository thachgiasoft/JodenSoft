using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls;
using SAF.Foundation;
using SAF.EntityFramework;
using SAF.CommonConfig.Entity;
using SAF.Foundation.ComponentModel;
using SAF.CommonConfig.CommonBill;

namespace SAF.CommonConfig
{
    public class sysCommonBillConfigViewViewModel : SingleViewViewModel<sysCommonBillConfig, sysCommonBillConfig>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            string sql = "SELECT a.Iden,a.Name FROM dbo.sysCommonBillConfig a WITH(NOLOCK) where ({0})".FormatWith(sCondition);
            this.IndexEntitySet.Query(sql);
        }

        protected override void OnQueryChild(object key)
        {
            string sql = "SELECT a.* FROM dbo.sysCommonBillConfig a WITH(NOLOCK) WHERE A.Iden=:Iden";
            this.MainEntitySet.Query(sql, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Name", "名称"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Iden", "序号"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntityFramework.EntitySetAddEventArgs<sysCommonBillConfig> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.Name = string.Empty;
            e.CurrentEntity.Config = string.Empty;
        }

        //protected override bool OnPreHandle()
        //{
        //    if (this.MainEntitySet.IsAddedOrModified)
        //    {
        //        var config = XmlSerializerHelper.Deserialize<CommonBillConfig>(this.MainEntitySet.CurrentEntity.Config);

        //        config.CheckNotNull("通用单据配置");

        //        config.QueryConfig.CheckNotNull("查询配置");
        //        config.QueryConfig.Validate();

        //        config.IndexEntitySetConfig.CheckNotNull("索引配置");
        //        config.IndexEntitySetConfig.Validate(EntitySetType.Index);

        //        config.MainEntitySetConfig.CheckNotNull("主数据配置");
        //        config.MainEntitySetConfig.Validate(EntitySetType.Main);

        //        if (config.DetailEntitySetConfigs != null)
        //        {
        //            foreach (var item in config.DetailEntitySetConfigs)
        //            {
        //                item.Validate(EntitySetType.Detail);
        //            }
        //        }
        //    }

        //    return base.OnPreHandle();
        //}

    }
}
