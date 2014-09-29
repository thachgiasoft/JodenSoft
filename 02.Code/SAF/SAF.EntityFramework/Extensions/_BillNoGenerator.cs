using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    public static class BillNoGenerator
    {
        public static string NewBillNo(string connectionName, int iBillNoId, string sParamValue, bool bSave, int iIncNum, int iStart, string sBillFormula, string sBillFormulaReset)
        {
            var obj = DataPortal.ExecuteScalar(connectionName,
@"
declare @sNewBillNo nvarchar(100),@sFormulaResetNo nvarchar(100)
EXEC dbo.sppbGenerateBillNo :iBillNoID,:sParamValue,:bSave,:iIncNum,:iStart,@sNewBillNo OUTPUT,@sFormulaResetNo OUTPUT,:sBillFormula,:sBillFormulaReset 
SELECT sNewBillNo=@sNewBillNo "
                , iBillNoId, sParamValue, bSave, iIncNum, iStart, sBillFormula, sBillFormulaReset);
            return Convert.ToString(obj);
        }

        public static string NewBillNo(string connectionName, int iBillNoId, bool bSave,string sBillFormula, string sBillFormulaReset)
        {
            return NewBillNo(connectionName, iBillNoId, "", bSave, 1, 1, sBillFormula, sBillFormulaReset);
        }

        public static string NewBillNo(int iBillNoId, bool bSave, string sBillFormula, string sBillFormulaReset)
        {
            return NewBillNo(ConfigContext.DefaultConnection, iBillNoId, bSave, sBillFormula, sBillFormulaReset);
        }
        public static string NewBillNo(int iBillNoId, bool bSave)
        {
            var sBillFormula = "";
            var sBillFormulaReset = "";
        return NewBillNo(ConfigContext.DefaultConnection, iBillNoId, bSave, sBillFormula, sBillFormulaReset);
        }

    }
}
