using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportService.InitializeReport(null, this.barButtonItem1, "1,2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var item = new TableReleation("a.Iden=b.iden");

            item.Validate();

        }
    }
}
