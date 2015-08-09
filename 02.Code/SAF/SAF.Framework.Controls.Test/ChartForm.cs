using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Test
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var area= this.chartControl1.OpenFile();
            area.MouseDoubleClick += area_MouseDoubleClick;
        }

        void area_MouseDoubleClick(object sender, Chart.MouseDoubleClickEventArgs e)
        {
            MessageBox.Show(e.DrawObjects.Count().ToString());
        }
    }
}
