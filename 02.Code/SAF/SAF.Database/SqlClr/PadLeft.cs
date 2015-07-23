using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlChars PadLeft(SqlChars input, SqlInt32 totalWidth, char paddingChar)
    {
        if (input.IsNull)
            return input;

        if (paddingChar == (char)0)
            return input;

        if (totalWidth.IsNull || totalWidth < 0)
            totalWidth = 0;

        // 在此处放置代码
        return new SqlChars(new string(input.Value).PadLeft(totalWidth.Value, paddingChar));
    }
}
