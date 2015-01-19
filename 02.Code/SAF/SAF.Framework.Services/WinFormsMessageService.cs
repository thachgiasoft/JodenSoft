using System;
using System.ComponentModel;
using System.Windows;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;
using System.Windows.Forms;
using SAF.Foundation;
using DevExpress.XtraEditors;

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
                ShowError(string.Format("{0}", ex.GetAllMessage()));
            else
                ShowError(string.Format("{0}{1}{2}", message, Environment.NewLine, ex.GetAllMessage()));
        }

        public void ShowError(string message)
        {
            XtraMessageBox.Show(DialogOwner, message, MessageBoxTitle + "- 出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowWarning(string message)
        {
            XtraMessageBox.Show(DialogOwner, message, MessageBoxTitle + "- 警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public bool AskQuestion(string question)
        {
            return XtraMessageBox.Show(DialogOwner, question, MessageBoxTitle + "- 确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void ShowMessage(string message)
        {
            XtraMessageBox.Show(DialogOwner, message, MessageBoxTitle + "- 消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
