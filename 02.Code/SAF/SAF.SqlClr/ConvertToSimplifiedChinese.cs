using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Microsoft.VisualBasic;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(IsDeterministic = true)]
    public static SqlChars ConvertToSimplifiedChinese(SqlChars input)
    {
        if (input.IsNull)
            return input;

        var str = new string(input.Value);
        // 在此处放置代码
        return new SqlChars(Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0));
    }
}
