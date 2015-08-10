using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using System.Reflection;
using SAF.Foundation.ComponentModel;
using log4net;
using SAF.Foundation.ServiceModel;

namespace SAF.Framework.ServiceModel
{
    /// <summary>
    /// log4net 方式记录日志
    /// </summary>
    public sealed class Log4netLoggingService : ILoggingService
    {
        ILog log;

        public Log4netLoggingService()
        {
            string configFilePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configFilePath));
            log = LogManager.GetLogger(typeof(Log4netLoggingService));
        }

        public void Debug(object message)
        {
            log.Debug(message);
        }

        public void DebugFormatted(string format, params object[] args)
        {
            log.DebugFormat(CultureInfo.InvariantCulture, format, args);
        }

        public void Info(object message)
        {
            log.Info(message);
        }

        public void InfoFormatted(string format, params object[] args)
        {
            log.InfoFormat(CultureInfo.InvariantCulture, format, args);
        }

        public void Warn(object message)
        {
            log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            log.Warn(message, exception);
        }

        public void WarnFormatted(string format, params object[] args)
        {
            log.WarnFormat(CultureInfo.InvariantCulture, format, args);
        }

        public void Error(object message)
        {
            log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }

        public void ErrorFormatted(string format, params object[] args)
        {
            log.ErrorFormat(CultureInfo.InvariantCulture, format, args);
        }

        public void Fatal(object message)
        {
            log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            log.Fatal(message, exception);
        }

        public void FatalFormatted(string format, params object[] args)
        {
            log.FatalFormat(CultureInfo.InvariantCulture, format, args);
        }

        public bool IsDebugEnabled
        {
            get
            {
                return log.IsDebugEnabled;
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return log.IsInfoEnabled;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return log.IsWarnEnabled;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return log.IsErrorEnabled;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return log.IsFatalEnabled;
            }
        }
    }
}
