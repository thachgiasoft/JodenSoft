using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    public interface IGraphicsList
    {
        bool Clear();
        int Count { get; }
        DrawObject this[int index] { get; }
        int SelectionCount { get; }
        IEnumerable<DrawObject> Selection { get; }
        void Add(DrawObject obj);
        void Insert(int index, DrawObject obj);
        void Replace(int index, DrawObject obj);
        void RemoveAt(int index);
        void DeleteLastAddedObject();
        void SelectInRectangle(Rectangle rectangle);
        void UnselectAll();
        void SelectAll();
        bool DeleteSelection();
        bool MoveSelectionToFront();
        bool MoveSelectionToBack();

    }
}
