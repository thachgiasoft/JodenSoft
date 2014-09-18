using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;


namespace JNHT_ProdSys
{
    public class bomChildViewViewModel : MasterDetailViewViewModel<bomParent, bomParent, bomChild>
    {
         private EntitySet<jd_v_inventory> _jd_v_inventory = null;
        public EntitySet<jd_v_inventory> jd_v_inventory
        {
            get
            {
                if (_jd_v_inventory == null)
                    _jd_v_inventory = new EntitySet<jd_v_inventory>(ConfigContext.DefaultConnection, null, ConfigContext.DefaultPageSize);
                return _jd_v_inventory;
            }
        }
      
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
           // base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT distinct Iden=0, BomId  from bomParent with(nolock) where ({0})".FormatEx(sCondition));//
            var bomId = this.IndexEntitySet.CurrentEntity == null ? string.Empty : this.IndexEntitySet.CurrentEntity.BomId;

            //this.bomEntity.Query("select Iden,BomParentId,BomChildId,BomChildDesc,UseQty  from bomparent with(nolock) where BomId='{0}' ".FormatEx(bomId));

            this.MainEntitySet.Query(@"select BomId,Iden,BomParentId,BomParentDesc,BomParentStd,BomParentStyle,BomChildId,BomChildDesc,BomChildStd,convert(decimal(20,0),UseQty) as UseQty,TotalUseQty=dbo.Fn_GetTotalUseQty(bomid,BomChildId),BomChildStyle 
            from  bomParent with(nolock) where BomId='{0}' ".FormatEx(bomId));
           
            
            jd_v_inventory.Query("select 存货编码,存货名称2,单位 from jd_v_inventory");
            
            
        }

        protected override void OnQueryChild(object key)
        {
            //base.OnQueryChild(key);
            //var bomId = this.MainEntitySet.CurrentEntity == null ? string.Empty : this.MainEntitySet.CurrentEntity.BomId;
            //var bomChildId = this.MainEntitySet.CurrentEntity == null ? string.Empty : this.MainEntitySet.CurrentEntity.BomChildId;

            //this.DetailEntitySet.Query("select * from bomchild where bomid='{0}' and bomChildid='{1}'".FormatEx(bomId,bomChildId));
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("BomId", "产品区分号"));
        }

    }
}
