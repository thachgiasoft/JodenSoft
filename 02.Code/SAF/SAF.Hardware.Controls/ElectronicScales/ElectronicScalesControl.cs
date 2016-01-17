using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO.Ports;
using System.Threading;
using SAF.Hardware.Controls.ElectronicScales.Controller;
using SAF.Hardware.Controls.ElectronicScales;
using SAF.Foundation.ServiceModel;

namespace SAF.Hardware.Controls
{
    public partial class ElectronicScalesControl : XtraUserControl, INotifyPropertyChanged
    {
        private bool Listening = false;//是否没有执行完invoke相关操作  
        private bool Closing = false;//是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke 

        public ElectronicScalesControl()
        {
            InitializeComponent();

            OnInitial();

            this.Disposed += _Disposed;

        }

        void _Disposed(object sender, EventArgs e)
        {
            this.Stop();
        }

        /// <summary>
        /// 电子称配置名称
        /// </summary>
        [DefaultValue("ElectronicScales")]
        public string ConfigName
        {
            get;
            set;
        }

        private ElectronicScalesType _ElectronicScalesType = ElectronicScalesType.None;
        /// <summary>
        /// 电子称类型
        /// </summary>
        [DefaultValue(typeof(ElectronicScalesType), "SAF.Hardware.Controls.ElectronicScales.ElectronicScalesType.None")]
        public ElectronicScalesType ElectronicScalesType
        {
            get { return _ElectronicScalesType; }
            set
            {
                _ElectronicScalesType = value;
                this._ElectronicScalesController = null;
            }
        }

        public void ApplyConfig(ElectronicScalesConfig config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            this.ConfigName = config.ConfigName;
            this.ElectronicScalesType = config.ElectronicScalesType;

            if (ComPortEnable)
            {
                if (!string.IsNullOrWhiteSpace(config.PortName))
                    this.serialPort.PortName = config.PortName;

                this.serialPort.BaudRate = config.BaudRate;
                this.serialPort.DataBits = config.DataBits;
                this.serialPort.Parity = config.Parity;
                this.serialPort.StopBits = config.StopBits;
                this.serialPort.Handshake = config.Handshake;
            }

        }

        public ElectronicScalesConfig GetConfig()
        {
            var config = new ElectronicScalesConfig();
            config.ConfigName = this.ConfigName;
            config.ElectronicScalesType = this.ElectronicScalesType;


            config.PortName = this.serialPort.PortName;
            config.BaudRate = Convert.ToInt32(this.serialPort.BaudRate);
            config.DataBits = this.serialPort.DataBits;
            config.Parity = this.serialPort.Parity;
            config.StopBits = this.serialPort.StopBits;
            config.Handshake = this.serialPort.Handshake;

            return config;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public SerialPort SerialPort
        {
            get { return serialPort; }
        }

        /// <summary>
        /// 开始读数
        /// </summary>
        public void Start()
        {
            if (!ComPortEnable)
            {
                MessageService.ShowError("未在本机检测到串口，无法启动电子称。");
                return;
            }

            if (this.serialPort.IsOpen)
                this.Stop();

            this._ElectronicScalesController = null;
            ElectronicScalesConfigManager.Current.RestoreConfig(this);

            try
            {
                this.serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageService.ShowError(string.Format("连接码表时发生错误。{0}{0}错误详情：{0}{1}", Environment.NewLine, ex.Message));
            }
        }

        /// <summary>
        /// 停止读数
        /// </summary>
        public void Stop()
        {
            if (this.serialPort.IsOpen)
            {
                Closing = true;
                while (Listening) Application.DoEvents();
                this.serialPort.Close();
                Closing = false;
            }
        }

        private void OnInitial()
        {
            this.ConfigName = "ElectronicScales";

            this.ledLabel1.Text = "0";
            this.ledLabel1.MouseDoubleClick += ledControl_MouseDoubleClick;

            this.ElectronicScalesType = ElectronicScalesType.None;


            var list = SerialPort.GetPortNames();
            if (list.Length > 0)
                this.serialPort.PortName = list[0];
            this.serialPort.BaudRate = 9600;
            this.serialPort.DataBits = 8;
            this.serialPort.Parity = Parity.None;
            this.serialPort.StopBits = StopBits.One;
            this.serialPort.Handshake = Handshake.None;


            this.serialPort.DataReceived += serialPort_DataReceived;
        }

        void ledControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                ConfigElectronicScales();
            }
        }

        /// <summary>
        /// 串口是否可用
        /// </summary>
        public static bool ComPortEnable
        {
            get
            {
                string[] portNames = SerialPort.GetPortNames();//串口名称
                return portNames.Length > 0;
            }
        }

        /// <summary>
        /// 配置电子称
        /// </summary>
        public void ConfigElectronicScales()
        {

#if !DEBUG

            if (!ComPortEnable)
            {
                MessageService.ShowError("未在本机检测到COM口，无法连接码表完成配置。");
                return;
            }

#endif

            if (ElectronicScalesConfigDialog.ShowSetting(this) == DialogResult.OK)
            {
                this.Stop();
                this.Start();
            }
        }

        void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (Closing) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环

            try
            {
                Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI的。

                Thread.Sleep(10);
                string value = string.Empty;

                try
                {
                    var decode = GetController();
                    value = decode.Read();
                    this.EditValue = string.IsNullOrWhiteSpace(value) ? 0.00m : Convert.ToDecimal(value);
                }
                finally
                {
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();
                }
            }
            finally
            {
                Listening = false;//我用完了，ui可以关闭串口了。
            }
        }

        private void UpdateLabel(string value)
        {
            if (this.IsHandleCreated && !this.IsDisposed && this.ledLabel1.IsHandleCreated && !this.ledLabel1.IsDisposed)
            {
                this.ledLabel1.Text = value;
            }
        }

        private IElectronicScalesController _ElectronicScalesController = null;
        private IElectronicScalesController GetController()
        {
            if (_ElectronicScalesController == null)
            {
                _ElectronicScalesController = ElectronicScalesControllerFactory.CreateController(this);
            }
            return _ElectronicScalesController;
        }

        private decimal _EditValue = 0m;
        [Bindable(true)]
        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal EditValue
        {
            get
            {
                return _EditValue;
            }
            set
            {
                this._EditValue = value;
                OnPropertyChanged("EditValue");

                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        this.UpdateLabel(this._EditValue.ToString());
                    }));
                }
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

}
