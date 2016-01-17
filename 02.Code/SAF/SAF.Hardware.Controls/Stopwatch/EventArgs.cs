using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Hardware.Controls
{
    /// <summary>
    /// 码表车速改变事件参数
    /// </summary>
    public class StopwatchSpeedChangedEventArgs : EventArgs
    {
        public decimal Speed { get; private set; }

        public StopwatchSpeedChangedEventArgs(decimal speed)
        {
            this.Speed = speed;
        }
    }
}
