﻿
using System;
using System.Runtime.Serialization;

namespace SAF.Framework.Controls.TextEditor.Document
{
	/// <summary>
	/// Indicates that the highlighting definition that was tried to load was invalid.
	/// You get this exception only once per highlighting definition, after that the definition
	/// is replaced with the default highlighter.
	/// </summary>
	[Serializable()]
	public class HighlightingDefinitionInvalidException : Exception
	{
		public HighlightingDefinitionInvalidException() : base()
		{
		}
		
		public HighlightingDefinitionInvalidException(string message) : base(message)
		{
		}
		
		public HighlightingDefinitionInvalidException(string message, Exception innerException) : base(message, innerException)
		{
		}
		
		protected HighlightingDefinitionInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
