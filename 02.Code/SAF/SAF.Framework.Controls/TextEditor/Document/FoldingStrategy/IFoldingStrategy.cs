﻿
using System;
using System.Collections.Generic;

namespace SAF.Framework.Controls.TextEditor.Document
{
	/// <summary>
	/// This interface is used for the folding capabilities
	/// of the textarea.
	/// </summary>
	public interface IFoldingStrategy
	{
		/// <remarks>
		/// Calculates the fold level of a specific line.
		/// </remarks>
		List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation);
	}
}
