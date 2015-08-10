using System;
using System.ComponentModel;
using System.Windows;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;
using System.Windows.Forms;
using SAF.Foundation;

namespace SAF.Framework.ServiceModel
{
    /// <summary>
    /// Class with static methods to show message boxes.
    /// </summary>
    public class WinFormsMessageService : IMessageService
    {
        /// <summary>
        /// Gets/Sets the form used as owner for shown message boxes.
        /// </summary>
        public IWin32Window DialogOwner { get; set; }


        /// <summary>
        /// 消息框的标题
        /// </summary>
        protected string MessageBoxTitle
        {
            get { return ApplicationService.Current.MainForm == null ? "System" : ApplicationService.Current.MainForm.Text; }
        }

        public virtual void ShowException(Exception ex, string message)
        {
            if (message.IsEmpty())
                ShowError(ex.Message, ex.GetAllMessage());
            else
                ShowError(message, ex.GetAllMessage());
        }

        public void ShowError(string message, string messageDtl = null)
        {
            MessageBoxEx.Show(message, MessageBoxTitle + "- 出错了", messageDtl, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowWarning(string message)
        {
            MessageBoxEx.Show(message, MessageBoxTitle + "- 警告", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public bool AskQuestion(string question)
        {
            return MessageBoxEx.Show(question, MessageBoxTitle + "- 确认", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void ShowMessage(string message)
        {
            MessageBoxEx.Show(message, MessageBoxTitle + "- 消息", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
