﻿

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SAF.Framework.Controls.TextEditor.Undo
{
	/// <summary>
	/// This class stacks the last x operations from the undostack and makes
	/// one undo/redo operation from it.
	/// </summary>
	internal sealed class UndoQueue : IUndoableOperation
	{
		List<IUndoableOperation> undolist = new List<IUndoableOperation>();
		
		/// <summary>
		/// </summary>
		public UndoQueue(Stack<IUndoableOperation> stack, int numops)
		{
			if (stack == null)  {
				throw new ArgumentNullException("stack");
			}
			
			Debug.Assert(numops > 0 , "SAF.Framework.Controls.TextEditor.Undo.UndoQueue : numops should be > 0");
			if (numops > stack.Count) {
				numops = stack.Count;
			}
			
			for (int i = 0; i < numops; ++i) {
				undolist.Add(stack.Pop());
			}
		}
		public void Undo()
		{
			for (int i = 0; i < undolist.Count; ++i) {
				undolist[i].Undo();
			}
		}
		
		public void Redo()
		{
			for (int i = undolist.Count - 1 ; i >= 0 ; --i) {
				undolist[i].Redo();
			}
		}
	}
}
