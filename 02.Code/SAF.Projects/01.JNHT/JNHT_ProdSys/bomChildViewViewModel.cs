using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;
using SAF.SystemEntities;

namespace JNHT_ProdSys
{
    public class bomChildViewViewModel : MasterDetailViewViewModel<bomParent, bomParent, bomChild>
    {
         private EntitySet<jd_v_inventory> _jd_v_inventory = null;
        public EntitySet<jd_v_inventory> jd_v_inventoryEntity
        {
            get
            {
                if (_jd_v_inventory == null)
                    _jd_v_inventory = new EntitySet<jd_v_inventory>(ConfigContext.DefaultConnection, null, ConfigContext.DefaultPageSize);
                return _jd_v_inventory;
            }
        }

        private EntitySet<sysOrganization> _sysOrganizationEntity = null;
        public EntitySet<sysOrganization> sysOrganizationEntity
        {
            get
            {
                if (_sysOrganizationEntity == null)
                    _sysOrganizationEntity = new EntitySet<sysOrganization>(ConfigContext.DefaultConnection, null, ConfigContext.DefaultPageSize);
                return _sysOrganizationEntity;
            }
        }

        string bomId = "";
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
           // base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT distinct Iden=0, BomId  from bomParent with(nolock) where ({0})".FormatEx(sCondition));//
             //bomId = this.IndexEntitySet.CurrentEntity == null ? string.Empty : this.IndexEntitySet.CurrentEntity.BomId;
            
            //this.bomEntity.Query("select Iden,BomParentId,BomChildId,BomChildDesc,UseQty  from bomparent with(nolock) where BomId='{0}' ".FormatEx(bomId));

           
            
            
        }

        
        protected override void OnQueryChild(object key)
        {
            //base.OnQueryChild(key);
            bomId = this.IndexEntitySet.CurrentEntity == null ? string.Empty : this.IndexEntitySet.CurrentEntity.BomId;
            //var bomChildId = this.MainEntitySet.CurrentEntity == null ? string.Empty : this.MainEntitySet.CurrentEntity.BomChildId;

            //this.DetailEntitySet.Query("select * from bomchild where bomid='{0}' and bomChildid='{1}'".FormatEx(bomId,bomChildId));
            this.MainEntitySet.Query(@"select BomId,Iden,BomParentId,BomParentDesc,BomParentStd,BomParentStyle,BomChildId,BomChildDesc,BomChildStd,convert(decimal(20,0),UseQty) as UseQty,TotalUseQty=dbo.Fn_GetTotalUseQty(bomid,BomChildId,BomParentId),BomChildStyle 
            from  bomParent with(nolock) where BomId='{0}' ".FormatEx(bomId));

            this.DetailEntitySet.Query("select * from bomChild with(nolock)");

            jd_v_inventoryEntity.Query("select Iden,存货编码,存货名称,单位,现存量  from jd_v_inventory");
            sysOrganizationEntity.Query("SELECT Name as 部门名称 FROM  dbo.sysOrganization WHERE IsDeleted=0");
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("BomId", "产品区分号"));
        }

        protected override void OnInitEvents()
        {
           // base.OnInitEvents();
           // this.DetailEntitySet.AfterAdd += DetailEntitySet_AfterAdd;
        }

        //void DetailEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<bomChild> e)
        //{
        //    e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        //}
    }
}
