using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts.Actions
{
    public class DeleteAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            if (drawArea == null || drawArea.ReadOnly) return;

            drawArea.DeleteSelection();
        }
    }

    public class CutAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            if (drawArea == null) return;
            if (drawArea.ReadOnly)
            {
                MessageBox.Show("非编辑模式下不能进行'剪切'操作.", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            drawArea.CutSelection();
        }
    }

    public class CopyAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            if (drawArea == null) return;

            drawArea.CopySelection();
        }
    }

    public class PasteAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            if (drawArea == null) return;
            if (drawArea.ReadOnly)
            {
                MessageBox.Show("非编辑模式下不能进行'粘贴'操作.", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            drawArea.PasteSelection();
        }
    }

    public class UndoAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            if (drawArea == null || drawArea.ReadOnly) return;

            drawArea.Undo();
        }
    }

    public class RedoAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            if (drawArea == null || drawArea.ReadOnly) return;

            drawArea.Redo();
        }
    }

    public class SearchAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            if (drawArea == null) return;
            drawArea.Search();
        }
    }

    public class BestFitAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            if (drawArea == null || drawArea.ReadOnly) return;

            drawArea.BestFitDrawObject();
        }
    }

    public class AutoDrawLineAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            if (drawArea == null || drawArea.ReadOnly) return;

            drawArea.AutoDrawLine();
        }
    }
}
