using System;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace SAF.Foundation.ServiceModel
{
    /// <summary>
    /// Class with static methods to show message boxes.
    /// </summary>
    public static class MessageService
    {
        #region Shows an error

        /// <summary>
        /// Shows an error using a message box.
        /// </summary>
        public static void ShowError(string message)
        {
            LoggingService.ErrorFormatted("ShowError{0}\tError Message:{1}", Environment.NewLine, message);
            ServiceManager.Instance.MessageService.ShowError(message);
        }
        /// <summary>
        /// Shows an error using a message box.
        /// <paramref name="formatMessage"/> is first passed through the
        /// <see cref="StringParser"/>,
        /// then through <see cref="string.Format(string, object)"/>, using the formatitems as arguments.
        /// </summary>
        public static void ShowErrorFormatted(string formatMessage, params object[] formatitems)
        {
            ShowError(Format(formatMessage, formatitems));
        }

        #endregion

        #region Shows an exception error

        /// <summary>
        /// Shows an exception error.
        /// </summary>
        public static void ShowException(Exception ex)
        {
            ShowException(ex, null);
        }
        /// <summary>
        /// Shows an exception.
        /// </summary>
        public static void ShowException(Exception ex, string message)
        {
            LoggingService.Error(string.Format("ShowException{0}\tException Message:{1}", Environment.NewLine,
                string.IsNullOrWhiteSpace(message) ? ex.Message : message), ex);
            LoggingService.Warn("Stack trace of last exception log:" + Environment.NewLine + Environment.StackTrace);
            ServiceManager.Instance.MessageService.ShowException(ex, message);
        }

        #endregion

        #region Shows a warning message

        /// <summary>
        /// Shows a warning message.
        /// </summary>
        public static void ShowWarning(string message)
        {
            LoggingService.WarnFormatted("ShowWarning{0}\tWarning Message:{1}", Environment.NewLine, message);
            ServiceManager.Instance.MessageService.ShowWarning(message);
        }
        /// <summary>
        /// Shows a warning message.
        /// <paramref name="formatstring"/> is first passed through the
        /// <see cref="StringParser"/>,
        /// then through <see cref="string.Format(string, object)"/>, using the formatitems as arguments.
        /// </summary>
        public static void ShowWarningFormatted(string formatstring, params object[] formatitems)
        {
            ShowWarning(Format(formatstring, formatitems));
        }

        #endregion

        #region Asks the user a Yes/No question
        /// <summary>
        /// Asks the user a Yes/No question, using "Yes" as the default button.
        /// Returns <c>true</c> if yes was clicked, <c>false</c> if no was clicked.
        /// </summary>
        public static bool AskQuestion(string question)
        {
            return ServiceManager.Instance.MessageService.AskQuestion(question);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="formatstring"></param>
        /// <param name="formatitems"></param>
        /// <returns></returns>
        public static bool AskQuestionFormatted(string formatstring, params object[] formatitems)
        {
            return AskQuestion(Format(formatstring, formatitems));
        }

        #endregion

        #region Show a Message

        public static void ShowMessage(string message)
        {
            LoggingService.InfoFormatted("ShowMessage{0}\tMessage:{1}", Environment.NewLine, message);
            ServiceManager.Instance.MessageService.ShowMessage(message);
        }

        public static void ShowMessageFormatted(string formatstring, params object[] formatitems)
        {
            ShowMessage(Format(formatstring, formatitems));
        }

        private static string Format(string formatstring, object[] formatitems)
        {
            try
            {
                return String.Format(formatstring, formatitems);
            }
            catch (FormatException ex)
            {
                LoggingService.Warn(ex);
                return formatstring;
            }
        }

        #endregion
    }
}
