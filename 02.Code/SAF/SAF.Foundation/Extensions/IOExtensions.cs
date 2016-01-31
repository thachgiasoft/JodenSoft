using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace SAF.Foundation.Extensions
{
    public static class IOExtensions
    {
        /// <summary>
        /// Open containing folder with Windows Explorer.
        /// </summary>
        /// <param name="filename">Path or File name.</param>
        /// <returns>Full path or the file name if open folder succeeded.</returns>
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public static string OpenContainingFolder(this string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename");
            }

            string fullPath = Path.GetFullPath(filename);

            string fullDirectoryPath = Path.GetDirectoryName(fullPath);

            Process.Start("explorer.exe", fullDirectoryPath);

            return fullPath;
        }

    }
}
