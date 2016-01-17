using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace SAF.Hardware.Controls.ElectronicScales.Controller
{
    internal static class ElectronicScalesControllerFactory
    {
        public static IElectronicScalesController CreateController(ElectronicScalesControl electronicScales)
        {
            switch (electronicScales.ElectronicScalesType)
            {
                case ElectronicScalesType.None:
                    return new DefaultController(electronicScales);
                default:
                    return new DefaultController(electronicScales);
            }
        }
    }
}
