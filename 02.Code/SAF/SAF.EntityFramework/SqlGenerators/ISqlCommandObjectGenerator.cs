using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using SAF.EntityFramework.Server;

namespace SAF.EntityFramework.SqlGenerators
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISqlCommandObjectGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="connectionName"></param>
        /// <param name="tableName"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        SqlCommandObject GenerateCommand(string connectionName, string tableName, DataRow dr);
    }
}
