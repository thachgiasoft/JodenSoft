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
using SAF.Framework.Controls.Charts;
using SAF.Foundation.ServiceModel;
using DevExpress.XtraTreeList.Nodes;

namespace SAF.SystemModule
{
    [BusinessObject("sysMenuDiagramView")]
    public partial class sysMenuChartView : SingleView
    {
        public sysMenuChartView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysMenuChartViewViewModel();
        }

        public new sysMenuChartViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysMenuChartViewViewModel;
            }
        }



        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            this.AccessFocusControl = this.txtName;

            this.menuChart.ContextMenuBeforePop += menuChart_ContextMenuBeforePop;

            this.grvIndex.FocusedRowChanged += grvIndex_FocusedRowChanged;
        }

        void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        void menuChart_ContextMenuBeforePop(object sender, EventArgs e)
        {
            this.bbiAddMenu.Enabled = !this.menuChart.ActiveDrawArea.ReadOnly;
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);
        }

        private void bbiAddMenu_Click(object sender, EventArgs e)
        {
            var menuSelector = new sysMenuSelector();
            menuSelector.Init();
            var form = menuSelector.CreateRibbonContainer(ApplicationService.Current.MainForm);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var list = menuSelector.Selection;

                var random = new Random(DateTime.Now.Second);
                foreach (TreeListNode item in list)
                {
                    if (!item.GetValue("BusinessViewId").m_IsEmpty())
                    {
                        int iMenuId = Convert.ToInt32(item.GetValue("Iden"));
                        string MenuName = item.GetValue("Name").ToString();

                        var left = random.Next(10, 200);
                        var top = random.Next(10, 100);
                        if (!this.menuChart.ActiveDrawArea.GraphicsCollection.Any(p => (p is DrawMenu) && (p as DrawMenu).iMenuId == iMenuId))
                        {
                            this.menuChart.ActiveDrawArea.AddDrawObject(new DrawMenu(left, top, 100, 50) { Name = MenuName, iMenuId = iMenuId });
                        }
                    }
                }
            }
        }

    }
}
