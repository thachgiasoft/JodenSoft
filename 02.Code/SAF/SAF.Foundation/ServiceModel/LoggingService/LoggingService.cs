using System;
using System.Collections.Generic;
using System.Text;

namespace SAF.Foundation.ServiceModel
{
    /// <summary>
    /// 日志记录服务
    /// </summary>
    public static class LoggingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(object message)
        {
            ServiceManager.Instance.LoggingService.Debug(message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void DebugFormatted(string format, params object[] args)
        {
            ServiceManager.Instance.LoggingService.DebugFormatted(format, args);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Info(object message)
        {
            ServiceManager.Instance.LoggingService.Info(message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void InfoFormatted(string format, params object[] args)
        {
            ServiceManager.Instance.LoggingService.InfoFormatted(format, args);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(object message)
        {
            ServiceManager.Instance.LoggingService.Warn(message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Warn(object message, Exception exception)
        {
            ServiceManager.Instance.LoggingService.Warn(message, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void WarnFormatted(string format, params object[] args)
        {
            ServiceManager.Instance.LoggingService.WarnFormatted(format, args);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Error(object message)
        {
            ServiceManager.Instance.LoggingService.Error(message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(object message, Exception exception)
        {
            ServiceManager.Instance.LoggingService.Error(message, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void ErrorFormatted(string format, params object[] args)
        {
            ServiceManager.Instance.LoggingService.ErrorFormatted(format, args);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(object message)
        {
            ServiceManager.Instance.LoggingService.Fatal(message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Fatal(object message, Exception exception)
        {
            ServiceManager.Instance.LoggingService.Fatal(message, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void FatalFormatted(string format, params object[] args)
        {
            ServiceManager.Instance.LoggingService.FatalFormatted(format, args);
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsDebugEnabled
        {
            get
            {
                return ServiceManager.Instance.LoggingService.IsDebugEnabled;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsInfoEnabled
        {
            get
            {
                return ServiceManager.Instance.LoggingService.IsInfoEnabled;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsWarnEnabled
        {
            get
            {
                return ServiceManager.Instance.LoggingService.IsWarnEnabled;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsErrorEnabled
        {
            get
            {
                return ServiceManager.Instance.LoggingService.IsErrorEnabled;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsFatalEnabled
        {
            get
            {
                return ServiceManager.Instance.LoggingService.IsFatalEnabled;
            }
        }
    }
}
