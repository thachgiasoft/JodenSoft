using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using SAF.Hardware.Controls.Input.HookEx;
using SAF.Hardware.Controls.Input;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using DevExpress.XtraEditors;

namespace SAF.Hardware.Controls
{
    public partial class ScreenKeyboard : XtraForm
    {
        private UserActivityHook hook;
        private static readonly IDictionary<string, string> keyPairs;
        private static readonly IDictionary<string, string> numKeyPairs;

        private static IDictionary<short, IList<KeyboardButton>> spacialVKButtonsMap;
        private static IDictionary<short, IList<KeyboardButton>> combinationVKButtonsMap;

        #region Key Pairs

        static ScreenKeyboard()
        {
            keyPairs = new Dictionary<string, string>();
            keyPairs.Add("1", "!");
            keyPairs.Add("2", "@");
            keyPairs.Add("3", "#");
            keyPairs.Add("4", "$");
            keyPairs.Add("5", "%");
            keyPairs.Add("6", "^");
            keyPairs.Add("7", "&&");
            keyPairs.Add("8", "*");
            keyPairs.Add("9", "(");
            keyPairs.Add("0", ")");
            keyPairs.Add("`", "~");
            keyPairs.Add("-", "_");
            keyPairs.Add("=", "+");
            keyPairs.Add("\\", "|");
            keyPairs.Add("[", "{");
            keyPairs.Add("]", "}");
            keyPairs.Add(";", ":");
            keyPairs.Add("'", "\"");
            keyPairs.Add(",", "<");
            keyPairs.Add(".", ">");
            keyPairs.Add("/", "?");

            numKeyPairs = new Dictionary<string, string>();
            numKeyPairs.Add("1", "End");
            numKeyPairs.Add("2", "↓");
            numKeyPairs.Add("3", "PgDn");
            numKeyPairs.Add("4", "←");
            numKeyPairs.Add("5", string.Empty);
            numKeyPairs.Add("6", "→");
            numKeyPairs.Add("7", "Home");
            numKeyPairs.Add("8", "↑");
            numKeyPairs.Add("9", "PgUp");
            numKeyPairs.Add("0", "Ins");
        }

        #endregion

        public ScreenKeyboard()
        {
            InitializeComponent();

            this.paintColor = new PaintColor();

            base.TopMost = true;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.lightCapsLock.AssositeButton = this.btnLOCK;
            this.lightNumLock.AssositeButton = this.btnNLK;
            this.lightScrollLock.AssositeButton = this.btnSLK;

            #region Initialize VK Button maps

            spacialVKButtonsMap = new Dictionary<short, IList<KeyboardButton>>();
            combinationVKButtonsMap = new Dictionary<short, IList<KeyboardButton>>();

            IList<KeyboardButton> buttonList = new List<KeyboardButton>();
            buttonList.Add(this.btnLCTRL);
            buttonList.Add(this.btnRCTRL);
            combinationVKButtonsMap.Add(KeyboardConstaint.VK_CONTROL, buttonList);

            buttonList = new List<KeyboardButton>();
            buttonList.Add(this.btnLSHFT);
            buttonList.Add(this.btnRSHFT);
            combinationVKButtonsMap.Add(KeyboardConstaint.VK_SHIFT, buttonList);

            buttonList = new List<KeyboardButton>();
            buttonList.Add(this.btnLALT);
            buttonList.Add(this.btnRALT);
            combinationVKButtonsMap.Add(KeyboardConstaint.VK_MENU, buttonList);

            //buttonList = new List<KeyboardButton>();
            //buttonList.Add(this.btnLW);
            //buttonList.Add(this.btnRW);
            //combinationVKButtonsMap.Add(KeyboardConstaint.VK_LWIN, buttonList);

            buttonList = new List<KeyboardButton>();
            buttonList.Add(this.btnLOCK);
            spacialVKButtonsMap.Add(KeyboardConstaint.VK_CAPITAL, buttonList);

            buttonList = new List<KeyboardButton>();
            buttonList.Add(this.btnNLK);
            spacialVKButtonsMap.Add(KeyboardConstaint.VK_NUMLOCK, buttonList);

            buttonList = new List<KeyboardButton>();
            buttonList.Add(this.btnSLK);
            spacialVKButtonsMap.Add(KeyboardConstaint.VK_SCROLL, buttonList);

            #endregion

            foreach (System.Windows.Forms.Control ctrl in this.Controls)
            {
                KeyboardButton button = ctrl as KeyboardButton;
                if (button == null)
                {
                    continue;
                }

                #region Set virtual keycode

                short key = 0;
                bool isSpacialKey = true;
                switch (button.Name)
                {
                    case "btnLCTRL":
                    case "btnRCTRL":
                        key = KeyboardConstaint.VK_CONTROL;
                        break;

                    case "btnLSHFT":
                    case "btnRSHFT":
                        key = KeyboardConstaint.VK_SHIFT;
                        break;

                    case "btnLALT":
                    case "btnRALT":
                        key = KeyboardConstaint.VK_MENU;
                        break;

                    case "btnLW":
                    case "btnRW":
                        key = KeyboardConstaint.VK_LWIN;
                        break;

                    case "btnESC":
                        key = KeyboardConstaint.VK_ESCAPE;
                        break;

                    case "btnTAB":
                        key = KeyboardConstaint.VK_TAB;
                        break;

                    case "btnF1":
                        key = KeyboardConstaint.VK_F1;
                        break;

                    case "btnF2":
                        key = KeyboardConstaint.VK_F2;
                        break;

                    case "btnF3":
                        key = KeyboardConstaint.VK_F3;
                        break;

                    case "btnF4":
                        key = KeyboardConstaint.VK_F4;
                        break;

                    case "btnF5":
                        key = KeyboardConstaint.VK_F5;
                        break;

                    case "btnF6":
                        key = KeyboardConstaint.VK_F6;
                        break;

                    case "btnF7":
                        key = KeyboardConstaint.VK_F7;
                        break;

                    case "btnF8":
                        key = KeyboardConstaint.VK_F8;
                        break;

                    case "btnF9":
                        key = KeyboardConstaint.VK_F9;
                        break;

                    case "btnF10":
                        key = KeyboardConstaint.VK_F10;
                        break;

                    case "btnF11":
                        key = KeyboardConstaint.VK_F11;
                        break;

                    case "btnF12":
                        key = KeyboardConstaint.VK_F12;
                        break;

                    case "btnENT":
                    case "btnNUMENT":
                        key = KeyboardConstaint.VK_RETURN;
                        break;

                    case "btnWave":
                        key = KeyboardConstaint.VK_OEM_3;
                        break;

                    case "btnSem":
                        key = KeyboardConstaint.VK_OEM_1;
                        break;

                    case "btnQute":
                        key = KeyboardConstaint.VK_OEM_7;
                        break;

                    case "btnSpace":
                        key = KeyboardConstaint.VK_SPACE;
                        break;

                    case "btnBKSP":
                        key = KeyboardConstaint.VK_BACK;
                        break;

                    case "btnComma":
                        key = KeyboardConstaint.VK_OEM_COMMA;
                        break;

                    case "btnFullStop":
                        key = KeyboardConstaint.VK_OEM_PERIOD;
                        break;

                    case "btnLOCK":
                        key = KeyboardConstaint.VK_CAPITAL;
                        break;

                    case "btnMinus":
                        key = KeyboardConstaint.VK_OEM_MINUS;
                        break;

                    case "btnEqual":
                        key = KeyboardConstaint.VK_OEM_PLUS;
                        break;

                    case "btnLBracket":
                        key = KeyboardConstaint.VK_OEM_4;
                        break;

                    case "btnRBracket":
                        key = KeyboardConstaint.VK_OEM_6;
                        break;

                    case "btnPath":
                        key = KeyboardConstaint.VK_OEM_5;
                        break;

                    case "btnDivide":
                        key = KeyboardConstaint.VK_OEM_2;
                        break;

                    case "btnMU":
                        key = KeyboardConstaint.VK_APPS;
                        break;

                    case "btnPSC":
                        key = KeyboardConstaint.VK_SNAPSHOT;
                        break;

                    case "btnSLK":
                        key = KeyboardConstaint.VK_SCROLL;
                        break;

                    case "btnBRK":
                        key = KeyboardConstaint.VK_PAUSE;
                        break;

                    case "btnINS":
                        key = KeyboardConstaint.VK_INSERT;
                        break;

                    case "btnHM":
                        key = KeyboardConstaint.VK_HOME;
                        break;

                    case "btnPUP":
                        key = KeyboardConstaint.VK_PRIOR;
                        break;

                    case "btnDEL":
                        key = KeyboardConstaint.VK_DELETE;
                        break;

                    case "btnEND":
                        key = KeyboardConstaint.VK_END;
                        break;

                    case "btnPDN":
                        key = KeyboardConstaint.VK_NEXT;
                        break;

                    case "btnUP":
                        key = KeyboardConstaint.VK_UP;
                        break;

                    case "btnDN":
                        key = KeyboardConstaint.VK_DOWN;
                        break;

                    case "btnLA":
                        key = KeyboardConstaint.VK_LEFT;
                        break;

                    case "btnRA":
                        key = KeyboardConstaint.VK_RIGHT;
                        break;

                    case "btnNUM0":
                        key = KeyboardConstaint.VK_NUMPAD0;
                        break;

                    case "btnNUM1":
                        key = KeyboardConstaint.VK_NUMPAD1;
                        break;

                    case "btnNUM2":
                        key = KeyboardConstaint.VK_NUMPAD2;
                        break;

                    case "btnNUM3":
                        key = KeyboardConstaint.VK_NUMPAD3;
                        break;

                    case "btnNUM4":
                        key = KeyboardConstaint.VK_NUMPAD4;
                        break;

                    case "btnNUM5":
                        key = KeyboardConstaint.VK_NUMPAD5;
                        break;

                    case "btnNUM6":
                        key = KeyboardConstaint.VK_NUMPAD6;
                        break;

                    case "btnNUM7":
                        key = KeyboardConstaint.VK_NUMPAD7;
                        break;

                    case "btnNUM8":
                        key = KeyboardConstaint.VK_NUMPAD8;
                        break;

                    case "btnNUM9":
                        key = KeyboardConstaint.VK_NUMPAD9;
                        break;

                    case "btnNLK":
                        key = KeyboardConstaint.VK_NUMLOCK;
                        break;

                    case "btnNUMDivide":
                        key = KeyboardConstaint.VK_DIVIDE;
                        break;

                    case "btnMultiply":
                        key = KeyboardConstaint.VK_MULTIPLY;
                        break;

                    case "btnNUMPlus":
                        key = KeyboardConstaint.VK_ADD;
                        break;

                    case "btnNUMMinus":
                        key = KeyboardConstaint.VK_SUBTRACT;
                        break;

                    case "btnNUMDot":
                        key = KeyboardConstaint.VK_DECIMAL;
                        break;

                    default:
                        isSpacialKey = false;
                        break;
                }

                if (!isSpacialKey)
                {
                    key = (short)button.Name[3];
                }

                button.VKCode = key;

                #endregion

                button.Click += ButtonOnClick;
            }
            this.hook = new UserActivityHook(true, true);
            HookEvents(true);
        }

        private void HookEvents(bool hook)
        {
            if (hook)
            {
                this.hook.KeyDown += HookOnGlobalKeyDown;
                this.hook.KeyUp += HookOnGlobalKeyUp;
                this.hook.MouseActivity += HookOnMouseActivity;
            }
            else {
                this.hook.KeyDown -= HookOnGlobalKeyDown;
                this.hook.KeyUp -= HookOnGlobalKeyUp;
                this.hook.MouseActivity -= HookOnMouseActivity;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            var left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Location = new Point(left, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            base.OnShown(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            SetButtonStatus();
            if (!this.lightNumLock.On)
            {
                short key = KeyboardConstaint.VK_NUMLOCK;
                SendKeyDown(key);
                SendKeyUp(key);
            }

            base.OnLoad(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.Msg == 0x100 && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            foreach (KeyValuePair<short, IList<KeyboardButton>> entry in combinationVKButtonsMap)
            {
                IList<KeyboardButton> buttonList = entry.Value;
                if (buttonList[0].Checked)
                {
                    SendKeyUp(entry.Key);
                }
            }

            base.OnClosing(e);
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            KeyboardButton btnKey = sender as KeyboardButton;
            if (btnKey == null)
            {
                return;
            }

            SendKeyCommand(btnKey);
        }

        private void SendKeyCommand(KeyboardButton keyButton)
        {
            short key = keyButton.VKCode;
            if (combinationVKButtonsMap.ContainsKey(key))
            {
                if (keyButton.Checked)
                {
                    SendKeyUp(key);
                }
                else
                {
                    SendKeyDown(key);
                }
            }
            else
            {
                SendKeyDown(key);
                SendKeyUp(key);
            }
        }

        private void SendKeyDown(short key)
        {
            if (Marshal.SizeOf(new IntPtr()) == 8)//64位系统
            {
                Input64[] input = new Input64[1];
                input[0].type = INPUT.KEYBOARD;
                input[0].ki.wVk = key;
                input[0].ki.time = NativeMethods.GetTickCount();
                if (NativeMethods.SendInput64((uint)input.Length, input, Marshal.SizeOf(input[0])) < input.Length)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            else
            {
                Input32[] input = new Input32[1];
                input[0].type = INPUT.KEYBOARD;
                input[0].ki.wVk = key;
                input[0].ki.time = NativeMethods.GetTickCount();
                if (NativeMethods.SendInput((uint)input.Length, input, Marshal.SizeOf(input[0])) < input.Length)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
        }

        private void SendKeyUp(short key)
        {
            if (Marshal.SizeOf(new IntPtr()) == 8)//64位系统
            {
                Input64[] input = new Input64[1];
                input[0].type = INPUT.KEYBOARD;
                input[0].ki.wVk = key;
                input[0].ki.dwFlags = KeyboardConstaint.KEYEVENTF_KEYUP;
                input[0].ki.time = NativeMethods.GetTickCount();

                if (NativeMethods.SendInput64((uint)input.Length, input, Marshal.SizeOf(input[0])) < input.Length)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            else
            {
                Input32[] input = new Input32[1];
                input[0].type = INPUT.KEYBOARD;
                input[0].ki.wVk = key;
                input[0].ki.dwFlags = KeyboardConstaint.KEYEVENTF_KEYUP;
                input[0].ki.time = NativeMethods.GetTickCount();

                if (NativeMethods.SendInput((uint)input.Length, input, Marshal.SizeOf(input[0])) < input.Length)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
        }

        private void HookOnGlobalKeyDown(object sender, KeyExEventArgs e)
        {
            SetButtonStatus(e, true);
        }

        private void HookOnGlobalKeyUp(object sender, KeyExEventArgs e)
        {
            SetButtonStatus(e, false);
        }

        private void HookOnMouseActivity(object sener, MouseExEventArgs e)
        {
            Point location = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                Rectangle captionRect = new Rectangle(this.Location, new Size(this.Width, SystemInformation.CaptionHeight));
                if (captionRect.Contains(location))
                {
                    NativeMethods.SetWindowLong(this.Handle, KeyboardConstaint.GWL_EXSTYLE,
                        (int)NativeMethods.GetWindowLong(this.Handle, KeyboardConstaint.GWL_EXSTYLE) & (~KeyboardConstaint.WS_DISABLED));
                    NativeMethods.SendMessage(this.Handle, KeyboardConstaint.WM_SETFOCUS, IntPtr.Zero, IntPtr.Zero);
                }
                else {
                    NativeMethods.SetWindowLong(this.Handle, KeyboardConstaint.GWL_EXSTYLE,
                        (int)NativeMethods.GetWindowLong(this.Handle, KeyboardConstaint.GWL_EXSTYLE) | KeyboardConstaint.WS_DISABLED);
                }
            }
        }

        private void SetButtonStatus(KeyExEventArgs args, bool isDown)
        {
            IList<KeyboardButton> buttonList = FindButtonList(args);

            if (buttonList.Count <= 0)
            {
                return;
            }

            short key = (short)args.KeyValue;
            if (spacialVKButtonsMap.ContainsKey(key))
            {
                if (!isDown)
                {
                    KeyboardButton button = spacialVKButtonsMap[key][0];
                    button.Checked = !button.Checked;
                }
            }
            else {
                foreach (KeyboardButton button in buttonList)
                {
                    button.Checked = isDown;
                }
            }

            SetButtonText();
        }

        private IList<KeyboardButton> FindButtonList(KeyExEventArgs args)
        {
            short key = (short)args.KeyValue;
            if (key == KeyboardConstaint.VK_LCONTROL || key == KeyboardConstaint.VK_RCONTROL)
            {
                key = KeyboardConstaint.VK_CONTROL;
            }
            else if (key == KeyboardConstaint.VK_LSHIFT || key == KeyboardConstaint.VK_RSHIFT)
            {
                key = KeyboardConstaint.VK_SHIFT;
            }
            else if (key == KeyboardConstaint.VK_LMENU || key == KeyboardConstaint.VK_RMENU)
            {
                key = KeyboardConstaint.VK_MENU;
            }
            else if (key == KeyboardConstaint.VK_RWIN)
            {
                key = KeyboardConstaint.VK_LWIN;
            }

            if (combinationVKButtonsMap.ContainsKey(key))
            {
                return combinationVKButtonsMap[key];
            }

            IList<KeyboardButton> buttonList = new List<KeyboardButton>();
            foreach (System.Windows.Forms.Control ctrl in this.Controls)
            {
                KeyboardButton button = ctrl as KeyboardButton;

                if (button == null)
                {
                    continue;
                }

                short theKey = button.VKCode;
                if (theKey == key)
                {
                    IDictionary<KeyboardButton, KeyboardButton> buttonMap = new Dictionary<KeyboardButton, KeyboardButton>();
                    buttonMap.Add(this.btnENT, this.btnNUMENT);
                    buttonMap.Add(this.btnNUM0, this.btnINS);
                    buttonMap.Add(this.btnNUMDot, this.btnDEL);
                    buttonMap.Add(this.btnNUM1, this.btnEND);
                    buttonMap.Add(this.btnNUM2, this.btnDN);
                    buttonMap.Add(this.btnNUM3, this.btnPDN);
                    buttonMap.Add(this.btnNUM4, this.btnLA);
                    buttonMap.Add(this.btnNUM6, this.btnRA);
                    buttonMap.Add(this.btnNUM7, this.btnHM);
                    buttonMap.Add(this.btnNUM8, this.btnUP);
                    buttonMap.Add(this.btnNUM9, this.btnPUP);
                    if (buttonMap.ContainsKey(button))
                    {
                        if ((args.Flags & 0x00000001) == 0)
                        {
                            buttonList.Add(button);
                        }
                        else {
                            buttonList.Add(buttonMap[button]);
                        }
                    }
                    else if (buttonMap.Values.Contains(button))
                    {
                        if ((args.Flags & 0x00000001) == 0)
                        {
                            KeyboardButton keyButton = null;
                            foreach (KeyValuePair<KeyboardButton, KeyboardButton> entry in buttonMap)
                            {
                                if (object.ReferenceEquals(entry.Value, button))
                                {
                                    keyButton = entry.Key;
                                    break;
                                }
                            }
                            if (keyButton != null)
                            {
                                buttonList.Add(keyButton);
                            }
                        }
                        else {
                            buttonList.Add(button);
                        }
                    }
                    else {
                        buttonList.Add(button);
                    }
                }
            }

            return buttonList;
        }

        private void SetButtonStatus()
        {
            foreach (KeyValuePair<short, IList<KeyboardButton>> entry in spacialVKButtonsMap)
            {
                bool isOn = IsSPactialKeyOn(entry.Key);
                foreach (KeyboardButton button in entry.Value)
                {
                    button.Checked = isOn;
                }
            }

            foreach (KeyValuePair<short, IList<KeyboardButton>> entry in combinationVKButtonsMap)
            {
                bool isDown = IsCommonKeyOn(entry.Key);
                foreach (KeyboardButton button in entry.Value)
                {
                    button.Checked = isDown;
                }
            }

            SetButtonText();
        }

        private void SetButtonText()
        {
            bool isShifOn = this.btnLSHFT.Checked;
            bool isCapsLockOn = this.btnLOCK.Checked;
            bool isNumLock = this.btnNLK.Checked;

            foreach (System.Windows.Forms.Control ctrl in this.Controls)
            {
                Button button = ctrl as Button;
                if (button == null)
                    continue;

                string buttonName = button.Name;
                if (buttonName.Length == 4)
                {
                    if (char.IsDigit(buttonName[3]))
                    {
                        // such as btn2
                        button.Text = isShifOn ? keyPairs[buttonName[3].ToString()] : buttonName[3].ToString();
                    }
                    else {
                        // such as btnA
                        bool shouldShowUpper = isShifOn ^ isCapsLockOn;
                        button.Text = shouldShowUpper ? buttonName[3].ToString() : buttonName[3].ToString().ToLower();
                    }
                }
                else if (buttonName.IndexOf("btnNUM") >= 0 && buttonName.Length > 6 && char.IsDigit(buttonName[6]))
                {
                    // such as btnNUM2 
                    if (isNumLock)
                    {
                        button.Text = buttonName[6].ToString();
                        ReverseNumPad(true);
                    }
                    else {
                        button.Text = numKeyPairs[buttonName[6].ToString()];
                        ReverseNumPad(false);
                    }
                }
                else if (string.Equals(buttonName, "btnNUMDot"))
                {
                    button.Text = isNumLock ? "." : "Del";
                }
                else {
                    IDictionary<string, string> buttonNameTextMaps = new Dictionary<string, string>();
                    buttonNameTextMaps.Add("btnWave", "`");
                    buttonNameTextMaps.Add("btnMinus", "-");
                    buttonNameTextMaps.Add("btnLBracket", "[");
                    buttonNameTextMaps.Add("btnRBracket", "]");
                    buttonNameTextMaps.Add("btnPath", "\\");
                    buttonNameTextMaps.Add("btnSem", ";");
                    buttonNameTextMaps.Add("btnQute", "'");
                    buttonNameTextMaps.Add("btnComma", ",");
                    buttonNameTextMaps.Add("btnFullStop", ".");
                    buttonNameTextMaps.Add("btnDivide", "/");
                    buttonNameTextMaps.Add("btnEqual", "=");

                    if (buttonNameTextMaps.ContainsKey(buttonName))
                    {
                        button.Text = isShifOn ? keyPairs[buttonNameTextMaps[buttonName]] : buttonNameTextMaps[buttonName];
                    }
                }
            }
        }

        private bool IsCommonKeyOn(short key)
        {
            short keyState = NativeMethods.GetKeyState(key);
            return (keyState & 0XFF80) == 0XFF80;
        }

        private bool IsSPactialKeyOn(short key)
        {
            short keyState = NativeMethods.GetKeyState(key);
            return (keyState & 0X0001) == 0X0001;
        }

        private void ReverseNumPad(bool isNumLock)
        {
            if (isNumLock)
            {
                this.btnNUM0.VKCode = KeyboardConstaint.VK_NUMPAD0;
                this.btnNUMDot.VKCode = KeyboardConstaint.VK_DECIMAL;
                this.btnNUM1.VKCode = KeyboardConstaint.VK_NUMPAD1;
                this.btnNUM2.VKCode = KeyboardConstaint.VK_NUMPAD2;
                this.btnNUM3.VKCode = KeyboardConstaint.VK_NUMPAD3;
                this.btnNUM4.VKCode = KeyboardConstaint.VK_NUMPAD4;
                this.btnNUM5.VKCode = KeyboardConstaint.VK_NUMPAD5;
                this.btnNUM6.VKCode = KeyboardConstaint.VK_NUMPAD6;
                this.btnNUM7.VKCode = KeyboardConstaint.VK_NUMPAD7;
                this.btnNUM8.VKCode = KeyboardConstaint.VK_NUMPAD8;
                this.btnNUM9.VKCode = KeyboardConstaint.VK_NUMPAD9;
            }
            else {
                this.btnNUM0.VKCode = KeyboardConstaint.VK_INSERT;
                //this.btnNUMDot.VKCode = KeyboardConstaint.VK_OEM_PERIOD;
                this.btnNUMDot.VKCode = KeyboardConstaint.VK_DELETE;

                this.btnNUM1.VKCode = KeyboardConstaint.VK_END;
                this.btnNUM2.VKCode = KeyboardConstaint.VK_DOWN;
                this.btnNUM3.VKCode = KeyboardConstaint.VK_NEXT;
                this.btnNUM4.VKCode = KeyboardConstaint.VK_LEFT;
                this.btnNUM5.VKCode = KeyboardConstaint.VK_NUMPAD5NOTHING;
                this.btnNUM6.VKCode = KeyboardConstaint.VK_RIGHT;
                this.btnNUM7.VKCode = KeyboardConstaint.VK_HOME;
                this.btnNUM8.VKCode = KeyboardConstaint.VK_UP;
                this.btnNUM9.VKCode = KeyboardConstaint.VK_PRIOR;
            }
        }

        #region 无焦点窗体

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static IntPtr SetActiveWindow(IntPtr handle);
        private const int WM_ACTIVATE = 0x006;
        private const int WM_ACTIVATEAPP = 0x01C;
        private const int WM_NCACTIVATE = 0x086;
        private const int WA_INACTIVE = 0;
        private const int WM_MOUSEACTIVATE = 0x21;
        private const int MA_NOACTIVATE = 3;

        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_MOUSEACTIVATE)
            {
                msg.Result = new IntPtr(MA_NOACTIVATE);
                return;
            }
            else if (msg.Msg == WM_NCACTIVATE)
            {
                if (((int)msg.WParam & 0xFFFF) != WA_INACTIVE)
                {
                    if (msg.LParam != IntPtr.Zero)
                    {
                        SetActiveWindow(msg.LParam);
                    }
                    else
                    {
                        SetActiveWindow(IntPtr.Zero);
                    }
                }
            }
            base.WndProc(ref msg);
        }

        #endregion

        #region Paint

        private PaintColor paintColor;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (base.ClientRectangle.IsEmpty)
            {
                return;
            }

            using (Brush brush = new LinearGradientBrush(base.ClientRectangle,
                this.paintColor.startColor, this.paintColor.endColor, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, base.ClientRectangle);
            }

            base.OnPaint(e);
        }

        private class PaintColor
        {
            internal Color startColor;
            internal Color endColor;

            public PaintColor()
            {
                this.startColor = Color.FromArgb(88, 134, 213);
                this.endColor = Color.FromArgb(4, 57, 149);

            }
        }

        #endregion

        #region 单例

        private static ScreenKeyboard _ScreenKeyboard = null;
        private static object lockObj = new object();
        /// <summary>
        /// 如果是Win10则弹出系统屏幕键盘
        /// </summary>
        /// <param name="allowUseSystemKeyboard">在WIN10系统中是否允许使用系统屏幕键盘</param>
        public static void ShowOnScreen(bool allowUseSystemKeyboard = true)
        {
            Version currentVersion = Environment.OSVersion.Version;
            Version compareToVersion = new Version("6.2");
            bool isWin10 = false;

#if !DEBUG            
            isWin10 = currentVersion.CompareTo(compareToVersion) >= 0;
#endif

            string tabTipFileName = @"C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe";
            if (isWin10 && System.IO.File.Exists(tabTipFileName) && allowUseSystemKeyboard)
            {
                Process.Start(tabTipFileName);
            }
            else
            {
                if (_ScreenKeyboard == null)
                {
                    lock (lockObj)
                    {
                        if (_ScreenKeyboard == null)
                            _ScreenKeyboard = new ScreenKeyboard();
                    }
                }
                _ScreenKeyboard.FormClosed += (s, e) =>
                {
                    _ScreenKeyboard = null;
                    GC.Collect();
                };

                _ScreenKeyboard.Show();
            }
        }

        #endregion

        #region 点击任意位置移动窗体

        private Point offset;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        #endregion

    }
}
