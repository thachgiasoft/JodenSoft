using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlChars PadRight(SqlChars sInput, SqlInt32 iTotalWidth, char sPadChar)
    {
        if (sInput.IsNull)
            return sInput;

        if (sPadChar == null)
            return sInput;

        if (iTotalWidth.IsNull || iTotalWidth < 0)
            iTotalWidth = 0;

        // 在此处放置代码
        return new SqlChars(new string(sInput.Value).PadRight(iTotalWidth.Value, sPadChar));
    }
}
