using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using DevExpress.XtraEditors;

namespace SAF.Framework.Controls
{
    /// <summary>
    /// 包装ToolBarButton为单一控件
    /// </summary>
    internal class ToggleButton : Control
    {
        /// <summary>
        /// 展开/收起图标数据
        /// </summary>
        const string ImgDataBase64 =
@"iVBORw0KGgoAAAANSUhEUgAAACAAAAAQCAYAAAB3AH1ZAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJ
bWFnZVJlYWR5ccllPAAAA3NJREFUeNqklVlPFEEQx/8zPccue6gorMd6gBegeCAQD4w+oCx+AInx
IB4EfTK8+g2MQUUTcBU8En0wmvigEkyMxgcTjRrUqHFVUBRQQaJGl2WPmbG6dzCLWUiESf7T0739
666urqqVDjVcxT9PAWkfqZKUY491ktpIzaRXGPv5L15J+dZIRx26dqAwf56c48+Cx+1CzDDR//13
/seevvx3HZ8OxmLxMzSvjhT5Z+Nx8UoKfHOu31e+qWwZPBkOMBkwTAvRuAE21QuvJwNz5s6U25++
rv365dtC+4SxifJsfeVWvsCJ2TOzqyo2FsHt1OBSFeiqTItIsOhHw7JgGBZM+s72TcOvX+GccHgw
k7qttgHj5slOLNE0tXZNSQGYJEEhiDEJusLoW4ZMfZnGJVv0QmHhYuiaup+zE+W5Aftyc/xMURRh
acJIKpowqDVhkhu5LCspiY6k0OIL5s9mdrCNyp9sDKL+6PExeW5AwOebigRNiiVMkoFIPIFwlLcG
huIm4mRI3DRpAQg38oPMmD6Nuz4wGn+koRGH64/hxr1HuHjl2qg8D8JcZ4ZTRCtLSDjT1Ijz51rS
5lfVzj2o2rWXXCzDPcnNh3L5K5WntdHYdAqng6cwa/EK+AuK8SDUSx65gUAlxR1ZkcqLLDBpkJ+S
R8yOvbXw+vx4GOoZsXlZyQqsK10pNlDpjlVZDPMs0FL55mATLl04C39+EWblFf3l2zs+w7jZii1b
Kkfw3IDOcDiS5/G4yLjknQcCAbrPW3j8plvMWlu8XGwOsblMASYjFh3i3S4SS+W3Vddg++6apJ8t
OwN4HHH/p+G5AW3f+gbyvB632DwGHigSyjdvpn4b9ElZWF9aJE6uMAanJsOlK3jdNcAXuE2y0vEQ
rcXfyeCT0vPcES0funoNRTJpgixSRUQsLbapogIbVq8S47rKCORShQvbX7437NI6Km8Ol9sxeG7A
i2g0Fnz2PAQ3TcjQGBw02UGWOqig8L7bweB1qCSFxHD3/nMMDkWDnJ0oP1yK6z529y1i8ovydaVL
wXOaXxl3W7K4yKKykY/Rdq8dofe9d+x6jonyw6WYu+Pyj5/hzLedPcU61dDJLh1T3E4BRgYjCHV0
4/qdJ+bn/h+naW41KZpiwLh5Kc3fMS+vNXaRybVT7YMdcM2228d6/ov/I8AAPfkI7yO+mM8AAAAA
SUVORK5CYII=";

        readonly bool isToggleMode;
        bool isChecked;
        readonly ImageList imgList;

        /// <summary>
        /// Checked改变后
        /// </summary>
        public event EventHandler CheckedChanged;

        /// <summary>
        /// 获取或设置按钮是否处于按下状态
        /// </summary>
        [Description("获取或设置按钮是否处于按下状态"), DefaultValue(false)]
        public bool Checked
        {
            get
            {
                if (IsHandleCreated)
                {
                    //保证isChecked与实情吻合。TB_ISBUTTONCHECKED
                    isChecked = Convert.ToBoolean(SendMessage(this.Handle, 0x40A, IntPtr.Zero, IntPtr.Zero).ToInt32());
                }
                return isChecked;
            }
            set
            {
                if (isChecked == value || !isToggleMode) { return; }

                isChecked = value;

                if (IsHandleCreated)
                {
                    //TB_CHECKBUTTON
                    SendMessage(this.Handle, 0x402, IntPtr.Zero, new IntPtr(Convert.ToInt32(value)));
                }

                OnCheckedChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// 创建ToolBarButtonControl
        /// </summary>
        public ToggleButton()
        {
            SetStyle(ControlStyles.UserPaint, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;

            this.isToggleMode = true;

            //将图标加入imageList
            imgList = new ImageList { ImageSize = new System.Drawing.Size(16, 16), ColorDepth = ColorDepth.Depth32Bit };
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(ImgDataBase64)))
            {
                imgList.Images.AddStrip(Image.FromStream(ms));
            }

        }

        /// <summary>
        /// 执行左键单击
        /// </summary>
        public void PerformClick()
        {
            SendMessage(this.Handle, 0x201, new IntPtr(0x1), IntPtr.Zero);//WM_LBUTTONDOWN
            Application.DoEvents();
            SendMessage(this.Handle, 0x202, IntPtr.Zero, IntPtr.Zero);    //WM_LBUTTONUP
        }

        protected override void WndProc(ref Message m)
        {
            //有节操的响应鼠标动作
            if ((m.Msg == 0x201 || m.Msg == 0x202) && (!this.Enabled || !this.Visible))
            {
                return;
            }
            base.WndProc(ref m);
        }

        //创建ToolBar
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams prms = base.CreateParams;
                prms.ClassName = "ToolbarWindow32";
                prms.Style = 0x40000000
                    | 0x10000000
                    //| 0x2000000 //WS_CLIPCHILDREN
                    //| 0x8000
                    | 0x1
                    | 0x4
                    | 0x8
                    | 0x40
                    | 0x1000 //TBSTYLE_LIST，图标文本横排
                    ;
                prms.Style |= 0x800; //TBSTYLE_FLAT。flat模式在NT6.x下，按钮按下会有动画效果

                prms.ExStyle = 0;

                return prms;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            //设置imgList
            SendMessage(this.Handle, 0x430, IntPtr.Zero, imgList.Handle);//TB_SETIMAGELIST

            //准备添加按钮
            int btnStructSize = Marshal.SizeOf(typeof(TBBUTTON));
            SendMessage(this.Handle, 0x41E, new IntPtr(btnStructSize), IntPtr.Zero);//TB_BUTTONSTRUCTSIZE，必须在添加按钮前

            //构建按钮信息
            TBBUTTON btnStruct = new TBBUTTON
            {
                //iBitmap = 0,
                //idCommand = 0,
                fsState = 0x4, //TBSTATE_ENABLED
                iString = SendMessage(this.Handle, 0x44D, 0, this.Text + '\0')//TB_ADDSTRING
            };
            if (this.isToggleMode) { btnStruct.fsStyle = 0x2; }//BTNS_CHECK。作为切换按钮时

            IntPtr btnStructStart = IntPtr.Zero;
            try
            {
                btnStructStart = Marshal.AllocHGlobal(btnStructSize);//在非托管区创建一个指针
                Marshal.StructureToPtr(btnStruct, btnStructStart, true);//把结构体塞到上述指针

                //添加按钮
                SendMessage(this.Handle, 0x444, new IntPtr(1)/*按钮数量*/, btnStructStart);//TB_ADDBUTTONS。从指针取按钮信息

                //设置按钮尺寸刚好为ToolBar尺寸
                AdjustButtonSize();
            }
            finally
            {
                if (btnStructStart != IntPtr.Zero) { Marshal.FreeHGlobal(btnStructStart); }
            }
        }

        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            //将空格和回车作为鼠标单击处理
            if (m.Msg == 0x100 && (keyData == Keys.Enter || keyData == Keys.Space))
            {
                PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref m, keyData);
        }

        /// <summary>
        /// 处理助记键
        /// </summary>
        protected override bool ProcessMnemonic(char charCode)
        {
            if (IsMnemonic(charCode, this.Text))
            {
                PerformClick();
                return true;
            }

            return base.ProcessMnemonic(charCode);
        }

        protected override void OnClick(EventArgs e)
        {
            //忽略鼠标右键
            MouseEventArgs me = e as MouseEventArgs;
            if (me != null && me.Button != System.Windows.Forms.MouseButtons.Left)
            { return; }

            //若是切换模式，直接引发Checked事件（不要通过设置Checked属性引发，因为OnClick发送之前就已经Check了）
            //存在理论上的不可靠，但暂无更好办法
            if (isToggleMode)
            { this.OnCheckedChanged(EventArgs.Empty); }

            base.OnClick(e);
        }

        //重绘后重设按钮尺寸
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            AdjustButtonSize();
        }

        /// <summary>
        /// 引发CheckedChanged事件
        /// </summary>
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            SetImageIndex(this.Checked ? 1 : 0);

            if (CheckedChanged != null) { CheckedChanged(this, e); }
        }

        /// <summary>
        /// 设置图标索引
        /// </summary>
        private void SetImageIndex(int index)
        {
            //TB_CHANGEBITMAP
            SendMessage(this.Handle, 0x42B, IntPtr.Zero, new IntPtr(index));
        }

        /// <summary>
        /// 调整按钮尺寸刚好为ToolBar尺寸
        /// </summary>
        private void AdjustButtonSize()
        {
            IntPtr lParam = new IntPtr((this.Width & 0xFFFF) | (this.Height << 0x10)); //MakeLParam手法
            SendMessage(this.Handle, 0x41F, IntPtr.Zero, lParam); //TB_SETBUTTONSIZE
        }

        #region Win32 API

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct TBBUTTON
        {
            public int iBitmap;
            public int idCommand;
            public byte fsState;
            public byte fsStyle;
            public byte bReserved0;
            public byte bReserved1;
            public IntPtr dwData;
            public IntPtr iString;
        }

        #endregion
    }
}
