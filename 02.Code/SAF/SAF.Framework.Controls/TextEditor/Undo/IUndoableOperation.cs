﻿
namespace SAF.Framework.Controls.TextEditor.Undo
{
	/// <summary>
	/// This Interface describes a the basic Undo/Redo operation
	/// all Undo Operations must implement this interface.
	/// </summary>
	public interface IUndoableOperation
	{
		/// <summary>
		/// Undo the last operation
		/// </summary>
		void Undo();
		
		/// <summary>
		/// Redo the last operation
		/// </summary>
		void Redo();
	}
}
