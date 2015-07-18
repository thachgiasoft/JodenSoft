using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using SAF.Framework.ViewModel;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.Framework.Controls;
using DevExpress.XtraBars;
using SAF.EntityFramework;

namespace SAF.Framework.View
{
    [ToolboxItem(false)]
    public partial class SingleView : BusinessView, ISingleView
    {
        public SingleView()
        {
            InitializeComponent();
        }

        protected override void OnInitQueryConfig()
        {
            base.OnInitQueryConfig();
            if (this.ViewModel != null)
            {
                this.ViewModel.InitQueryConfig();
                this.qcMain.Init(this.ViewModel.QueryConfig);
            }
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();
            this.ribbonMain.Visible = false;
        }

        protected override void OnInitViewParam()
        {
            base.OnInitViewParam();

            var es = new EntitySet<QueryEntity>();

            if (DataPortal.TableIsExists(es.ConnectionName, "[dbo].[sysMenuParam]"))
            {
                es.Query("SELECT Name,[Value] FROM [dbo].[sysMenuParam] with(nolock) WHERE [MenuId]=:MenuId", this.UniqueId);
                if (!es.IsEmpty())
                {
                    foreach (var entity in es)
                    {
                        this.ViewParameters[entity.GetFieldValue<string>("Name")] = entity.GetFieldValue<string>("Value");
                    }
                }
            }
        }

        public override SAF.Framework.View.ParameterDictionary OutParameters
        {
            get
            {
                if (this.ViewModel != null && this.ViewModel.MainEntitySet.Count > 0)
                    base.OutParameters.Copy(this.ViewModel.MainEntitySet.CurrentEntity);
                return base.OutParameters;
            }
        }

        void pageControlMain_PageIndexChanged(object sender, EventArgs e)
        {
            var condition = pcMain.GetQueryArgs(QueryArgs_Condition).ToStringEx();
            var args = pcMain.GetQueryArgs(QueryArgs_Args) as object[];
            this.Query(condition, args);
        }

        public override RibbonControl Ribbon
        {
            get
            {
                return this.ribbonMain;
            }
        }

        public override RibbonPageGroup GroupCustom
        {
            get
            {
                return this.groupCustom;
            }
        }

        public virtual string InitCondition
        {
            get { return "1=2"; }
        }

        #region Button Actions

        private void bbiAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddNew();
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Edit();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void bbiCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cancel();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete();
        }

        private void bbiSend_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.bbiSend.Tag.ToStringEx() == "SendToAudit")
                SendToAudit();
            else
                UnSendToAudit();
        }

        private void bbiExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        #endregion

        #region ISingleView

        /// <summary>
        /// 新增
        /// </summary>
        public void AddNew()
        {
            OnAddNew();
            RefreshUI();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public void Edit()
        {
            if (!AllowEdit()) return;

            OnEdit();
            RefreshUI();
        }

        protected virtual bool AllowEdit()
        {
            if (ViewModel != null)
                return ViewModel.AllowEdit();
            return true;
        }

        /// <summary>
        /// 取消
        /// </summary>
        public void Cancel()
        {
            OnCancel();
            RefreshUI();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
        {
            if (!AllowDelete()) return;

            if (MessageService.AskQuestionFormatted("确定要删除选中的数据吗?{0}删除后将无法恢复.", Environment.NewLine))
            {
                OnDelete();
                IndexRowChange();
                RefreshUI();
            }
        }

        protected virtual bool AllowDelete()
        {
            if (ViewModel != null)
                return ViewModel.AllowDelete();
            return true;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            PostUIData();
            try
            {
                var bSaveSuccess = OnSave();
                RefreshUI();

                OnAfterSave(bSaveSuccess);

                if (bSaveSuccess)
                    MessageService.ShowMessage("保存成功!");
            }
            catch (Exception ex)
            {
                throw new SaveException("保存失败!", ex);
            }
        }
        /// <summary>
        /// 界面保存后事件
        /// </summary>
        /// <param name="bSaveSuccess"></param>
        protected virtual void OnAfterSave(bool bSaveSuccess)
        {

        }

        protected override void OnPostUIData()
        {
            base.OnPostUIData();

            if (this.ViewModel != null)
                this.ViewModel.EndEdit();
        }

        /// <summary>
        /// 高级查询
        /// </summary>
        public void AdvancedSearch()
        {
            OnAdvancedSearch();
            RefreshUI();
        }

        /// <summary>
        /// 选择所有
        /// </summary>
        public void SelectAll()
        {
            OnSelectAll();
        }

        /// <summary>
        /// 取消选择
        /// </summary>
        public void CancelSelect()
        {
            OnCancelSelect();
        }

        /// <summary>
        /// 反选
        /// </summary>
        public void ReverseSelect()
        {
            OnReverseSelect();
        }
        /// <summary>
        /// 送审
        /// </summary>
        public void SendToAudit()
        {
            OnSendToAudit();
            RefreshUI();
        }
        /// <summary>
        /// 取消送审
        /// </summary>
        public void UnSendToAudit()
        {
            OnUnSendToAudit();
            RefreshUI();
        }

        #endregion

        #region protected virtual Methods

        protected virtual void OnAddNew()
        {
            if (this.ViewModel != null)
            {
                ViewModel.AddNew();
            }
        }

        protected virtual void OnEdit()
        {
            if (this.ViewModel != null)
            {
                ViewModel.Edit();
            }
        }

        protected virtual void OnBeforeSave()
        {
        }

        protected virtual bool OnSave()
        {
            if (ViewModel != null)
            {
                var result = ViewModel.Save();
                RefreshPageControl();
                return result;
            }

            return false;
        }

        protected virtual void OnDelete()
        {
            if (ViewModel != null)
                ViewModel.Delete();
        }

        public void RefreshPageControl()
        {
            this.pcMain.CurrentPageIndex = this.ViewModel.IndexEntitySet.CurrentPageIndex;
            this.pcMain.TotalPageCount = this.ViewModel.IndexEntitySet.TotalPageCount;
            this.pcMain.TotalRecordCount = this.ViewModel.IndexEntitySet.TotalRecordCount;
        }

        protected virtual void OnCancel()
        {
            if (ViewModel != null)
                ViewModel.Cancel();
        }

        protected virtual void OnAdvancedSearch()
        {

        }

        protected virtual void OnSelectAll()
        {

        }

        protected virtual void OnCancelSelect()
        {

        }

        protected virtual void OnReverseSelect()
        {

        }

        public void IndexRowChange()
        {
            if (ViewModel == null) return;

            OnIndexRowChange();
            RefreshUI();
        }

        protected virtual void OnIndexRowChange()
        {
            if (ViewModel == null) return;

            if (!ViewModel.IndexEntitySet.IsBusy)
            {
                var key = ViewModel.IndexEntitySet.CurrentKey;
                ViewModel.QueryChild(key);
            }
        }
        /// <summary>
        /// 送审
        /// </summary>
        protected virtual void OnSendToAudit()
        {
            if (ViewModel == null) return;

            if (this.IsAddNew || this.IsEdit)
            {
                MessageService.ShowError("编辑模式下不能 送审 单据,请先提交数据或撤消更改.");
                return;
            }

            try
            {
                if (!MessageService.AskQuestion("确定要 送审 单据码?")) return;

                ViewModel.SendToAudit();
                MessageService.ShowMessage("送审成功.");
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex, "送审失败!");
            }
        }
        /// <summary>
        /// 取消送审
        /// </summary>
        protected virtual void OnUnSendToAudit()
        {
            if (ViewModel == null) return;

            if (this.IsAddNew || this.IsEdit)
            {
                MessageService.ShowError("编辑模式下不能 取消送审 单据,请先提交数据或撤消更改.");
                return;
            }

            try
            {
                if (!MessageService.AskQuestion("确定要 取消送审 单据码?")) return;

                ViewModel.SendToAudit();
                MessageService.ShowMessage("取消送审成功.");
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex, "取消送审失败!");
            }

        }

        #endregion

        protected new ISingleViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as ISingleViewViewModel;
            }
        }

        protected override void OnInitEvent()
        {
            base.OnInitEvent();

            this.pcMain.PageIndexChanged += pageControlMain_PageIndexChanged;
            this.qcMain.Query += qcMain_Query;

            if (this.ViewModel != null)
            {
                this.ViewModel.AfterSave += (sender, args) =>
                {
                    RefreshPageControl();
                };
            }
        }

        void qcMain_Query(object sender, Controls.QueryEventArgs e)
        {
            this.pcMain.CurrentPageIndex = 1;
            this.Query(e.Conditions);
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();

            if (this.ViewModel != null)
            {
                this.ViewModel.IndexEntitySet.SetBindingSource(this.bsIndex);
                this.ViewModel.MainEntitySet.SetBindingSource(this.bsMain);
            }
        }

        protected override void OnInitData()
        {
            base.OnInitData();

            this.Query(this.InitCondition);
        }


        /// <summary>
        /// 是否浏览状态
        /// </summary>
        protected bool IsBrowse
        {
            get { return this.ViewModel == null ? false : this.ViewModel.EditState == EditState.Browse; }
        }
        /// <summary>
        /// 是否新增状态
        /// </summary>
        protected bool IsAddNew
        {
            get { return this.ViewModel == null ? false : this.ViewModel.EditState == EditState.AddNew; }
        }
        /// <summary>
        /// 是否编辑状态
        /// </summary>
        protected bool IsEdit
        {
            get { return this.ViewModel == null ? false : this.ViewModel.EditState == EditState.Edit; }
        }

        protected override void OnRefreshRibbonMenu()
        {
            base.OnRefreshRibbonMenu();
            if (ViewModel == null) return;

            int count = this.ViewModel.MainEntitySet.Count;

            var operateRight = this.ViewModel.MainEntitySet.BillOperateRight;
            var curr = this.ViewModel.MainEntitySet.CurrentEntity;
            var dataRight = curr == null ? BillDataRight.None : curr.BillDataRight;

            bool canAddNew = operateRight.IncludeEnum(BillOperateRight.AddNew);
            bool canEdit = dataRight.IncludeEnum(BillDataRight.Edit);
            bool canDelete = dataRight.IncludeEnum(BillDataRight.Delete);
            bool canPreview = dataRight.IncludeEnum(BillDataRight.Print);

            bool canSendToAudit = dataRight.IncludeEnum(BillDataRight.SendToAudit);

            UIController.RefreshControl(this.bbiAddNew, IsBrowse && canAddNew);
            UIController.RefreshControl(this.bbiEdit, IsBrowse && count > 0 && canEdit);
            UIController.RefreshControl(this.bbiDelete, IsBrowse && count > 0 && canDelete);
            UIController.RefreshControl(this.bbiCancel, IsAddNew || IsEdit);
            UIController.RefreshControl(this.bbiSave, IsAddNew || IsEdit);

            UIController.RefreshControl(this.bbiSend, IsBrowse && this.BillTypeId > 0 && curr != null && canSendToAudit && curr.BillState == BillState.Draft);

            UIController.RefreshControl(this.bbiPreview, IsBrowse && curr != null && canPreview);

            if (curr != null)
            {
                if (curr.BillState.In(BillState.Draft))
                {
                    this.bbiSend.Tag = "SendToAudit";
                    this.bbiSend.Caption = "送审";
                    this.bbiSend.LargeGlyph = Properties.Resources.Action_SendToAudit_32x32;
                }
                else if (curr.BillState.In(BillState.Unaudited))
                {
                    this.bbiSend.Tag = "UnSendToAudit";
                    this.bbiSend.Caption = "取消送审";
                    this.bbiSend.LargeGlyph = Properties.Resources.Action_UnSendToAudit_32x32;
                }
                else
                {
                    this.bbiSend.Tag = "SendToAudit";
                    this.bbiSend.Caption = "送审";
                    this.bbiSend.LargeGlyph = Properties.Resources.Action_SendToAudit_32x32;
                }
            }
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            if (this.ViewModel == null) return;

            qcMain.Enabled = IsBrowse;
            pcMain.Enabled = IsBrowse;

            UIController.RefreshControl(splitMain.Panel1, this.ViewModel.EditState, true, RefreshMode.Unnatural);
            //UIController.RefreshControl(splitMain.Panel2, this.ViewModel.EditState);
        }

        private static readonly string QueryArgs_Condition = "Condition";
        private static readonly string QueryArgs_Args = "Args";

        protected override string CalcCondition(string condition)
        {
            string result = string.Empty;

            if (!condition.IsEmpty())
                result = "({0})".FormatEx(condition);

            if (!qcMain.AdditionalCondition.IsEmpty())
                result = result.IsEmpty() ? " ({0}) ".FormatEx(qcMain.AdditionalCondition) : result + " AND ({1})".FormatEx(qcMain.AdditionalCondition);

            return result.IsEmpty() ? " (1=1) " : result;
        }

        protected virtual void OnAfterQuery()
        {

        }

        public void Query(string condition, params object[] args)
        {
            if (ViewModel != null)
            {
                this.ViewModel.IndexEntitySet.CurrentPageIndex = this.pcMain.CurrentPageIndex;

                this.pcMain.ClearQueryArgs();
                this.pcMain.SaveQueryArgs(QueryArgs_Condition, condition);
                this.pcMain.SaveQueryArgs(QueryArgs_Args, args);

                condition = CalcCondition(condition);
                ViewModel.Query(condition, args);

                OnAfterQuery();

                RefreshPageControl();
                RefreshUI();
            }
        }

        private void bbiAddToFavorite_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.OnAddMenuToFavorite();
        }
    }
}
