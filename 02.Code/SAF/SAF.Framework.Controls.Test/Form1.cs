using DevExpress.XtraEditors;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;

namespace SAF.Framework.Controls.Test
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();

            ReportService.InitializeReport(this.bbiReport, 0);
        }

    }
}
