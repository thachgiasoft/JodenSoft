using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Security;
using System.Runtime.InteropServices;
using SAF.Foundation.ServiceModel;

namespace SAF.Framework.Controls
{
    /// <summary>
    /// 进度条服务
    /// </summary>
    public static class ProgressService
    {
        #region private

        /// <summary>
        /// 进度条的引用计数
        /// </summary>
        private static int _RefCount = 0;
        /// <summary>
        /// 用于保护进度条的引用计数现场
        /// </summary>
        private static int _RefCountSnapshot = 0;
        /// <summary>
        /// 用于保护进度条的消息
        /// </summary>
        private static string _MessageSnapshot = string.Empty;
        /// <summary>
        /// 用于保护计时器现场
        /// </summary>
        private static int _TimerSnapShot = 0;
        /// <summary>
        /// 进度条接口变量
        /// </summary>
        private static fmProgress progress;

        #endregion

        #region public property

        [SuppressUnmanagedCodeSecurity, DllImport("user32", CharSet = CharSet.Auto, EntryPoint = "SetForegroundWindow", ExactSpelling = true)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);

        /// <summary>
        /// 控件皮肤
        /// </summary>
        public static string SkinName { get; set; }

        private static void ActivateParentForm(Form parentForm)
        {
            if (parentForm != null)
            {
                //HandleRef href = new HandleRef(ParentForm, ParentForm.Handle);
                //SetForegroundWindow(href);

                parentForm.Invoke(new Action(() => { parentForm.Activate(); }));
            }
            else if (ApplicationService.Current.MainForm != null)
            {
                ApplicationService.Current.MainForm.Invoke(new Action(() => { ApplicationService.Current.MainForm.Activate(); }));
            }
        }
        /// <summary>
        /// 设置消息
        /// </summary>
        /// <param name="msg"></param>
        public static string Message
        {
            get { return progress.Message; }
            set
            {
                if (_RefCount > 0)
                {
                    progress.Message = value;
                }
            }
        }
        /// <summary>
        /// 是否为测试模式
        /// </summary>
        public static bool bTestMode { get; set; }
        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="msg"></param>
        public static string Title
        {
            get { return progress.sTitle; }
            set
            {
                if (_RefCount > 0)
                {
                    progress.sTitle = value;
                }
            }
        }
        #endregion

        #region Close
        /// <summary>
        /// 强制关闭进度条,catch块使用
        /// </summary>
        public static void Abort(Form parentForm = null)
        {
            if (bTestMode)
                return;
            if (_RefCount > 0)
            {
                _RefCountSnapshot = _RefCount;
                _MessageSnapshot = progress.Message;
                _TimerSnapShot = progress.Seconds;
                try
                {
                    progress.CloseProgress();
                    progress = null;
                    ActivateParentForm(parentForm);
                }
                catch { }
            }
            _RefCount = 0;
        }

        /// <summary>
        /// 关闭进度条
        /// </summary>
        public static void Close(Form parentForm = null)
        {
            if (bTestMode)
                return;
            _RefCount--;

            if (_RefCount == 0)
            {
                try
                {
                    progress.CloseProgress();
                    progress = null;
                    ActivateParentForm(parentForm);
                }
                catch { }
            }

            if (_RefCount < 0) _RefCount = 0;
        }

        #endregion

        #region StepIt

        /// <summary>
        /// 步进
        /// </summary>
        public static void StepIt()
        {
            if (bTestMode)
                return;
            if (_RefCount > 0)
            {
                progress.StepIt(1);
            }
        }
        /// <summary>
        /// 步进指定的Value
        /// </summary>
        /// <param name="value"></param>
        public static void StepIt(int value)
        {
            if (bTestMode)
                return;
            if (_RefCount > 0)
            {
                progress.StepIt(value);
            }
        }

        #endregion

        #region Show

        /// <summary>
        /// 显示进度条,Show必须与Close配对出现,否则进度条无法关闭
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="IsIndeterminate"></param>
        public static void Show(string message, int minimum, int maximum, bool IsIndeterminate)
        {
            if (bTestMode)
                return;
            if (_RefCount == 0)
            {
                progress = ProgressProxy.Show(message, minimum, maximum, IsIndeterminate);
            }
            else
            {
                progress.Message = message;
            }
            _RefCount++;
        }
        /// <summary>
        /// 显示进度信息,Minimum=0, Maximum=100
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="IsIndeterminate">如果ProgressBar 显示实际值，则为 false；如果 ProgressBar 显示一般进度，则为 true。</param>
        /// <returns></returns>
        public static void Show(string message, bool IsIndeterminate)
        {
            Show(message, 0, 100, IsIndeterminate);
        }
        /// <summary>
        /// 显示一般进度信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void Show(string message)
        {
            Show(message, 0, 100, true);
        }
        /// <summary>
        /// 显示进度信息,Minimum=0
        /// </summary>
        /// <param name="message"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static void Show(string message, int maximum)
        {
            Show(message, 0, maximum, false);
        }

        #endregion

        #region 恢复进度条

        /// <summary>
        /// 恢复进度条,用传入的消息替换原进度条消息
        /// </summary>
        /// <param name="msg"></param>
        public static void Restore(string msg, bool restoreTimer)
        {
            if (bTestMode)
                return;
            if (_RefCountSnapshot > 0)
            {
                if (_RefCount > 0)
                {
                    progress.Message = string.IsNullOrEmpty(msg) ? string.Empty : msg;
                    if (restoreTimer)
                        progress.Seconds = _TimerSnapShot;
                }
                else
                {
                    Show(msg);
                    if (restoreTimer)
                        progress.Seconds = _TimerSnapShot;
                    _RefCount = _RefCountSnapshot - 1;
                    _RefCountSnapshot = 0;
                    _MessageSnapshot = string.Empty;
                    _TimerSnapShot = 0;
                }
            }
        }
        /// <summary>
        /// 还原进度条,包括原消息
        /// <para>目前只提供一般进度条的恢复功能</para>
        /// </summary>
        public static void Restore()
        {
            Restore(_MessageSnapshot, false);
        }
        /// <summary>
        /// 还原进度条
        /// </summary>
        /// <param name="restoreTimer">是否还原计时器</param>
        public static void Restore(bool restoreTimer)
        {
            Restore(_MessageSnapshot, restoreTimer);
        }

        #endregion
    }
}
