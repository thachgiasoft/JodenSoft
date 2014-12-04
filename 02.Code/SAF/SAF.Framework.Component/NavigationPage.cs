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
using SAF.EntityFramework;

namespace SAF.SystemModule
{
    public partial class NavigationPage : BusinessView
    {
        public NavigationPage()
        {
            InitializeComponent();
        }

        private EntitySet<QueryEntity> queryEntitySet = null;
        public virtual EntitySet<QueryEntity> QueryEntitySet
        {
            get
            {
                if (queryEntitySet == null)
                {
                    queryEntitySet = new EntitySet<QueryEntity>();
                    queryEntitySet.IsReadOnly = true;
                }
                return queryEntitySet;
            }
        }

        protected override void OnAfterInit()
        {
            base.OnAfterInit();

            this.QueryEntitySet.Query("select * from sysMenuChart with(nolock)");

            foreach (var item in QueryEntitySet)
            {
                var page = tabControl.TabPages.Add(item.GetFieldValue<string>("Name"));
                var ctl = new MenuChartControl() { Dock = DockStyle.Fill, Data = item.GetFieldValue<byte[]>("FileData") };
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
