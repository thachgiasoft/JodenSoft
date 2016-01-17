using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace SAF.Hardware.Controls.Stopwatch.Controller
{
    internal static class StopwatchControllerFactory
    {
        public static IStopwatchController CreateController(StopwatchControl stopwatch)
        {
            switch (stopwatch.StopwatchType)
            {
                case StopwatchType.None:
                    return new DefaultController(stopwatch);
                default:
                    return new DefaultController(stopwatch);
            }
        }
    }
}
