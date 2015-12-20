using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// 显示异常的所有描述信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetAllMessage(this Exception ex)
        {
            StringBuilder message = new StringBuilder();
            Exception e = ex;
            while (e != null)
            {
                message.AppendLine(e.Message);
                e = e.InnerException;
            }
            return message.ToString().Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetAllException(this Exception ex)
        {
            StringBuilder message = new StringBuilder();
            Exception e = ex;
            while (e != null)
            {
                message.AppendLine("Message: {0}".FormatWith(e.Message));
                message.AppendLine("Source: {0}".FormatWith(e.Source));
                message.AppendLine("StackTrace: {0}".FormatWith(e.StackTrace));
                message.AppendLine("TargetSite: {0}".FormatWith(e.TargetSite.ToStringEx()));
                message.AppendLine("===========================");
                message.AppendLine("");

                e = e.InnerException;
            }
            return message.ToString().Trim();
        }
    }
}
