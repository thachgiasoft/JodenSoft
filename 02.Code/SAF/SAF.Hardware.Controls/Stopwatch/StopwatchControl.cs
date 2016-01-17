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
using SAF.Hardware.Controls.Stopwatch.Controller;
using SAF.Hardware.Controls.Stopwatch;
using SAF.Foundation.ServiceModel;

namespace SAF.Hardware.Controls
{
    public partial class StopwatchControl : XtraUserControl, INotifyPropertyChanged
    {
        private bool Listening = false;//是否没有执行完invoke相关操作  
        private bool Closing = false;//是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke 


        #region 事件

        private static readonly object SpeedChangedEvent = new object();

        public event EventHandler<StopwatchSpeedChangedEventArgs> SpeedChanged
        {
            add { this.Events.AddHandler(SpeedChangedEvent, value); }
            remove { this.Events.RemoveHandler(SpeedChangedEvent, value); }
        }

        private void OnSpeedChanged(decimal speed)
        {
            var handler = this.Events[SpeedChangedEvent] as EventHandler<StopwatchSpeedChangedEventArgs>;
            if (handler != null)
            {
                handler(this, new StopwatchSpeedChangedEventArgs(speed));
            }
        }

        #endregion

        public StopwatchControl()
        {
            InitializeComponent();

            OnInitial();

            this.Disposed += _Disposed;

#if DEBUG
            Application.Idle += Application_Idle;
#endif

        }

        private void Application_Idle(object sender, EventArgs e)
        {
            CalcSpeed();
        }

        void _Disposed(object sender, EventArgs e)
        {
            this.Stop();
        }

        /// <summary>
        /// 码表配置名称
        /// </summary>
        [DefaultValue("Stopwatch")]
        public string ConfigName
        {
            get;
            set;
        }

        private StopwatchType _StopwatchType = StopwatchType.None;
        /// <summary>
        /// 码表类型
        /// </summary>
        [DefaultValue(typeof(StopwatchType), "SAF.Hardware.Controls.Stopwatch.StopwatchType.None")]
        public StopwatchType StopwatchType
        {
            get { return _StopwatchType; }
            set
            {
                _StopwatchType = value;
                this._StopwatchController = null;
            }
        }

        [DefaultValue(typeof(StopwatchUnit), "SAF.Hardware.Controls.Stopwatch.StopwatchUnit.M")]
        public StopwatchUnit StopwatchUnit
        {
            get; set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string Unit
        {
            get
            {
                return StopwatchUnit == StopwatchUnit.M ? "M" : "YD";
            }
        }

        /// <summary>
        /// 码表系数,SHHS专用
        /// </summary>
        [DefaultValue(1)]
        [Browsable(false)]
        public decimal Ratio
        {
            get; private set;
        }

        private decimal _speedValue = 0m;
        /// <summary>
        /// 车速(时间间隔用分钟，分别为 码/分， 米/分)
        /// </summary>
        [Bindable(true)]
        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal SpeedValue
        {
            get { return _speedValue; }
            set
            {
                _speedValue = value;
                OnPropertyChanged("SpeedValue");
                OnSpeedChanged(_speedValue);
            }
        }

        public void ApplyConfig(StopwatchConfig config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            this.ConfigName = config.ConfigName;
            this.StopwatchType = config.StopwatchType;
            this.Ratio = config.Ratio;
            this.StopwatchUnit = config.StopwatchUnit;

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

        public StopwatchConfig GetConfig()
        {
            var config = new StopwatchConfig();
            config.ConfigName = this.ConfigName;
            config.StopwatchType = this.StopwatchType;
            config.Ratio = this.Ratio;
            config.StopwatchUnit = this.StopwatchUnit;

            config.PortName = this.serialPort.PortName;
            config.BaudRate = Convert.ToInt32(this.serialPort.BaudRate);
            config.DataBits = this.serialPort.DataBits;
            config.Parity = this.serialPort.Parity;
            config.StopBits = this.serialPort.StopBits;
            config.Handshake = this.serialPort.Handshake;

            return config;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                MessageService.ShowError("未在本机检测到串口，无法启动码表。");
                return;
            }

            if (this.serialPort.IsOpen)
                this.Stop();

            this._StopwatchController = null;
            StopwatchConfigManager.Current.RestoreConfig(this);

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
            this.ConfigName = "Stopwatch";

            this.ledLabel1.Text = "0";
            this.ledLabel1.MouseDoubleClick += ledControl_MouseDoubleClick;

            this.StopwatchType = StopwatchType.None;
            this.StopwatchUnit = StopwatchUnit.M;

            var list = SerialPort.GetPortNames();
            if (list.Length > 0)
                this.serialPort.PortName = list[0];
            this.serialPort.BaudRate = 9600;
            this.serialPort.DataBits = 8;
            this.serialPort.Parity = Parity.None;
            this.serialPort.StopBits = StopBits.One;
            this.serialPort.Handshake = Handshake.None;
            this.Ratio = 1;

            this.serialPort.DataReceived += serialPort_DataReceived;
        }

        void ledControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                ConfigStopwatch();
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
        /// 配置码表
        /// </summary>
        public void ConfigStopwatch()
        {

#if !DEBUG

            if (!ComPortEnable)
            {
                MessageService.ShowError("未在本机检测到COM口，无法连接码表完成配置。");
                return;
            }

#endif

            if (StopwatchConfigDialog.ShowSetting(this) == DialogResult.OK)
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

        private IStopwatchController _StopwatchController = null;
        private IStopwatchController GetController()
        {
            if (_StopwatchController == null)
            {
                _StopwatchController = StopwatchControllerFactory.CreateController(this);
            }
            return _StopwatchController;
        }

        /// <summary>
        /// 清零
        /// </summary>
        public void ClearZero()
        {
            var controller = GetController();
            if (controller != null)
            {
                controller.ClearZero();
            }
        }

        /// <summary>
        /// 设置连续模式
        /// </summary>
        public void SetContinuousMode()
        {
            var controller = GetController();
            if (controller != null)
            {
                controller.SetContinuousMode();
            }
        }


        private int number = 0;
        private decimal lastMeter = 0m;
        int lastTickCount = Environment.TickCount;

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

                number++;
                CalcSpeed();
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        this.UpdateLabel(this._EditValue.ToString());
                    }));
                }
            }
        }

        private void CalcSpeed()
        {
            //10次读数后计算码表车速
            if (number >= 10)
            {
                SpeedValue = Math.Round((this._EditValue - lastMeter) * 1000 * 60 / (Environment.TickCount - lastTickCount), 2);
                lastMeter = this._EditValue;
                lastTickCount = Environment.TickCount;
                number = 0;
            }
            else
            {
                ///15秒之后码表计数未变则速度显示为0
                if (Environment.TickCount - lastTickCount > 1500)
                {
                    if (Math.Abs(this._EditValue - lastMeter) <= 0.000000001m)
                    {
                        SpeedValue = 0.00m;
                        lastMeter = this._EditValue;
                        lastTickCount = Environment.TickCount;
                        number = 0;
                    }
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
