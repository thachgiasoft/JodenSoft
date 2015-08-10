using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using SAF.Framework.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework
{
    public static class BaseViewExtensions
    {
        public static RibbonForm CreateRibbonContainer(this BaseView ctl, Form owner = null)
        {
            RibbonForm container = new RibbonForm();

            var ribbon = new RibbonControl();
            ribbon.RibbonStyle = RibbonControlStyle.Office2013;
            container.Controls.Add(ribbon);
            container.Ribbon = ribbon;
            container.Ribbon.MdiMergeStyle = RibbonMdiMergeStyle.Always;

            container.Width = (int)(SystemInformation.WorkingArea.Width * 0.9);
            container.Height = (int)(SystemInformation.WorkingArea.Height * 0.9);

            if (container.Owner == null)
                container.StartPosition = FormStartPosition.CenterScreen;
            else
            {
                container.Owner = owner;
                container.StartPosition = FormStartPosition.CenterParent;
            }

            if (ctl != null)
            {
                container.Text = ctl.Text;
                container.Controls.Add(ctl);
                ctl.Dock = DockStyle.Fill;

                if (ctl.Ribbon != null)
                    container.Ribbon.MergeRibbon(ctl.Ribbon);

                ctl.TextChanged += (sender, args) =>
                {
                    container.Text = ctl.Text;
                };

                if (ctl.ViewModel != null)
                {
                    ctl.ViewModel.EditStatusChanged += (sender, args) =>
                        {
                            container.Text = ctl.Text + (ctl.IsDirty ? " *" : string.Empty);
                        };
                }

                container.Shown += (sender, args) =>
                {
                    ctl.OnShown();
                };

                container.FormClosing += (sender, args) =>
                {
                    args.Cancel = false;
                    ctl.OnClosing(args);
                };

                container.FormClosed += (sender, args) =>
                {
                    ctl.OnClosed(args);
                };
            }

            return container;
        }
    }
}
