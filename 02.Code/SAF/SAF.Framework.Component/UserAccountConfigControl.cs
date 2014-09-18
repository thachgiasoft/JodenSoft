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
                    "Office 2013 Dark Gray",
                    "Office 2013 Light Gray",
                    "Office 2010 Silver",
                    "Office 2010 Blue",
                    "Office 2010 Black",
                    "DevExpress Style"
                });
            this.cbxSkins.EditValue = UserLookAndFeel.Default.SkinName;
            this.cbxSkins.SelectedIndexChanged += cbxSkins_SelectedIndexChanged;
        }

        void cbxSkins_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle(this.cbxSkins.EditValue.ToStringEx());
            ProgressService.SkinName = UserLookAndFeel.Default.SkinName;
            ApplicationConfigHelper.SetAppSetting("ApplicationSkinName", UserLookAndFeel.Default.SkinName);

            this.Refresh();
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
