using SAF.Framework.Diaglogs;
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string obj = string.Empty;
            InputBox.Show(ref obj, p => { if (string.IsNullOrWhiteSpace(p)) { MessageBox.Show("输入空值了。"); return false; } else return true; });

            MessageBox.Show(obj);
        }
    }
}
