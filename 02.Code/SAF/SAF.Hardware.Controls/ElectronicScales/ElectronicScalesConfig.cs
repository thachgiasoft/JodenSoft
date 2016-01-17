using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SAF.Hardware.Controls.ElectronicScales
{
    [XmlRoot("ElectronicScalesConfig")]
    public class ElectronicScalesConfig
    {
        /// <summary>
        /// 码表名称
        /// </summary>
        public string ConfigName { get; set; }
        /// <summary>
        /// 码表类型
        /// </summary>
        public ElectronicScalesType ElectronicScalesType { get; set; }

        #region 串口参数

        /// <summary>
        /// 串口名称
        /// </summary>
        public string PortName { get; set; }
        /// <summary>
        /// 每秒位数（比特率）
        /// </summary>
        public int BaudRate { get; set; }
        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBits { get; set; }
        /// <summary>
        /// 奇偶校验
        /// </summary>
        public Parity Parity { get; set; }
        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBits { get; set; }
        /// <summary>
        /// 流控制
        /// </summary>
        public Handshake Handshake { get; set; }

        #endregion

    }

    [XmlRoot("ElectronicScalesConfigCollection")]
    public class ElectronicScalesConfigCollection : Collection<ElectronicScalesConfig>
    {

    }
}
