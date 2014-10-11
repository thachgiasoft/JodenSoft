using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;

namespace JNHT_ProdSys
{
    public class woDetaildealView1ViewModel : MasterDetailViewViewModel<woOrder, woOrder,woDetail>
    {
        int woiden = 0;
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            //base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT Iden,WoCode,WoVersion,CParentId,IsClose,Qty,CparentName,BomId FROM dbo.woOrder with(nolock) where ({0})".FormatEx(sCondition));
            //this.MainEntitySet.Query("select Iden, WoCode,WoVersion,CParentId,CparentName,BomId,IsClose,Qty  from woorder with(nolock) where iden={0}".FormatEx(IndexEntitySet.CurrentEntity.Iden));
        }

        protected override void OnQueryChild(object key)
        {
            //base.OnQueryChild(key);
           
            woiden = this.IndexEntitySet.CurrentEntity.Iden;
            this.DetailEntitySet.Query("select * from wodetail with(nolock) where woiden='{0}'".FormatEx(woiden));
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("WoCode", "生产令单号"));
        }

        
    }
}
