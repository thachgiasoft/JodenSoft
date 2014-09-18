using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.Docking2010.Views;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.ServiceModel;
using SAF.Foundation;
using DevExpress.LookAndFeel;
using SAF.Framework.View;

namespace SAF.Framework.Controls
{
    [ToolboxItem(false)]
    public partial class DocumentController : BaseUserControl
    {
        public DocumentController()
        {
            InitializeComponent();

            tabbedView.DocumentProperties.AllowFloat = false;
            tabbedView.DocumentProperties.AllowFloatOnDoubleClick = false;

            tabbedView.DocumentActivated += tabbedView_DocumentActivated;
            tabbedView.DocumentClosed += tabbedView_DocumentClosed;
            tabbedView.DocumentClosing += tabbedView_DocumentClosing;

            tabbedView.DocumentAdded += tabbedView_DocumentAdded;
        }

        void tabbedView_DocumentClosing(object sender, DocumentCancelEventArgs e)
        {
            var view = e.Document.Control as SAF.Framework.View.BaseView;

            if (view != null && view.IsDirty)
            {
                string message = "确定要关闭\"{0}\"吗?{1}关闭操作将丢弃所有未更改的保存.".FormatEx(view.Text, Environment.NewLine);
                var result = MessageService.AskQuestion(message);
                if (!result)
                    e.Cancel = true;
            }
        }

        void tabbedView_DocumentAdded(object sender, DocumentEventArgs e)
        {
            this.tabbedView.Controller.Move(e.Document as Document, 0);
        }

        void tabbedView_DocumentClosed(object sender, DocumentEventArgs e)
        {
            this.Focus();

            if (this.tabbedView.Documents.Count <= 0)
            {
                var shell = this.FindForm() as IShell;
                if (shell != null)
                {
                    shell.UnMergeRibbon();
                }
            }
        }

        void tabbedView_DocumentActivated(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            if (e.Document != null)
            {
                var view = e.Document.Control as BusinessView;
                if (view != null)
                {
                    view.MergeRibbon();
                }
            }
        }

        public void CloseDocument(Control view)
        {
            if (view != null)
            {
                BaseDocument doc;
                this.tabbedView.Documents.TryGetValue(view, out doc);
                if (doc != null)
                    this.tabbedView.Controller.Close(doc);
            }
        }

        public BaseDocument AddDocument(SAF.Framework.View.BaseView view, string caption, string guid)
        {
            view.Padding = new Padding(2);
            view.Text = caption;
            var doc = tabbedView.AddDocument(view) as Document;

            doc.Image = SAF.Framework.Properties.Resources.Icon_Form_16x16;
            doc.Tooltip = caption;
            doc.Caption = GetCaption(caption);

            doc.Tag = guid;
            tabbedView.ActivateDocument(view);
            view.Owner = this;

            if (view.ViewModel != null)
            {
                view.ViewModel.EditStatusChanged += (sender, args) =>
                {
                    doc.Caption = GetCaption(caption) + (view.IsDirty ? " *" : string.Empty);
                };
            }

            if (tabbedView.Documents.Count <= 1)
            {
                if (view is IBusinessView)
                    (view as IBusinessView).MergeRibbon();
            }

            return doc;
        }

        private string GetCaption(string caption)
        {
            return caption.Left(6) + (caption.Length > 6 ? "..." : string.Empty);
        }

        public void ActiveDocument(Control control)
        {
            if (control != null)
                tabbedView.ActivateDocument(control);
        }

        public BaseDocument FindDocument(string hashCode)
        {
            if (this.tabbedView.Documents == null || this.tabbedView.Documents.Count <= 0) return null;

            foreach (var item in this.tabbedView.Documents)
            {
                if (item.Tag != null)
                {
                    var id = item.Tag.ToString();
                    if (id != null && id.Equals(hashCode, StringComparison.InvariantCultureIgnoreCase))
                        return item;
                }
            }
            return null;
        }

        public string GetAllDirtyViewCpations()
        {
            var list = this.tabbedView.Documents.Where(p => p.Control is IBaseView && (p.Control as IBaseView).IsDirty).Select(p => p.Control as IBaseView);

            if (list.IsEmpty()) return string.Empty;

            string str = list.Select(p => p.Text).JoinText(Environment.NewLine);
            return str;
        }

    }
}
