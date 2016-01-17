using DevExpress.XtraEditors;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SAF.Hardware.Controls.Stopwatch
{
    [XmlRoot("StopwatchConfig")]
    public class StopwatchConfig
    {
        /// <summary>
        /// 码表配置名称
        /// </summary>
        public string ConfigName { get; set; }
        /// <summary>
        /// 码表类型
        /// </summary>
        public StopwatchType StopwatchType { get; set; }
        /// <summary>
        /// 码表单位
        /// </summary>
        public StopwatchUnit StopwatchUnit { get; set; }

        private decimal _Ratio = 1;
        /// <summary>
        /// 码表系数
        /// </summary>
        public decimal Ratio
        {
            get
            {
                return Math.Round(_Ratio, 6);
            }
            set
            {
                if (Math.Round(value, 6) <= 0)
                {
                    MessageService.ShowError("码表系数必须大于0.");
                    return;
                }
                _Ratio = Math.Round(value, 6);
            }
        }

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

    [XmlRoot("StopwatchConfigCollection")]
    public class StopwatchConfigCollection : Collection<StopwatchConfig>
    {

    }
}
