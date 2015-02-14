using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using SAF.Foundation;
using System.Data;
using SAF.Foundation.ServiceModel;
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
            IndexEntitySet.Query(@"SELECT *  from jdMoorder with(nolock) where ({0})  ORDER BY sOrderNo DESC ".FormatEx(sCondition));//
        }
        
        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT  *  FROM  jdMoorder with(nolock) where Iden='{0}'".FormatEx(key));
            this.emEquipmentCapacityProduceEntity.Query("select Iden,uGuid,uEquipmentGuid,sEquipmentNo,sMaterialNo+'-'+sEquipmentNo  AS sMaterialNo,sMaterialName,uemEquipmentModelGUID,nCapacity from emEquipmentCapacityProduce with(nolock)");
           
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sOrderNo", "工单号"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("sEquipmentModelName", "机台编号"));
        }
        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<jdMoorder> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);

            e.CurrentEntity.sOrderNo =  BillNoGenerator.NewBillNo(11);//(1000000000 + e.CurrentEntity.Iden).ToString();// ; //BillNoGenerator.NewBillNo(2);
                //DataPortal.ExecuteScalar(ConfigContext.DefaultConnection, "exec JD_P_GetMoOrderNumber").ToString();// (1000000000 + e.CurrentEntity.Iden).ToString();
            e.CurrentEntity.sBillNO = e.CurrentEntity.sOrderNo;
        }

        protected override void OnDelete()
        {
            if (checkisExists(this.MainEntitySet.CurrentEntity.sOrderNo))
            {
                MessageService.ShowMessage("此订单在排产,不能删除!");
                return;
            }
            base.OnDelete();
        }

        private bool checkisExists(string p)
        {
            string sql = "SELECT  COUNT(*)  FROM psWpp WHERE sOrderNo='{0}'".FormatEx(p);
            return Convert.ToInt32(DataPortal.ExecuteScalar(ConfigContext.DefaultConnection,sql))>0;
        }
    }
}
