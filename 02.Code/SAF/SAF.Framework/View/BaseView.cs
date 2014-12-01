using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SAF.Framework.View;
using SAF.Framework.ViewModel;
using SAF.Foundation;
using SAF.EntityFramework;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using SAF.Framework.Controls;
using SAF.Foundation.ServiceModel;

namespace SAF.Framework.View
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class BaseView : XtraUserControl, IBaseView
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseView()
        {
            InitializeComponent();

            this.Closing += BaseView_Closing;
        }

        void BaseView_Closing(object sender, FormClosingEventArgs e)
        {
            if (this.IsDirty && e.CloseReason == CloseReason.UserClosing)
            {
                string message = "确定要关闭\"{0}\"吗?{1}关闭操作将丢弃所有未更改的保存.".FormatEx(this.Text, Environment.NewLine);
                var result = MessageService.AskQuestion(message);
                if (!result)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
        }

        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(1);
            }
        }

        #region 初始化

        public virtual Control AccessFocusControl { get; set; }

        public void Init()
        {
            if (this.DesignMode) return;

            OnInitViewParam();
            OnInitBillRight();
            GenarateCustomRibbonMenu();
            OnInitConfig();
            OnInitUI();
            OnInitEvent();
            OnInitQueryConfig();
            OnInitData();
            OnInitBinding();
            OnInitDefaultActions();
            OnAfterInit();
            RefreshUI();
        }

        protected virtual void OnAfterInit()
        {

        }

        protected virtual void OnInitBillRight()
        {

        }

        protected virtual void OnInitViewParam()
        {
            var es = new EntitySet<QueryEntity>();
            es.Query("SELECT Name,[Value] FROM  [dbo].[sysMenuParam] with(nolock) WHERE [MenuId]=:MenuId", this.UniqueId);
            if (es.IsNotEmpty())
            {
                foreach (var entity in es)
                {
                    if (entity.GetFieldValue<string>("Value").IsNotEmpty())
                        this.SetViewParam(entity.GetFieldValue<string>("Name"), entity.GetFieldValue<string>("Value"));
                }
            }
        }

        #endregion

        #region ProcessDialogKey

        private Dictionary<Keys, IAction> defaultActions = new Dictionary<Keys, IAction>();

        public void AddAction(Keys key, IAction action)
        {
            defaultActions[key] = action;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return ExecuteDialogKey(keyData) || base.ProcessCmdKey(ref msg, keyData);
        }

        private bool ExecuteDialogKey(Keys keyData)
        {
            IAction action = GetAction(keyData);

            if (action != null)
            {
                action.Execute(this);
                return true;
            }
            return false;
        }

        private bool IsAction(Keys keyData)
        {
            return defaultActions.ContainsKey(keyData);
        }

        private IAction GetAction(Keys keyData)
        {
            if (!IsAction(keyData))
            {
                return null;
            }
            return (IAction)defaultActions[keyData];
        }

        /// <summary>
        /// 初始化快捷键事件
        /// </summary>
        protected virtual void OnInitDefaultActions()
        {
        }

        #endregion

        /// <summary>
        /// 初始化查询组件
        /// </summary>
        protected virtual void OnInitQueryConfig()
        {

        }
        /// <summary>
        /// 添加主菜单项
        /// </summary>
        protected void GenarateCustomRibbonMenu()
        {
            OnInitCustomRibbonMenuCommands();
            GenarateCustomRibbonMenuButtons();
        }
        /// <summary>
        /// 将焦点定位到输入控件
        /// </summary>
        public virtual bool FocusFirstEditControl()
        {
            if (this.AccessFocusControl != null)
                return this.AccessFocusControl.Focus();
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshUI()
        {
            OnRefreshRibbonMenu();

            OnRefreshCustomRibbonMenu();

            OnRefreshDetailToolBar();

            OnRefreshUI();

            FocusFirstEditControl();
        }
        /// <summary>
        /// 刷新明细的工具栏
        /// </summary>
        protected virtual void OnRefreshDetailToolBar()
        {

        }
        /// <summary>
        /// 刷新界面控件
        /// </summary>
        protected virtual void OnRefreshUI()
        {

        }
        /// <summary>
        /// 刷新菜单
        /// </summary>
        protected virtual void OnRefreshRibbonMenu()
        {

        }

        /// <summary>
        /// 刷新自定义按钮
        /// </summary>
        protected virtual void OnRefreshCustomRibbonMenu()
        {
            if (this.GroupCustom != null)
            {
                if (this.buttons != null && this.buttons.Count > 0)
                {
                    GroupCustom.Visible = true;
                    GroupCustom.Enabled = true;
                    foreach (var item in this.buttons)
                    {
                        UIController.RefreshControl(item.Key, item.Value.CanExecute(item.Key));
                    }
                }
                else
                {
                    GroupCustom.Visible = false;
                    GroupCustom.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        protected virtual void OnInitData()
        {

        }
        /// <summary>
        /// 初始化绑定
        /// </summary>
        protected virtual void OnInitBinding()
        {

        }
        /// <summary>
        /// 初始化UI
        /// </summary>
        protected virtual void OnInitUI()
        {

        }
        /// <summary>
        /// 初始化配置
        /// </summary>
        protected virtual void OnInitConfig()
        {

        }
        /// <summary>
        /// 初始化事件
        /// </summary>
        protected virtual void OnInitEvent()
        {

        }


        [Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// 关闭时是否需要提示
        /// </summary>
        [Browsable(false)]
        public virtual bool IsDirty
        {
            get
            {
                return this.ViewModel == null ? false : this.ViewModel.EditStatus.In(EditStatus.AddNew, EditStatus.Edit);
            }
        }

        /// <summary>
        /// 视图唯一ID
        /// </summary>
        [Browsable(false)]
        public int UniqueId
        {
            get;
            set;
        }

        private volatile IBaseViewViewModel _viewModel = null;
        [Browsable(false)]
        public virtual IBaseViewViewModel ViewModel
        {
            get
            {
                if (_viewModel == null)
                {
                    _viewModel = OnCreateViewModel();
                    if (_viewModel != null)
                    {
                        _viewModel.UniqueId = this.UniqueId;
                    }
                }
                return _viewModel;
            }
        }

        protected virtual IBaseViewViewModel OnCreateViewModel()
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        public void PostUIData()
        {
            SendKeys.Send("{TAB}");

            OnPostUIData();
        }
        /// <summary>
        /// 提交界面编辑的数据.
        /// </summary>
        protected virtual void OnPostUIData()
        {

        }

        [Browsable(false)]
        [ViewParam("单据类型")]
        public virtual int BillTypeId
        {
            get { return Convert.ToInt32(this.GetViewParam("BillTypeId")); }
            set { this.SetViewParam("BillTypeId", value.ToString()); }
        }

        protected virtual string CalcCondition(string condition)
        {
            return condition.IsEmpty() ? NullCondition : condition;
        }

        [Browsable(false)]
        public virtual string NullCondition
        {
            get { return " (1=1) "; }
        }

        #region 界面参数

        private Dictionary<string, string> viewParams = new Dictionary<string, string>();
        /// <summary>
        /// 添加界面参数,如果存在则更新,不存在则新增
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public virtual void SetViewParam(string name, string value)
        {
            if (this.viewParams.ContainsKey(name))
                this.viewParams[name] = value;
            else
                this.viewParams.Add(name, value);
        }
        /// <summary>
        /// 获取界面参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual string GetViewParam(string name)
        {
            if (this.viewParams.ContainsKey(name))
                return this.viewParams[name];
            return null;
        }

        #endregion

        #region CustomRibbonMenu

        [Browsable(false)]
        public virtual RibbonControl Ribbon
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 自定义菜单分组
        /// </summary>
        [Browsable(false)]
        public virtual RibbonPageGroup GroupCustom
        {
            get
            {
                return null;
            }
        }

        private List<IRibbonMenuCommand> CustomRibbonMenuCommands = new List<IRibbonMenuCommand>();

        private Dictionary<BarButtonItem, IRibbonMenuCommand> buttons = new Dictionary<BarButtonItem, IRibbonMenuCommand>();

        protected void AddRibbonMenuCommand(IRibbonMenuCommand cmd)
        {
            CustomRibbonMenuCommands.Add(cmd);
        }

        protected virtual void OnInitCustomRibbonMenuCommands()
        {

        }

        protected void GenarateCustomRibbonMenuButtons()
        {
            if (this.CustomRibbonMenuCommands == null || CustomRibbonMenuCommands.Count <= 0) return;

            if (this.Ribbon == null || this.GroupCustom == null) return;

            foreach (var item in CustomRibbonMenuCommands)
            {
                BarButtonItem btn = new BarButtonItem();
                btn.Caption = item.Caption;
                btn.ItemShortcut = item.ItemShortcut;
                btn.LargeGlyph = item.LargeGlyph;
                btn.Glyph = item.Glyph;
                if (item.DropDownControl != null)
                {
                    btn.ButtonStyle = BarButtonStyle.DropDown;
                    btn.DropDownControl = item.DropDownControl;
                }
                btn.ItemClick += (sender, args) =>
                {
                    item.Execute(btn);
                };

                this.Ribbon.Items.Add(btn);
                this.GroupCustom.ItemLinks.Add(btn, item.BeginGroup);

                buttons.Add(btn, item);
            }
        }
        #endregion

        #region 事件

        private static readonly object EventShown;
        private static readonly object EventClosed;
        private static readonly object EventClosing;

        static BaseView()
        {
            BaseView.EventClosed = new object();
            BaseView.EventClosing = new object();
            BaseView.EventShown = new object();
        }

        public virtual void Close()
        {
            var frm = this.FindForm();
            if (frm != null)
                frm.Close();
        }

        public event FormClosedEventHandler Closed
        {
            add { base.Events.AddHandler(BaseView.EventClosed, value); }
            remove { base.Events.RemoveHandler(BaseView.EventClosed, value); }
        }

        public void OnClosed(FormClosedEventArgs args)
        {
            var handler = (FormClosedEventHandler)base.Events[BaseView.EventClosed];
            if (handler != null)
                handler(this, args);
        }

        public event FormClosingEventHandler Closing
        {
            add { base.Events.AddHandler(BaseView.EventClosing, value); }
            remove { base.Events.RemoveHandler(BaseView.EventClosing, value); }
        }

        public void OnClosing(FormClosingEventArgs args)
        {
            var handler = (FormClosingEventHandler)base.Events[BaseView.EventClosing];
            if (handler != null)
                handler(this, args);
        }

        public event EventHandler Shown
        {
            add { base.Events.AddHandler(BaseView.EventShown, value); }
            remove { base.Events.RemoveHandler(BaseView.EventShown, value); }
        }

        public void OnShown()
        {
            var handler = (EventHandler)base.Events[BaseView.EventShown];
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion

    }
}
