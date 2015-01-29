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
    public class emEquipmentCapacityProduceViewViewModel : SingleViewViewModel<emEquipmentCapacityProduce, emEquipmentCapacityProduce>
    {
        private EntitySet<emEquipmentEx> _emEquipmentExEntity = null;
        public EntitySet<emEquipmentEx> emEquipmentExEntity
        {
            get
            {
                if (_emEquipmentExEntity == null)
                    _emEquipmentExEntity = new EntitySet<emEquipmentEx>(ConfigContext.DefaultConnection, null, ConfigContext.DefaultPageSize);
                return _emEquipmentExEntity;
            }
        }
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT *  from emEquipmentCapacityProduce with(nolock) where ({0})".FormatEx(sCondition));//
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT  *  FROM  emEquipmentCapacityProduce where Iden='{0}'".FormatEx(key));
            this.emEquipmentExEntity.Query(@"select Iden ,uGuid ,sEquipmentNo ,sEquipmentName,
                uemEquipmentModelGUID,sEquipmentModelCaption,sEquipmentModelName,nDailyOuputQty from emEquipmentEx with(nolock)");
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sEquipmentNo", "机台编号"));
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<emEquipmentCapacityProduce> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.uGuid = Guid.NewGuid();
        }
    }
}
