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
        protected override void OnIndexRowChange()
        {
            base.OnIndexRowChange();
            InitChooseTreeList();
        }
        private void InitChooseTreeList()
        {   
            this.treeList.Properties.DataSource = this.ViewModel.MainEntitySet.DefaultView;
            this.treeList.Properties.ValueMember = "Iden";
            this.treeList.Properties.DisplayMember = "MaterialTypeName";
            this.treeList.Properties.TreeList.KeyFieldName = "Iden";
            this.treeList.Properties.TreeList.ParentFieldName = "MaterialTypeId";
            this.treeList.Properties.TreeList.OptionsView.ShowColumns = false;
            this.treeList.Properties.TreeList.OptionsView.ShowIndicator = false;
            this.treeList.Properties.TreeList.OptionsView.ShowHorzLines = false;
            this.treeList.Properties.TreeList.OptionsView.ShowVertLines = false;
        }
 

        private void treeList_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {

        }

        private void searchLookUpEdit_DragOver(object sender, DragEventArgs e)
        {

        }
 

    }
}
