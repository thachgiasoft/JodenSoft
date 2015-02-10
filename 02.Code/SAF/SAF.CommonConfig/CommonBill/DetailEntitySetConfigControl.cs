using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.Controls;
using SAF.Foundation.ServiceModel;
using SAF.Framework;
using SAF.Foundation;

namespace SAF.CommonConfig.CommonBill
{
    [ToolboxItem(true)]
    public partial class DetailEntitySetConfigControl : BaseUserControl
    {
        private List<EntitySetConfig> configs = new List<EntitySetConfig>();

        public List<EntitySetConfig> DetailEntitySetConfigs
        {
            get { return configs; }
            set
            {
                configs = value;
                this.bsDetail.DataSource = configs;
                this.bsDetail.ResetBindings(false);
            }
        }

        public DetailEntitySetConfigControl()
        {
            InitializeComponent();

            this.lbxDetailEntities.DataSource = this.bsDetail;
            this.lbxDetailEntities.ValueMember = "Caption";
            this.lbxDetailEntities.DisplayMember = "Caption";

            this.lbxDetailEntities.SelectedIndexChanged += lbxDetailEntities_SelectedIndexChanged;
        }

        void lbxDetailEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = this.lbxDetailEntities.SelectedItem as EntitySetConfig;
            if (obj == null)
                obj = new EntitySetConfig();
            this.detailConfigControl.EntitySetConfig = obj;
        }

        private static int index = 1;
        private void btnAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var obj = this.bsDetail.AddNew() as EntitySetConfig;
            obj.Caption = "EntitySetConfig " + index++;
            this.bsDetail.EndEdit();
            this.bsDetail.ResetBindings(false);
            this.detailConfigControl.ResetBindingSource();

            RefreshUI();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.bsDetail.Count > 0)
            {
                if (MessageService.AskQuestion("确定要删除选中的明细数据集配置吗？"))
                    this.bsDetail.RemoveCurrent();
            }

            RefreshUI();
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();
            if (this.bsDetail.Count <= 0)
            {
                UIController.RefreshControl(this.detailConfigControl, false, true);
            }
            else
            {
                UIController.RefreshControl(this.detailConfigControl, true, true);
            }
        }

        private void btnUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.bsDetail.MoveCurrentUp();
        }

        private void btnDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.bsDetail.MoveCurrentDown();
        }

    }
}
