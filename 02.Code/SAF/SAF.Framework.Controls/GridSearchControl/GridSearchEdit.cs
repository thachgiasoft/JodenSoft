using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;

namespace SAF.Framework.Controls
{
    [ToolboxItem(true)]
    public class GridSearchEdit : PopupContainerEdit
    {
        public GridSearchEdit()
        {
            this.KeyDown += GridSearchEdit_KeyDown;
        }

        void GridSearchEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                this.ShowPopup();
            }
        }

        static GridSearchEdit()
        {
            RepositoryItemGridSearchEdit.RegisterGridSearchEdit();
        }

        public override string EditorTypeName
        {
            get
            {
                return RepositoryItemGridSearchEdit.GridSearchEditName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemGridSearchEdit Properties
        {
            get { return base.Properties as RepositoryItemGridSearchEdit; }
        }

        protected override Size CalcPopupFormSize()
        {
            return new Size(Properties.PopupWidth, Properties.PopupHeight);
        }

        protected override bool IsAcceptCloseMode(PopupCloseMode closeMode)
        {
            return closeMode == PopupCloseMode.Normal;
        }
    }
}
