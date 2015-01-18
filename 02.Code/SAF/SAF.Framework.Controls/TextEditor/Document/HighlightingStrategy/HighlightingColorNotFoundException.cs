﻿
using System;
using System.Runtime.Serialization;

namespace SAF.Framework.Controls.TextEditor.Document
{
	[Serializable()]
	public class HighlightingColorNotFoundException : Exception
	{
		public HighlightingColorNotFoundException() : base()
		{
		}
		
		public HighlightingColorNotFoundException(string message) : base(message)
		{
		}
		
		public HighlightingColorNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}
		
		protected HighlightingColorNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
