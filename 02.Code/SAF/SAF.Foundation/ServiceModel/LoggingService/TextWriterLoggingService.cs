using System;
using System.IO;
using SAF.Foundation.ComponentModel;

namespace SAF.Foundation.ServiceModel
{
    /// <summary>
    /// TextWriterLoggingService implementation that logs into a TextWriter.
    /// </summary>
    public class TextWriterLoggingService : ILoggingService
    {
        readonly TextWriter writer;
        private bool _IsDebugEnabled;
        private bool _IsInfoEnabled;
        private bool _IsWarnEnabled;
        private bool _IsErrorEnabled;
        private bool _IsFatalEnabled;

        public TextWriterLoggingService(TextWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            this.writer = writer;

            this._IsFatalEnabled = true;
            this._IsErrorEnabled = true;
            this._IsWarnEnabled = true;
            this._IsInfoEnabled = true;
            this._IsDebugEnabled = true;
        }

        void Write(object message, Exception exception)
        {
            if (message != null)
            {
                writer.WriteLine(message.ToString());
            }
            if (exception != null)
            {
                writer.WriteLine(exception.ToString());
            }
        }

        public bool IsDebugEnabled
        {
            get { return _IsDebugEnabled; }
        }
        public bool IsInfoEnabled
        {
            get { return _IsInfoEnabled; }
        }
        public bool IsWarnEnabled
        {
            get { return _IsWarnEnabled; }
        }
        public bool IsErrorEnabled
        {
            get { return _IsErrorEnabled; }
        }
        public bool IsFatalEnabled
        {
            get { return _IsFatalEnabled; }
        }

        public void Debug(object message)
        {
            if (IsDebugEnabled)
            {
                Write(message, null);
            }
        }

        public void DebugFormatted(string format, params object[] args)
        {
            Debug(string.Format(format, args));
        }

        public void Info(object message)
        {
            if (IsInfoEnabled)
            {
                Write(message, null);
            }
        }

        public void InfoFormatted(string format, params object[] args)
        {
            Info(string.Format(format, args));
        }

        public void Warn(object message)
        {
            Warn(message, null);
        }

        public void Warn(object message, Exception exception)
        {
            if (IsWarnEnabled)
            {
                Write(message, exception);
            }
        }

        public void WarnFormatted(string format, params object[] args)
        {
            Warn(string.Format(format, args));
        }

        public void Error(object message)
        {
            Error(message, null);
        }

        public void Error(object message, Exception exception)
        {
            if (IsErrorEnabled)
            {
                Write(message, exception);
            }
        }

        public void ErrorFormatted(string format, params object[] args)
        {
            Error(string.Format(format, args));
        }

        public void Fatal(object message)
        {
            Fatal(message, null);
        }

        public void Fatal(object message, Exception exception)
        {
            if (IsFatalEnabled)
            {
                Write(message, exception);
            }
        }

        public void FatalFormatted(string format, params object[] args)
        {
            Fatal(string.Format(format, args));
        }
    }
}
