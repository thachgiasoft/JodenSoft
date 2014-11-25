﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.Utils;
using DevExpress.Utils.Controls;

namespace SAF.Framework.Controls.Charts
{
    public partial class XtraPropertyGrid : UserControl
    {
        public XtraPropertyGrid()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            biDescription.Down = true;
            bciCategories.Checked = true;
            //ImageCollection images = ImageHelper.CreateImageCollectionFromResources("SAF.Framework.Controls.Properties.Resources.Properties.png", typeof(XtraPropertyGrid).Assembly, new Size(16, 16));
            //barManager1.Images = images;

            this.propertyGridControl1.OptionsBehavior.ResizeRowValues = false;
            this.propertyGridControl1.OptionsBehavior.ResizeRowHeaders = false;
        }

        void SetPanelHeight()
        {
            pncDescription.Height = lbCaption.Height + pnlHint.Height + 4;
        }

        private void XtraPropertyGrid_Resize(object sender, System.EventArgs e)
        {
            SetPanelHeight();
        }

        private void bci_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            propertyGridControl1.OptionsView.ShowRootCategories = bciCategories.Checked;
        }

        private void biDescription_DownChanged(object sender, ItemClickEventArgs e)
        {
            pncDescription.Visible = pnlBottom.Visible = biDescription.Down;
        }

        public PropertyGridControl PropertyGrid
        {
            get { return propertyGridControl1; }
        }

        private void propertyGridControl1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            PropertyDescriptor descriptor = null;
            if (e.Row != null) descriptor = propertyGridControl1.GetPropertyDescriptor(e.Row);
            if (descriptor != null)
            {
                lbCaption.Text = descriptor.Name;
                pnlHint.Text = descriptor.Description;
            }
            else if (e.Row != null)
            {
                lbCaption.Text = e.Row.Properties.Caption;
                pnlHint.Text = string.Empty;
            }
            else
            {
                lbCaption.Text = pnlHint.Text = string.Empty;
            }
            SetPanelHeight();
        }

        [DefaultValue(true)]
        public bool ShowDescription
        {
            get { return biDescription.Down; }
            set
            {
                biDescription.Down = value;
            }
        }
        [DefaultValue(true)]
        public bool ShowCategories
        {
            get { return bciCategories.Checked; }
            set
            {
                if (value)
                    bciCategories.Checked = true;
                else bciAlphabetical.Checked = true;
            }
        }
        [DefaultValue(true)]
        public bool ShowButtons
        {
            get { return bMain.Visible; }
            set
            {
                bMain.Visible = pnlTop.Visible = value;
            }
        }

        public event EventHandler PropertyValueChanged;
        public event EventHandler PropertyValueChanging;

        private void propertyGridControl1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (PropertyValueChanged != null)
            {
                PropertyValueChanged(this, EventArgs.Empty);
            }
        }

        private void propertyGridControl1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (PropertyValueChanging != null)
            {
                PropertyValueChanging(this, EventArgs.Empty);
            }
        }

    }
}
