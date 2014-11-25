using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    public class ChartControlSelectionChangedEventArg : EventArgs
    {
        public IEnumerable<DrawObject> Selection { get; private set; }

        public ChartControlSelectionChangedEventArg(IEnumerable<DrawObject> selection)
        {
            this.Selection = selection;
        }
    }

    public class DiagramTypeChangedEventArg : EventArgs
    {
        public DiagramType DiagramType { get; private set; }
        public DrawArea DrawArea { get; private set; }

        public DiagramTypeChangedEventArg(DiagramType diagramType, DrawArea drawArea)
        {
            this.DiagramType = diagramType;
            this.DrawArea = drawArea;
        }
    }

    public class DirtyChangedEventArg : EventArgs
    {
        public bool Dirty { get; private set; }
        public DrawArea DrawArea { get; private set; }

        public DirtyChangedEventArg(DrawArea drawArea, bool dirty)
        {
            this.Dirty = dirty;
            this.DrawArea = drawArea;
        }
    }

    public class SaveEventArgs : EventArgs
    {
        public List<DrawArea> DrawAreaList { get; private set; }
        public SaveEventArgs()
        {
            DrawAreaList = new List<DrawArea>();
        }
    }

    public class ReloadEventArgs : EventArgs
    {
        public int Id { get; private set; }
        public string Xml { get; set; }
        public byte[] Data { get; set; }
        public object Tag { get; set; }

        public ReloadEventArgs(int id, object tag)
        {
            this.Id = id;
            this.Xml = string.Empty;
            this.Data = null;
            this.Tag = tag;
        }
    }

    public class BeforeEditEventArgs : EventArgs
    {
        public bool AllowEdit { get; set; }
        public DrawArea DrawArea { get; private set; }

        public BeforeEditEventArgs(DrawArea area)
        {
            this.DrawArea = area;
        }
    }
}
