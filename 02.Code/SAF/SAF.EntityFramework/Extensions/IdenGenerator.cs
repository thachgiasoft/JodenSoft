using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public static class IdenGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="groupName"></param>
        /// <param name="count"></param>
        /// <param name="save"></param>
        /// <param name="startIden"></param>
        /// <returns></returns>
        public static int NewIden(string connectionName, string groupName, int count, bool save, int startIden)
        {
            var obj = DataPortal.ExecuteScalar(connectionName, "exec dbo.sysGenerateIden :GroupName,:Count,0,:Save,1,:StartIden", groupName, count, save, startIden);
            return Convert.ToInt32(obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static int NewIden(string connectionName, string groupName)
        {
            return NewIden(connectionName, groupName, 1, true, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static int NewIden(string groupName)
        {
            return NewIden(ConfigContext.DefaultConnection, groupName);
        }
    }
}
