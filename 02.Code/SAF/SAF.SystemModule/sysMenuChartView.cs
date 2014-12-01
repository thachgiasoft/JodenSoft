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
            this.menuChart.ActiveDrawArea.DoubleClick += ActiveDrawArea_DoubleClick;
        }

        void ActiveDrawArea_DoubleClick(object sender, DrawAreaDoubleClickEventArgs e)
        {
            if (e.Selection.Count != 1) return;

            var obj = e.Selection.First();

            MessageService.ShowMessage((obj as DrawMenu).iMenuId.ToString());
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
            this.menuChart.ActiveDrawArea.AddDrawObject(new DrawMenu(10, 10, 100, 50) { Name = "测试界面", iMenuId = 123 });
        }

    }
}
