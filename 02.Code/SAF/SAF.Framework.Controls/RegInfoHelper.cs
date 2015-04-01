﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.Entities;
using SAF.EntityFramework;
using SAF.Foundation;
using SAF.Foundation.Security;
using SAF.Foundation.ServiceModel;
using SAF.Foundation.ComponentModel;

namespace SAF.Framework.Controls
{
    public static class RegInfoHelper
    {
        public static string GetRegInfo()
        {
            var es = new EntitySet<sysRegInfo>();
            es.Query("SELECT * FROM dbo.sysRegInfo WITH(NOLOCK) WHERE ProductId=@ProductId", Session.ProductCode);
            if (es.IsEmpty() || !es.CurrentEntity.FieldIsExists(P => P.RegInfo) || es.CurrentEntity.RegInfo.IsEmpty())
            {
                return string.Empty;
            }

            try
            {
                return DESHelper.Decrypt(es.CurrentEntity.RegInfo);
            }
            catch (Exception ex)
            {
                LoggingService.Error("获取客户端注册信息出错.", ex);
                return string.Empty;
            }
        }

        public static void WriteRegInfo(string pollCode)
        {
            var es = new EntitySet<sysRegInfo>();
            es.Query("SELECT * FROM dbo.sysRegInfo WITH(NOLOCK) WHERE ProductId=@ProductId", Session.ProductCode);
            var entity = es.AddNew();
            entity.Iden = IdenGenerator.NewIden(entity.DbTableName);
            entity.ProductId = Session.ProductCode;
            entity.ComputerName = Session.MachineInfo.MachineName;
            entity.ComputerUserName = Session.MachineInfo.MachineUser;
            entity.RegInfo = DESHelper.Encrypt(pollCode);
            entity.LastLoginTime = DateTime.Now;
            es.SaveChanges();
        }

        public static void UpdateLastTime()
        {
            try
            {
                DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection, "update sysRegInfo set LastLoginTime=getdate() where ProductId=@ProductId", Session.ProductCode);
            }
            catch (Exception ex)
            {
                LoggingService.Error("更新用户最后一次验证时间出错.", ex);
            }
        }
    }

}
