using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts.Actions
{
    public abstract class CaretAction : AbstractEditAction
    {
        protected int X { get; set; }
        protected int Y { get; set; }

        public override void m_Execute(DrawArea drawArea)
        {
            if (drawArea == null || drawArea.ReadOnly) return;

            if (drawArea.GraphicsCollection.Selection.Count() > 0)
            {
                int dx = X;
                int dy = Y;
                foreach (DrawObject o in drawArea.GraphicsCollection.Selection)
                {
                    o.Move(dx, dy);

                    if (o is Swimlane)
                    {
                        var swimLane = o as Swimlane;
                       // var rect = new Rectangle(swimLane.Left, swimLane.Top, swimLane.Width, swimLane.Height);
                        drawArea.GraphicsCollection.MoveSwimlane(swimLane, dx, dy, o.GUID);
                    }
                }

                if (drawArea.GraphicsCollection.Count > 0)
                {
                    int x = drawArea.GraphicsCollection.Selection.Min(g => g.Left);
                    if (x <= 0)
                    {
                        foreach (DrawObject item in drawArea.GraphicsCollection.Selection)
                        {
                            if (item.Left == x)
                            {
                                item.Left = 1;
                            }
                            else
                            {
                                item.Left += Math.Abs(dx);
                            }

                            if (item is DrawLine)
                                item.Width += Math.Abs(dx);
                        }
                    }

                    int y = drawArea.GraphicsCollection.Selection.Min(g => g.Top);
                    if (y <= 0)
                    {
                        foreach (DrawObject item in drawArea.GraphicsCollection.Selection)
                        {
                            if (item.Top == y)
                            {
                                item.Top = 1;
                            }
                            else
                            {
                                item.Top += Math.Abs(dy);
                            }

                            if (item is DrawLine)
                                item.Height += Math.Abs(dy);
                        }
                    }
                }

                //drawArea.SetAutoScrollMinSize();

                drawArea.Cursor = Cursors.SizeAll;
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }
    }

    public class CaretLeftAction : CaretAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            this.X = -1;
            this.Y = 0;
            base.m_Execute(drawArea);
        }
    }

    public class CaretRightAction : CaretAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            this.X = 1;
            this.Y = 0;
            base.m_Execute(drawArea);
        }
    }

    public class CaretUpAction : CaretAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            this.X = 0;
            this.Y = -1;
            base.m_Execute(drawArea);
        }
    }

    public class CaretDownAction : CaretAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            this.X = 0;
            this.Y = 1;
            base.m_Execute(drawArea);
        }
    }

}
