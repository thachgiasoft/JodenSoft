using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[SqlUserDefinedAggregate(Format.UserDefined, IsInvariantToDuplicates = false,
    IsInvariantToNulls = true, IsInvariantToOrder = false,IsNullIfEmpty=true,
    MaxByteSize = -1)]
public struct ConcatString : IBinarySerialize
{
    private StringBuilder result;
    private int splitterLength;
    public void Init()
    {
        // 在此处放置代码
        result = new StringBuilder();
        splitterLength = 0;
    }
    /// <summary>
    /// 把每个值进行累加
    /// </summary>
    /// <param name="value"></param>
    public void Accumulate(SqlChars value, SqlString connector)
    {
        if (value.IsNull)
            return;
        if (splitterLength == 0)
            splitterLength = (connector.IsNull ? "," : connector.Value).Length;
        // 在此处放置代码
        result.Append(value.Value).Append(connector.IsNull ? "," : connector.Value);
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
            output = this.result.ToString(0, this.result.Length - splitterLength);
        }

        return new SqlChars(output);
    }

    #region IBinarySerialize 成员

    public void Read(System.IO.BinaryReader reader)
    {
        result = new StringBuilder(reader.ReadString());
        splitterLength = reader.ReadInt32();
    }

    public void Write(System.IO.BinaryWriter writer)
    {
        writer.Write(result.ToString());
        writer.Write(splitterLength);
    }

    #endregion
}
