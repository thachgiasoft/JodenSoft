using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.Framework.Controls.ViewConfig
{
    public class QueryConfig
    {
        public QuickQuery QuickQuery { get; set; }

        public QueryConfig()
        {
            QuickQuery = new QuickQuery();
        }

        public void Validate()
        {
            QuickQuery.CheckNotNull("速查配置");
            QuickQuery.QueryFields.CheckNotNullOrEmpty("速查字段");
            QuickQuery.QueryFields.Required(p => !p.Any(a => a.FieldName.IsEmpty() || a.Caption.IsEmpty()), "速查字段或标题不能为空。");
        }
    }
}
