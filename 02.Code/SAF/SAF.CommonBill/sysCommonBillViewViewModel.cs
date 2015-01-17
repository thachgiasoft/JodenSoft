using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntities;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using SAF.EntityFramework;

namespace SAF.CommonBill
{
    public class sysCommonBillViewViewModel : MasterDetailViewViewModel<QueryEntity, QueryEntity, QueryEntity>
    {
        public CommonBillConfig CommonBillConfig = new CommonBillConfig();

        private EntitySet<sysCommonBillConfig> _commonBillConfigEntitySet = null;
        public EntitySet<sysCommonBillConfig> CommonBillConfigEntitySet
        {
            get
            {
                if (_commonBillConfigEntitySet == null)
                {
                    _commonBillConfigEntitySet = new EntitySet<sysCommonBillConfig>();
                }
                return _commonBillConfigEntitySet;
            }
        }


        public List<EntitySet<QueryEntity>> dtlEntitys = new List<EntitySet<QueryEntity>>();

        public CommonBillConfig QueryBillConfg(object key)
        {
            //            string sql = @"
            //SELECT a.Iden,a.Config,a.CreatedBy,a.CreatedOn,a.ModifiedBy,a.ModifiedOn,a.VersionNumber
            //FROM dbo.sysCommonBillConfig a WITH(NOLOCK)
            //WHERE Iden=:Iden";
            //            IndexEntitySet.Query(sql, key);
            //            if (IndexEntitySet.CurrentEntity == null || IndexEntitySet.CurrentEntity.Config.IsEmpty())
            //                return null;
            //            return XmlSerializerHelper.Deserialize<CommonBillConfig>(IndexEntitySet.CurrentEntity.Config);

            CommonBillConfig.IndexEntitySetConfig.DbTableName = "sdOrder";
            CommonBillConfig.IndexEntitySetConfig.PrimaryKeyName = "Iden";
            CommonBillConfig.IndexEntitySetConfig.Sql = "SELECT * FROM dbo.sdOrder with(nolock)";
            CommonBillConfig.IndexEntitySetConfig.IsReadOnly = true;
            CommonBillConfig.IndexEntitySetConfig.Fields.Add(new EntitySetField("Iden", "序号"));
            CommonBillConfig.IndexEntitySetConfig.Fields.Add(new EntitySetField("OrderNo", "订单号"));

            CommonBillConfig.MainEntitySetConfig.DbTableName = "sdOrder";
            CommonBillConfig.MainEntitySetConfig.PrimaryKeyName = "Iden";
            CommonBillConfig.MainEntitySetConfig.Sql = "SELECT * FROM dbo.sdOrder with(nolock) where Iden=:Iden";
            CommonBillConfig.MainEntitySetConfig.Fields.Add(new EntitySetField("Iden", "序号"));
            CommonBillConfig.MainEntitySetConfig.Fields.Add(new EntitySetField("OrderNo", "订单号"));

            var dtlConfig = new DetailEntitySetConfig();
            dtlConfig.DbTableName = "sdOrderDtl";
            dtlConfig.PrimaryKeyName = "Iden";
            dtlConfig.Caption = "订单明细";
            dtlConfig.Sql = " SELECT * FROM [dbo].[sdOrderDtl] WITH(NOLOCK) WHERE OrderId=:Iden";
            dtlConfig.Fields.Add(new EntitySetField("Iden", "序号", true));
            dtlConfig.Fields.Add(new EntitySetField("Qty", "数量"));
            CommonBillConfig.DetailEntitySetConfigs.Add(dtlConfig);

            dtlConfig = new DetailEntitySetConfig();
            dtlConfig.DbTableName = "sdOrderDtl";
            dtlConfig.PrimaryKeyName = "Iden";
            dtlConfig.Caption = "订单明细2";
            dtlConfig.Sql = " SELECT * FROM [dbo].[sdOrderDtl] WITH(NOLOCK) WHERE OrderId=:Iden";
            dtlConfig.Fields.Add(new EntitySetField("Iden", "序号", true));
            dtlConfig.Fields.Add(new EntitySetField("Qty", "数量"));
            CommonBillConfig.DetailEntitySetConfigs.Add(dtlConfig);

            return CommonBillConfig;

        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            if (CommonBillConfig.IndexEntitySetConfig.Sql.IsNotEmpty())
                IndexEntitySet.Query(CommonBillConfig.IndexEntitySetConfig.Sql);
        }

        protected override void OnQueryChild(object key)
        {
            if (CommonBillConfig.MainEntitySetConfig.Sql.IsNotEmpty())
                this.MainEntitySet.Query(CommonBillConfig.MainEntitySetConfig.Sql, key);

            for (int i = 0; i < dtlEntitys.Count; i++)
            {
                var config = CommonBillConfig.DetailEntitySetConfigs[i];
                if (config.Sql.IsNotEmpty())
                {
                    this.dtlEntitys[i].Query(config.Sql, key);
                }
            }
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {

        }
    }
}
