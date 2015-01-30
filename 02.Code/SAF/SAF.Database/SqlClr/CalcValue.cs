using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct CalcValue
{
    int iTotalValue;
    bool bFirst;
    public void Init()
    {
        // 在此处放置代码
        iTotalValue = 0;
        bFirst = true;
    }

    public void Accumulate(SqlInt32 iValue, SqlString sOperate)
    {
        // 在此处放置代码
        if (iValue.IsNull)
            return;
        if (sOperate.IsNull)
            return;
        if (bFirst)
        {
            iTotalValue = iValue.Value;
            bFirst = false;
            return;
        }

        switch (sOperate.Value)
        {
            case "+":
                iTotalValue += iValue.Value;
                break;
            case "-":
                iTotalValue -= iValue.Value;
                break;
            case "*":
                iTotalValue *= iValue.Value;
                break;
            case "/":
                if (iValue != 0)
                    iTotalValue /= iValue.Value;
                break;
            case "%":
                if (iValue != 0)
                    iTotalValue %= iValue.Value;
                break;
            //位移
            case "<<":
                iTotalValue <<= iValue.Value;
                break;
            case ">>":
                iTotalValue >>= iValue.Value;
                break;
            //逻辑“与”
            case "&":
                iTotalValue &= iValue.Value;
                break;
            //逻辑“异或”
            case "^":
                iTotalValue ^= iValue.Value;
                break;
            //逻辑“或”
            case "|":
                iTotalValue |= iValue.Value;
                break;
            default:
                break;
        }
    }

    public void Merge(CalcValue Group)
    {
        // 在此处放置代码
        this.iTotalValue += Group.iTotalValue;
        this.bFirst = Group.bFirst;
    }

    public SqlInt32 Terminate()
    {
        // 在此处放置代码
        return new SqlInt32(iTotalValue);
    }
}
