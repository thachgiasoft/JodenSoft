using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ScheduleQueryPortal.Foundation
{
    public static class WebConfig
    {
        public static string GetConnectionString()
        {
            return GetConnectionString("DefaultConnection");
        }
        public static string GetConnectionString(string connectionStringKeyName)
        {
            var connectionStringSetting = ConfigurationManager.ConnectionStrings[connectionStringKeyName];
            if (connectionStringSetting == null)
            {
                throw new Exception(string.Format("配置文件中不存在名称为[{0}]的数据库连接配置项。", connectionStringKeyName));
            }

            return connectionStringSetting.ConnectionString;
        }
    }
}
