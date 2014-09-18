using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using SAF.EntityFramework;
using SAF.Foundation.Security;
using System.Diagnostics;
using SAF.Foundation;
using System.Reflection;
using DevExpress.XtraSplashScreen;
using SAF.Framework.Controls.Entities;
using SAF.Foundation.ServiceModel;
using SAF.Framework.View;
using DevExpress.XtraTreeList;
using System.Threading;

namespace SAF.Framework.Controls
{
    [ToolboxItem(false)]
    public partial class WorkSpace : BaseUserControl
    {
        public WorkSpace()
        {
            InitializeComponent();

            InitUI();
        }

        private void InitUI()
        {
            this.TreeMenu.SelectImageList = this.imageCollectionTreeList;
            this.TreeMenu.GetSelectImage += TreeMenu_GetSelectImage;
        }

        void TreeMenu_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            var drv = this.TreeMenu.GetDataRecordByNode(e.Node) as DataRowView;

            if (drv["ClassName"].IsNotEmpty())
            {
                e.NodeImageIndex = 2;
            }
            else
            {
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            }
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

                //如果已经打开则激活模块，否则新增模块窗体
                string hashCode = MD5Helper.Hash(drv["Iden"].ToString());
                BaseDocument doc = documentController.FindDocument(hashCode);
                if (doc != null)
                    this.documentController.ActiveDocument(doc.Control);
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
                                ctl.UniqueId = Convert.ToInt32(drv["Iden"]);
                                ctl.Init();
                                this.documentController.AddDocument(ctl, drv["Name"].ToString(), hashCode);
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

        public string GetAllDirtyViewCpations()
        {
            return documentController.GetAllDirtyViewCpations();
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
                this.mainEntitySet.DefaultView.RowFilter = "Name like '%{0}%'".FormatEx(filter);
            }
            else
            {
                this.mainEntitySet.DefaultView.RowFilter = null;
                this.txtFind.EditValue = null;
            }

        }

    }

}
