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
using SAF.Framework.Controls.Charts;
using SAF.Foundation.ServiceModel;
using SAF.Framework;

namespace SAF.SystemModule
{
    [BusinessObject("sysNavigationView")]
    public partial class sysNavigationView : SingleView
    {
        public sysNavigationView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysNavigationViewViewModel();
        }

        public new sysNavigationViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysNavigationViewViewModel;
            }
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            this.pnlPageControl.Enabled = false;
            this.pnlPageControl.Visible = false;

            this.pnlQueryControl.Enabled = false;
            this.pnlQueryControl.Visible = false;
        }

        protected override void OnAfterInit()
        {
            base.OnAfterInit();

            foreach (var item in this.ViewModel.IndexEntitySet)
            {
                var page = tabControl.TabPages.Add(item.Name);
                var ctl = new MenuChartControl() { Dock = DockStyle.Fill, Data = item.FileData };
                ctl.HideMenu();
                ctl.ActiveDrawArea.DoubleClick += ActiveDrawArea_DoubleClick;
                page.Controls.Add(ctl);
            }
        }

        void ActiveDrawArea_DoubleClick(object sender, DrawAreaDoubleClickEventArgs e)
        {
            if (e.Selection.Count() == 1)
            {
                var obj = e.Selection.First() as DrawMenu;

                var shell = ApplicationService.Current.MainForm as IShell;
                if (shell != null && obj != null)
                    shell.ShowBusinessView(obj.iMenuId);

                e.HasHandle = true;
            }
        }



    }
}
