using System;

namespace SAF.Framework.Controls.TextEditor.Util
{
	/// <summary>
	/// Central location for logging calls in the text editor.
	/// </summary>
	static class LoggingService
	{
		public static void Debug(string text)
		{
			#if DEBUG
			Console.WriteLine(text);
			#endif
		}
	}
}
