using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Windows;
using Microsoft.Win32;
using System.Globalization;

namespace SAF.Foundation.Interop
{
    /// <summary>
    /// 
    /// </summary>
    public static class NativeMethods
    {
        #region Const
        internal const int SW_RESTORE = 9;
        internal const int GWL_STYLE = -16;
        internal const int GWL_EXSTYLE = -20;
        internal const int SWP_NOSIZE = 0x0001;
        internal const int SWP_NOMOVE = 0x0002;
        internal const int SWP_NOZORDER = 0x0004;
        internal const int SWP_FRAMECHANGED = 0x0020;
        internal const uint WSETICON = 0x0080;
        internal const int WS_SYSMENU = 0x00080000;
        internal const int WS_EX_DLGMODALFRAME = 0x0001;
        #endregion

        #region Kernel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwErrorCode"></param>
        [SuppressUnmanagedCodeSecurity, DllImport("kernel32", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void SetLastError(int dwErrorCode);

        #endregion

        #region User

        #region Enums
        /// <summary>
        /// 
        /// </summary>
        public enum WindowLongValue
        {
            /// <summary>
            /// 
            /// </summary>
            WndProc = -4,
            /// <summary>
            /// 
            /// </summary>
            HInstace = -6,
            /// <summary>
            /// 
            /// </summary>
            HwndParent = -8,
            /// <summary>
            /// 
            /// </summary>
            Style = -16,
            /// <summary>
            /// 
            /// </summary>
            ExtendedStyle = -20,
            /// <summary>
            /// 
            /// </summary>
            UserData = -21,
            /// <summary>
            /// 
            /// </summary>
            ID = -12,
        }

        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum WindowStyles
        {
            /// <summary>
            /// 
            /// </summary>
            SysMemu = 0x80000,
            /// <summary>
            /// 
            /// </summary>
            MinimizeBox = 0x20000,
            /// <summary>
            /// 
            /// </summary>
            MaximizeBox = 0x10000,
            /// <summary>
            /// 
            /// </summary>
            ThickFrame = 0x40000,
        }
        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum WindowExStyles
        {
            /// <summary>
            /// 
            /// </summary>
            DlgModalFrame = 0x1,
        }
        /// <summary>
        /// 
        /// </summary>
        public enum WindowMessage
        {
            Destroy = 0x2,
            Close = 0x10,
            SetIcon = 0x80,
            MeasureItem = 0x2c,
            MouseMove = 0x200,
            MouseDown = 0x201,
            LButtonUp = 0x0202,
            LButtonDblClk = 0x0203,
            RButtonDown = 0x0204,
            RButtonUp = 0x0205,
            RButtonDblClk = 0x0206,
            MButtonDown = 0x0207,
            MButtonUp = 0x0208,
            MButtonDblClk = 0x0209,
            TrayMouseMessage = 0x800,
        }

        public enum NotifyIconMessage
        {
            BalloonShow = 0x402,
            BalloonHide = 0x403,
            BalloonTimeout = 0x404,
            BalloonUserClick = 0x405,
            PopupOpen = 0x406,
            PopupClose = 0x407,
        }

        public enum SystemMenu
        {
            Size = 0xF000,
            Close = 0xF060,
            Restore = 0xF120,
            Minimize = 0xF020,
            Maximize = 0xF030,
        }

        #endregion

        [DllImport("user32.dll")]
        internal extern static int SetWindowLong(IntPtr hwnd, int index, int value);
        [DllImport("user32.dll")]
        internal extern static int GetWindowLong(IntPtr hwnd, int index);
        [DllImport("user32.dll")]
        internal static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int width, int height, uint flags);
        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        internal static extern IntPtr DefWindowProc(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);

        [SuppressUnmanagedCodeSecurity, DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(HandleRef hWnd, WindowMessage msg, IntPtr wParam, IntPtr lParam);

        [SuppressUnmanagedCodeSecurity, DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(HandleRef hwnd, WindowMessage msg, IntPtr wparam, IntPtr lparam);

        [SuppressUnmanagedCodeSecurity, DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);
        /// <summary> 
        /// 该函数设置由不同线程产生的窗口的显示状态。 
        /// </summary> 
        /// <param name="hWnd">窗口句柄</param> 
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表，请查阅ShowWlndow函数的说明部分。</param> 
        /// <returns>如果函数原来可见，返回值为非零；如果函数原来被隐藏，返回值为零。</returns> 
        [SuppressUnmanagedCodeSecurity, DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int cmdShow);

        [SuppressUnmanagedCodeSecurity, DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int RegisterWindowMessage(string msg);

        [SuppressUnmanagedCodeSecurity, DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool DestroyIcon(IntPtr hIcon);

        [SuppressUnmanagedCodeSecurity, DllImport("user32", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int IntGetWindowLong(HandleRef hWnd, int nIndex);

        [SuppressUnmanagedCodeSecurity, DllImport("user32", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntGetWindowLongPtr(HandleRef hWnd, int nIndex);

        [DllImport("user32", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int IntSetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntSetWindowLongPtr(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

        public static int GetWindowLong(HandleRef hWnd, WindowLongValue nIndex)
        {
            int result = 0;
            int error = 0;
            SetLastError(0);
            if (IntPtr.Size == 4)
            {
                result = IntGetWindowLong(hWnd, (int)nIndex);
                error = Marshal.GetLastWin32Error();
            }
            else
            {
                IntPtr resultPtr = IntGetWindowLongPtr(hWnd, (int)nIndex);
                error = Marshal.GetLastWin32Error();
                result = IntPtrToInt32(resultPtr);
            }
            return result;
        }

        public static IntPtr SetWindowLong(HandleRef hWnd, WindowLongValue nIndex, IntPtr dwNewLong)
        {
            int error = 0;
            IntPtr result = IntPtr.Zero;
            SetLastError(0);
            if (IntPtr.Size == 4)
            {
                int intResult = IntSetWindowLong(hWnd, (int)nIndex, IntPtrToInt32(dwNewLong));
                error = Marshal.GetLastWin32Error();
                result = new IntPtr(intResult);
            }
            else
            {
                result = IntSetWindowLongPtr(hWnd, (int)nIndex, dwNewLong);
                error = Marshal.GetLastWin32Error();
            }
            return result;
        }

        [DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern bool EnableMenuItem(HandleRef hMenu, SystemMenu UIDEnabledItem, int uEnable);

        [DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetSystemMenu(HandleRef hWnd, bool bRevert);

        public static void SetSystemMenuItems(HandleRef hwnd, bool isEnabled, params SystemMenu[] menus)
        {
            if (menus != null && menus.Length > 0)
            {
                HandleRef hMenu = new HandleRef(null, GetSystemMenu(hwnd, false));

                foreach (SystemMenu menu in menus)
                {
                    SetMenuItem(hMenu, menu, isEnabled);
                }
            }
        }

        public static void SetMenuItem(HandleRef hMenu, SystemMenu menu, bool isEnabled)
        {
            EnableMenuItem(hMenu, menu, (isEnabled) ? ~1 : 1);
        }

        #endregion

        #region Shell

        #region Structures and Enums

        [StructLayout(LayoutKind.Sequential)]
        public struct BROWSEINFO
        {
            /// <summary>
            /// Handle to the owner window for the dialog box.
            /// </summary>
            public IntPtr HwndOwner;

            /// <summary>
            /// Pointer to an item identifier list (PIDL) specifying the 
            /// location of the root folder from which to start browsing.
            /// </summary>
            public IntPtr Root;

            /// <summary>
            /// Address of a buffer to receive the display name of the
            /// folder selected by the user.
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string DisplayName;

            /// <summary>
            /// Address of a null-terminated string that is displayed 
            /// above the tree view control in the dialog box.
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string Title;

            /// <summary>
            /// Flags specifying the options for the dialog box.
            /// </summary>
            public uint Flags;

            /// <summary>
            /// Address of an application-defined function that the
            /// dialog box calls when an event occurs.
            /// </summary>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public WndProc Callback;

            /// <summary>
            /// Application-defined value that the dialog box passes to 
            /// the callback function
            /// </summary>
            public int LParam;

            /// <summary>
            /// Variable to receive the image associated with the selected folder.
            /// </summary>
            public int Image;
        }

        [Flags]
        public enum FolderBrowserOptions
        {
            /// <summary>
            /// None.
            /// </summary>
            None = 0,
            /// <summary>
            /// For finding a folder to start document searching
            /// </summary>
            FolderOnly = 0x0001,
            /// <summary>
            /// For starting the Find Computer
            /// </summary>
            FindComputer = 0x0002,
            /// <summary>
            /// Top of the dialog has 2 lines of text for BROWSEINFO.lpszTitle and 
            /// one line if this flag is set.  Passing the message 
            /// BFFSETSTATUSTEXTA to the hwnd can set the rest of the text.  
            /// This is not used with BIF_USENEWUI and BROWSEINFO.lpszTitle gets
            /// all three lines of text.
            /// </summary>
            ShowStatusText = 0x0004,
            ReturnAncestors = 0x0008,
            /// <summary>
            /// Add an editbox to the dialog
            /// </summary>
            ShowEditBox = 0x0010,
            /// <summary>
            /// insist on valid result (or CANCEL)
            /// </summary>
            ValidateResult = 0x0020,
            /// <summary>
            /// Use the new dialog layout with the ability to resize
            /// Caller needs to call OleInitialize() before using this API
            /// </summary>
            UseNewStyle = 0x0040,
            UseNewStyleWithEditBox = (UseNewStyle | ShowEditBox),
            /// <summary>
            /// Allow URLs to be displayed or entered. (Requires BIF_USENEWUI)
            /// </summary>
            AllowUrls = 0x0080,
            /// <summary>
            /// Add a UA hint to the dialog, in place of the edit box. May not be
            /// combined with BIF_EDITBOX.
            /// </summary>
            ShowUsageHint = 0x0100,
            /// <summary>
            /// Do not add the "New Folder" button to the dialog.  Only applicable 
            /// with BIF_NEWDIALOGSTYLE.
            /// </summary>
            HideNewFolderButton = 0x0200,
            /// <summary>
            /// don't traverse target as shortcut
            /// </summary>
            GetShortcuts = 0x0400,
            /// <summary>
            /// Browsing for Computers.
            /// </summary>
            BrowseComputers = 0x1000,
            /// <summary>
            /// Browsing for Printers.
            /// </summary>
            BrowsePrinters = 0x2000,
            /// <summary>
            /// Browsing for Everything
            /// </summary>
            BrowseFiles = 0x4000,
            /// <summary>
            /// sharable resources displayed (remote shares, requires BIF_USENEWUI)
            /// </summary>
            BrowseShares = 0x8000
        }

        #endregion

        #region Notify Icon

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class NOTIFYICONDATA
        {
            public int cbSize = Marshal.SizeOf(typeof(NOTIFYICONDATA));
            public IntPtr hWnd;
            public int uID;
            public NotifyIconFlags uFlags;
            public int uCallbackMessage;
            public IntPtr hIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x80)]
            public string szTip;
            public int dwState;
            public int dwStateMask;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x100)]
            public string szInfo;
            public int uTimeoutOrVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x40)]
            public string szInfoTitle;
            public int dwInfoFlags;
        }

        [Flags]
        public enum NotifyIconFlags
        {
            /// <summary>
            /// The hIcon member is valid.
            /// </summary>
            Icon = 2,
            /// <summary>
            /// The uCallbackMessage member is valid.
            /// </summary>
            Message = 1,
            /// <summary>
            /// The szTip member is valid.
            /// </summary>
            ToolTip = 4,
            /// <summary>
            /// The dwState and dwStateMask members are valid.
            /// </summary>
            State = 8,
            /// <summary>
            /// Use a balloon ToolTip instead of a standard ToolTip. The szInfo, uTimeout, szInfoTitle, and dwInfoFlags members are valid.
            /// </summary>
            Balloon = 0x10,
        }

        [DllImport("shell32", CharSet = CharSet.Auto)]
        public static extern int Shell_NotifyIcon(int message, NOTIFYICONDATA pnid);

        #endregion

        #region Malloc

        [ComImport, SuppressUnmanagedCodeSecurity, Guid("00000002-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IMalloc
        {
            [PreserveSig]
            IntPtr Alloc(int cb);
            [PreserveSig]
            IntPtr Realloc(IntPtr pv, int cb);
            [PreserveSig]
            void Free(IntPtr pv);
            [PreserveSig]
            int GetSize(IntPtr pv);
            [PreserveSig]
            int DidAlloc(IntPtr pv);
            [PreserveSig]
            void HeapMinimize();
        }


        public static IMalloc GetSHMalloc()
        {
            IMalloc[] ppMalloc = new IMalloc[1];
            SHGetMalloc(ppMalloc);
            return ppMalloc[0];
        }

        [DllImport("shell32")]
        private static extern int SHGetMalloc([Out, MarshalAs(UnmanagedType.LPArray)] IMalloc[] ppMalloc);

        #endregion

        #region Folders

        [DllImport("shell32")]
        public static extern int SHGetFolderLocation(IntPtr hwndOwner, Int32 nFolder, IntPtr hToken, uint dwReserved, out IntPtr ppidl);

        [DllImport("shell32")]
        public static extern int SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)]string pszName, IntPtr pbc, out IntPtr ppidl, uint sfgaoIn, out uint psfgaoOut);

        [DllImport("shell32")]
        public static extern IntPtr SHBrowseForFolder(ref BROWSEINFO lbpi);

        [DllImport("shell32", CharSet = CharSet.Auto)]
        public static extern bool SHGetPathFromIDList(IntPtr pidl, IntPtr pszPath);

        #endregion

        #endregion

        #region Winmm

        #region Enums

        [Flags]
        private enum PlaySoundFlags
        {
            SND_ALIAS = 0x10000,
            SND_APPLICATION = 0x80,
            SND_ASYNC = 1,
            SND_FILENAME = 0x20000,
            SND_LOOP = 8,
            SND_MEMORY = 4,
            SND_NODEFAULT = 2,
            SND_NOSTOP = 0x10,
            SND_NOWAIT = 0x2000,
            SND_PURGE = 0x40,
            SND_RESOURCE = 0x40000,
            SND_SYNC = 0,
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soundName"></param>
        /// <returns></returns>
        private static string GetSystemSound(string soundName)
        {
            string path = null;
            string name = string.Format(CultureInfo.InvariantCulture, @"AppEvents\Schemes\Apps\.Default\{0}\.current\", soundName);

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(name))
                {
                    if (key != null)
                    {
                        path = (string)key.GetValue("");
                    }
                    return path;
                }
            }
            finally
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soundName"></param>
        /// <param name="hmod"></param>
        /// <param name="soundFlags"></param>
        /// <returns></returns>
        [SuppressUnmanagedCodeSecurity, DllImport("winmm", CharSet = CharSet.Unicode)]
        private static extern bool PlaySound(string soundName, IntPtr hmod, PlaySoundFlags soundFlags);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soundName"></param>
        public static void PlaySound(string soundName)
        {
            string systemSound = GetSystemSound(soundName);
            if (!string.IsNullOrEmpty(systemSound))
            {
                PlaySound(systemSound, IntPtr.Zero, PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_NOSTOP | PlaySoundFlags.SND_NODEFAULT | PlaySoundFlags.SND_ASYNC);
            }
        }

        #endregion

        #region Helpers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intPtr"></param>
        /// <returns></returns>
        public static int IntPtrToInt32(IntPtr intPtr)
        {
            return (int)intPtr.ToInt64();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        #endregion
    }
}
