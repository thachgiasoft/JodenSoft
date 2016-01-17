using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Hardware.Controls.Stopwatch.Controller
{
    internal interface IStopwatchController
    {
        /// <summary>
        /// 读数
        /// </summary>
        /// <returns></returns>
        string Read();
        /// <summary>
        /// 清零
        /// </summary>
        void ClearZero();
        /// <summary>
        /// 设置连续模式
        /// </summary>
        void SetContinuousMode();
    }
}
