using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    public static class DataRowExtensions
    {
        public static bool IsFieldExists(this DataRow dr, string fieldName)
        {
            return dr != null && fieldName.IsNotEmpty() && dr.Table.Columns.Contains(fieldName);
        }
    }
}
