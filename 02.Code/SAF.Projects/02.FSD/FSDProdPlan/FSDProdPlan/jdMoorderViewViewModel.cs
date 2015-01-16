using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using SAF.Foundation;
using System.Data;
namespace FSDProdPlan
{
    public class jdMoorderViewViewModel : SingleViewViewModel<jdMoorder, jdMoorder>
    {
        private EntitySet<emEquipmentCapacityProduce> _emEquipmentCapacityProduceEntity = null;
        public EntitySet<emEquipmentCapacityProduce> emEquipmentCapacityProduceEntity
        {
            get
            {
                if (_emEquipmentCapacityProduceEntity == null)
                    _emEquipmentCapacityProduceEntity = new EntitySet<emEquipmentCapacityProduce>(ConfigContext.DefaultConnection, null,0);
                return _emEquipmentCapacityProduceEntity;
            }
        }
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT *  from jdMoorder with(nolock) where ({0})".FormatEx(sCondition));//
        }
        
        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT  *  FROM  jdMoorder where Iden='{0}'".FormatEx(key));
            this.emEquipmentCapacityProduceEntity.Query("select Iden,uGuid,uEquipmentGuid,sEquipmentNo,sMaterialNo+'-'+sEquipmentNo AS sMaterialNo,sMaterialNo,sMaterialName,uemEquipmentModelGUID,nCapacity from emEquipmentCapacityProduce with(nolock)");
           
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sOrderNo", "工单号"));
        }
        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<jdMoorder> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);

            e.CurrentEntity.sOrderNo = BillNoGenerator.NewBillNo(2);
                //DataPortal.ExecuteScalar(ConfigContext.DefaultConnection, "exec JD_P_GetMoOrderNumber").ToString();// (1000000000 + e.CurrentEntity.Iden).ToString();
        }
    }
}
