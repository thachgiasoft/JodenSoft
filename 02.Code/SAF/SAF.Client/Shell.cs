using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using SAF.EntityFramework;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.Security;
using SAF.Foundation.ServiceModel;
using SAF.Framework;
using SAF.Framework.Controls;
using SAF.Framework.Controls.Entities;
using SAF.Framework.ServiceModel;
using SAF.SystemModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Web.Security;
using System.Windows.Forms;

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

        BackstageViewControl backstageViewControl = new BackstageViewControl();

        public Shell()
        {
            InitializeComponent();

            OnInitialize();

#if DEBUG
            this.Text = "DIP - DEBUG";
#else
            this.Text = "SAF";
#endif

            this.Shown += Shell_Shown;
            this.FormClosing += Shell_FormClosing;

            ApplicationService.Current.MainForm = this;
        }

        void Shell_FormClosing(object sender, FormClosingEventArgs e)
        {
            var s = this.GetAllDirtyViewCpations();
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

        void Shell_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();

                //设置焦点
                if (string.IsNullOrWhiteSpace(UserConfig.Current.UserName))
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
            this.splMenu.Visible = false;
            this.navMainMenu.Visible = false;

            this.WindowState = FormWindowState.Maximized;

            InitLoginControl();
        }

        private void InitLoginControl()
        {
            loginControl = new LoginAuthenticate();
            loginControl.Dock = DockStyle.Fill;
            loginControl.Login += loginControl_Login;
            loginControl.Exit += loginControl_Exit;

            loginControl.LoadConfig();

            this.Controls.Add(loginControl);
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
                UserConfig.Current.UserName = e.UserName;
                UserConfig.Current.SavePassword = e.SavePassword;
                if (e.SavePassword)
                {
                    UserConfig.Current.Password = DESHelper.Encrypt(e.Password, HardwareInfo.GetHardwareId());
                }
                UserConfig.Current.Save();

                e.IsSuccess = true;

                this.NotifyMessage("初始化工作区...");
                this.InitMenuTree();
                this.TreeMenu.SelectImageList = this.imageCollectionTreeList;
                this.TreeMenu.GetSelectImage += TreeMenu_GetSelectImage;
                this.TreeMenu.DoubleClick += TreeMenu_DoubleClick;
                this.txtFind.EditValueChanged += txtFind_EditValueChanged;

                this.Controls.Remove(loginControl);
                loginControl.Dispose();

                this.splMenu.Visible = true;
                this.navMainMenu.Visible = true;

                this.NotifyMessage("就绪...");
            }
        }

        public RibbonControl RibbonControl
        {
            get { return this.ribbonMain; }
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
            get { return this; }
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

        #region MainEntitySet

        protected EntitySet<sysMenu> mainEntitySet = null;

        public virtual EntitySet<sysMenu> MainEntitySet
        {
            get
            {
                if (mainEntitySet == null)
                {
                    mainEntitySet = new EntitySet<sysMenu>();
                }
                return mainEntitySet;
            }
        }

        #endregion

        public void InitMenuTree()
        {
            string sql = @"
DECLARE @result TABLE
(
	Iden INT,
	Name NVARCHAR(500),
	ClassName NVARCHAR(500),
	[FileName] NVARCHAR(500),
	ParentId INT,
	MenuOrder INT
)

IF EXISTS(
	SELECT TOP 1 1 
	FROM dbo.sysUser a WITH(NOLOCK)
	JOIN dbo.sysUserRole b WITH(NOLOCK) ON a.Iden=b.UserId
	JOIN dbo.sysRole c WITH(NOLOCK) ON b.RoleId=c.Iden
	WHERE c.IsAdministrator=1 AND a.Iden=:UserId)
BEGIN
	--系统管理员显示所有菜单
	INSERT @result(Iden,Name,ClassName,[FileName],ParentId,MenuOrder)
	SELECT a.[Iden],a.[Name],b.[ClassName],[FileName]=c.[Name],a.[ParentId],a.[MenuOrder]
	FROM [dbo].[sysMenu] a with(nolock)
	LEFT JOIN [dbo].[sysBusinessView] b with(nolock) ON a.[BusinessViewId]=b.[Iden]
	LEFT JOIN [dbo].[sysFile] c with(nolock) ON b.[FileId]=c.[Iden]

END
ELSE BEGIN
	--根据用户权限显示菜单
	INSERT @result(Iden,Name,ClassName,[FileName],ParentId,MenuOrder)
	SELECT DISTINCT a.[Iden],a.[Name],b.[ClassName],[FileName]=c.[Name],a.[ParentId],a.[MenuOrder]
	FROM [dbo].[sysMenu] a with(nolock)
	LEFT JOIN [dbo].[sysBusinessView] b with(nolock) ON a.[BusinessViewId]=b.[Iden] and b.IsDeleted=0
	LEFT JOIN [dbo].[sysFile] c with(nolock) ON b.[FileId]=c.[Iden] and c.IsActive=1
	JOIN dbo.sysRoleMenu d WITH(nolock) ON d.MenuId = a.Iden
	JOIN dbo.sysUserRole e WITH(NOLOCK) ON d.RoleId=e.RoleId
	JOIN dbo.sysRole f WITH(NOLOCK) ON e.RoleId=f.Iden AND f.IsDeleted=0
	WHERE e.UserId=:UserId

	WHILE @@ROWCOUNT>0
	BEGIN
		INSERT @result(Iden,Name,ClassName,[FileName],ParentId,MenuOrder)
		SELECT DISTINCT temp.*
		FROM @result res
		JOIN (	SELECT a.[Iden],a.[Name],b.[ClassName],[FileName]=c.[Name],a.[ParentId],a.[MenuOrder]
				FROM [dbo].[sysMenu] a with(nolock)
				LEFT JOIN [dbo].[sysBusinessView] b with(nolock) ON a.[BusinessViewId]=b.[Iden]
				LEFT JOIN [dbo].[sysFile] c with(nolock) ON b.[FileId]=c.[Iden]
			) temp ON res.ParentId=temp.Iden AND NOT EXISTS(SELECT TOP 1 1 FROM @result res2 WHERE temp.Iden=res2.Iden)
	END
END

SELECT * FROM @result a ORDER BY a.[ParentId],a.[MenuOrder]
";
            MainEntitySet.Query(sql, Session.Current.UserId);

            if (this.TreeMenu.Columns.ColumnByFieldName("Name") == null)
            {
                var colName = this.TreeMenu.Columns.Add();
                colName.Caption = "名称";
                colName.FieldName = "Name";
                colName.Name = "colName";
                colName.OptionsColumn.AllowEdit = false;
                colName.OptionsColumn.AllowMove = false;
                colName.OptionsColumn.AllowMoveToCustomizationForm = false;
                colName.OptionsColumn.AllowSort = false;
                colName.OptionsColumn.ReadOnly = true;
                colName.OptionsColumn.ShowInCustomizationForm = false;
                colName.OptionsColumn.ShowInExpressionEditor = false;
                colName.OptionsFilter.AllowAutoFilter = false;
                colName.OptionsFilter.AllowFilter = false;
                colName.Visible = true;
                colName.VisibleIndex = 0;
            }

            this.TreeMenu.DataSource = MainEntitySet.DefaultView;
            this.TreeMenu.KeyFieldName = "Iden";
            this.TreeMenu.ParentFieldName = "ParentId";
        }

        private void TreeMenu_DoubleClick(object sender, EventArgs e)
        {
            Point point = TreeMenu.PointToClient(Cursor.Position);
            TreeListHitInfo hitInfo = TreeMenu.CalcHitInfo(point);
            switch (hitInfo.HitInfoType)
            {
                case HitInfoType.Cell:
                case HitInfoType.SelectImage:
                    if (this.TreeMenu.FocusedNode != null)
                    {
                        var drv = this.TreeMenu.GetDataRecordByNode(this.TreeMenu.FocusedNode) as DataRowView;
                        if (drv != null)
                        {
                            ShowBusinessView(drv);
                        }
                    }
                    break;
                default:
                    this.Cursor = Cursors.Default;
                    break;
            }
        }

        private void ShowBusinessView(DataRowView drv)
        {
            bool flag = false;
            try
            {
                Monitor.Enter(this, ref flag);

                var className = drv["ClassName"].ToString();
                if (className.IsEmpty())
                    return;

                int iMenuId = Convert.ToInt32(drv["Iden"]);
                //如果已经打开则激活模块，否则新增模块窗体
                Form doc = this.FindForm(iMenuId);
                if (doc != null)
                    this.tabbedView.ActivateDocument(doc);
                else
                {
                    Application.DoEvents();
                    try
                    {
                        var startupPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                        string fileName = System.IO.Path.Combine(startupPath, drv["FileName"].ToString());
                        if (!System.IO.File.Exists(fileName))
                            throw new Exception("文件{0}不存在,无法创建业务窗口.".FormatEx(fileName));

                        ProgressService.Show("正在创建业务窗口...");
                        try
                        {
                            object obj = Assembly.LoadFrom(fileName).CreateInstance(className, true);
                            if (obj == null)
                                throw new Exception("业务窗口'{0}'类型错误,无法创建.该类型在Dll文件中不存在.".FormatEx(className));

                            var ctl = obj as SAF.Framework.View.BaseView;
                            if (ctl != null)
                            {
                                ctl.UniqueId = iMenuId;
                                ctl.Init();
                                ctl.Text = drv["Name"].ToString();

                                var frm = ctl.CreateRibbonContainer();
                                frm.Icon = Icon.FromHandle(SAF.Client.Properties.Resources.Icon_Form_16x16.GetHicon());
                                frm.MdiParent = this;
                                frm.Show();
                            }
                            else
                                throw new Exception("业务窗口'{0}'不是UserControl,无法加载显示.".FormatEx(className));

                            ProgressService.Close(ApplicationService.Current.MainForm);
                        }
                        catch
                        {
                            ProgressService.Abort(ApplicationService.Current.MainForm);
                            throw;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("系统创建业务窗口时出现错误。", ex);
                    }
                }
            }
            finally
            {
                if (flag)
                    Monitor.Exit(this);
            }
        }

        private Form FindForm(int iMenuId)
        {
            foreach (var item in this.MdiChildren)
            {
                if (item.Tag != null && item.Tag.ToString() == iMenuId.ToString())
                    return item;
            }
            return null;
        }

        public string GetAllDirtyViewCpations()
        {
            //TODO:documentController.GetAllDirtyViewCpations();
            return string.Empty; //documentController.GetAllDirtyViewCpations();
        }

        private void btnRefreshMenu_Click(object sender, EventArgs e)
        {
            var node = this.TreeMenu.FocusedNode;
            InitMenuTree();
            this.TreeMenu.FocusedNode = node;
        }

        private void txtFind_EditValueChanged(object sender, EventArgs e)
        {
            var filter = this.txtFind.EditValue.ToStringEx().Trim();
            if (!filter.IsEmpty())
            {
                this.mainEntitySet.DefaultView.RowFilter = "Name like '%{0}%' and ClassName Is NOT NULL".FormatEx(filter);
            }
            else
            {
                this.mainEntitySet.DefaultView.RowFilter = null;
                this.txtFind.EditValue = null;
            }
        }

        void TreeMenu_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            var drv = this.TreeMenu.GetDataRecordByNode(e.Node) as DataRowView;

            if (drv == null) return;

            if (drv["ClassName"].IsNotEmpty())
            {
                e.NodeImageIndex = 2;
            }
            else
            {
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            }
        }

        private void Shell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F3)
                MessageService.ShowMessage("Shell F3");
        }
    }
}