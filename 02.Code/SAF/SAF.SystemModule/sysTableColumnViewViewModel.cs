using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls;
using SAF.SystemEntity;

namespace SAF.SystemModule
{
    public class sysTableColumnViewViewModel : SingleViewViewModel<Tables, sysTableColumn>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);

            this.IndexEntitySet.Query("SELECT Name FROM sys.tables WHERE name NOT IN ('sysdiagrams','sysIden','sysTableColumn') ORDER BY create_date");
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);

            const string sql = @"
SELECT a.name,b.InsertDefaultValue,b.UpdateDefaultValue
FROM sys.columns a
LEFT JOIN dbo.sysTableColumn b WITH(NOLOCK) on a.NAME=b.ColumnName 
WHERE a.object_id=OBJECT_ID(:tableName) 
	AND a.system_type_id IN(36,40,41,42,48,52,56,58,59,60,61,62,104,106,108,122,127,167,175,231,239)
ORDER BY a.column_id";
            this.MainEntitySet.Query(sql, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
        }
    }
}
