using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using GTMS.EntitySet;
using SAF.Foundation;

namespace GTMS.PB
{
    public class pbMaterialTypeViewViewModel : SingleViewViewModel<pbMaterialType, pbMaterialType>
    {

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        private void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<pbMaterialType> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.Usabled = true;
        }
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            string sql = @"
SELECT  Iden, MaterialTypeId, MaterialTypeCode, MaterialTypeName, sDescription, Usabled, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn
FROM dbo.pbMaterialType A WITH(NOLOCK)
WHERE {0} ORDER BY MaterialTypeId".FormatEx(sCondition);

            this.IndexEntitySet.Query(sql, parameterValues);
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query(@"
SELECT  Iden, MaterialTypeId, MaterialTypeCode, MaterialTypeName, sDescription, Usabled, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn
FROM dbo.pbMaterialType A  WITH(NOLOCK)
WHERE A.Iden=:Iden", key);

        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField() { Caption = "物料类别编号", FieldName = "MaterialTypeCode", IsDefault = true });
            queryConfig.QuickQuery.QueryFields.Add(new QueryField() { Caption = "物料类别名称", FieldName = "MaterialTypeName" });
  
        }
    }
}
