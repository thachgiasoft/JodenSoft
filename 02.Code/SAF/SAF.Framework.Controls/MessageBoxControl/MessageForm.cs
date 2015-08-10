using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using DevExpress.XtraEditors;

namespace SAF.Framework.Controls
{
    /// <summary>
    /// 消息窗体
    /// </summary>
    /// <remarks>参数有效性由MessageBoxEx负责</remarks>
    internal class MessageForm : XtraForm
    {
        /* todo 存在问题：
         * 当消息区文本非常非常多时，且反复进行改变消息框窗口大小、位置、展开收起的操作，那么在某次展开时
           详细信息文本框可能会在原位置（即消息区内某rect）瞬闪一下，
           原因是文本框控件在显示时总会在原位置WM_NCPAINT + WM_ERASEBKGND一下，暂无解决办法。
           实际应用中碰到的几率很小，就算碰到，影响也可以忽略。
         */

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbMsg = new SAF.Framework.Controls.MessageViewer();
            this.plButtonsZone = new SAF.Framework.Controls.PanelBasic();
            this.ckbToggle = new SAF.Framework.Controls.ToggleButton();
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.button2 = new DevExpress.XtraEditors.SimpleButton();
            this.button3 = new DevExpress.XtraEditors.SimpleButton();
            this.plAttachZone = new SAF.Framework.Controls.PanelBasic();
            this.txbAttach = new SAF.Framework.Controls.AttachMessageBox();
            this.plButtonsZone.SuspendLayout();
            this.plAttachZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbAttach.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.White;
            this.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMsg.Icon = null;
            this.lbMsg.Location = new System.Drawing.Point(0, 0);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Padding = new System.Windows.Forms.Padding(21, 18, 21, 18);
            this.lbMsg.Size = new System.Drawing.Size(426, 94);
            this.lbMsg.TabIndex = 0;
            // 
            // plButtonsZone
            // 
            this.plButtonsZone.Controls.Add(this.ckbToggle);
            this.plButtonsZone.Controls.Add(this.button1);
            this.plButtonsZone.Controls.Add(this.button2);
            this.plButtonsZone.Controls.Add(this.button3);
            this.plButtonsZone.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtonsZone.Location = new System.Drawing.Point(0, 94);
            this.plButtonsZone.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.plButtonsZone.Name = "plButtonsZone";
            this.plButtonsZone.Size = new System.Drawing.Size(426, 36);
            this.plButtonsZone.TabIndex = 1;
            // 
            // ckbToggle
            // 
            this.ckbToggle.Location = new System.Drawing.Point(10, 8);
            this.ckbToggle.Name = "ckbToggle";
            this.ckbToggle.Size = new System.Drawing.Size(95, 27);
            this.ckbToggle.TabIndex = 3;
            this.ckbToggle.Text = "详细信息(&D)";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(149, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 27);
            this.button1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(240, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 27);
            this.button2.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(331, 8);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 27);
            this.button3.TabIndex = 2;
            // 
            // plAttachZone
            // 
            this.plAttachZone.Controls.Add(this.txbAttach);
            this.plAttachZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plAttachZone.Location = new System.Drawing.Point(0, 0);
            this.plAttachZone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plAttachZone.Name = "plAttachZone";
            this.plAttachZone.Size = new System.Drawing.Size(426, 130);
            this.plAttachZone.TabIndex = 2;
            this.plAttachZone.Visible = false;
            // 
            // txbAttach
            // 
            this.txbAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAttach.Location = new System.Drawing.Point(10, 7);
            this.txbAttach.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txbAttach.Name = "txbAttach";
            this.txbAttach.Properties.ReadOnly = true;
            this.txbAttach.Size = new System.Drawing.Size(406, 121);
            this.txbAttach.TabIndex = 0;
            this.txbAttach.UseOptimizedRendering = true;
            // 
            // MessageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(426, 147);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.plButtonsZone);
            this.Controls.Add(this.plAttachZone);
            this.DoubleBuffered = true;
            this.Name = "MessageForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 17);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.plButtonsZone.ResumeLayout(false);
            this.plAttachZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txbAttach.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ToggleButton ckbToggle;
        private AttachMessageBox txbAttach;
        private MessageViewer lbMsg;
        private SimpleButton button2;
        private SimpleButton button1;
        private PanelBasic plButtonsZone;
        private PanelBasic plAttachZone;
        private SimpleButton button3;

        /// <summary>
        /// 最大默认窗体客户区宽度
        /// </summary>
        const int MaxClientWidth = 700;

        int expandHeight;
        /// <summary>
        /// 详细信息区展开高度
        /// </summary>
        private int ExpandHeight
        {
            get { return expandHeight < 150 ? 150 : expandHeight; }
            set { expandHeight = value; }
        }

        /// <summary>
        /// 消息按钮
        /// </summary>
        private MessageBoxButtons MessageButtons { get; set; }

        /// <summary>
        /// 消息图标
        /// </summary>
        private MessageBoxIcon MessageIcon { get; set; }

        /// <summary>
        /// 默认按钮
        /// </summary>
        private MessageBoxDefaultButton DefaultButton { get; set; }

        /// <summary>
        /// 创建消息窗体
        /// </summary>
        private MessageForm()
        {
            InitializeComponent();
            this.StartPosition = Form.ActiveForm == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;
            this.Font = SystemFonts.MessageBoxFont;

            //注册事件
            this.button1.Click += button_Click;
            this.button2.Click += button_Click;
            this.button3.Click += button_Click;
            this.plAttachZone.Resize += plAttachZone_Resize;

            this.ckbToggle.Click += ckbToggle_CheckedChanged;
        }

        /// <summary>
        /// 创建消息窗体
        /// </summary>
        public MessageForm(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, string attachMessage)
            : this()
        {
            this.lbMsg.Text = message;
            this.Text = caption;
            this.txbAttach.Text = attachMessage;
            this.MessageButtons = buttons;
            this.MessageIcon = icon;
            this.DefaultButton = defaultButton;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            //须在计算各种尺寸前搞掂
            ProcessIcon();
            ProcessButtons();

            this.MinimumSize = SizeFromClientSize(new Size(GetPanelButtonMinWidth(), GetClientMinHeight()));

            //参数意义定为客户区最大大小，所以需刨掉非客户区高度后传入
            this.ClientSize = this.GetPreferredSize(new Size(MaxClientWidth, Screen.PrimaryScreen.WorkingArea.Height - (this.Height - this.ClientSize.Height)));

            base.OnLoad(e);
        }

        protected override void OnShown(EventArgs e)
        {
            //设置默认按钮焦点。须在OnShown中设置按钮焦点才有用
            Button dfBtn;
            if ((dfBtn = this.AcceptButton as Button) != null)
            {
                dfBtn.Focus();
            }

            //播放消息提示音
            PlayMessageSound(this.MessageIcon);

            base.OnShown(e);
        }

        //重写窗体参数
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams prms = base.CreateParams;

                if ((Convert.ToInt32(this.MessageButtons) & 1) == 0) //没有Cancel按钮时屏蔽关闭按钮，刚好在偶数项
                {
                    prms.ClassStyle |= 0x200;
                }

                return prms;
            }
        }

        /// <summary>
        /// 计算合适的窗口尺寸
        /// </summary>
        /// <param name="proposedSize">该参数此处定义为客户区可设置的最大尺寸</param>
        public override Size GetPreferredSize(Size proposedSize)
        {
            int reservedHeight = plButtonsZone.Height + Padding.Bottom;
            Size size = lbMsg.GetPreferredSize(new Size(proposedSize.Width, proposedSize.Height - reservedHeight));
            size.Height += reservedHeight;
            return size;
        }

        //展开收起
        private void ckbToggle_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();

            if (ckbToggle.Checked)
            {
                plButtonsZone.SendToBack();
                lbMsg.SendToBack();

                lbMsg.Dock = DockStyle.Top;
                plButtonsZone.Dock = DockStyle.Top;

                ChangeFormHeight(ExpandHeight);
                plAttachZone.Visible = true;
            }
            else
            {
                ExpandHeight = plAttachZone.Height;//记忆展开高度
                plAttachZone.Visible = false;
                ChangeFormHeight(-ExpandHeight);

                plButtonsZone.SendToBack();

                plButtonsZone.Dock = DockStyle.Bottom;
                lbMsg.Dock = DockStyle.Fill;
            }

            this.ResumeLayout();
        }

        //按钮事件
        private void button_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)((sender as SimpleButton).Tag);
        }

        //用户手工收完详细区则触发折叠
        private void plAttachZone_Resize(object sender, EventArgs e)
        {
            if (ckbToggle.Checked && plAttachZone.Height == 0)
            {
                ckbToggle.Checked = false;
            }
        }

        /// <summary>
        /// 处理按钮相关
        /// </summary>
        private void ProcessButtons()
        {
            this.ckbToggle.Visible = txbAttach.Text.Trim().Length != 0; //无详细信息就不显示展开按钮

            int btnCount = 3; //按钮数量

            switch (MessageButtons) //老实用case，可读点
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    button1.Text = "中止(&A)";
                    button1.Tag = DialogResult.Abort;
                    button2.Text = "重试(&R)";
                    button2.Tag = DialogResult.Retry;
                    button3.Text = "忽略(&I)";
                    button3.Tag = DialogResult.Ignore;
                    break;
                case MessageBoxButtons.OK:
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Text = "确定";
                    button3.Tag = DialogResult.OK;
                    btnCount = 1;
                    break;
                case MessageBoxButtons.OKCancel:
                    button1.Visible = false;
                    button2.Text = "确定";
                    button2.Tag = DialogResult.OK;
                    button3.Text = "取消";
                    button3.Tag = DialogResult.Cancel;
                    btnCount = 2;
                    break;
                case MessageBoxButtons.RetryCancel:
                    button1.Visible = false;
                    button2.Text = "重试(&R)";
                    button2.Tag = DialogResult.Retry;
                    button3.Text = "取消";
                    button3.Tag = DialogResult.Cancel;
                    btnCount = 2;
                    break;
                case MessageBoxButtons.YesNo:
                    button1.Visible = false;
                    button2.Text = "是(&Y)";
                    button2.Tag = DialogResult.Yes;
                    button3.Text = "否(&N)";
                    button3.Tag = DialogResult.No;
                    btnCount = 2;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    button1.Text = "是(&Y)";
                    button1.Tag = DialogResult.Yes;
                    button2.Text = "否(&N)";
                    button2.Tag = DialogResult.No;
                    button3.Text = "取消";
                    button3.Tag = DialogResult.Cancel;
                    break;
                default:
                    break;
            }

            //仅有OK和有取消按钮时设CancelButton
            if ((int)MessageButtons == 0 || ((int)MessageButtons & 1) == 1)
            {
                this.CancelButton = button3;
            }

            //处理默认按钮
            if (btnCount == 1)
            {
                this.AcceptButton = button3;
            }
            else if (btnCount == 2)
            {
                this.AcceptButton = DefaultButton == MessageBoxDefaultButton.Button2 ? button3 : button2;
            }
            else
            {
                SimpleButton[] btnArray = { button1, button2, button3 };
                this.AcceptButton = btnArray[Convert.ToInt32(DefaultButton) / 0x100];
            }
        }

        /// <summary>
        /// 处理图标
        /// </summary>
        /// <remarks>之所以不在此处顺便把Sound处理了是为了松耦合</remarks>
        private void ProcessIcon()
        {
            switch (MessageIcon)
            {
                //MessageBoxIcon.Information同样
                case MessageBoxIcon.Asterisk:
                    lbMsg.Icon = SystemIcons.Information;
                    break;

                //MessageBoxIcon.Hand、MessageBoxIcon.Stop同样
                case MessageBoxIcon.Error:
                    lbMsg.Icon = SystemIcons.Error;
                    break;

                //MessageBoxIcon.Warning同样
                case MessageBoxIcon.Exclamation:
                    lbMsg.Icon = SystemIcons.Warning;
                    break;

                case MessageBoxIcon.Question:
                    lbMsg.Icon = SystemIcons.Question;
                    break;

                default:
                    lbMsg.Icon = null;
                    break;
            }
        }

        /// <summary>
        /// 计算窗体客户区最小高度
        /// </summary>
        private int GetClientMinHeight()
        {
            return lbMsg.MinimumHeight + plButtonsZone.Height + Padding.Bottom;
        }

        /// <summary>
        /// 计算按钮区最小宽度
        /// </summary>
        private int GetPanelButtonMinWidth()
        {
            int r = 20 /*左右Padding*/, visibleCount = -1 /*因为两个以上才会有间距*/;
            if (ckbToggle.Visible)
            {
                r += ckbToggle.Width;
                visibleCount++;
            }
            if (button1.Visible)
            {
                r += button1.Width * 3;
                visibleCount += 3;
            }
            else if (button2.Visible)
            {
                r += button2.Width * 2;
                visibleCount += 2;
            }
            else
            {
                r += button3.Width;
                visibleCount++;
            }

            if (visibleCount != -1)
            {
                r += visibleCount * 6;
            } //按钮间距

            if (string.IsNullOrWhiteSpace(this.txbAttach.Text))
                return r;

            return Math.Max(r, 400);
        }

        /// <summary>
        /// 改变窗体高度。内部有动画处理
        /// </summary>
        /// <param name="increment">增量（负数即为减小高度）</param>
        private void ChangeFormHeight(int increment)
        {
            int finalHeight = this.Height + increment; //正确的目标高度

            const int step = 8; //帧数

            for (int i = 0; i < step; i++)
            {
                if (i == step - 1) //最后一步直达目标
                {
                    this.Height = finalHeight;
                    return;
                }

                this.Height += increment / step;

                Application.DoEvents(); //必要
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// 播放系统事件声音
        /// </summary>
        /// <remarks>之所以不用MessageBeep API是因为这货在NT6上不出声，所以用PlaySound代替</remarks>
        private static void PlayMessageSound(MessageBoxIcon msgType)
        {
            string eventString;
            switch (msgType)
            {
                case MessageBoxIcon.None:
                    eventString = "SystemDefault";
                    break;

                //Question原本是没声音的，此实现让它蹭一下Information的
                case MessageBoxIcon.Question:

                //MessageBoxIcon.Information同样
                case MessageBoxIcon.Asterisk:
                    eventString = "SystemAsterisk";
                    break;

                //MessageBoxIcon.Hand、MessageBoxIcon.Stop同样
                case MessageBoxIcon.Error:
                    eventString = "SystemHand";
                    break;

                //MessageBoxIcon.Warning同样
                case MessageBoxIcon.Exclamation:
                    eventString = "SystemExclamation";
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            PlaySound(eventString, IntPtr.Zero, 0x10000 /*SND_ALIAS*/| 0x1 /*SND_ASYNC*/);
        }

        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern bool PlaySound([MarshalAs(UnmanagedType.LPWStr)] string soundName, IntPtr hmod, int soundFlags);

    }
}
