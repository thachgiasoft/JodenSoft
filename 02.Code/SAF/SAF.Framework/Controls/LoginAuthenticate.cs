using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SAF.Foundation.ServiceModel;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.Security;
using SAF.EntityFramework;

namespace SAF.Framework.Controls
{
    [ToolboxItem(false)]
    public partial class LoginAuthenticate : BaseUserControl
    {
        public LoginAuthenticate()
        {
            InitializeComponent();

            this.btnOK.Click += btnOK_Click;
            this.btnExit.Click += btnExit_Click;

            this.txtUserName.KeyDown += txtUserName_KeyDown;
            this.txtPassword.KeyDown += txtPassword_KeyDown;
            this.chkSavePassword.KeyDown += chkSavePassword_KeyDown;
        }

        void chkSavePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                OnLoginEvent();
            }
        }

        public void FocusUserName()
        {
            this.txtUserName.Focus();
        }

        public void FocusPassword()
        {
            this.txtPassword.Focus();
        }

        public string UserName
        {
            get { return this.txtUserName.EditValue == null ? string.Empty : this.txtUserName.EditValue.ToString(); }
            set { this.txtUserName.EditValue = value; }
        }

        public string Password
        {
            get { return this.txtPassword.EditValue == null ? string.Empty : this.txtPassword.EditValue.ToString(); }
            set { this.txtPassword.EditValue = value; }
        }

        public bool SavePassword
        {
            get { return this.chkSavePassword.Checked; }
            set { this.chkSavePassword.Checked = value; }
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            OnExitEvent();
        }

        void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                OnLoginEvent();
            }
        }

        void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPassword.Focus();
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            OnLoginEvent();
        }

        private bool CheckLoginParamIsRight()
        {
            if (string.IsNullOrWhiteSpace(this.txtUserName.Text))
            {
                MessageService.ShowErrorFormatted("请输入“用户名”。{0}“用户名”不能为空。", Environment.NewLine);
                this.txtUserName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                MessageService.ShowErrorFormatted("请输入“密码”。{0}“密码”不能为空。", Environment.NewLine);
                this.txtPassword.Focus();
                return false;
            }

            return true;
        }

        private static readonly object EventLogin;
        private static readonly object EventExit;

        static LoginAuthenticate()
        {
            EventLogin = new object();
            EventExit = new object();
        }

        public event EventHandler<LoginEventArgs> Login
        {
            add { Events.AddHandler(LoginAuthenticate.EventLogin, value); }
            remove { Events.RemoveHandler(LoginAuthenticate.EventLogin, value); }
        }

        public event EventHandler Exit
        {
            add { Events.AddHandler(LoginAuthenticate.EventExit, value); }
            remove { Events.RemoveHandler(LoginAuthenticate.EventExit, value); }
        }

        private void OnLoginEvent()
        {
            this.Enabled = false;
            try
            {
                if (!CheckLoginParamIsRight()) return;

                var handler = (EventHandler<LoginEventArgs>)Events[LoginAuthenticate.EventLogin];
                if (handler != null)
                {
                    var arg = new LoginEventArgs(this.txtUserName.Text, this.txtPassword.Text, this.chkSavePassword.Checked);
                    handler(this, arg);

                    if (!arg.IsSuccess)
                    {
                        MessageService.ShowErrorFormatted("{0}{1}{2}", "登录失败!", Environment.NewLine, arg.Message);

                        this.Enabled = true;
                        this.txtPassword.EditValue = null;
                        this.txtPassword.Focus();
                    }
                }
            }
            finally
            {
                this.Enabled = true;
            }
        }


        private void OnExitEvent()
        {
            var handler = (EventHandler)Events[LoginAuthenticate.EventExit];
            if (handler != null)
            {
                var arg = new EventArgs();
                handler(this, arg);
            }
        }


        public void LoadConfig()
        {
            UserName = UserConfig.Current.UserName;
            if (UserConfig.Current.SavePassword)
            {
                try
                {
                    Password = DESHelper.Decrypt(UserConfig.Current.Password, Session.MachineInfo.MachineCode);
                }
                catch
                {
                    Password = string.Empty;
                }
                SavePassword = UserConfig.Current.SavePassword;
            }
        }
    }

    public class LoginEventArgs : EventArgs
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool SavePassword { get; private set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public LoginEventArgs(string userName, string password, bool savePassword)
        {
            this.UserName = userName;
            this.Password = password;
            IsSuccess = false;
            Message = string.Empty;
            this.SavePassword = savePassword;
        }

    }
}
