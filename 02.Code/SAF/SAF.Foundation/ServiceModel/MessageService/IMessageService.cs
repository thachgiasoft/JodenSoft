using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;

namespace SAF.Foundation.ServiceModel
{
    /// <summary>
    /// MessageService接口
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Shows an error.
        /// </summary>
        void ShowError(string message);
        /// <summary>
        /// Shows an exception.
        /// </summary>
        void ShowException(Exception ex, string message);
        /// <summary>
        /// Shows a warning message.
        /// </summary>
        void ShowWarning(string message);
        /// <summary>
        /// Asks the user a Yes/No question, using "Yes" as the default button.
        /// Returns <c>true</c> if yes was clicked, <c>false</c> if no was clicked.
        /// </summary>
        bool AskQuestion(string question);
        /// <summary>
        /// Show a message
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
    }
}
