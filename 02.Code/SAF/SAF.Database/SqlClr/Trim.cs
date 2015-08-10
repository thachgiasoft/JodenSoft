using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlChars Trim(SqlChars input)
    {
        if (input.IsNull) return input;

        return new SqlChars(new string(input.Value).Trim());
    }
}
