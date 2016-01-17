
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using SAF.Foundation;

namespace SAF.Hardware.Controls.Stopwatch.Controller
{
    /// <summary>
    /// 环思19寸大屏终端自带码表解码控制器
    /// </summary>
    internal class SHHSController : DefaultController
    {
        public SHHSController(StopwatchControl control) : base(control)
        {
        }

        
        private string recivedStr = string.Empty;
        private string oldStr = string.Empty;

        public override string Read()
        {
            var zeroString = "0.00";
            if (!this.serialPort.IsOpen)
            {
                return zeroString;
            }

            try
            {
                int iLength = this.serialPort.BytesToRead;

                Byte[] chrdata = new Byte[iLength];
                serialPort.Read(chrdata, 0, iLength);

                for (int i = 0; i < iLength; i++)
                {
                    //如果字节为70，则在末尾加上FF做为结束符并另起一行
                    recivedStr += (chrdata[i].ToString("X2") == "70" ? "FF" + Environment.NewLine : string.Empty) + chrdata[i].ToString("X2") + " ";
                    if (recivedStr.Length > 100)
                        break;
                }
                //取最后一次的有效值.
                Regex paramReg = new Regex(@"(?<p>70\s+7A.+FF)");
                MatchCollection matches = paramReg.Matches(String.Concat(recivedStr, " "));
                if (matches.Count > 0)
                {
                    recivedStr = string.Empty;
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();

                    Match m = matches[matches.Count - 1];
                    oldStr = m.Groups["p"].Value;
                }

                var data = oldStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (data.Length != 7)
                {
                    return zeroString;
                }

                Int64 value = Convert.ToInt64(string.Concat(data[5], data[4], data[3], data[2]), 16);

                var nLength = value * this.Stopwatch.Ratio;

                if (this.Stopwatch.StopwatchUnit == StopwatchUnit.M)
                    return Math.Round(nLength, 4).ToString("0.####");
                else
                    return Math.Round(nLength / 0.9144m, 4).ToString("0.####");
            }
            catch
            {
                return zeroString;
            }
        }

        public override void ClearZero()
        {
            //707A03
            var isColse = true;
            if (!this.serialPort.IsOpen)
            {
                try
                {
                    this.serialPort.Open();
                    isColse = true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("尝试清零出错，串口无法打开！{0}错误详情：{1}".FormatWith(Environment.NewLine, ex.Message), "CIP- 消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                isColse = false;
            }

            var data = new byte[3];
            data[0] = 0x70;
            data[1] = 0x7A;
            data[2] = 0x03;
            this.serialPort.Write(data, 0, 3);

            if (isColse)
            {
                this.serialPort.Close();
            }
        }

        public override void SetContinuousMode()
        {
            //707A0401
            var isColse = true;
            if (!this.serialPort.IsOpen)
            {
                try
                {
                    this.serialPort.Open();
                    isColse = true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("尝试清零出错，串口无法打开！{0}错误详情：{1}".FormatWith(Environment.NewLine, ex.Message), "CIP- 消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                isColse = false;
            }

            var data = new byte[4];
            data[0] = 0x70;
            data[1] = 0x7A;
            data[2] = 0x04;
            data[3] = 0x01;
            this.serialPort.Write(data, 0, 4);

            if (isColse)
            {
                this.serialPort.Close();
            }

            XtraMessageBox.Show("设置成功。", "CIP- 消息", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
