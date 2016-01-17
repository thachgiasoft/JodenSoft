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
using SAF.Foundation;
using SAF.Hardware.Controls.ElectronicScales;
using SAF.Foundation.ServiceModel;

namespace SAF.Hardware.Controls
{
    public partial class ElectronicScalesConfigDialog : XtraForm
    {
        private ElectronicScalesControl _ElectronicScalesControl;

        private ElectronicScalesConfigDialog()
        {
            InitializeComponent();
        }

        private ElectronicScalesConfigDialog(ElectronicScalesControl control)
            : this()
        {
            if (control == null)
                throw new ArgumentNullException("control", "构造函数中的参数control不能为空.");

            this._ElectronicScalesControl = control;
        }

        public static DialogResult ShowSetting(ElectronicScalesControl control)
        {
            using (var dlg = new ElectronicScalesConfigDialog(control))
            {
                return dlg.ShowDialog();
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitUI(ElectronicScalesConfig config)
        {
            txtConfigName.Text = _ElectronicScalesControl.ConfigName;
            txtConfigName.Enabled = false;

            cmbType.Properties.Items.AddEnum(typeof(ElectronicScalesType));
            cmbType.EditValue = _ElectronicScalesControl.ElectronicScalesType;

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

        }

        private void electronicScalesConfig_Load(object sender, EventArgs e)
        {
            ElectronicScalesConfig setting = ElectronicScalesConfigManager.Current.GetConfig(_ElectronicScalesControl.ConfigName);
            if (setting == null)
            {
                setting = _ElectronicScalesControl.GetConfig();
                ElectronicScalesConfigManager.Current.AddSetting(setting);
            }

            InitUI(setting);

            txtConfigName.Text = setting.ConfigName;
            cmbType.EditValue = setting.ElectronicScalesType;

            cmbPortName.SelectedItem = setting.PortName;//串口名称
            txtBautTate.Text = setting.BaudRate.ToString();//每秒位数（比特率）
            txtDataBits.Text = setting.DataBits.ToString();//数据位
            cmbParity.SelectedItem = setting.Parity;//奇偶校验
            cmbStopBit.SelectedItem = setting.StopBits;//停止位
            cmbHandshake.SelectedItem = setting.Handshake;//流控制
        }
        /// <summary>
        /// 点击保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                MessageService.ShowError("数据位必须为数字.");
                return;
            }

            ElectronicScalesConfig config = new ElectronicScalesConfig();
            config.ConfigName = txtConfigName.Text;
            config.ElectronicScalesType = (ElectronicScalesType)cmbType.EditValue;
            config.PortName = cmbPortName.EditValue.ToStringEx();
            config.BaudRate = Convert.ToInt32(txtBautTate.Text);
            config.DataBits = Convert.ToInt32(txtDataBits.Text);
            config.Parity = (Parity)cmbParity.EditValue;
            config.StopBits = (StopBits)cmbStopBit.EditValue;
            config.Handshake = (Handshake)cmbHandshake.EditValue;
            config.StopBits = (StopBits)cmbStopBit.EditValue;
            ElectronicScalesConfigManager.Current.AddSetting(config);

            MessageService.ShowMessage("配置保存成功。");
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
