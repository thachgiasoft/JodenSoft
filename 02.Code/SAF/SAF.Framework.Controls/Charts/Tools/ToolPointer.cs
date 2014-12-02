using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Pointer tool
    /// </summary>
    internal class ToolPointer : Tool
    {
        private enum SelectionMode
        {
            None,
            NetSelection,   // group selection is active
            Move,           // object(s) are moves
            Size            // object is resized
        }

        private SelectionMode selectMode = SelectionMode.None;

        // Object which is currently resized:
        private DrawObject resizedObject;
        private int resizedObjectHandle;

        // Keep state about last and current point (used to move and resize objects)
        private Point lastPoint = new Point(0, 0);
        private Point startPoint = new Point(0, 0);

        private CommandChangeState commandChangeState;
        bool wasMove;

        public ToolPointer()
        {
        }

        /// <summary>
        /// Left mouse button is pressed
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            commandChangeState = null;
            wasMove = false;

            selectMode = SelectionMode.None;
            Point point = new Point(e.X, e.Y);

            point = ToolObject.TranslatePoint(drawArea, point);
            point = ToolObject.UnzoomPoint(point, drawArea.Zoom);

            // Test for resizing (only if control is selected, cursor is on the handle)
            foreach (DrawObject o in drawArea.GraphicsCollection.Selection)
            {
                int handleNumber = o.HitTest(point);

                if (handleNumber > 0)
                {
                    selectMode = SelectionMode.Size;

                    // keep resized object in class member
                    resizedObject = o;
                    resizedObjectHandle = handleNumber;

                    // Since we want to resize only one object, unselect all other objects
                    drawArea.GraphicsCollection.UnselectAll();
                    o.Selected = true;

                    commandChangeState = new CommandChangeState(drawArea.GraphicsCollection);

                    break;
                }
            }

            // Test for move (cursor is on the object)
            if (selectMode == SelectionMode.None)
            {
                int n1 = drawArea.GraphicsCollection.Count;
                DrawObject o = null;

                for (int i = 0; i < n1; i++)
                {
                    if (drawArea.GraphicsCollection[i].HitTest(point) == 0)
                    {
                        o = drawArea.GraphicsCollection[i];
                        break;
                    }
                }

                if (o != null)
                {
                    selectMode = SelectionMode.Move;

                    // Unselect all if Ctrl is not pressed and clicked object is not selected yet
                    if ((Control.ModifierKeys & Keys.Control) == 0 && !o.Selected)
                        drawArea.GraphicsCollection.UnselectAll();

                    // Select clicked object
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        o.Selected = !o.Selected;
                    else
                        o.Selected = true;

                    commandChangeState = new CommandChangeState(drawArea.GraphicsCollection);

                    drawArea.Cursor = Cursors.SizeAll;

                }
            }

            if (e.Clicks >= 2)
            {
                if (drawArea.GraphicsCollection.SelectionCount > 0)
                {
                    //双击时执行双击事件
                    var hasHandle = drawArea.FireDoubleClick(drawArea.GraphicsCollection.Selection);

                    if (!hasHandle && drawArea.GraphicsCollection.ShowPropertiesDialog(drawArea))
                    {
                        drawArea.Refresh();
                    }
                    return;
                }
            }

            // Net selection
            if (selectMode == SelectionMode.None)
            {
                // click on background
                if ((Control.ModifierKeys & Keys.Control) == 0)
                    drawArea.GraphicsCollection.UnselectAll();

                selectMode = SelectionMode.NetSelection;

            }

            Point p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);

            lastPoint.X = p.X;
            lastPoint.Y = p.Y;
            startPoint.X = p.X;
            startPoint.Y = p.Y;

            drawArea.Capture = true;

            drawArea.Refresh();

            if (selectMode == SelectionMode.NetSelection)
            {
                // Draw selection rectangle in initial position
                ControlPaint.DrawReversibleFrame(
                    drawArea.RectangleToScreen(DrawRectangle.GetNormalizedRectangle(startPoint, lastPoint)),
                    Color.Black,
                    FrameStyle.Dashed);
            }
        }

        private DrawObject currentHitObj = null;

        private DrawObject oldHitObj = null;

        /// <summary>
        /// Mouse is moved.
        /// None button is pressed, or left button is pressed.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            //if (drawArea.IsLine) return;

            Point point = new Point(e.X, e.Y);
            point = ToolObject.TranslatePoint(drawArea, point);
            point = ToolObject.UnzoomPoint(point, drawArea.Zoom);

            Point oldPoint = lastPoint;

            wasMove = true;

            // set cursor when mouse button is not pressed
            if (e.Button == MouseButtons.None)
            {
                Cursor cursor = null;

                currentHitObj = null;

                for (int i = 0; i < drawArea.GraphicsCollection.Count; i++)
                {
                    int n = drawArea.GraphicsCollection[i].HitTest(point);

                    if (n >= 0)
                    {
                        currentHitObj = drawArea.GraphicsCollection[i];
                        if (n > 0)
                        {
                            cursor = drawArea.GraphicsCollection[i].GetHandleCursor(n);
                            break;
                        }
                    }

                }
                if (currentHitObj != null)
                {
                    if (oldHitObj == null)
                    {
                        oldHitObj = currentHitObj;
                        //drawArea.ToolTipTextTitle = currentHitObj.Name;
                        //drawArea.ToolTipText = "Text:{1}{0}Status:{2}".FormatEx2(Environment.NewLine, currentHitObj.Text, currentHitObj.Status);
                    }
                    else
                    {
                        if (currentHitObj.GUID != oldHitObj.GUID)
                        {
                            oldHitObj = currentHitObj;
                            //drawArea.ToolTipTextTitle = currentHitObj.Name;
                            //drawArea.ToolTipText = "Text:{1}{0}Status:{2}".FormatEx2(Environment.NewLine, currentHitObj.Text, currentHitObj.Status);
                        }
                    }
                }
                else
                {
                    oldHitObj = null;
                    //drawArea.ToolTipText = null;
                }

                if (cursor == null)
                    cursor = Cursors.Default;

                drawArea.Cursor = cursor;

                return;
            }

            if (e.Button != MouseButtons.Left)
                return;

            // Find difference between previous and current position
            Point p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);

            int dx = p.X - lastPoint.X;
            int dy = p.Y - lastPoint.Y;

            lastPoint.X = p.X;
            lastPoint.Y = p.Y;

            // resize
            if (selectMode == SelectionMode.Size && !drawArea.ReadOnly)
            {
                if (resizedObject != null)
                {
                    resizedObject.MoveHandleTo(point, resizedObjectHandle);
                    drawArea.SetDirty();
                    drawArea.Refresh();
                }
            }

            // move
            if (selectMode == SelectionMode.Move && !drawArea.ReadOnly)
            {
                foreach (DrawObject o in drawArea.GraphicsCollection.Selection)
                {
                    int x = drawArea.GraphicsCollection.Selection.Min(g => g.Left);
                    int y = drawArea.GraphicsCollection.Selection.Min(g => g.Top);

                    if (x + dx < 0)
                        dx = Math.Min(Math.Abs(x), Math.Abs(dx));

                    if (y + dy < 0)
                        dy = Math.Min(Math.Abs(y), Math.Abs(dy));

                    o.Move(dx, dy);
                    if (o is Swimlane)
                    {
                        var swimLane = o as Swimlane;
                        //var rect = new Rectangle(swimLane.Left, swimLane.Top, swimLane.Width, swimLane.Height);
                        drawArea.GraphicsCollection.MoveSwimlane(swimLane, dx, dy, o.GUID);
                    }

                    var line = (o as DrawLine);
                    if (line != null && drawArea.GraphicsCollection.SelectionCount == 1)
                    {
                        var obj = drawArea.GraphicsCollection.FirstOrDefault(k => k.GUID == line.StartDrawObjectID);
                        line.StartOffsetSize = new Size(Math.Abs(line.StartPoint.X - obj.Left), Math.Abs(line.StartPoint.Y - obj.Top));

                        obj = drawArea.GraphicsCollection.FirstOrDefault(k => k.GUID == line.EndDrawObjectID);
                        line.EndOffsetSize = new Size(Math.Abs(line.EndPoint.X - obj.Left), Math.Abs(line.EndPoint.Y - obj.Top));
                    }
                }

                drawArea.Cursor = Cursors.SizeAll;
                drawArea.SetDirty();
                drawArea.Refresh();
            }

            if (selectMode == SelectionMode.NetSelection)
            {
                var start = ToolObject.ZoomPoint(startPoint, drawArea.Zoom);
                start = CalcDrawReversibleFramePoint(start, drawArea);
                var old = ToolObject.ZoomPoint(oldPoint, drawArea.Zoom);
                old = CalcDrawReversibleFramePoint(old, drawArea);

                // Remove old selection rectangle
                var rect = drawArea.RectangleToScreen(DrawRectangle.GetNormalizedRectangle(start, old));

                rect.X -= Math.Abs(drawArea.AutoScrollPosition.X);
                rect.Y -= Math.Abs(drawArea.AutoScrollPosition.Y);

                ControlPaint.DrawReversibleFrame(
                    rect,
                    Color.Black,
                    FrameStyle.Dashed);

                var pCurrent = ToolObject.ZoomPoint(point, drawArea.Zoom);
                pCurrent = CalcDrawReversibleFramePoint(pCurrent, drawArea);
                // Draw new selection rectangle
                rect = drawArea.RectangleToScreen(DrawRectangle.GetNormalizedRectangle(start, pCurrent));

                rect.X -= Math.Abs(drawArea.AutoScrollPosition.X);
                rect.Y -= Math.Abs(drawArea.AutoScrollPosition.Y);
                ControlPaint.DrawReversibleFrame(
                    rect,
                    Color.Black,
                    FrameStyle.Dashed);

                return;
            }
        }

        private Point CalcDrawReversibleFramePoint(Point p, DrawArea drawArea)
        {
            var pt = new Point(p.X, p.Y);
            if (pt.X < drawArea.Left)
                pt.X = drawArea.Left;

            if (pt.Y < drawArea.Top)
                pt.Y = drawArea.Top;

            if (pt.X > drawArea.Left + drawArea.Width)
                pt.X = drawArea.Left + drawArea.Width;

            if (pt.Y > drawArea.Top + drawArea.Height)
                pt.Y = drawArea.Top + drawArea.Height;

            return pt;
        }

        /// <summary>
        /// Right mouse button is released
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            //if (drawArea.IsLine) return;

            if (selectMode == SelectionMode.NetSelection)
            {
                var start = ToolObject.ZoomPoint(startPoint, drawArea.Zoom);
                start = CalcDrawReversibleFramePoint(start, drawArea);

                var last = ToolObject.ZoomPoint(lastPoint, drawArea.Zoom);
                last = CalcDrawReversibleFramePoint(last, drawArea);

                var rect = drawArea.RectangleToScreen(DrawRectangle.GetNormalizedRectangle(start, last));

                rect.X -= Math.Abs(drawArea.AutoScrollPosition.X);
                rect.Y -= Math.Abs(drawArea.AutoScrollPosition.Y);

                // Remove old selection rectangle
                ControlPaint.DrawReversibleFrame(
                    rect,
                    Color.Black,
                    FrameStyle.Dashed);

                // Make group selection
                drawArea.GraphicsCollection.SelectInRectangle(
                    DrawRectangle.GetNormalizedRectangle(startPoint, lastPoint));

                selectMode = SelectionMode.None;

            }
            else if (selectMode == SelectionMode.Move || selectMode == SelectionMode.Size)
            {
                drawArea.GraphicsCollection.CalcOwnerId();
                selectMode = SelectionMode.None;
            }

            if (resizedObject != null)
            {
                // after resizing
                resizedObject.Normalize();
                resizedObject = null;
            }

            drawArea.Capture = false;

            drawArea.Refresh();

            if (commandChangeState != null && wasMove && !drawArea.ReadOnly)
            {
                // Keep state after moving/resizing and add command to history
                commandChangeState.NewState(drawArea.GraphicsCollection);
                drawArea.AddCommandToHistory(commandChangeState);
                commandChangeState = null;
            }


        }
    }

}
