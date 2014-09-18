using SAF.Framework.Controls;
using System;
using System.Threading;
using System.Windows.Forms;

namespace SAF.Framework.Controls
{
    /// <summary>
    /// 进度窗口通用方法
    /// </summary>
    internal static class ProgressProxy
    {
        private static ManualResetEvent _SplashManualResetEvent = new ManualResetEvent(false);
        /// <summary>
        /// 
        /// </summary>
        internal static ManualResetEvent SplashManualResetEvent
        {
            get { return ProgressProxy._SplashManualResetEvent; }
        }

        private static fmProgress window = null;

        private static void ShowProgressWindow(object param)
        {
            ThreadParam threadParam = (ThreadParam)param;
            window = new fmProgress();
            //设置当前线程皮肤
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(ProgressService.SkinName);
            window.ShowInTaskbar = false;
            window.StartPosition = FormStartPosition.CenterScreen;

            window.Text = "正在执行...";
            window.Message = threadParam.Message;
            window.ProgressBar.Properties.Minimum = threadParam.Minimum;
            window.ProgressBar.Properties.Maximum = threadParam.Maximum;
            window.ProgressBar.Position = threadParam.Value;
            window.ProgressBar.Visible = !threadParam.IsIndeterminate;

            window.MarqueeProgressBar.Visible = threadParam.IsIndeterminate;
            window.MarqueeProgressBar.Location = window.ProgressBar.Location;

            window.ShowDialog();
        }

        /// <summary>
        /// 显示进度信息
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="IsIndeterminate">如果ProgressBar 显示实际值，则为 false；如果 ProgressBar 显示一般进度，则为 true。</param>
        /// <returns></returns>
        public static fmProgress Show(string message, int minimum, int maximum, bool IsIndeterminate)
        {
            SplashManualResetEvent.Reset();
            ThreadParam param = new ThreadParam();
            param.Message = message;
            param.Maximum = maximum;
            param.Minimum = minimum;
            param.IsIndeterminate = IsIndeterminate;
            param.Value = 0;

            Thread th = new Thread(new ParameterizedThreadStart(ShowProgressWindow));
            th.IsBackground = true;
            th.SetApartmentState(ApartmentState.STA);
            th.Start(param);
            SplashManualResetEvent.WaitOne();
            return window;
        }

        #region 线程创建进度窗口的参数
        /// <summary>
        /// 线程创建进度窗口的参数
        /// </summary>
        internal class ThreadParam
        {
            internal Form Owner { set; get; }
            internal string Message { set; get; }
            internal int Minimum { set; get; }
            internal int Maximum { set; get; }
            internal int Value { set; get; }
            internal bool IsIndeterminate { set; get; }
        }

        #endregion

    }




}
