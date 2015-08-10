using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using SAF.Foundation;
using System.Collections.Specialized;
using SAF.EntityFramework.SqlGenerators;
using SAF.EntityFramework.Server;

namespace SAF.EntityFramework
{
    /// <summary>
    /// SQL脚本生成器
    /// </summary>
    internal static class SqlCommandObjectGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dbTableName"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<SqlCommandObject> GeneratorCommand(string connectionName, string dbTableName, DataTable table, DataRowState state)
        {
            if (connectionName.IsEmpty())
                throw new Exception("GeneratorCommand方法中的connectionName为空.");

            List<SqlCommandObject> cmds = new List<SqlCommandObject>();
            if (table.IsEmpty())
                return cmds;

            InsertCommandGenerator insertCommandGenerator = new InsertCommandGenerator();
            DeleteCommandGenerator deleteCommandGenerator = new DeleteCommandGenerator();
            UpdateCommandGenerator updateCommandGenerator = new UpdateCommandGenerator();

            SqlCommandObject cmd = null;
            if (table != null)
            {
                DataTable dtChanges = null;
                if (state == DataRowState.Unchanged)
                {
                    dtChanges = table.GetChanges();
                }
                else
                {
                    dtChanges = table.GetChanges(state);
                }

                if (dtChanges == null) return cmds;

                if (dbTableName.IsEmpty())
                    throw new Exception("GeneratorCommand方法中的tableName为空.");

                foreach (DataRow dr in dtChanges.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Deleted:
                            cmd = deleteCommandGenerator.GenerateCommand(connectionName, dbTableName, dr);
                            break;
                        case DataRowState.Modified:
                            cmd = updateCommandGenerator.GenerateCommand(connectionName, dbTableName, dr);
                            break;
                        case DataRowState.Added:
                            cmd = insertCommandGenerator.GenerateCommand(connectionName, dbTableName, dr);
                            break;
                        default:
                            cmd = null;
                            break;
                    }
                    if (cmd != null)
                    {
                        cmds.Add(cmd);
                    }
                }
            }
            return cmds;
        }
    }
}
