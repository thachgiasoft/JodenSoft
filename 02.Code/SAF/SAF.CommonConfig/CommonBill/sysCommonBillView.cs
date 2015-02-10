using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Framework;
using SAF.Foundation.MetaAttributes;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using SAF.Foundation;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors;
using SAF.EntityFramework;
using DevExpress.Utils;
using SAF.Framework.Controls.ViewConfig;
using SAF.CommonConfig.Entities;
using SAF.CommonConfig.CommonBill;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.ServiceModel;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars;
using SAF.CommonConfig.Properties;

namespace SAF.CommonConfig
{
    [BusinessObject("通用单据")]
    public partial class sysCommonBillView : SingleView
    {
        public sysCommonBillView()
        {
            InitializeComponent();

            this.Shown += sysCommonBillView_Shown;
        }

        [Browsable(false)]
        [ViewParam("通用单据配置ID")]
        public virtual int CommonBillConfigId
        {
            get { return Convert.ToInt32(this.GetViewParam("CommonBillConfigId")); }
            set { this.SetViewParam("CommonBillConfigId", value.ToString()); }
        }

        protected override Framework.ViewModel.IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonBillViewViewModel();
        }

        public new sysCommonBillViewViewModel ViewModel
        {
            get { return base.ViewModel as sysCommonBillViewViewModel; }
        }

        private List<GridView> gridViews = new List<GridView>();

        void sysCommonBillView_Shown(object sender, EventArgs e)
        {
            foreach (var grv in gridViews)
            {
                if (grv != null)
                    grv.BestFitColumns();
            }
        }

        protected override void OnInitCommonBill()
        {
            base.OnInitCommonBill();

            this.ViewModel.QueryBillConfig(this.CommonBillConfigId);

            CreateIndexControl(this.ViewModel.CommonBillConfig.IndexEntitySetConfig);

            CreateMainControl(this.ViewModel.CommonBillConfig.MainEntitySetConfig);

            CreateDetailsControl(this.ViewModel.CommonBillConfig.DetailEntitySetConfigs);
        }


        private void CreateDetailsControl(IList<EntitySetConfig> dtlConfigs)
        {
            this.tcDtl.TabPages.Clear();

            if (dtlConfigs == null || dtlConfigs.Count <= 0)
            {
                this.splitRight.PanelVisibility = SplitPanelVisibility.Panel1;
                return;
            }

            this.splitRight.PanelVisibility = SplitPanelVisibility.Both;

            if (dtlConfigs.Count <= 1)
                this.tcDtl.ShowTabHeader = DefaultBoolean.False;
            else
                this.tcDtl.ShowTabHeader = DefaultBoolean.True;

            for (int i = 0; i < dtlConfigs.Count; i++)
            {
                var dtlConfig = dtlConfigs[i];

                var page = this.tcDtl.TabPages.Add();
                page.Padding = new System.Windows.Forms.Padding(1);
                page.Text = dtlConfig.Caption.IsEmpty() ? "明细数据" + i : dtlConfig.Caption;

                var bsDtl = new BindingSource();

                var dtlEntity = this.ViewModel.CreateDetailEntitySet(dtlConfig);
                dtlEntity.SetBindingSource(bsDtl);

                if (dtlConfig.ControlType == EntitySetControlType.GridControl)
                {
                    var standalone = CreateStandaloneBarDockControl(dtlConfig);
                    standalone.Dock = DockStyle.Top;
                    page.Controls.Add(standalone);

                    var bar = CreateDetailToolbar(dtlConfig);
                    bar.StandaloneBarDockControl = standalone;

                    var grdDtl = this.CreateGridControl(dtlConfig);
                    var grvDtl = grdDtl.MainView as GridView;
                    page.Controls.Add(grdDtl);
                    grdDtl.Dock = DockStyle.Fill;
                    grdDtl.BringToFront();
                    grdDtl.DataSource = bsDtl;
                }
                else
                {
                    MessageService.ShowError("索引区控件类型只支持GridControl");
                }
            }
        }

        private StandaloneBarDockControl CreateStandaloneBarDockControl(EntitySetConfig dtlConfig)
        {
            var standalone = new StandaloneBarDockControl();
            standalone.Name = "barStandalone_" + dtlConfig.UniqueId.ToString("N");
            standalone.Text = "barStandalone_" + dtlConfig.Caption;
            standalone.Height = 28;
            bmMain.DockControls.Add(standalone);
            return standalone;
        }

        private Bar CreateDetailToolbar(EntitySetConfig dtlConfig)
        {
            var bar = new Bar();

            bar.BarName = "bar_" + dtlConfig.UniqueId.ToString("N");
            bar.Text = "bar" + dtlConfig.Caption;
            bar.CanDockStyle = BarCanDockStyle.Standalone;
            bar.DockStyle = BarDockStyle.Standalone;
            bar.DockCol = 0;
            bar.DockRow = 0;
            bar.OptionsBar.AllowQuickCustomization = false;
            bar.OptionsBar.DrawDragBorder = false;
            bar.OptionsBar.UseWholeRow = true;
            this.bmMain.Bars.Add(bar);

            BarButtonItem bbiDtl = new BarButtonItem(bmMain, "新增");
            bbiDtl.Glyph = Resources.Action_New_16x16;
            bbiDtl.Id = 1;
            bbiDtl.Name = "bbiDtl_" + dtlConfig.UniqueId.ToString("N");
            bbiDtl.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiDtl.Tag = dtlConfig.UniqueId;
            bar.LinksPersistInfo.Add(new LinkPersistInfo(bbiDtl, true));

            bbiDtl = new BarButtonItem(bmMain, "删除");
            bbiDtl.Glyph = Resources.Action_Delete_16x16;
            bbiDtl.Id = 2;
            bbiDtl.Name = "bbiDtl_" + dtlConfig.UniqueId.ToString("N");
            bbiDtl.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiDtl.Tag = dtlConfig.UniqueId;
            bar.LinksPersistInfo.Add(new LinkPersistInfo(bbiDtl));

            return bar;
        }

        private void CreateMainControl(EntitySetConfig mainConfig)
        {
            if (mainConfig == null) return;

            this.ViewModel.MainEntitySet.DbTableName = mainConfig.DbTableName;
            this.ViewModel.MainEntitySet.PrimaryKeyName = mainConfig.PrimaryKeyName;
            this.ViewModel.MainEntitySet.IsReadOnly = mainConfig.IsReadOnly;

            this.ViewModel.MainEntitySet.SetBindingSource(this.bsMain);

            if (mainConfig.ControlType == EntitySetControlType.LayoutControl)
            {
                foreach (var field in mainConfig.Fields)
                {
                    LayoutControlItem lci = this.lcMain.Root.AddItem(field.Caption.IsEmpty() ? field.FieldName : field.Caption);
                    var name = Guid.NewGuid().ToString("N");
                    lci.Name = "lci_" + name;
                    var edt = new TextEdit() { Name = "lci_edt_" + name };
                    edt.DataBindings.Add("EditValue", this.bsMain, field.FieldName);
                    lci.Control = edt;
                }
            }
            else
            {
                MessageService.ShowError("索引区控件类型只支持LayoutControl");
            }

        }

        private void CreateIndexControl(EntitySetConfig indexConfig)
        {
            if (indexConfig == null) return;

            this.ViewModel.IndexEntitySet.DbTableName = indexConfig.DbTableName;
            this.ViewModel.IndexEntitySet.PrimaryKeyName = indexConfig.PrimaryKeyName;
            this.ViewModel.IndexEntitySet.IsReadOnly = indexConfig.IsReadOnly;
            this.ViewModel.IndexEntitySet.SetBindingSource(this.bsIndex);

            if (indexConfig.ControlType == EntitySetControlType.GridControl)
            {
                var grdIndex = this.CreateGridControl(indexConfig);
                var grvIndex = grdIndex.MainView as GridView;
                grvIndex.FocusedRowChanged += (s, e) => { this.IndexRowChange(); };
                this.splitMain.Panel1.Controls.Add(grdIndex);
                grdIndex.Dock = DockStyle.Fill;
                grdIndex.DataSource = this.bsIndex;
                grvIndex.OptionsBehavior.Editable = false;

            }
            else if (indexConfig.ControlType == EntitySetControlType.TreeList)
            {
                var treeList = this.CreateTreeList(indexConfig);
                treeList.FocusedNodeChanged += (s, e) => { this.IndexRowChange(); };
                this.splitMain.Panel1.Controls.Add(treeList);
                treeList.Dock = DockStyle.Fill;
                treeList.DataSource = this.bsIndex;
                treeList.OptionsBehavior.Editable = false;
            }
            else
            {
                MessageService.ShowError("索引区控件类型只支持GridControl和TreeList");
            }
        }

        private GridControl CreateGridControl(EntitySetConfig config)
        {
            var grd = new GridControl() { Name = "grd_" + config.UniqueId.ToString("N") };
            var grv = new GridView(grd) { Name = "grv_" + config.UniqueId.ToString("N") };
            gridViews.Add(grv);
            grv.OptionsView.ColumnAutoWidth = false;

            grd.ViewCollection.Add(grv);
            grd.MainView = grv;

            foreach (var field in config.Fields)
            {
                var column = grv.Columns.AddField(field.FieldName);
                column.Caption = field.Caption.IsEmpty() ? field.FieldName : field.Caption;
                column.Visible = true;
            }

            return grd;
        }

        private TreeList CreateTreeList(EntitySetConfig config)
        {
            var treeList = new TreeList();
            treeList.KeyFieldName = config.ControlKeyFieldName;
            treeList.ParentFieldName = config.ControlParentFieldName;

            treeList.OptionsBehavior.AutoPopulateColumns = false;

            if (config.Fields.Count <= 1)
            {
                treeList.OptionsView.ShowColumns = false;
                treeList.OptionsView.ShowHorzLines = false;
                treeList.OptionsView.ShowIndicator = false;
                treeList.OptionsView.ShowVertLines = false;
            }

            for (int i = 0; i < config.Fields.Count; i++)
            {
                var field = config.Fields[0];

                var colName = treeList.Columns.Add();
                colName.Caption = field.Caption.IsEmpty() ? field.FieldName : field.Caption;
                colName.FieldName = field.FieldName;
                colName.Name = "treeList_col_" + Guid.NewGuid().ToString("N");
                colName.OptionsColumn.AllowEdit = false;
                colName.OptionsColumn.AllowMove = false;
                colName.OptionsColumn.AllowSort = false;
                colName.OptionsColumn.ReadOnly = true;
                colName.Visible = true;
                colName.VisibleIndex = i;
            }

            return treeList;
        }
    }
}
