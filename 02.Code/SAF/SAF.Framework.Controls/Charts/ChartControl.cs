using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SAF.Framework.Controls.Charts
{
    [ToolboxItem(true)]
    public partial class ChartControl : XtraUserControl
    {
        public ChartControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Application.Idle += (sender, args) =>
            {
                RefreshToolBar();
            };

            this.tabbedView.DocumentProperties.AllowFloat = false;
            this.tabbedView.DocumentProperties.AllowFloatOnDoubleClick = false;
            this.tabbedView.DocumentProperties.AllowPin = true;
            this.tabbedView.DocumentProperties.ShowPinButton = true;

            this.barDrawTools.OptionsBar.AllowQuickCustomization = false;
            this.barActions.OptionsBar.AllowQuickCustomization = false;

            this.bbiPointer.PerformClick();


        }

        public DrawArea ActiveDrawArea
        {
            get
            {
                if (this.tabbedView.ActiveDocument != null)
                {
                    return this.tabbedView.ActiveDocument.Control as DrawArea;
                }
                return null;
            }
        }

        public void RefreshToolBar()
        {
            bool isNotNull = this.ActiveDrawArea != null;

            this.bbiRectangle.Enabled = isNotNull;
            this.bbiRectangle.Down = isNotNull && this.ActiveDrawArea.ActiveDrawTool == DrawToolType.Rectangle;

            this.bbiEllipse.Enabled = isNotNull;
            this.bbiEllipse.Down = isNotNull && this.ActiveDrawArea.ActiveDrawTool == DrawToolType.Ellipse;

            this.bbiRhombus.Enabled = isNotNull;
            this.bbiRhombus.Down = isNotNull && this.ActiveDrawArea.ActiveDrawTool == DrawToolType.Rhombus;

            this.bbiLine.Enabled = isNotNull;
            this.bbiLine.Down = isNotNull && this.ActiveDrawArea.ActiveDrawTool == DrawToolType.Line;

            this.bbiPointer.Enabled = isNotNull;
            this.bbiPointer.Down = isNotNull && this.ActiveDrawArea.ActiveDrawTool == DrawToolType.Pointer;


            this.bbiUndo.Enabled = isNotNull && this.ActiveDrawArea.CanUndo;
            this.bbiRedo.Enabled = isNotNull && this.ActiveDrawArea.CanRedo;

        }

        public DrawArea OpenFile()
        {
            var drawArea = new DrawArea(this);
            var doc = tabbedView.AddDocument(drawArea);
            doc.Caption = "测试";
            this.tabbedView.ActivateDocument(drawArea);
            return drawArea;
        }

        private void bbiPointer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandPointer();
        }

        private void bbiRectangle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandRectangle();
        }

        private void bbiEllipse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandEllipse();
        }

        private void bbiLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandLine();
        }

        private void bbiUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandUndo();
        }

        private void bbiRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandRedo();
        }


        private void CommandPointer()
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.ActiveDrawTool = DrawToolType.Pointer;
        }

        private void CommandRectangle()
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.ActiveDrawTool = DrawToolType.Rectangle;
        }

        private void CommandEllipse()
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.ActiveDrawTool = DrawToolType.Ellipse;
        }

        private void CommandLine()
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.ActiveDrawTool = DrawToolType.Line;
        }

        private void CommandUndo()
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.Undo();
        }

        private void CommandRedo()
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.Redo();
        }

    }
}
