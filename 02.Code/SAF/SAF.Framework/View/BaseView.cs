﻿using System;
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
                string message = "确定要关闭\"{0}\"吗?{1}关闭操作将丢弃所有未更改的保存.".FormatWith(this.Text, Environment.NewLine);
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
        /// <summary>
        /// 全局初始化
        /// </summary>
        public void Init()
        {
            if (this.DesignMode) return;

            OnInitViewParam();
            OnInitCommonBill();
            OnInitBillRight();
            OnGenarateCustomRibbonMenu();
            OnInitReport();
            OnInitConfig();
            OnInitUI();
            OnInitEvent();
            OnInitQueryConfig();
            OnInitData();
            OnInitBinding();
            OnInitShortCut();
            OnAfterInit();
            RefreshUI();
        }

        /// <summary>
        /// 初始化报表
        /// </summary>
        protected virtual void OnInitReport()
        {

        }

        /// <summary>
        /// 初始化通用单据
        /// </summary>
        protected virtual void OnInitCommonBill()
        {

        }
        /// <summary>
        /// 初始化结束后
        /// </summary>
        protected virtual void OnAfterInit()
        {

        }
        /// <summary>
        /// 初始化单据权限
        /// </summary>
        protected virtual void OnInitBillRight()
        {

        }
        /// <summary>
        /// 初始化菜单参数
        /// </summary>
        protected virtual void OnInitViewParam()
        {

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
        protected virtual void OnInitShortCut()
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
        protected void OnGenarateCustomRibbonMenu()
        {
            OnInitCustomRibbonMenuCommands(this.CustomRibbonMenuCommands);
            OnGenarateCustomRibbonMenuButtons();
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
        /// 刷新界面
        /// </summary>
        public void RefreshUI()
        {
            OnRefreshUI();

            OnRefreshRibbonMenu();

            OnRefreshCustomRibbonMenu();

            OnRefreshDetailToolBar();

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
            if (this.Ribbon == null) return;

            var systemPage = this.Ribbon.Pages.GetPageByName("systemPage");
            if (systemPage == null)
            {
                LoggingService.Error("BaseView.OnRefreshCustomRibbonMenu处方法GetPageByName未找到systemPage");
                return;
            }

            var GroupCustom = systemPage.GetGroupByName("groupCustom");
            if (GroupCustom == null)
            {
                LoggingService.Error("BaseView.OnRefreshCustomRibbonMenu处方法GetGroupByName未找到groupCustom");
                return;
            }

            if (GroupCustom != null)
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

        /// <summary>
        /// 标题
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
                return this.ViewModel == null ? false : this.ViewModel.EditState.In(EditState.AddNew, EditState.Edit);
            }
        }

        /// <summary>
        /// 视图对应的菜单ID
        /// </summary>
        [Browsable(false)]
        public object UniqueId
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
        /// 提交界面数据
        /// </summary>
        public void PostUIData()
        {
            //SendKeys.Send("{TAB}");
            if (!this.SelectNextControl(ActiveControl, true, true, true, true))
                if (!this.SelectNextControl(ActiveControl, false, true, true, true))
                    if (!this.SelectNextControl(ActiveControl, false, true, false, true))
                        this.SelectNextControl(ActiveControl, true, true, false, true);

            OnPostUIData();
        }
        /// <summary>
        /// 提交界面编辑的数据.
        /// </summary>
        protected virtual void OnPostUIData()
        {

        }
        /// <summary>
        /// 单据类型ID
        /// </summary>
        [Browsable(false)]
        public int BillTypeId
        {
            get { return ViewModel == null ? 0 : ViewModel.BillTypeId; }
        }

        protected virtual string CalcCondition(string condition)
        {
            return condition.IsEmpty() ? NullCondition : condition;
        }
        /// <summary>
        /// 空条件
        /// </summary>
        [Browsable(false)]
        public virtual string NullCondition
        {
            get { return " (1=1) "; }
        }

        public virtual ParameterDictionary OutParameters
        {
            get
            {
                return new ParameterDictionary(this.ViewParameters);
            }
        }

        #region 界面参数

        private ParameterDictionary _viewParameters = new ParameterDictionary();

        public ParameterDictionary ViewParameters
        {
            get { return _viewParameters; }
            set { _viewParameters = value; }
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

        private RibbonMenuCommandCollection CustomRibbonMenuCommands = new RibbonMenuCommandCollection();

        private Dictionary<BarButtonItem, IRibbonMenuCommand> buttons = new Dictionary<BarButtonItem, IRibbonMenuCommand>();

        protected virtual void OnInitCustomRibbonMenuCommands(RibbonMenuCommandCollection commands)
        {

        }

        protected void OnGenarateCustomRibbonMenuButtons()
        {
            if (this.CustomRibbonMenuCommands == null || CustomRibbonMenuCommands.Count <= 0) return;
            if (this.Ribbon == null) return;

            var systemPage = this.Ribbon.Pages.GetPageByName("systemPage");
            if (systemPage == null) return;

            var GroupCustom = systemPage.GetGroupByName("groupCustom");
            if (GroupCustom == null) return;

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
                GroupCustom.ItemLinks.Add(btn, item.BeginGroup);

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
