using DevExpress.XtraEditors;
using SAF.EntityFramework;
using SAF.Foundation.Security;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;

namespace SAF.Framework.Component
{
    public partial class ChangePassword : XtraForm
    {
        public ChangePassword()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Icon = ApplicationService.Current.MainForm.Icon;
            this.Shown += ChangePassword_Shown;
        }

        void ChangePassword_Shown(object sender, EventArgs e)
        {
            this.txtUserName.Text = "{0}.{1}".FormatWith(Session.UserInfo.UserId, Session.UserInfo.UserName);
            this.txtOldPassword.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var es = new EntitySet<sysUser>();
            es.Query("SELECT Iden,UserName,Password,IsActive,IsDeleted FROM dbo.sysUser where Iden=:UserId", Session.UserInfo.UserId);
            if (es.Count <= 0)
            {
                MessageService.ShowError("在系统中未找到用户,无法修改密码.");
                return;
            }

            var user = es.CurrentEntity;
            if (user.IsDeleted)
            {
                MessageService.ShowError("用户在系统中已被删除,无法修改密码.");
                return;
            }
            if (!user.IsActive)
            {
                MessageService.ShowError("用户在系统中已被禁用,无法修改密码.");
                return;
            }

            var oldPassword = SHA1Helper.Hash(this.txtOldPassword.Text);
            if (!user.Password.Equals(oldPassword, StringComparison.InvariantCulture))
            {
                MessageService.ShowError("原密码错误,无法修改密码.");
                this.txtOldPassword.Focus();
                return;
            }

            if (!this.txtNewPassword.Text.Equals(this.txtNewPassword2.Text, StringComparison.InvariantCulture))
            {
                MessageService.ShowError("新密码与确认新密码不一致,无法修改密码.");
                this.txtNewPassword.Focus();
                return;
            }

            user.Password = SHA1Helper.Hash(this.txtNewPassword.Text);
            es.SaveChanges();
            MessageService.ShowMessageFormatted("密码修改成功,请使用新密码登录系统.");
            this.Close();
        }
    }
}
