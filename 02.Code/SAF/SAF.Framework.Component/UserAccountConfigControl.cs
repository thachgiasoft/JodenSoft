using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;
using DevExpress.LookAndFeel;
using SAF.Foundation.ComponentModel;
using SAF.EntityFramework;
using SAF.Framework.Controls;
using System.ComponentModel.Composition;
using SAF.Framework.ComponentModel;
using SAF.Foundation.ServiceModel;

namespace SAF.Framework.Component
{
    [ToolboxItem(true)]
    [Export(typeof(IBackstageViewTabItem))]
    public partial class UserAccountConfigControl : BaseBackstageViewTabItem
    {
        public UserAccountConfigControl()
        {
            InitializeComponent();

            this.Load += UserAccountConfigControl_Load;
        }

        void UserAccountConfigControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            InitUserInfo();

            this.cbxSkins.Properties.Items.AddRange(
                new string[] {
                    "Office 2013",
                    "Office 2013 Light Gray",
                    "Office 2013 Dark Gray"
                });
            this.cbxSkins.EditValue = AppConfig.Current.ThemeName;
            this.cbxSkins.SelectedIndexChanged += cbxSkins_SelectedIndexChanged;

            this.chkShowWelcomePage.EditValue = AppConfig.Current.ShowWelcomePage;
            this.chkShowWelcomePage.EditValueChanged += chkShowWelcomePage_EditValueChanged;

            this.chkShowNavigationPage.EditValue = AppConfig.Current.ShowNavigationPage;
            this.chkShowNavigationPage.EditValueChanged += chkShowNavigationPage_EditValueChanged;

            this.chkShowWorkSpace.EditValue = AppConfig.Current.ShowWorkSpace;
            this.chkShowWorkSpace.EditValueChanged += chkShowWorkSpace_EditValueChanged;
        }

        private void InitUserInfo()
        {
            Session.UserInfo.RetriveImage();
            this.picUserPicture.Image = Session.UserInfo.UserImage ?? AssemblyInfoHelper.UserDefaultImage;

            this.lblUserName.Text = "{0} ({1})".FormatWith(Session.UserInfo.UserName, Session.UserInfo.UserFullName);
            this.lblEmail.Text = Session.UserInfo.Email;
        }

        void chkShowWorkSpace_EditValueChanged(object sender, EventArgs e)
        {
            AppConfig.Current.ShowWorkSpace = this.chkShowWorkSpace.IsOn;
            AppConfig.Current.Save();
        }

        void chkShowWelcomePage_EditValueChanged(object sender, EventArgs e)
        {
            AppConfig.Current.ShowWelcomePage = this.chkShowWelcomePage.IsOn;
            AppConfig.Current.Save();
        }

        void chkShowNavigationPage_EditValueChanged(object sender, EventArgs e)
        {
            AppConfig.Current.ShowNavigationPage = this.chkShowNavigationPage.IsOn;
            AppConfig.Current.Save();
        }

        void cbxSkins_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Current.ThemeName = this.cbxSkins.EditValue.ToStringEx();
            AppConfig.Current.Save();

            AppConfig.Current.SetTheme();
        }

        private void lblChangePicture_Click(object sender, EventArgs e)
        {
            var form = new ChangePicture();
            form.AfterPictureChanged += (s, args) =>
            {
                var es = new EntitySet<sysUser>();
                es.Query("Select * from sysUser with(nolock) where Iden=:UserId", Session.UserInfo.UserId);
                if (es.Count > 0)
                {
                    Session.UserInfo.Assign(es.CurrentEntity);
                }
                InitUserInfo();
            };

            form.ShowDialog(ApplicationService.Current.MainForm);
        }

        private void lblChangePassword_Click(object sender, EventArgs e)
        {
            var form = new ChangePassword();
            form.ShowDialog(ApplicationService.Current.MainForm);
        }

        private void lblChangeUser_Click(object sender, EventArgs e)
        {
            if (!MessageService.AskQuestionFormatted("确定要切换用户账户吗?{0}注:切换用户账户时系统会关闭所有已打开的界面.", Environment.NewLine)) return;
            Application.DoEvents();

            var shell = (ApplicationService.Current.MainForm as IShell);
            shell.RibbonControl.HideApplicationButtonContentControl();

            Application.DoEvents();
            shell.Relogin();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.BackColor = Color.Transparent;
            base.OnPaint(e);
        }

        public override string Caption
        {
            get { return "帐户"; }
        }

        public override int Index
        {
            get
            {
                return 50;
            }
        }

        public override DisplayMode DisplayMode
        {
            get
            {
                return DisplayMode.AfterLogin;
            }
        }
    }
}
