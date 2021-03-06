﻿using System;
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
using SAF.Framework.Controls;

namespace SAF.Framework.Component
{
    public partial class WelcomePage : BusinessView
    {
        public WelcomePage()
        {
            InitializeComponent();

            widgetView1.AllowDocumentStateChangeAnimation = DevExpress.Utils.DefaultBoolean.True;
            widgetView1.AllowResizeAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.widgetView1.QueryControl += widgetView1_QueryControl;
        }

        void widgetView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Document.ControlTypeName))
            {
                var control = Activator.CreateInstance(Type.GetType(e.Document.ControlTypeName)) as BaseUserControl;
                control.Init();
                control.RefreshUI();
                e.Control = control;
            }
            else
                e.Control = new Control();
        }

    }
}
