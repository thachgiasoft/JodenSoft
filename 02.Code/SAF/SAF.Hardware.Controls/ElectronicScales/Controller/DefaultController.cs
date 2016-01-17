using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace SAF.Hardware.Controls.ElectronicScales.Controller
{
    internal class DefaultController : IElectronicScalesController
    {
        protected SerialPort serialPort = null;
        protected ElectronicScalesControl ElectronicScales = null;

        public DefaultController(ElectronicScalesControl control)
        {
            this.ElectronicScales = control;
            this.serialPort = this.ElectronicScales.SerialPort;
        }
        /// <summary>
        /// 读数
        /// </summary>
        /// <returns></returns>
        public virtual string Read()
        {
            return "0.00";
        }
        
    }
}
