using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;

namespace JNHT_ProdSys
{
    public class bomRotingViewViewModel : SingleViewViewModel<bomRoting, bomRoting>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
           // base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT distinct Iden=0, BomId  from bomParent with(nolock) where ({0})".FormatEx(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            //base.OnQueryChild(key);
            var bomId = this.IndexEntitySet.CurrentEntity == null ? string.Empty : this.IndexEntitySet.CurrentEntity.BomId;

            //this.bomEntity.Query("select Iden,BomParentId,BomChildId,BomChildDesc,UseQty  from bomparent with(nolock) where BomId='{0}' ".FormatEx(bomId));

            this.MainEntitySet.Query(@"SELECT Iden,BomId,BomChildId,OpDep,RotingId ,RotingName ,RotingDesc,Production
                                        ,RotingProduction ,FZMeterial,ZhunJie ,DanJian,define1 ,define2,define3
                                        ,define4 ,define5,define6,define7,define8 ,define9,define10
                                         FROM dbo.bomRoting with(nolock) where BomId='{0}' ".FormatEx(bomId));
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            //base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("BomId", "产品区分号"));
        }
        protected override void OnInitEvents()
        {
            //base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, SAF.EntityFramework.EntitySetAddEventArgs<bomRoting> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }
    }
}
