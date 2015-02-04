using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct CalcValue
{
    int totalValue;
    bool isFirst;
    public void Init()
    {
        // 在此处放置代码
        totalValue = 0;
        isFirst = true;
    }

    public void Accumulate(SqlInt32 value, SqlString operate)
    {
        // 在此处放置代码
        if (value.IsNull)
            return;
        if (operate.IsNull)
            return;
        if (isFirst)
        {
            totalValue = value.Value;
            isFirst = false;
            return;
        }

        switch (operate.Value)
        {
            case "+":
                totalValue += value.Value;
                break;
            case "-":
                totalValue -= value.Value;
                break;
            case "*":
                totalValue *= value.Value;
                break;
            case "/":
                if (value != 0)
                    totalValue /= value.Value;
                break;
            case "%":
                if (value != 0)
                    totalValue %= value.Value;
                break;
            //位移
            case "<<":
                totalValue <<= value.Value;
                break;
            case ">>":
                totalValue >>= value.Value;
                break;
            //逻辑“与”
            case "&":
                totalValue &= value.Value;
                break;
            //逻辑“异或”
            case "^":
                totalValue ^= value.Value;
                break;
            //逻辑“或”
            case "|":
                totalValue |= value.Value;
                break;
            default:
                break;
        }
    }

    public void Merge(CalcValue Group)
    {
        // 在此处放置代码
        this.totalValue += Group.totalValue;
        this.isFirst = Group.isFirst;
    }

    public SqlInt32 Terminate()
    {
        // 在此处放置代码
        return new SqlInt32(totalValue);
    }
}
