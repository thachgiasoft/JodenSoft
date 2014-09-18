using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SAF.Foundation.ServiceModel
{
    /// <summary>
    /// TextWriter that writes into System.Diagnostics.Debug
    /// </summary>
    public class DebugTextWriter : TextWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public override Encoding Encoding
        {
            get
            {
                return Encoding.Unicode;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public override void Write(char value)
        {
            Debug.Write(value.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public override void Write(char[] buffer, int index, int count)
        {
            Debug.Write(new string(buffer, index, count));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public override void Write(string value)
        {
            Debug.Write(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void WriteLine()
        {
            Debug.WriteLine(string.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public override void WriteLine(string value)
        {
            Debug.WriteLine(value);
        }
    }
}
