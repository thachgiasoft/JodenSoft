using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Hardware.Controls.ElectronicScales.Controller
{
    internal interface IElectronicScalesController
    {
        /// <summary>
        /// 读数
        /// </summary>
        /// <returns></returns>
        string Read();

    }
}
