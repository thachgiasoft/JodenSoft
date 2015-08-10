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
        public static string NewBillNo(string connectionName, int billNoId, string dynamicContent = "")
        {
            var obj = DataPortal.ExecuteScalar(connectionName, "exec dbo.sysGenerateBillNo @BillNoId=:BillNoId,@DynamicContent=:DynamicContent,@BillNo='',@Return=1", billNoId, dynamicContent);
            return obj.ToString();
        }

        public static string NewBillNo(int billNoId, string dynamicContent = "")
        {
            return NewBillNo(ConfigContext.DefaultConnection, billNoId, dynamicContent);
        }
    }
}
