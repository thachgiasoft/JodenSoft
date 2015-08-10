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
using SAF.EntityFramework;
using JNHT_ProdSys.Method;
using SAF.Framework.Controls;

namespace JNHT_ProdSys
{
    [BusinessObject("生产令单管理")]
    public partial class woBomParentView : SingleView
    {
        public woBomParentView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new woBomParentViewViewModel();
        }

        public new woBomParentViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as woBomParentViewViewModel;
            }
        }
        public override int BillTypeId
        {
            get
            {
                return base.BillTypeId;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.pnlQueryControl.Visible = false;
            this.pnlPageControl.Visible = false;
        }
        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            this.ViewModel.woOrderEntity.SetBindingSource(bswo);
            this.ViewModel.MainEntitySet.SetBindingSource(bsMain);
        }

        private void grvwo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //ProgressService.Show("正在生成工单结构树...");
            //Common.InitBomTree(this.ViewModel.woOrderEntity.CurrentEntity,treeBom);
            //ProgressService.Close();
            this.ViewModel.queryMain();

        }

        //private void treeBom_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    string bomparentid = treeBom.SelectedNode.Tag.ToString();
        //    var woid = this.ViewModel.woOrderEntity.CurrentEntity.Iden;

        //}

    }
}
