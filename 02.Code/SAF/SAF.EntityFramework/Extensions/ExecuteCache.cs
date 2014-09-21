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
        /// <summary>
        /// 重置起始值
        /// </summary>
        void Reset();

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
            Reset();
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
            this.Reset();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SqlCommandObject> ToList()
        {
            return this.sqlObjects.OrderBy(p => p.GroupId).ToList();
        }

        private int _SystemGroupId = 0;
        /// <summary>
        /// 每取一次值递增1
        /// </summary>
        public int SystemGroupId
        {
            get { return _SystemGroupId++; }
        }

        private int _UserGroupId = 0;
        /// <summary>
        /// 每取一次值递增1
        /// </summary>
        public int UserGroupId
        {
            get { return _UserGroupId++; }
        }

        /// <summary>
        /// 重置起始值
        /// </summary>
        public void Reset()
        {
            _SystemGroupId = 1000;
            _UserGroupId = 100000;
        }
    }
}
