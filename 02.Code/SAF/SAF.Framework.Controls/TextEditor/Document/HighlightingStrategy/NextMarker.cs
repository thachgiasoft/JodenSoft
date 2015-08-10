﻿using System;
using System.Xml;

namespace SAF.Framework.Controls.TextEditor.Document
{
	/// <summary>
	/// Used for mark next token
	/// </summary>
	public class NextMarker
	{
		string      what;
		HighlightColor color;
		bool        markMarker = false;
		
		/// <value>
		/// String value to indicate to mark next token
		/// </value>
		public string What {
			get {
				return what;
			}
		}
		
		/// <value>
		/// Color for marking next token
		/// </value>
		public HighlightColor Color {
			get {
				return color;
			}
		}
		
		/// <value>
		/// If true the indication text will be marked with the same color
		/// too
		/// </value>
		public bool MarkMarker {
			get {
				return markMarker;
			}
		}
		
		/// <summary>
		/// Creates a new instance of <see cref="NextMarker"/>
		/// </summary>
		public NextMarker(XmlElement mark)
		{
			color = new HighlightColor(mark);
			what  = mark.InnerText;
			if (mark.Attributes["markmarker"] != null) {
				markMarker = Boolean.Parse(mark.Attributes["markmarker"].InnerText);
			}
		}
	}

}
