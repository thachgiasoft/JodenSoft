using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using SAF.SystemModule;
using SAF.Framework.Controls;
using DevExpress.XtraSplashScreen;
using System.Threading;
using SAF.Foundation.ServiceModel;
using SAF.Foundation;
using System.ComponentModel.Composition;
using SAF.Foundation.ComponentModel;
using System.Web.Security;
using SAF.Foundation.Security;
using SAF.EntityFramework;
using SAF.Framework.ServiceModel;
using SAF.Framework;
using System.Security;
using System.Runtime.InteropServices;

namespace SAF.Client
{
    [Export("Shell", typeof(IShell))]
    public partial class Shell : RibbonForm, IShell
    {
        /// <summary>
        /// 各子系统信息
        /// </summary>
        [ImportMany(typeof(ISubProductInfo))]
        public IEnumerable<ISubProductInfo> SubProductInfos { private set; get; }

        /// <summary>
        /// 应用程序菜单模块
        /// </summary>
        [ImportMany(typeof(IBackstageViewTabItem))]
        public IEnumerable<Lazy<IBackstageViewTabItem>> BackstageViewTabItems { get; private set; }

        [ImportMany(typeof(IBackstageViewCommand))]
        public IEnumerable<Lazy<IBackstageViewCommand>> BackstageViewCommands { get; private set; }

        private LoginAuthenticate loginControl;
        private WorkSpace workSpace;

        BackstageViewControl backstageViewControl = new BackstageViewControl();

        public Shell()
        {
            InitializeComponent();

            OnInitialize();

#if DEBUG
            this.Text += " - DEBUG";
#endif

            this.Shown += Shell_Shown;
            this.FormClosing += Shell_FormClosing;

            ApplicationService.Current.MainForm = this;
            this.View = this;
        }

        void Shell_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workSpace != null)
            {
                var s = workSpace.GetAllDirtyViewCpations();
                if (s.IsNotEmpty())
                {
                    string question = "以下界面的数据未保存,关闭将丢失更改:{0}{1}确定要退出系统吗?".FormatEx(Environment.NewLine, s);
                    var allowClose = MessageService.AskQuestion(question);
                    e.Cancel = !allowClose;
                }
                else
                {
                    var allowClose = MessageService.AskQuestion("确定要退出系统吗?");
                    e.Cancel = !allowClose;
                }
            }
            else
            {
                var allowClose = MessageService.AskQuestion("确定要退出系统吗?");
                e.Cancel = !allowClose;
            }
        }

        void Shell_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();

                string userName;
                UserConfigHelper.GetUser(out userName);
                loginControl.UserName = userName;
                //设置焦点
                if (string.IsNullOrWhiteSpace(userName))
                {
                    loginControl.FocusUserName();
                }
                else
                {
                    loginControl.FocusPassword();
                }
            }
            finally
            {
                SAF.Framework.Controls.SplashScreen.CloseSplashScreen();
            }
        }

        private void OnInitialize()
        {
            this.SuspendLayout();
            try
            {
                this.WindowState = FormWindowState.Maximized;

                loginControl = new LoginAuthenticate();
                loginControl.Dock = DockStyle.Fill;
                loginControl.Login += loginControl_Login;
                loginControl.Exit += loginControl_Exit;

                this.Controls.Add(loginControl);
            }
            finally
            {
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }

        void loginControl_Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotifyMessage(string message)
        {
            this.bsiMessage.Caption = message;
            Application.DoEvents();
        }

        void loginControl_Login(object sender, LoginEventArgs e)
        {
            this.NotifyMessage("正在登录...");

            var provider = Membership.Provider as FormMembershipProvider;

            if (provider.IsEmpty())
            {
                e.IsSuccess = false;
                e.Message = "未配置 Membership.Provider.";
                return;
            }

            var userName = e.UserName;
            var password = e.Password;
            if (password.IsEmpty()) password = "admin";
            string msg;
            password = SHA1Helper.Hash(password);
            if (!provider.Login(userName, password, out msg))
            {
                e.IsSuccess = false;
                e.Message = msg;
                this.NotifyMessage("准备就绪...");
            }
            else
            {
                UserConfigHelper.SaveUser(e.UserName);
                e.IsSuccess = true;

                this.NotifyMessage("初始化工作区...");

                workSpace = new WorkSpace() { Dock = DockStyle.Fill };
                workSpace.InitMenuTree();
                workSpace.Width = Screen.PrimaryScreen.WorkingArea.Width;
                workSpace.Height = Screen.PrimaryScreen.WorkingArea.Height;

                this.Controls.Remove(loginControl);
                loginControl.Dispose();

                this.Controls.Add(workSpace);
                workSpace.BringToFront();

                this.NotifyMessage("准备就绪...");
            }

        }

        public RibbonControl RibbonControl
        {
            get { return this.ribbonMain; }
        }

        public void MergeRibbon(RibbonControl childRibbon)
        {
            if (this.RibbonControl != null)
            {
                base.SuspendLayout();
                this.RibbonControl.MergeRibbon(childRibbon);

                if (this.RibbonControl.MergedPages.Count > 0)
                {
                    this.RibbonControl.SelectedPage = childRibbon.SelectedPage;
                }
                base.ResumeLayout();
            }
        }

        public void UnMergeRibbon()
        {
            if (this.RibbonControl != null)
            {
                this.RibbonControl.UnMergeRibbon();
            }
        }

        private void bbiExitApplication_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        public Form View
        {
            get;
            private set;
        }

        public void InitComponent()
        {
            this.ribbonMain.ApplicationButtonDropDownControl = this.backstageViewControl;
            InitBackstageViewTabItemAndCommand(DisplayMode.BeforeLogin);
        }

        private void InitBackstageViewTabItemAndCommand(DisplayMode displayMode)
        {
            backstageViewControl.Items.Clear();

            if (this.BackstageViewTabItems != null)
            {
                var list = BackstageViewTabItems.Where(p => p.Value.DisplayMode.In(displayMode, DisplayMode.All)).OrderBy(p => p.Value.Index);
                foreach (var item in list)
                {
                    item.Value.Init();

                    if (item.Value.BeginGroup)
                    {
                        BackstageViewItemSeparator sp = new BackstageViewItemSeparator();
                        backstageViewControl.Items.Add(sp);
                    }

                    BackstageViewTabItem tab = new BackstageViewTabItem();
                    tab.Caption = item.Value.Caption;
                    tab.ContentControl.Controls.Add(item.Value.View);
                    item.Value.View.Dock = DockStyle.Fill;
                    backstageViewControl.Items.Add(tab);

                    tab.Selected = item.Value.IsSelected;
                    tab.SelectedChanged += (sender, args) =>
                    {
                        item.Value.RefreshUI();
                    };
                }
            }

            if (this.BackstageViewCommands != null)
            {
                var list = BackstageViewCommands.Where(p => p.Value.DisplayMode.In(displayMode, DisplayMode.All)).OrderBy(p => p.Value.Index);
                foreach (var item in list)
                {
                    if (item.Value.BeginGroup)
                    {
                        BackstageViewItemSeparator sp = new BackstageViewItemSeparator();
                        backstageViewControl.Items.Add(sp);
                    }
                    BackstageViewButtonItem btn = new BackstageViewButtonItem();
                    btn.Caption = item.Value.Caption;
                    btn.Glyph = item.Value.m_Glyph;
                    btn.ItemClick += item.Value.ItemClick;
                    backstageViewControl.Items.Add(btn);
                }
            }
        }

        private void bbiHomepage_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://www.baidu.com");
        }

        private void bbiAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            var shell = ApplicationService.Current.MainForm as IShellBase;

            SAF.Framework.Component.AboutBox about = new SAF.Framework.Component.AboutBox(shell == null ? null : shell.SubProductInfos);
            about.Owner = this;
            about.ShowDialog();
        }

        private void bbiHelp_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiExitApplication_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplicationService.Current.MainForm.Close();
        }
    }
}