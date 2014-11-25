using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    public static class ObjectExtensions
    {
        public static bool m_IsEmpty(this object obj)
        {
            return obj == null || obj == DBNull.Value || string.IsNullOrEmpty(obj.ToString().Trim());
        }
    }
}
