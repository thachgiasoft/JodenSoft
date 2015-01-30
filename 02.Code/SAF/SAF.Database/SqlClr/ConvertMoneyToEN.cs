using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using SAF.SqlClr.Helper;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString ConvertMoneyToEN(SqlMoney nMoney)
    {
        if (nMoney.IsNull)
            return SqlString.Null;
        // 在此处放置代码
        return new SqlString(MoneyConverter.GetEnString(nMoney.ToString()));
    }
}
