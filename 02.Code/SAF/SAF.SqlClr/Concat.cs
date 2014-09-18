//------------------------------------------------------------------------------
// <copyright file="CSSqlAggregate.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct Concat
{
    public void Init()
    {
        // 在此处放置代码
    }

    public void Accumulate(SqlString Value)
    {
        // 在此处放置代码
    }

    public void Merge (Concat Group)
    {
        // 在此处放置代码
    }

    public SqlString Terminate ()
    {
        // 在此处放置代码
        return new SqlString (string.Empty);
    }

    // 这是占位符成员字段
    public int _var1;
}
