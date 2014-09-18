using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;

namespace SAF.EntityFramework.Server
{
    /// <summary>
    /// 供执行的Sql脚本
    /// </summary>
    [DataContract]
    [KnownType("GetKnownType")]
    public class SqlCommandObject
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int GroupId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CommandText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public SqlCommandParameter[] Parameters { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public object[] ParameterValues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SqlCommandObject()
        {
            this.GroupId = 0;
            this.CommandText = string.Empty;
            Parameters = null;
            ParameterValues = null;
        }

        private static Type[] GetKnownType()
        {
            return KnownTypeHelper.GetKnownType();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [KnownType("GetKnownType")]
    public class SqlCommandParameter
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DbType DataType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public object Value { get; set; }

        private static Type[] GetKnownType()
        {
            return KnownTypeHelper.GetKnownType();
        }
    }

    public static class KnownTypeHelper
    {
        public static Type[] GetKnownType()
        {
            //将自定义对象的程序集下的所有类型标记为KnownType。  
            var types = new List<Type>();

            types.Add(typeof(int));
            types.Add(typeof(short));
            types.Add(typeof(long));

            types.Add(typeof(uint));
            types.Add(typeof(ushort));
            types.Add(typeof(ulong));

            types.Add(typeof(decimal));
            types.Add(typeof(double));
            types.Add(typeof(float));

            types.Add(typeof(byte));
            types.Add(typeof(sbyte));
            types.Add(typeof(bool));

            types.Add(typeof(char));
            types.Add(typeof(string));

            types.Add(typeof(DateTime));
            types.Add(typeof(Guid));
            types.Add(typeof(DBNull));
            types.Add(typeof(byte[]));

            return types.ToArray();
        }

    }

}
