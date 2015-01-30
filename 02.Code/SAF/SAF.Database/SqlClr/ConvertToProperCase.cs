using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Microsoft.VisualBasic;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlChars ConvertToProperCase(SqlChars sInputString)
    {
        if (sInputString.IsNull)
            return sInputString;

        var str = new string(sInputString.Value);
        // 在此处放置代码
        return new SqlChars(Strings.StrConv(str, VbStrConv.ProperCase, 0));
    }
}
