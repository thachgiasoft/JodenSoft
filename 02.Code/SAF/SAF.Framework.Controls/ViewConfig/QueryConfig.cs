using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.ViewConfig
{
    public class QueryConfig
    {
        public QuickQuery QuickQuery { get; set; }
        

        public QueryConfig()
        {
            QuickQuery = new QuickQuery();
           
        }
    }
}
