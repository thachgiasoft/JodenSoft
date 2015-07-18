using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Framework.ViewModel;
using SAF.Foundation.MetaAttributes;
using SAF.Framework;
using SAF.EntityFramework;
using DevExpress.XtraEditors;
using SAF.Foundation.ServiceModel;
using DevExpress.XtraLayout.Utils;

namespace SAF.CommonConfig
{
    [BusinessObject("报表中心配置")]
    public partial class sysCommonReportView : MasterDetailView
    {
        public sysCommonReportView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonReportConfigViewViewModel();
        }

        public new sysCommonReportConfigViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysCommonReportConfigViewViewModel;
            }
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(txtIden, false);
            UIController.RefreshControl(txtParamList, false);
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            this.cbxParent.QueryPopUp += cbxParent_QueryPopUp;

            this.treeIndex.FocusedNodeChanged += treeIndex_FocusedNodeChanged;
        }

        void treeIndex_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        void cbxParent_QueryPopUp(object sender, CancelEventArgs e)
        {
            InitEditor();
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            this.cbxNodeType.Properties.Items.AddEnum(typeof(NodeType), true);

            InitEditor();

            this.pnlPageControl.Visible = false;
        }

        private void InitEditor()
        {
            var sql = @"
with result as
(
SELECT A.Iden,A.Name,A.ParentId 
FROM dbo.sysReport A WITH(NOLOCK) 
WHERE A.NodeType=1
UNION ALL
SELECT Iden=-1,Name='无',ParentId=-1
)

SELECT * FROM result 
ORDER BY ParentId, Iden
";
            var es = new EntitySet<QueryEntity>();
            es.Query(sql);
            this.cbxParent.Properties.SetDataSource(es.DefaultView, "Iden", "Name", "ParentId");
        }

        public override string InitCondition
        {
            get
            {
                return "1=1";
            }
        }

        private void cbxNodeType_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (this.IsEdit && Convert.ToInt32(e.NewValue) == (int)NodeType.Folder)
            {
                if (this.ViewModel.DetailEntitySet.Count > 0)
                {
                    if (MessageService.AskQuestion("切换类型会删除已有的报表格式,确定要切换类型吗"))
                        this.ViewModel.DetailEntitySet.DeleteAll();
                    else
                        e.Cancel = true;
                }
            }

        }

        private void cbxNodeType_EditValueChanged(object sender, EventArgs e)
        {
            if (this.cbxNodeType.EditValue != null && Convert.ToInt32(this.cbxNodeType.EditValue) == (int)NodeType.Report)
            {
                this.lcMain.BeginUpdate();
                this.lciSqlScript.Visibility = LayoutVisibility.Always;
                this.lciDataSetAlias.Visibility = LayoutVisibility.Always;
                lciParamList.Visibility = LayoutVisibility.Always;
                lciParamValues.Visibility = LayoutVisibility.Always;
                this.lcMain.EndUpdate();

                this.splitRight.PanelVisibility = SplitPanelVisibility.Both;
            }
            else
            {
                this.splitRight.PanelVisibility = SplitPanelVisibility.Panel1;

                this.lcMain.BeginUpdate();
                this.lciSqlScript.Visibility = LayoutVisibility.Never;
                this.lciDataSetAlias.Visibility = LayoutVisibility.Never;
                lciParamList.Visibility = LayoutVisibility.Never;
                lciParamValues.Visibility = LayoutVisibility.Never;
                this.lcMain.EndUpdate();

                txtSqlScript.Clear();
                txtDataSetAlias.Clear();
                txtParamList.Clear();
                txtParamValues.Clear();
            }

        }

        private void bbiDesignReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected override void OnRefreshDetailToolBar()
        {
            base.OnRefreshDetailToolBar();

            if (this.ViewModel == null) return;

            var count = this.ViewModel.DetailEntitySet.Count;
            UIController.RefreshControl(this.btnDesignReport, count > 0 && this.IsBrowse);
        }

    }

    public enum NodeType
    {
        /// <summary>
        /// 报表
        /// </summary>
        [Description("报表")]
        Report = 0,
        /// <summary>
        /// 目录
        /// </summary>
        [Description("目录")]
        Folder = 1
    }
}
