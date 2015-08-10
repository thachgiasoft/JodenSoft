using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean IsNullOrWhiteSpace(SqlChars input)
    {
        if (input.IsNull) return true;

        var str = new string(input.Value);

        return new SqlBoolean(string.IsNullOrWhiteSpace(str));
    }
}
