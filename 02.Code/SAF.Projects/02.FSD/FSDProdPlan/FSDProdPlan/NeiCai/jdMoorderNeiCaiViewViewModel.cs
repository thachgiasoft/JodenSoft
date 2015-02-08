using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using SAF.Foundation;

namespace FSDProdPlan.NeiCai
{
    public class jdMoorderNeiCaiViewViewModel : MasterDetailViewViewModel<jdMoorderNeiCai, jdMoorderNeiCai, woRouting>
    {
        private EntitySet<emModel> _emModelEntity = null;
        public EntitySet<emModel> emModelEntity
        {
            get
            {
                if (_emModelEntity == null)
                    _emModelEntity = new EntitySet<emModel>(ConfigContext.DefaultConnection, null, 0);
                return _emModelEntity;
            }
        }
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            this.IndexEntitySet.Query("select * from jdMoorderNeiCai with(nolock) where {0}".FormatEx(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("select * from jdMoorderNeiCai with(nolock) where Iden={0}".FormatEx(key));
            this.DetailEntitySet.Query("select * from woRouting with(nolock) where woIden={0}".FormatEx(key));
            this.emModelEntity.Query("select Iden   ,sEquipmentModelNo  ,sEquipmentModelName ,uGuid  from emModel with(nolock)");

        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sMaterialName", "产品名称"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
            this.DetailEntitySet.AfterAdd += DetailEntitySet_AfterAdd;
        }

        void DetailEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<woRouting> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.uGuid = Guid.NewGuid();
            e.CurrentEntity.woIden = this.MainEntitySet.CurrentEntity.Iden;
            e.CurrentEntity.woIden=;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<jdMoorderNeiCai> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }
    }
}
