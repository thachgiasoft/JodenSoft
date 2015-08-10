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

    }
}
