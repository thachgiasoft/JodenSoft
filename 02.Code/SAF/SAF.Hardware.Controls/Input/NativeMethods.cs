using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace SAF.Hardware.Controls.Input
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public int mouseData;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct KEYBDINPUT
    {
        public short wVk;
        public short wScan;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct Input32
    {
        [FieldOffset(0)]
        public int type;
        [FieldOffset(4)]
        public MOUSEINPUT mi;
        [FieldOffset(4)]
        public KEYBDINPUT ki;
        [FieldOffset(4)]
        public HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct Input64
    {
        [FieldOffset(0)]
        public int type;
        [FieldOffset(8)]
        public MOUSEINPUT mi;
        [FieldOffset(8)]
        public KEYBDINPUT ki;
        [FieldOffset(8)]
        public HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct HARDWAREINPUT
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    }

    internal class INPUT
    {
        public const int MOUSE = 0;
        public const int KEYBOARD = 1;
        public const int HARDWARE = 2;
    }

    internal static class NativeMethods
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        internal static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        internal static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("User32.dll", EntryPoint = "SendInput", CharSet = CharSet.Auto)]
        internal static extern UInt32 SendInput(UInt32 nInputs, Input32[] pInputs, Int32 cbSize);

        [DllImport("User32.dll", EntryPoint = "SendInput", CharSet = CharSet.Auto)]
        internal static extern UInt32 SendInput64(UInt32 nInputs, Input64[] pInputs, Int32 cbSize);

        [DllImport("Kernel32.dll", EntryPoint = "GetTickCount", CharSet = CharSet.Auto)]
        internal static extern int GetTickCount();

        [DllImport("User32.dll", EntryPoint = "GetKeyState", CharSet = CharSet.Auto)]
        internal static extern short GetKeyState(int nVirtKey);

        [DllImport("User32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);


        /// <summary>
        /// 获取一个应用程序或动态链接库的模块句柄
        /// </summary>
        /// <param name="name">指定模块名，这通常是与模块的文件名相同的一个名字</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);
    }
}
