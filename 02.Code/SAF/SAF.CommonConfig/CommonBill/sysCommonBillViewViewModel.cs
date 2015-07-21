using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntity;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using SAF.EntityFramework;
using SAF.CommonConfig.Entity;
using SAF.CommonConfig.CommonBill;

namespace SAF.CommonConfig
{
    public class sysCommonBillViewViewModel : SingleViewViewModel<QueryEntity, QueryEntity>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            if (CommonBillConfig != null && !CommonBillConfig.IndexEntitySetConfig.SqlScript.IsEmpty())
                IndexEntitySet.Query(CommonBillConfig.IndexEntitySetConfig.SqlScript.FormatWith(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            if (CommonBillConfig != null && !CommonBillConfig.MainEntitySetConfig.SqlScript.IsEmpty())
                this.MainEntitySet.Query(CommonBillConfig.MainEntitySetConfig.SqlScript, key);

            for (int i = 0; i < CommonBillConfig.DetailEntitySetConfigs.Count; i++)
            {
                var config = CommonBillConfig.DetailEntitySetConfigs[i];
                if (!config.SqlScript.IsEmpty())
                {
                    detailEntities[config.UniqueId].Query(config.SqlScript, key);
                }
            }
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery = CommonBillConfig.QueryConfig.QuickQuery;
        }

        #region 通用配置

        private Dictionary<Guid, EntitySet<QueryEntity>> detailEntities = new Dictionary<Guid, EntitySet<QueryEntity>>();

        public EntitySetBase CreateDetailEntitySet(EntitySetConfig config)
        {
            var es = new EntitySet<QueryEntity>(this.ExecuteCache);
            es.TableName = config.DbTableName;
            es.PrimaryKeyName = config.PrimaryKeyName;
            es.IsReadOnly = config.IsReadOnly;

            detailEntities.Add(config.UniqueId, es);
            this.MainEntitySet.ChildEntitySets.Add(es);
            return es;
        }

        /// <summary>
        /// 通用配置
        /// </summary>
        public CommonBillConfig CommonBillConfig
        {
            get;
            private set;
        }

        /// <summary>
        /// 查询通用单据配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void QueryBillConfig(object key)
        {
            var configEntitySet = new EntitySet<sysCommonBillConfig>();

            string sql = @"
            SELECT a.Iden,a.Config
            FROM dbo.sysCommonBillConfig a WITH(NOLOCK)
            WHERE Iden=:Iden";
            configEntitySet.Query(sql, key);

            if (configEntitySet.CurrentEntity == null || configEntitySet.CurrentEntity.Config.IsEmpty())
                CommonBillConfig = null;
            CommonBillConfig = (CommonBillConfig)XmlSerializerHelper.Deserialize<CommonBillConfig>(configEntitySet.CurrentEntity.Config);
        }

        #endregion

    }
}
