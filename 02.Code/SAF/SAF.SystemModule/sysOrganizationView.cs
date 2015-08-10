using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using DevExpress.XtraEditors.Controls;
using SAF.Framework.Controls;
using SAF.Foundation.MetaAttributes;
using SAF.Framework;

namespace SAF.SystemModule
{
    [BusinessObject("组织管理")]
    public partial class sysOrganizationView : SingleView
    {
        public sysOrganizationView()
        {
            InitializeComponent();
        }

        protected override Framework.ViewModel.IBaseViewViewModel OnCreateViewModel()
        {
            return new sysOrganizationViewViewModel();
        }

        protected new sysOrganizationViewViewModel ViewModel
        {
            get { return base.ViewModel as sysOrganizationViewViewModel; }
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            this.pnlPageControl.Visible = false;
            this.pnlPageControl.Enabled = false;

            this.treeOrg.KeyFieldName = "Iden";
            this.treeOrg.ParentFieldName = "ParentId";

            this.treeOrg.GetSelectImage += treeList1_GetSelectImage;
        }

        void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            if (e.Node.ParentNode == null)
            {
                e.NodeImageIndex = 0;
            }
            else if (!e.Node.HasChildren)
            {
                e.NodeImageIndex = 2;
            }
            else
            {
                e.NodeImageIndex = 1;
            }
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();
            UIController.RefreshControl(this.txtIden, false);
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            this.AccessFocusControl = this.txtName;

            UIController.SetupTreelist(this.treeOrg);
        }

        protected override void OnInitEvent()
        {
            base.OnInitEvent();

            this.treeOrg.FocusedNodeChanged += treeList1_FocusedNodeChanged;
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        protected override void OnIndexRowChange()
        {
            base.OnIndexRowChange();

            InitParent();
        }

        private void InitParent()
        {
            this.tluParent.Properties.DataSource = this.ViewModel.ParentEntitySet.DefaultView;
            this.tluParent.Properties.ValueMember = "Iden";
            this.tluParent.Properties.DisplayMember = "Name";
            this.tluParent.Properties.TreeList.KeyFieldName = "Iden";
            this.tluParent.Properties.TreeList.ParentFieldName = "ParentId";
            this.tluParent.Properties.TreeList.OptionsView.ShowColumns = false;
            this.tluParent.Properties.TreeList.OptionsView.ShowIndicator = false;
            this.tluParent.Properties.TreeList.OptionsView.ShowHorzLines = false;
            this.tluParent.Properties.TreeList.OptionsView.ShowVertLines = false;
        }

        private void tluParent_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                if (this.ViewModel != null && this.ViewModel.MainEntitySet != null && this.ViewModel.MainEntitySet.CurrentEntity != null)
                {
                    this.ViewModel.MainEntitySet.CurrentEntity.ParentId = -1;
                }
            }
        }

    }
}
