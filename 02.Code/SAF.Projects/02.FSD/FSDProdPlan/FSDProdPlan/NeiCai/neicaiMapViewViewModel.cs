using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;

namespace FSDProdPlan.NeiCai
{
    public class neicaiMapViewViewModel : SingleViewViewModel<QueryEntity, QueryEntity>
    {
        
      
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            this.IndexEntitySet.Query("SELECT sEquipmentName AS 机台编号 FROM dbo.emEquipmentEx WHERE sEquipmentModelCaption IN (SELECT sEquipmentModelNo FROM dbo.emModel WHERE WorkCenter='内材车间')");
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
           // this.MainEntitySet.Query("select * from  ");

        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
        }
    }
}
