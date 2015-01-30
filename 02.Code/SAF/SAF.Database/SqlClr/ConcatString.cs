using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[SqlUserDefinedAggregate(Format.UserDefined, IsInvariantToDuplicates = false,
    IsInvariantToNulls = true, IsInvariantToOrder = false,
    MaxByteSize = -1)]
public struct ConcatString : IBinarySerialize
{
    private StringBuilder result;
    private int iSplitLength;
    public void Init()
    {
        // 在此处放置代码
        result = new StringBuilder();
        iSplitLength = 0;
    }
    /// <summary>
    /// 把每个值进行累加
    /// </summary>
    /// <param name="value"></param>
    public void Accumulate(SqlChars value, SqlString split)
    {
        if (value.IsNull)
            return;
        if (iSplitLength == 0)
            iSplitLength = (split.IsNull ? "," : split.Value).Length;
        // 在此处放置代码
        result.Append(value.Value).Append(split.IsNull ? "," : split.Value);
    }
    /// <summary>
    /// 与其他对象进行合并
    /// </summary>
    /// <param name="other"></param>
    public void Merge(ConcatString other)
    {
        // 在此处放置代码
        result.Append(other.result);
    }
    /// <summary>
    /// 返回值
    /// </summary>
    /// <returns></returns>
    public SqlChars Terminate()
    {
        string output = string.Empty;
        if (this.result != null && this.result.Length > 0)
        {
            output = this.result.ToString(0, this.result.Length - iSplitLength);
        }

        return new SqlChars(output);
    }

    #region IBinarySerialize 成员

    public void Read(System.IO.BinaryReader r)
    {
        result = new StringBuilder(r.ReadString());
        iSplitLength = r.ReadInt32();
    }

    public void Write(System.IO.BinaryWriter w)
    {
        w.Write(result.ToString());
        w.Write(iSplitLength);
    }

    #endregion
}
