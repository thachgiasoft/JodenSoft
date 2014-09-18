using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SAF.Foundation;
using System.Configuration.Provider;
using System.Windows.Forms;

namespace SAF.Foundation.ServiceModel
{
    public class MessageBoxMessageService : IMessageService
    {
        /// <summary>
        /// 消息框的标题
        /// </summary>
        protected string MessageBoxTitle
        {
            get { return "System"; }
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowException(Exception ex, string message)
        {
            if (ex != null)
            {
                message += Environment.NewLine + "Exception occurred: " + ex.ToString();
            }
            ShowError(message);
        }

        public void ShowWarning(string message)
        {
            MessageBox.Show(message, MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public bool AskQuestion(string question)
        {
            DialogResult result = DialogResult.None;

            result = MessageBox.Show(question, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
