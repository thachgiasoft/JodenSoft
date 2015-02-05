using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.ViewConfig
{
    [Serializable]
    public class QuickQuery
    {
        public List<QueryField> QueryFields { get; set; }
        public QuickQueryType QuickQueryType { get; set; }

        public QuickQuery()
        {
            QueryFields = new List<QueryField>();
            QuickQueryType = QuickQueryType.Combinatorial;
        }
    }
}
