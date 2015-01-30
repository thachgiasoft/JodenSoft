using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(FillRowMethodName = "SplitFillRow", TableDefinition = "item nvarchar(max)")]
    public static IEnumerable SplitString(SqlChars input, SqlChars separators)
    {
        string[] array;
        if (input.IsNull)
        {
            array = new string[] { null };
        }
        else if (separators.IsNull)
        {
            array = new string[] { input.ToSqlString().Value };
        }
        else
        {
            string inputStr = input.ToSqlString().Value;
            string sepStr = separators.ToSqlString().Value;
            string[] separatorsArray = sepStr.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            array = inputStr.Split(separatorsArray, StringSplitOptions.RemoveEmptyEntries);
        }
        return array;
    }

    private static void SplitFillRow(Object obj, ref SqlString item)
    {
        if (obj != null)
        {
            item = (string)obj;
        }
    }
}
