
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace SAF.Framework.Controls.TextEditor.Document
{
	public class ResourceSyntaxModeProvider : ISyntaxModeFileProvider
	{
		List<SyntaxMode> syntaxModes = null;
		
		public ICollection<SyntaxMode> SyntaxModes {
			get {
				return syntaxModes;
			}
		}
		
		public ResourceSyntaxModeProvider()
		{
			Assembly assembly = typeof(SyntaxMode).Assembly;
            Stream syntaxModeStream = assembly.GetManifestResourceStream("SAF.Framework.Controls.TextEditor.Resources.SyntaxModes.xml");
			if (syntaxModeStream != null) {
				syntaxModes = SyntaxMode.GetSyntaxModes(syntaxModeStream);
			} else {
				syntaxModes = new List<SyntaxMode>();
			}
		}
		
		public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
		{
			Assembly assembly = typeof(SyntaxMode).Assembly;
            return new XmlTextReader(assembly.GetManifestResourceStream("SAF.Framework.Controls.TextEditor.Resources." + syntaxMode.FileName));
		}
		
		public void UpdateSyntaxModeList()
		{
			// resources don't change during runtime
		}
	}
}
