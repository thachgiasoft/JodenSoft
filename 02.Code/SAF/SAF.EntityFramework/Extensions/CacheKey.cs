using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public static class CacheKey
    {
        private static readonly string flag = "{A01298C0-876B-4764-A562-CCDCF66086E1}";
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ConnectionStringCachePrefix = "ConnectionString_{0}_".FormatEx(flag);
        /// <summary>
        /// 
        /// </summary>
        public static readonly string sysConnectionString = "ConnectionString_{0}_sysConnectionString".FormatEx(flag);
        /// <summary>
        /// 
        /// </summary>
        public static readonly string EntityPropertiesPrefix = "EntityProperties_{0}_".FormatEx(flag);
        /// <summary>
        /// 
        /// </summary>
        public static readonly string EntityTableNamePrefix = "EntityTableName_{0}_".FormatEx(flag);
        /// <summary>
        /// 
        /// </summary>
        public static readonly string EntityPrimaryKeyPrefix = "EntityPrimaryKey_{0}_".FormatEx(flag);
        /// <summary>
        /// 
        /// </summary>
        public static readonly string EntityTableFieldsKeyPrefix = "EntityTableFields_{0}_".FormatEx(flag);

    }
}
