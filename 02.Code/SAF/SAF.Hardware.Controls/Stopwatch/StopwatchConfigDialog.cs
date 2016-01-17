using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.IO.Ports;
using System.Xml.Linq;
using DevExpress.XtraEditors;
using SAF.Hardware.Controls.Stopwatch;
using SAF.Foundation;
using SAF.Foundation.ServiceModel;

namespace SAF.Hardware.Controls
{
    public partial class StopwatchConfigDialog : XtraForm
    {
        private StopwatchControl _StopwatchControl;

        private StopwatchConfigDialog()
        {
            InitializeComponent();
        }

        private StopwatchConfigDialog(StopwatchControl control)
            : this()
        {
            if (control == null)
                throw new ArgumentNullException("control", "构造函数中的参数control不能为空.");

            this._StopwatchControl = control;
        }

        public static DialogResult ShowSetting(StopwatchControl control)
        {
            using (var dlg = new StopwatchConfigDialog(control))
            {
                return dlg.ShowDialog();
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitUI(StopwatchConfig config)
        {
            txtConfigName.Text = _StopwatchControl.ConfigName;//码表名称
            txtConfigName.Enabled = false;

            cmbType.Properties.Items.AddEnum(typeof(StopwatchType));
            cmbType.EditValue = _StopwatchControl.StopwatchType;

            cbxUnit.Properties.Items.AddEnum(typeof(StopwatchUnit));
            cbxUnit.EditValue = _StopwatchControl.StopwatchUnit;

            string[] portNames = SerialPort.GetPortNames();//串口名称
            if (portNames.Length <= 0)
            {
                MessageService.ShowError("本机没有检测到串口，请检查。");
                cmbPortName.Enabled = false;
            }
            else
            {
                cmbPortName.Properties.Items.AddRange(portNames);
                if (portNames.Any(p => p.Equals(config.PortName)))
                    cmbPortName.EditValue = config.PortName;
                else
                    cmbPortName.SelectedIndex = 0;
            }

            txtBautTate.Text = config.BaudRate.ToString();//每秒位数（比特率）
            txtDataBits.Text = config.DataBits.ToString();//数据位

            cmbParity.Properties.Items.Add(Parity.None);//奇偶校验
            cmbParity.Properties.Items.Add(Parity.Even);
            cmbParity.Properties.Items.Add(Parity.Mark);
            cmbParity.Properties.Items.Add(Parity.Odd);
            cmbParity.Properties.Items.Add(Parity.Space);
            cmbParity.EditValue = config.Parity;

            cmbStopBit.Properties.Items.Add(StopBits.None);//停止位
            cmbStopBit.Properties.Items.Add(StopBits.One);
            cmbStopBit.Properties.Items.Add(StopBits.OnePointFive);
            cmbStopBit.Properties.Items.Add(StopBits.Two);
            cmbStopBit.EditValue = config.StopBits;

            cmbHandshake.Properties.Items.Add(Handshake.None);//流控制
            cmbHandshake.Properties.Items.Add(Handshake.RequestToSend);
            cmbHandshake.Properties.Items.Add(Handshake.RequestToSendXOnXOff);
            cmbHandshake.Properties.Items.Add(Handshake.XOnXOff);
            cmbHandshake.EditValue = config.Handshake;

            txtRatio.EditValue = config.Ratio;


        }

        private void balanceConfig_Load(object sender, EventArgs e)
        {
            StopwatchConfig setting = StopwatchConfigManager.Current.GetConfig(_StopwatchControl.ConfigName);
            if (setting == null)
            {
                setting = _StopwatchControl.GetConfig();
                StopwatchConfigManager.Current.AddSetting(setting);
            }

            InitUI(setting);

            txtConfigName.Text = setting.ConfigName;
            cmbType.EditValue = setting.StopwatchType;
            txtRatio.EditValue = setting.Ratio;
            cbxUnit.EditValue = setting.StopwatchUnit;

            cmbPortName.SelectedItem = setting.PortName;//串口名称
            txtBautTate.Text = setting.BaudRate.ToString();//每秒位数（比特率）
            txtDataBits.Text = setting.DataBits.ToString();//数据位
            cmbParity.SelectedItem = setting.Parity;//奇偶校验
            cmbStopBit.SelectedItem = setting.StopBits;//停止位
            cmbHandshake.SelectedItem = setting.Handshake;//流控制


        }
        //点击保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            var result = int.TryParse(this.txtBautTate.EditValue.ToStringEx(), out i);
            if (!result)
            {
                MessageService.ShowError("每秒位数必须为数字.");
                return;
            }
            result = int.TryParse(this.txtDataBits.EditValue.ToStringEx(), out i);
            if (!result)
            {
                MessageService.ShowError("数据位必须为数字");
                return;
            }

            StopwatchConfig bs = new StopwatchConfig();
            bs.ConfigName = txtConfigName.Text;
            bs.StopwatchType = (StopwatchType)cmbType.EditValue;
            bs.PortName = cmbPortName.EditValue.ToStringEx();
            bs.BaudRate = Convert.ToInt32(txtBautTate.Text);
            bs.DataBits = Convert.ToInt32(txtDataBits.Text);
            bs.Parity = (Parity)cmbParity.EditValue;
            bs.StopBits = (StopBits)cmbStopBit.EditValue;
            bs.Handshake = (Handshake)cmbHandshake.EditValue;
            bs.StopBits = (StopBits)cmbStopBit.EditValue;
            bs.Ratio = txtRatio.Value;
            StopwatchConfigManager.Current.AddSetting(bs);

            MessageService.ShowMessage("配置保存成功。");
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetContinuousMode_Click(object sender, EventArgs e)
        {
            _StopwatchControl.SetContinuousMode();
        }
    }
}
