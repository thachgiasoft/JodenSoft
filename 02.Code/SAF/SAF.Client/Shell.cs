using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
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
using SAF.Framework.Component;
using SAF.Framework.ComponentModel;
using SAF.Framework.Controls;
using SAF.Framework.Entity;
using SAF.Framework.ServiceModel;
using SAF.Framework.View;
using SAF.SystemModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
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

        public bool IsLogin { get; set; }

        public Shell()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Icon = Properties.Resources.SAF_Icon;

            ApplicationService.Current.MainForm = this;

            OnInitialize();

#if DEBUG
            this.Text = "DIP - DEBUG";
#else
            this.Text = "SAF";
#endif
            this.Shown += Shell_Shown;
            this.FormClosing += Shell_FormClosing;

        }

        void Shell_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.IsLogin)
            {
                var s = this.GetAllDirtyViewCpations();
                if (!s.IsEmpty())
                {
                    string question = "以下界面的数据未保存,关闭将丢失更改:{0}{1}{0}{0}确定要退出系统吗?".FormatWith(Environment.NewLine, s);
                    var allowClose = MessageService.AskQuestion(question);
                    e.Cancel = !allowClose;
                }
                else
                {
                    var allowClose = MessageService.AskQuestion("确定要退出系统吗?");
                    e.Cancel = !allowClose;
                }
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

            this.bbiWelcomePage.Enabled = false;
            this.bbiWelcomePage.Visibility = BarItemVisibility.Never;

            this.bbiNavigation.Enabled = false;
            this.bbiNavigation.Visibility = BarItemVisibility.Never;

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
                this.IsLogin = false;
                e.Message = msg;
                this.NotifyMessage("就绪...");
            }
            else
            {
                UserConfig.Current.UserName = e.UserName;
                UserConfig.Current.SavePassword = e.SavePassword;
                if (e.SavePassword)
                {
                    UserConfig.Current.Password = DESHelper.Encrypt(e.Password, Session.MachineInfo.MachineCode);
                }
                UserConfig.Current.Save();

                AppConfig.Current.Load();
                AppConfig.Current.SetTheme();

                e.IsSuccess = true;
                this.IsLogin = true;

                this.NotifyMessage("初始化工作区...");
                this.InitBackstageViewTabItemAndCommand(DisplayMode.AfterLogin);
                InitWorkspace();

                if (AppConfig.Current.ShowWorkSpace)
                    this.navMainMenu.ActiveGroup = sysMyWorkspace;
                else
                    this.navMainMenu.ActiveGroup = systemMenuGroup;

                Form welcome = null;

                if (AppConfig.Current.ShowWelcomePage)
                {
                    this.NotifyMessage("显示欢迎页...");
                    welcome = ShowWelcomePage();
                }

                if (AppConfig.Current.ShowNavigationPage)
                {
                    this.NotifyMessage("显示导航图...");
                    ShowNavigationPage();
                }

                this.NotifyMessage("打开界面...");
                ShowAutoOpenView();

                if (welcome != null)
                    this.tabbedView.ActivateDocument(welcome);

                this.NotifyMessage("就绪...");
            }
        }

        private void ShowAutoOpenView()
        {
            try
            {
                var autoOpenList = this.MainEntitySet.Where(p => p.IsAutoOpen == true);
                foreach (var item in autoOpenList)
                {
                    ShowBusinessView(item.DataRowView);
                }
            }
            catch { }
        }

        private static readonly int WelcomePageId = -10000;

        private Form ShowWelcomePage()
        {
            Form frm = this.FindBusinessView(WelcomePageId);
            if (frm != null)
                this.tabbedView.ActivateDocument(frm);
            else
            {
                var page = new WelcomePage() { UniqueId = WelcomePageId };
                page.Init();
                frm = page.CreateRibbonContainer();
                frm.Tag = WelcomePageId;
                frm.Icon = Icon.FromHandle(SAF.Client.Properties.Resources.Icon_Form_16x16.GetHicon());
                frm.MdiParent = this;
                frm.Show();
            }

            BaseDocument doc;
            this.tabbedView.Documents.TryGetValue(frm, out doc);
            if (doc is Document)
                (doc as Document).Pinned = true;

            return frm;
        }

        private void InitWorkspace()
        {
            this.InitMenuTree();
            this.TreeMenu.SelectImageList = this.imageCollectionTreeList;
            this.TreeMenu.GetSelectImage += TreeMenu_GetSelectImage;
            this.TreeMenu.DoubleClick += TreeMenu_DoubleClick;
            this.txtFind.EditValueChanged += txtFind_EditValueChanged;
            this.txtFind.KeyDown += txtFind_KeyDown;
            this.btnRefreshMenu.Click += btnRefreshMenu_Click;

            this.InitMyWorkspace();
            this.treeMyMenu.SelectImageList = this.imageCollectionTreeList;
            this.treeMyMenu.GetSelectImage += TreeMenu_GetSelectImage;
            this.treeMyMenu.DoubleClick += TreeMenu_DoubleClick;

            this.Controls.Remove(loginControl);
            loginControl.Dispose();

            this.splMenu.Visible = true;
            this.navMainMenu.Visible = true;

            this.bbiWelcomePage.Enabled = true;
            this.bbiWelcomePage.Visibility = BarItemVisibility.Always;

            this.bbiNavigation.Enabled = true;
            this.bbiNavigation.Visibility = BarItemVisibility.Always;
        }

        #region myMenuEntitySet

        protected EntitySet<sysMenu> myMenuEntitySet = null;

        protected EntitySet<sysMyFavoriteMenu> myFavoriteMenu = null;
        public virtual EntitySet<sysMyFavoriteMenu> MyFavoriteMenu
        {
            get
            {
                if (myFavoriteMenu == null)
                {
                    myFavoriteMenu = new EntitySet<sysMyFavoriteMenu>();
                }
                return myFavoriteMenu;
            }
        }

        #endregion


        private void InitMyWorkspace()
        {
            myMenuEntitySet = this.MainEntitySet.Clone() as EntitySet<sysMenu>;
            var root = myMenuEntitySet.AddNew();
            root.Iden = -1;
            root.ParentId = -2;
            root.Name = "我收藏的菜单";
            root.MenuOrder = -1;

            MyFavoriteMenu.Query("SELECT a.Iden, a.MenuId,RowNumber FROM dbo.sysMyFavoriteMenu a with(nolock) WHERE UserId=:UserId", Session.UserInfo.UserId);

            var list = this.MainEntitySet.Where(p => MyFavoriteMenu.Any(x => x.MenuId == p.Iden));

            foreach (var item in list)
            {
                var obj = myMenuEntitySet.AddNew();
                obj.Copy(item);
                obj.ParentId = root.Iden;
                obj.MenuOrder = MyFavoriteMenu.First(p => p.MenuId == item.Iden).RowNumber;
                obj.MenuType = (int)sysMenuType.Menu;
            }

            this.treeMyMenu.OptionsBehavior.AutoPopulateColumns = false;
            this.treeMyMenu.OptionsBehavior.Editable = false;
            if (this.treeMyMenu.Columns.ColumnByFieldName("Name") == null)
            {
                var colName = this.treeMyMenu.Columns.Add();
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

            var source = myMenuEntitySet.OrderBy(p => p.ParentId).OrderBy(p => p.MenuOrder).OrderBy(p => p.Iden);
            this.treeMyMenu.DataSource = new BindingSource() { DataSource = source.Select(p => p.DataRowView) };
            this.treeMyMenu.KeyFieldName = "Iden";
            this.treeMyMenu.ParentFieldName = "ParentId";
            this.treeMyMenu.ExpandAll();
        }

        void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (TreeMenu.FocusedNode != null)
                {
                    var drv = TreeMenu.GetDataRecordByNode(TreeMenu.FocusedNode) as DataRowView;
                    if (drv != null)
                    {
                        sysMenu entity = new sysMenu() { DataRowView = drv };
                        if (entity.MenuType == (int)sysMenuType.Catalog)
                        {
                            TreeMenu.FocusedNode.Expanded = !TreeMenu.FocusedNode.Expanded;
                            e.Handled = true;
                            return;
                        }
                    }
                }

                this.ShowView(this.TreeMenu);
                e.Handled = true;
            }
            else if (e.KeyData == Keys.Up)
            {
                this.TreeMenu.MovePrevVisible();
                e.Handled = true;
            }
            else if (e.KeyData == Keys.Down)
            {
                this.TreeMenu.MoveNextVisible();
                e.Handled = true;
            }
            else if (e.KeyData == Keys.Escape)
            {
                this.txtFind.EditValue = null;
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
            //System.Diagnostics.Process.Start("iexplore.exe", "http://www.baidu.com");
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
	MenuOrder INT,
    IsAutoOpen BIT,
    MenuType INT,
    MenuFileName NVARCHAR(MAX),
    FileParameter NVARCHAR(MAX),
    IsShowDialog BIT
)

IF EXISTS(
	SELECT TOP 1 1 
	FROM dbo.sysUser a WITH(NOLOCK)
	JOIN dbo.sysUserRole b WITH(NOLOCK) ON a.Iden=b.UserId
	JOIN dbo.sysRole c WITH(NOLOCK) ON b.RoleId=c.Iden
	WHERE c.IsAdministrator=1 AND a.Iden=:UserId)
BEGIN
	--系统管理员显示所有菜单
	INSERT @result(Iden,Name,ClassName,[FileName],ParentId,MenuOrder,IsAutoOpen,MenuType,MenuFileName,FileParameter,IsShowDialog)
	SELECT a.[Iden],a.[Name],b.[ClassName],[FileName]=c.[Name],a.[ParentId],a.[MenuOrder], A.[IsAutoOpen],A.[MenuType],A.[FileName],A.[FileParameter],A.[IsShowDialog]
	FROM [dbo].[sysMenu] a with(nolock)
	LEFT JOIN [dbo].[sysBusinessView] b with(nolock) ON a.[BusinessViewId]=b.[Iden]
	LEFT JOIN [dbo].[sysFile] c with(nolock) ON b.[FileId]=c.[Iden]

END
ELSE BEGIN
	--根据用户权限显示菜单
	INSERT @result(Iden,Name,ClassName,[FileName],ParentId,MenuOrder,IsAutoOpen,MenuType,[MenuFileName],[FileParameter],IsShowDialog)
	SELECT DISTINCT a.[Iden],a.[Name],b.[ClassName],[FileName]=c.[Name],a.[ParentId],a.[MenuOrder], A.[IsAutoOpen],A.[MenuType],A.[FileName],A.[FileParameter],A.[IsShowDialog]
	FROM [dbo].[sysMenu] a with(nolock)
	LEFT JOIN [dbo].[sysBusinessView] b with(nolock) ON a.[BusinessViewId]=b.[Iden] and b.IsDeleted=0
	LEFT JOIN [dbo].[sysFile] c with(nolock) ON b.[FileId]=c.[Iden] and c.IsActive=1
	JOIN dbo.sysRoleMenu d WITH(nolock) ON d.MenuId = a.Iden
	JOIN dbo.sysUserRole e WITH(NOLOCK) ON d.RoleId=e.RoleId
	JOIN dbo.sysRole f WITH(NOLOCK) ON e.RoleId=f.Iden AND f.IsDeleted=0
	WHERE e.UserId=:UserId

	WHILE @@ROWCOUNT>0
	BEGIN
		INSERT @result(Iden,Name,ClassName,[FileName],ParentId,MenuOrder,IsAutoOpen,MenuType,[MenuFileName],[FileParameter],IsShowDialog)
		SELECT DISTINCT temp.*
		FROM @result res
		JOIN (	SELECT a.[Iden],a.[Name],b.[ClassName],[FileName]=c.[Name],a.[ParentId],a.[MenuOrder], A.[IsAutoOpen],A.[MenuType],MenuFileName=A.[FileName],A.[FileParameter],A.[IsShowDialog]
				FROM [dbo].[sysMenu] a with(nolock)
				LEFT JOIN [dbo].[sysBusinessView] b with(nolock) ON a.[BusinessViewId]=b.[Iden]
				LEFT JOIN [dbo].[sysFile] c with(nolock) ON b.[FileId]=c.[Iden]
			) temp ON res.ParentId=temp.Iden AND NOT EXISTS(SELECT TOP 1 1 FROM @result res2 WHERE temp.Iden=res2.Iden)
	END
END

SELECT * FROM @result a ORDER BY a.[ParentId],a.[MenuOrder]
";
            MainEntitySet.Query(sql, Session.UserInfo.UserId);

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

            this.TreeMenu.DataSource = new BindingSource() { DataSource = MainEntitySet.DefaultView };
            this.TreeMenu.KeyFieldName = "Iden";
            this.TreeMenu.ParentFieldName = "ParentId";
            if (this.TreeMenu.Nodes.Count > 0)
            {
                this.TreeMenu.Nodes[0].Expanded = true;
            }
        }

        private void TreeMenu_DoubleClick(object sender, EventArgs e)
        {
            var tree = (sender as TreeList);
            if (tree == null) return;
            Point point = tree.PointToClient(Cursor.Position);
            TreeListHitInfo hitInfo = tree.CalcHitInfo(point);
            switch (hitInfo.HitInfoType)
            {
                case HitInfoType.Cell:
                case HitInfoType.SelectImage:
                    ShowView(tree);
                    break;
                default:
                    this.Cursor = Cursors.Default;
                    break;
            }
        }

        private void ShowView(TreeList tree)
        {
            if (tree.FocusedNode != null)
            {
                var drv = tree.GetDataRecordByNode(tree.FocusedNode) as DataRowView;
                if (drv != null)
                {
                    sysMenu entity = new sysMenu() { DataRowView = drv };
                    if (entity.MenuType == (int)sysMenuType.Menu)
                    {
                        ShowBusinessView(entity.DataRowView);
                    }
                    else if (entity.MenuType.In((int)sysMenuType.ExternalForm))
                    {
                        string fileName = Path.Combine(Application.StartupPath, entity.GetFieldValue<string>("MenuFileName"));
                        if (!File.Exists(fileName))
                        {
                            MessageService.ShowErrorFormatted("菜单对应的文件名不存在.文件名称为:{0}", fileName);
                            return;
                        }
                        var param = ParseFileParameter(entity.FileParameter);
                        ProcessStartInfo startInfo = new ProcessStartInfo(fileName);
                        startInfo.Arguments = param;
                        var customProcess = Process.Start(startInfo);
                        if (entity.IsShowDialog)
                            customProcess.WaitForExit();
                    }
                }
            }
        }

        private string ParseFileParameter(string sileParameter)
        {
            string param = sileParameter + " ";
            Regex paramReg = new Regex(@":UserId\s+");
            param = paramReg.Replace(param, Session.UserInfo.UserId.ToString());

            paramReg = new Regex(@":UserId\s?,");
            param = paramReg.Replace(param, Session.UserInfo.UserId.ToString() + ",");

            paramReg = new Regex(@":UserId" + "\\s?\"\\s+");
            param = paramReg.Replace(param, Session.UserInfo.UserId.ToString() + "\"");

            paramReg = new Regex(@":UserId" + "\\s?\"\\s?,");
            param = paramReg.Replace(param, Session.UserInfo.UserId.ToString() + "\",");

            //替换UserName
            paramReg = new Regex(@":UserName\s+");
            param = paramReg.Replace(param, Session.UserInfo.UserName.ToString());

            paramReg = new Regex(@":UserName\s?,");
            param = paramReg.Replace(param, Session.UserInfo.UserName.ToString() + ",");

            paramReg = new Regex(@":UserName" + "\\s?\"\\s+");
            param = paramReg.Replace(param, Session.UserInfo.UserId.ToString() + "\"");

            paramReg = new Regex(@":UserName" + "\\s?\"\\s?,");
            param = paramReg.Replace(param, Session.UserInfo.UserId.ToString() + "\",");

            return param;
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
                Form doc = this.FindBusinessView(iMenuId);
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
                            throw new Exception("文件{0}不存在,无法创建业务窗口.".FormatWith(fileName));

                        ProgressService.Show("正在创建业务窗口");
                        try
                        {
                            object obj = Assembly.LoadFrom(fileName).CreateInstance(className, true);
                            if (obj == null)
                                throw new Exception("业务窗口'{0}'类型错误,无法创建.该类型在Dll文件中不存在.".FormatWith(className));

                            var ctl = obj as SAF.Framework.View.BaseView;
                            if (ctl != null)
                            {
                                ctl.UniqueId = iMenuId;
                                ctl.Init();
                                ctl.Text = drv["Name"].ToString();

                                var frm = ctl.CreateRibbonContainer();
                                frm.Icon = Icon.FromHandle(SAF.Client.Properties.Resources.Icon_Form_16x16.GetHicon());
                                frm.MdiParent = this;
                                frm.Tag = iMenuId;
                                frm.Show();
                            }
                            else
                                throw new Exception("业务窗口'{0}'不是UserControl,无法加载显示.".FormatWith(className));

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

        private Form FindBusinessView(int iMenuId)
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
            var list = this.MdiChildren.Where(p => p.Controls[0] is IBaseView && (p.Controls[0] as IBaseView).IsDirty).Select(p => p.Controls[0] as IBaseView);

            if (list.IsEmpty()) return string.Empty;

            string str = list.Select(p => p.Text).JoinText(Environment.NewLine);
            return str;
        }

        private void btnRefreshMenu_Click(object sender, EventArgs e)
        {
            InitMenuTree();
            this.txtFind_EditValueChanged(this.txtFind, EventArgs.Empty);
        }

        private void txtFind_EditValueChanged(object sender, EventArgs e)
        {
            var filter = this.txtFind.EditValue.ToStringEx().Trim();
            if (!filter.IsEmpty())
            {
                this.mainEntitySet.DefaultView.RowFilter = "(Name Like '%{0}%' or ClassName Like '%{0}%') and ClassName Is NOT NULL".FormatWith(filter);
                if (this.TreeMenu.Nodes.Count > 0)
                {
                    this.TreeMenu.Nodes[0].Selected = true;
                }
            }
            else
            {
                this.mainEntitySet.DefaultView.RowFilter = null;
                this.txtFind.EditValue = null;

                if (this.TreeMenu.Nodes.Count > 0)
                {
                    this.TreeMenu.Nodes[0].Expanded = true;
                    this.TreeMenu.Nodes[0].Selected = true;
                }
            }
        }

        void TreeMenu_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            var drv = (sender as TreeList).GetDataRecordByNode(e.Node) as DataRowView;

            if (drv == null) return;

            var menu = new sysMenu() { DataRowView = drv };

            if (menu.MenuType == 1)
            {
                e.NodeImageIndex = 2;
            }
            else if (menu.MenuType.In(2, 3))
            {
                e.NodeImageIndex = 3;
            }
            else
            {
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            }
        }

        public void ShowBusinessView(int iMenuId)
        {
            var obj = MainEntitySet.FirstOrDefault(p => p.Iden == iMenuId);
            if (obj != null)
            {
                this.ShowBusinessView(obj.DataRowView);
            }
        }

        private void btnMyMenuDelete_Click(object sender, EventArgs e)
        {
            if (this.treeMyMenu.FocusedNode != null)
            {
                var menu = treeMyMenu.GetDataRecordByNode(this.treeMyMenu.FocusedNode) as sysMenu;
                if (menu != null && menu.Iden != -1)
                {
                    if (MessageService.AskQuestion("确定要删除收藏的菜单吗?"))
                    {
                        var obj = this.MyFavoriteMenu.FirstOrDefault(p => p.MenuId == menu.Iden);
                        if (obj != null)
                        {
                            obj.Delete();
                            MyFavoriteMenu.SaveChanges();
                            treeMyMenu.DeleteNode(this.treeMyMenu.FocusedNode);
                        }
                    }
                }
            }
        }

        private void btnUpMyMenu_Click(object sender, EventArgs e)
        {
            //TODO:btnUpMyMenu_Click
        }

        private void btnMyMenuDown_Click(object sender, EventArgs e)
        {
            //TODO:btnMyMenuDown_Click
        }

        private void btnRefreshMyFavorite_Click(object sender, EventArgs e)
        {
            RefreshFavorite();
        }

        private void bbiWelcomePage_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWelcomePage();
        }

        public void RefreshFavorite()
        {
            this.InitMyWorkspace();
        }

        private void bbiNavigation_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowNavigationPage();
        }

        private static readonly int NavigationPageId = -10010;
        private Form ShowNavigationPage()
        {
            Form frm = this.FindBusinessView(NavigationPageId);
            if (frm != null)
                this.tabbedView.ActivateDocument(frm);
            else
            {
                var page = new NavigationPage() { UniqueId = NavigationPageId };
                page.Init();
                frm = page.CreateRibbonContainer();
                frm.Tag = NavigationPageId;
                frm.Icon = Icon.FromHandle(SAF.Client.Properties.Resources.Icon_Form_16x16.GetHicon());
                frm.MdiParent = this;
                frm.Show();
            }

            BaseDocument doc;
            this.tabbedView.Documents.TryGetValue(frm, out doc);
            if (doc is Document)
                (doc as Document).Pinned = true;

            return frm;
        }

        public void Relogin()
        {
            this.NotifyMessage("正在关闭已打开的窗体...");
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
            if (this.MdiChildren.Any())
            {
                this.NotifyMessage("子窗口未成功关闭,已取消切换用户账户操作.");
                return;
            }
            Application.DoEvents();
            Session.UserInfo.Clear();
            this.NotifyMessage("初始化登录界面...");
            this.OnInitialize();
            this.NotifyMessage("就绪...");
        }

        private void Shell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Q)
            {
                this.txtFind.SelectAll();
                this.txtFind.Focus();
                e.Handled = true;
            }
        }
    }
}