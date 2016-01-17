using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace SAF.Hardware.Controls.Stopwatch.Controller
{
    internal class DefaultController : IStopwatchController
    {
        protected SerialPort serialPort = null;
        protected StopwatchControl Stopwatch = null;

        public DefaultController(StopwatchControl control)
        {
            this.Stopwatch = control;
            this.serialPort = this.Stopwatch.SerialPort;
        }
        /// <summary>
        /// 读数
        /// </summary>
        /// <returns></returns>
        public virtual string Read()
        {
            return "0.00";
        }
        /// <summary>
        /// 清零
        /// </summary>
        public virtual void ClearZero()
        {

        }
        /// <summary>
        /// 设置连续模式
        /// </summary>
        public virtual void SetContinuousMode()
        {

        }
    }
}
