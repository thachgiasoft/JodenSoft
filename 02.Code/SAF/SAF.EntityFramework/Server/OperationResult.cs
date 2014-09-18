using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SAF.EntityFramework.Server
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [KnownType("GetKnownType")]
    public class OperationResult
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public object Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool IsSucess { get; set; }

        private static Type[] GetKnownType()
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

            types.Add(typeof(DataSet));
            types.Add(typeof(DataTable));

            return types.ToArray();
        }

    }
}
