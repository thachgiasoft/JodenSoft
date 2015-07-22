using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(FillRowMethodName = "DualFillRow", TableDefinition = "item nvarchar(max)")]
    public static IEnumerable Dual(SqlInt32 count)
    {
        int iCount = 0;
        if (count.IsNull || count < 0)
            iCount = 0;
        else
            iCount = count.Value;

        string[] array = null;

        if (iCount > 0)
        {
            array = new string[iCount];

            for (int i = 0; i < iCount; i++)
            {
                array[i] = (i+1).ToString();
            }
        }

        return array;
    }

    private static void DualFillRow(Object obj, ref SqlString item)
    {
        if (obj != null)
        {
            item = (string)obj;
        }
    }
}
