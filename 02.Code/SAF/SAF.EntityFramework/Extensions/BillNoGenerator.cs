using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 单据号生成器
    /// </summary>
    public static class BillNoGenerator
    {
        private static string NewBillNo(string connectionName, string billNoType, string dynamicContent = "")
        {
            var obj = DataPortal.ExecuteScalar(connectionName, "exec dbo.sysGenerateBillNo :BillNoType,:DynamicContent,'',1", billNoType, dynamicContent);
            return obj.ToString();
        }

        public static string NewBillNo(string billNoType, string dynamicContent = "")
        {
            return NewBillNo(ConfigContext.DefaultConnection, billNoType, dynamicContent);
        }
    }
}
