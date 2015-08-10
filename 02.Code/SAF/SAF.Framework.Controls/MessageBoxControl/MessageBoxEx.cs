using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SAF.Framework.Controls
{
    /// <summary>
    /// 可以携带详细信息的消息框
    /// </summary>
    public static class MessageBoxEx
    {
        //异常消息文本
        private const string InvalidButtonExString = "按钮参数不是有效的枚举项！";
        private const string InvalidIconExString = "图标参数不是有效的枚举项！";
        private const string InvalidDfButtonExString = "默认按钮参数不是有效的枚举项！";

        #region 公开方法

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="attachMessage">附加消息</param>
        public static DialogResult Show(string message, string caption = null, string attachMessage = null)
        {
            return ShowCore(message, caption, attachMessage, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        /*下面这仨弄成重载而不是可选方法是为了避免不必要的参数检查*/

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="attachMessage">附加消息</param>
        /// <param name="buttons">按钮组合</param>
        public static DialogResult Show(string message, string caption, string attachMessage, MessageBoxButtons buttons)
        {
            if (!Enum.IsDefined(typeof(MessageBoxButtons), buttons)) { throw new InvalidEnumArgumentException(InvalidButtonExString); }

            return ShowCore(message, caption, attachMessage, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="attachMessage">附加消息</param>
        /// <param name="buttons">按钮组合</param>
        /// <param name="icon">图标</param>
        public static DialogResult Show(string message, string caption, string attachMessage, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            if (!Enum.IsDefined(typeof(MessageBoxButtons), buttons)) { throw new InvalidEnumArgumentException(InvalidButtonExString); }
            if (!Enum.IsDefined(typeof(MessageBoxIcon), icon)) { throw new InvalidEnumArgumentException(InvalidIconExString); }

            return ShowCore(message, caption, attachMessage, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="attachMessage">附加消息</param>
        /// <param name="buttons">按钮组合</param>
        /// <param name="icon">图标</param>
        /// <param name="defaultButton">默认按钮</param>
        public static DialogResult Show(string message, string caption, string attachMessage, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            if (!Enum.IsDefined(typeof(MessageBoxButtons), buttons)) { throw new InvalidEnumArgumentException(InvalidButtonExString); }
            if (!Enum.IsDefined(typeof(MessageBoxIcon), icon)) { throw new InvalidEnumArgumentException(InvalidIconExString); }
            if (!Enum.IsDefined(typeof(MessageBoxDefaultButton), defaultButton)) { throw new InvalidEnumArgumentException(InvalidDfButtonExString); }

            return ShowCore(message, caption, attachMessage, buttons, icon, defaultButton);
        }

        /********传入异常的重载********/

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="exception">异常实例</param>
        public static DialogResult Show(string message, string caption, Exception exception)
        {
            return Show(message, caption, exception == null ? string.Empty : exception.ToString());
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="exception">异常实例</param>
        /// <param name="buttons">按钮组合</param>
        public static DialogResult Show(string message, string caption, Exception exception, MessageBoxButtons buttons)
        {
            return Show(message, caption, exception == null ? string.Empty : exception.ToString(), buttons);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="exception">异常实例</param>
        /// <param name="buttons">按钮组合</param>
        /// <param name="icon">图标</param>
        public static DialogResult Show(string message, string caption, Exception exception, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(message, caption, exception == null ? string.Empty : exception.ToString(), buttons, icon);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="exception">异常实例</param>
        /// <param name="buttons">按钮组合</param>
        /// <param name="icon">图标</param>
        /// <param name="defaultButton">默认按钮</param>
        public static DialogResult Show(string message, string caption, Exception exception, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(message, caption, exception == null ? string.Empty : exception.ToString(), buttons, icon, defaultButton);
        }

        #endregion

        //内部方法，不检查参数有效性
        private static DialogResult ShowCore(string message, string caption, string attachMessage, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            using (MessageForm f = new MessageForm(message, caption, buttons, icon, defaultButton, attachMessage))
            {
                return f.ShowDialog();
            }
        }

    }
}
