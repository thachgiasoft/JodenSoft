using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Charts.Actions
{
    public class SelectWholeDocumentAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            drawArea.GraphicsCollection.SelectAll();
            drawArea.Refresh();
            drawArea.FireSelectionChanged();
        }
    }

    public class ClearAllSelectionsAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            drawArea.GraphicsCollection.UnselectAll();
            drawArea.Refresh();
            drawArea.FireSelectionChanged();
        }
    }
}
