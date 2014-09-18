using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using SAF.Foundation;
using DevExpress.XtraWaitForm;

namespace SAF.Framework.Controls
{
    internal partial class fmProgress : XtraForm
    {
        internal ProgressBarControl ProgressBar
        {
            get { return this.progressBarControl1; }
        }

        private string msg = string.Empty;
        /// <summary>
        /// 窗口的进度消息
        /// </summary>
        internal string Message
        {
            get { return msg; }
            set
            {
                SetMessage(value);
            }
        }
        /// <summary>
        /// 更新消息
        /// </summary>
        /// <param name="message"></param>
        internal void SetMessage(string message)
        {
            if (this.lblMessage.InvokeRequired)
            {
                this.lblMessage.Invoke(new Action<string>(SetMessage), message);
            }
            else
            {
                this.lblMessage.Text = message;
                this.msg = message;
            }
        }

        internal MarqueeProgressBarControl MarqueeProgressBar
        {
            get { return this.marqueeProgressBarControl1; }
        }

        System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();

        int seconds = 0;
        /// <summary>
        /// 计时器时间
        /// </summary>
        public int Seconds
        {
            get { return seconds; }
            set
            {
                seconds = value;
                ShowTitle();
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        internal fmProgress()
        {
            InitializeComponent();
            this.lblMessage.Text = string.Empty;

            this.Width = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.4);

            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            this.Load += new EventHandler(fmProgress_Load);
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            seconds++;
            ShowTitle();
        }
        public string sTitle = string.Empty;

        private void ShowTitle()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ShowTitle));
            }
            else
            {
                string sCaption = string.Format("正在执行...( {0}s ) ", seconds);
                if (!sTitle.IsEmpty())
                    sCaption = string.Format("{0}  {1}", sTitle, sCaption);
                this.Text = sCaption;
            }
        }

        void fmProgress_Load(object sender, EventArgs e)
        {
            ShowTitle();
            this.Refresh();
            Application.DoEvents();
            tmr.Start();
            ProgressProxy.SplashManualResetEvent.Set();
        }

        /// <summary>
        /// 步进Value
        /// </summary>
        /// <param name="value"></param>
        internal void StepIt(int value)
        {
            if (this.ProgressBar.InvokeRequired)
            {
                this.ProgressBar.Invoke(new Action<int>(StepIt), value);
            }
            else
            {
                if (!this.ProgressBar.Visible) return;
                if (this.ProgressBar.Position + value <= this.ProgressBar.Properties.Maximum)
                {
                    this.ProgressBar.Position += value;
                }
                else
                {
                    this.ProgressBar.Position = this.ProgressBar.Properties.Maximum;
                }
            }
        }

        /// <summary>
        /// 关闭进度窗口
        /// </summary>
        internal void CloseProgress()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(CloseProgress));
            }
            else
            {
                try
                {
                    if (!this.IsDisposed)
                        Close();
                }
                catch { }
            }
        }
    }
}
