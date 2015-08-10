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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using SAF.Framework.Controls;
using SAF.Foundation;
using SAF.Framework;
using SAF.Framework.Entities;
using DevExpress.XtraLayout.Utils;

namespace GTMS.PB
{
    [BusinessObject("pbMaterialTypeView[物料类别维护]")]
    public partial class pbMaterialTypeView : SingleView
    {
        public pbMaterialTypeView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new pbMaterialTypeViewViewModel();
        }

        public new pbMaterialTypeViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as pbMaterialTypeViewViewModel;
            }
        }
        protected override void OnAfterInit()
        {
            base.OnAfterInit();
            InitChooseTreeList();
        }
        private void InitChooseTreeList()
        {  
            this.treeList.Properties.SetDataSource(this.ViewModel.IndexEntitySet.DefaultView, "Iden", "MaterialTypeName", "MaterialTypeId");
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            this.treeMenu.FocusedNodeChanged += treeMenu_FocusedNodeChanged;
        }

        void treeMenu_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        private void treeList_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {

        }

        private void searchLookUpEdit_DragOver(object sender, DragEventArgs e)
        {

        }

        private void treeMenu_FocusedNodeChanged_1(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }
 

    }
}
