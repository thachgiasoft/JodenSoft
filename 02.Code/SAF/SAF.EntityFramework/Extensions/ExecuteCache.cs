using SAF.EntityFramework.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public interface IExecuteCache
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlObj"></param>
        void Execute(SqlCommandObject sqlObj);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        void Execute(int groupId, string commandText, params Object[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        void Execute(string commandText, params Object[] parameters);
        /// <summary>
        /// 
        /// </summary>
        int Count { get; }
        /// <summary>
        /// 
        /// </summary>
        void Clear();
        /// <summary>
        /// 
        /// </summary>
        int SystemGroupId { get; }
        /// <summary>
        /// 
        /// </summary>
        int UserGroupId { get; }
        /// <summary>
        /// 按GroupId排序
        /// </summary>
        /// <returns></returns>
        List<SqlCommandObject> ToList();
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExecuteCache : IExecuteCache
    {
        private List<SqlCommandObject> sqlObjects = new List<SqlCommandObject>();

        private string connectionName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        public ExecuteCache(string connectionName)
        {
            this.connectionName = connectionName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlObj"></param>
        public void Execute(SqlCommandObject sqlObj)
        {
            this.sqlObjects.Add(sqlObj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        public void Execute(int groupId, string commandText, params object[] parameters)
        {
            SqlCommandObject obj = new SqlCommandObject();
            obj.CommandText = commandText;
            obj.GroupId = groupId;
            obj.ParameterValues = parameters.ToArray();
            this.Execute(obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        public void Execute(string commandText, params object[] parameters)
        {
            this.Execute(UserGroupId, commandText, parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return this.sqlObjects.Count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.sqlObjects.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SqlCommandObject> ToList()
        {
            return this.sqlObjects.OrderBy(p => p.GroupId).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        public int SystemGroupId
        {
            get { return 1000; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserGroupId
        {
            get { return 50000; }
        }
    }
}
