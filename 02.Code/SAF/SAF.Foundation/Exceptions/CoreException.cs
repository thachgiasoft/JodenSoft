using System;
using System.Runtime.Serialization;

namespace SAF.Foundation
{
    /// <summary>
    /// 在SAF内核执行期间发生的错误,此异常会导致应用程序强行关闭
    /// </summary>
    [Serializable()]
    public class CoreException : Exception
    {
        /// <summary>
        /// 初始化 CoreException 类的新实例。
        /// </summary>
        public CoreException()
            : base()
        {
        }
        /// <summary>
        /// 使用指定的错误消息初始化 CoreException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public CoreException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化 CoreException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        /// <param name="innerException">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用</param>
        public CoreException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        /// <summary>
        /// 用序列化数据初始化 System.Exception 类的新实例。
        /// </summary>
        /// <param name="info">System.Runtime.Serialization.SerializationInfo，它存有有关所引发异常的序列化的对象数据。</param>
        /// <param name="context">System.Runtime.Serialization.StreamingContext，它包含有关源或目标的上下文信息。</param>
        protected CoreException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
