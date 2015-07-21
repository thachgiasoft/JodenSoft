using DevExpress.XtraEditors;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SAF.Foundation;

namespace SAF.Framework.Controls
{
    [ToolboxItem(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SplashScreen : XtraForm
    {
        private SplashScreen()
        {
            InitializeComponent();
            this.Load += frmSplash_Load;
            this.Shown += SplashScreen_Shown;
        }

        int GetYearString()
        {
            return DateTime.Now.Year;
        }

        void SplashScreen_Shown(object sender, EventArgs e)
        {
            
            label1.Text = string.Format(@"本计算机程序受著作权法和国际条约保护，详情请参见""帮助""/""关于""。{0}Copyright © 2003 - {1} {2}。", Environment.NewLine, GetYearString(), AssemblyInfoHelper.Company);
            label1.Text += "{0}保留所有权利。".FormatWith(Environment.NewLine);
            this.picHS.Image = Properties.Resources.JodenSoft;

            this.marqueeProgressBarControl1.Top = this.panel1.Top - this.marqueeProgressBarControl1.Height - 10;
            var top = this.marqueeProgressBarControl1.Top - this.txtMessage.Height - 5;
            this.txtMessage.Top = top;

            SplashScreen.Set();
        }

        System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();

        void frmSplash_Load(object sender, EventArgs e)
        {
            tmr.Interval = 400;
            tmr.Tick += new EventHandler(tmr_Tick);

            this.Activate();
            var href = new HandleRef(this, this.Handle);
            SetForegroundWindow(href);
        }

        /// <summary>
        /// 更新进度信息
        /// </summary>
        /// <param name="message">消息</param>
        public void ShowSplashMessage(string message)
        {
            this.txtMessage.Text = message;
            _message = message;
            tmr.Stop();
            tmr.Start();
        }

        int dotCount = 0;
        string _message = string.Empty;

        void tmr_Tick(object sender, EventArgs e)
        {
            if (++dotCount > 3) dotCount = 0;

            this.txtMessage.Text = string.Format("{0}{1}", _message, GetDots(dotCount));
        }

        string GetDots(int count)
        {
            string ret = string.Empty;
            for (int i = 0; i < count; i++) ret += ". ";
            return ret;
        }

        #region  ManualResetEvent

        private static ManualResetEvent _SplashManualResetEvent = new ManualResetEvent(false);
        /// <summary>
        /// 停止等待,允许同步
        /// </summary>
        public static void Set()
        {
            _SplashManualResetEvent.Set();
        }
        /// <summary>
        /// 阻止线程,等待同步消息
        /// </summary>
        public static void WaitOne()
        {
            _SplashManualResetEvent.WaitOne();
        }

        #endregion

        #region static methods

        private static SplashScreen _SplashScreen = null;
        private static object lockobj = new object();

        private static void CreateInstance()
        {
            if (_SplashScreen == null)
            {
                lock (lockobj)
                {
                    if (_SplashScreen == null)
                    {
                        _SplashScreen = new SplashScreen();
                        _SplashScreen.FormBorderStyle = FormBorderStyle.None;
                        _SplashScreen.ShowInTaskbar = false;
                        _SplashScreen.TopMost = false;
                    }
                }
            }
        }
        /// <summary>
        /// 显示SplashScreen
        /// </summary>
        public static void ShowSplashScreen(string message)
        {
            Thread th = new Thread(new ParameterizedThreadStart(SplashScreen.ShowSplash));
            th.IsBackground = true;
            th.SetApartmentState(ApartmentState.STA);
            th.Start(message);
            SplashScreen.WaitOne();
        }

        private static void ShowSplash(object message)
        {
            CreateInstance();
            _SplashScreen.ShowSplashMessage(message.ToStringEx());
            _SplashScreen.ShowDialog();
        }
        /// <summary>
        /// 关闭SplashScreen
        /// </summary>
        public static void CloseSplashScreen()
        {
            if (_SplashScreen != null)
            {
                _SplashScreen.Invoke(new Action(ActureCloseScreen), null);
            }
        }


        [SuppressUnmanagedCodeSecurity, DllImport("user32", CharSet = CharSet.Auto, EntryPoint = "SetForegroundWindow", ExactSpelling = true)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);

        private static void ActureCloseScreen()
        {
            if (_SplashScreen != null)
            {
                try
                {
                    _SplashScreen.tmr.Stop();
                    _SplashScreen.tmr.Dispose();
                }
                catch
                { }
                finally
                {
                    try
                    {
                        _SplashScreen.Close();
                        _SplashScreen.Dispose();
                    }
                    catch
                    { }
                    finally
                    {
                        _SplashScreen = null;

                        //激活主窗口
                        var href = new HandleRef(null, ApplicationService.Current.MainFormHandle);
                        SetForegroundWindow(href);
                    }
                }
            }
        }

        /// <summary>
        /// 在SplashScreen显示进度消息
        /// </summary>
        /// <param name="message"></param>
        public static void ShowMessage(string message)
        {
            if (_SplashScreen != null)
            {
                _SplashScreen.Invoke(new Action<string>(_SplashScreen.ShowSplashMessage), message);
            }
        }
        #endregion

    }
}