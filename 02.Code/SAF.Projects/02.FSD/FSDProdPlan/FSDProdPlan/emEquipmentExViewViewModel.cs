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
    public class emEquipmentExViewViewModel : SingleViewViewModel<emEquipmentEx, emEquipmentEx>
    {
        private EntitySet<emModel> _emModelEntity = null;
        public EntitySet<emModel> emModelEntity
        {
            get
            {
                if (_emModelEntity == null)
                    _emModelEntity = new EntitySet<emModel>(ConfigContext.DefaultConnection, null, ConfigContext.DefaultPageSize);
                return _emModelEntity;
            }
        }
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT *  from emEquipmentEx with(nolock) where ({0})".FormatEx(sCondition));//
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT  *  FROM  emEquipmentEx where Iden='{0}'".FormatEx(key));
            this.emModelEntity.Query("select Iden ,uGuid ,sEquipmentNo ,sEquipmentName from emModel with(nolock)");
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sEquipmentNo", "机台编号"));
        }
        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<emEquipmentEx> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }
    }
}
