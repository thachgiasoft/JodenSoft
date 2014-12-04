using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.Controls;
using DevExpress.XtraEditors;

namespace SAF.Framework.Component.WelcomePageControl
{
    public partial class ToDoList : BaseUserControl
    {
        static Font RegularFont = new System.Drawing.Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        static Font StrikeoutFont = new System.Drawing.Font("Segoe UI", 8.25F, FontStyle.Strikeout, GraphicsUnit.Point, 0);
        public ToDoList()
        {
            InitializeComponent();
        }
        void OnCheckedChanged(object sender, EventArgs e)
        {
            CheckEdit checkEdit = (sender as CheckEdit);
            if (checkEdit.Checked)
                checkEdit.Font = StrikeoutFont;
            else
                checkEdit.Font = RegularFont;
        }
    }
}
