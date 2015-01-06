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

            this.picUserPicture.Image = Session.Current.UserImage ?? AssemblyInfoHelper.UserDefaultImage;

            this.lblUserName.Text = "{0} ({1})".FormatEx(Session.Current.UserName, Session.Current.UserFullName);
            this.lblEmail.Text = Session.Current.Email;

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
            //TODO:修改用户图片
        }

        private void lblChangePassword_Click(object sender, EventArgs e)
        {
            //TODO:修改密码
        }

        private void lblChangeUser_Click(object sender, EventArgs e)
        {
            //TODO:切换用户
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = Color.Transparent;
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
    }
}
