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

namespace SAF.CommonBill
{
    [BusinessObject("通用单据")]
    public partial class sysCommonBillView : MasterDetailView
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

        private CommonBillConfig config = new CommonBillConfig();

        protected override void OnInitUI()
        {
            base.OnInitUI();

            var config = ViewModel.QueryBillConfg(this.CommonBillConfigId);

            CreateIndexControl(config.IndexEntitySetConfig);

            CreateMainControl(config.MainEntitySetConfig);

            CreateDetailsControl(config.DetailEntitySetConfigs);

        }

        private void CreateDetailsControl(IList<EntitySetConfig> dtlConfigs)
        {
            if (dtlConfigs == null || dtlConfigs.Count <= 0) return;

            this.tcDtl.TabPages.Clear();

            if (dtlConfigs.Count <= 1)
                this.tcDtl.ShowTabHeader = DefaultBoolean.False;
            else
                this.tcDtl.ShowTabHeader = DefaultBoolean.True;


            for (int i = 0; i < dtlConfigs.Count; i++)
            {
                var config = dtlConfigs[i];

                var page = this.tcDtl.TabPages.Add();
                page.Padding = new System.Windows.Forms.Padding(1);
                page.Text = config.Caption.IsEmpty() ? "明细数据" + i : config.Caption;
                var bsDtl = new BindingSource();

                var dtlEntity = new EntitySet<QueryEntity>(this.ViewModel.ExecuteCache);
                dtlEntity.IsReadOnly = config.IsReadOnly;
                this.ViewModel.dtlEntitys.Add(dtlEntity);
                dtlEntity.SetBindingSource(bsDtl);

                if (config.ControlSetting.ControlType == EntitySetControlType.GridControl)
                {
                    var grdDtl = new GridControl() { Name = "grdDtl_" + i };
                    var grvDtl = new GridView(grdDtl) { Name = "grvDtl_" + i };
                    gridViews.Add(grvDtl);
                    grvDtl.OptionsView.ColumnAutoWidth = false;
                    grvDtl.OptionsBehavior.Editable = true;

                    grdDtl.ViewCollection.Add(grvDtl);
                    grdDtl.MainView = grvDtl;

                    page.Controls.Add(grdDtl);
                    grdDtl.Dock = DockStyle.Fill;
                    grdDtl.DataSource = bsDtl;
                    this.ViewModel.IndexEntitySet.SetBindingSource(this.bsIndex);

                    foreach (var field in config.Fields)
                    {
                        var column = grvDtl.Columns.AddField(field.FieldName);
                        column.Caption = field.Caption.IsEmpty() ? field.FieldName : field.Caption;
                        column.OptionsColumn.ReadOnly = field.IsReadOnly;
                        column.OptionsColumn.AllowEdit = !field.IsReadOnly;
                        column.Visible = true;
                    }

                }
            }
        }

        private void CreateMainControl(EntitySetConfig mainConfig)
        {
            if (mainConfig == null) return;

            this.ViewModel.MainEntitySet.DbTableName = mainConfig.DbTableName;
            this.ViewModel.MainEntitySet.PrimaryKeyName = mainConfig.PrimaryKeyName;
            this.ViewModel.MainEntitySet.IsReadOnly = mainConfig.IsReadOnly;

            this.ViewModel.MainEntitySet.SetBindingSource(this.bsMain);

            int i = 0;
            foreach (var field in mainConfig.Fields)
            {
                LayoutControlItem lci = this.lcMain.Root.AddItem(field.Caption);
                i++;
                lci.Name = "lci_" + i;
                var edt = new TextEdit() { Name = "edt_" + i };
                edt.DataBindings.Add("EditValue", this.bsMain, field.FieldName);
                lci.Control = edt;
            }

        }

        private void CreateIndexControl(EntitySetConfig indexConfig)
        {
            if (indexConfig == null) return;

            this.ViewModel.IndexEntitySet.DbTableName = indexConfig.DbTableName;
            this.ViewModel.IndexEntitySet.PrimaryKeyName = indexConfig.PrimaryKeyName;
            this.ViewModel.IndexEntitySet.IsReadOnly = indexConfig.IsReadOnly;

            if (indexConfig.ControlSetting.ControlType == EntitySetControlType.GridControl)
            {
                var grdIndex = new GridControl() { Name = "grdIndex" };
                var grvIndex = new GridView(grdIndex) { Name = "grvIndex" };
                gridViews.Add(grvIndex);
                grvIndex.OptionsView.ColumnAutoWidth = false;
                grvIndex.OptionsBehavior.Editable = false;

                grvIndex.FocusedRowChanged += (s, e) => { this.IndexRowChange(); };

                grdIndex.ViewCollection.Add(grvIndex);
                grdIndex.MainView = grvIndex;

                this.splitMain.Panel1.Controls.Add(grdIndex);
                grdIndex.Dock = DockStyle.Fill;
                grdIndex.DataSource = this.bsIndex;
                this.ViewModel.IndexEntitySet.SetBindingSource(this.bsIndex);

                foreach (var field in indexConfig.Fields)
                {
                    var column = grvIndex.Columns.AddField(field.FieldName);
                    column.Caption = field.Caption.IsEmpty() ? field.FieldName : field.Caption;
                    column.Visible = true;
                }
            }
        }

    }
}
