using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using SAF.SqlClr.Helper;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlChars ConvertToPinyin(SqlChars input)
    {
        if (input.IsNull)
            return input;
        var str = new string(input.Value);
        return new SqlChars(StringConverter.GetChineseSpell(str));
    }
}
