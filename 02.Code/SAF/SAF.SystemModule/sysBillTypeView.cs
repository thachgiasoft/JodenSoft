using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Framework.ViewModel;
using SAF.Foundation.MetaAttributes;
using SAF.Framework;
using SAF.EntityFramework;
using SAF.Foundation;
using DevExpress.XtraGrid.Columns;

namespace SAF.SystemModule
{
    [BusinessObject("单据类型")]
    public partial class sysBillTypeView : MasterDetailView
    {
        public sysBillTypeView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysBillTypeViewViewModel();
        }

        public new sysBillTypeViewViewModel ViewModel
        {
            get { return base.ViewModel as sysBillTypeViewViewModel; }
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            this.AccessFocusControl = this.txtName;

            this.Shown += sysBillTypeView_Shown;
        }

        void sysBillTypeView_Shown(object sender, EventArgs e)
        {
            this.grvRightDefine.ExpandAllGroups();
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();

            this.ViewModel.MainEntitySet.ChildEntitySets.Add(this.ViewModel.sysBillDataRightEntitySet);
            this.ViewModel.MainEntitySet.ChildEntitySets.Add(this.ViewModel.sysBillRightDefineEntitySet);

            this.ViewModel.sysBillDataRightEntitySet.SetBindingSource(this.bsDataRight);

            this.bsRightDefine.DataSource = this.ViewModel._dtDataRightDefine.DefaultView;
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            var obj = this.ViewModel.GetDataRoles().DefaultView;
            this.sluDataRole.SetDataSource(obj, "Iden", "Name", "Name|业务角色");
            this.sluDataRole2.SetDataSource(obj, "Iden", "Name", "Name|业务角色");

            var dataRightType = typeof(BillRightType).ToList<int>();
            this.luDataRight.SetDataSource(dataRightType, "Key", "Value");

        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);
            UIController.RefreshControl(this.chkIsSystem, false);

            foreach (GridColumn item in this.grvRightDefine.Columns)
            {
                if (item.FieldName.In("RightType", "FieldName"))
                {
                    item.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    item.OptionsColumn.AllowEdit = true;
                }
            }

            this.grvIndex.BestFitColumns();
            this.grvOperateRight.BestFitColumns();
            this.grvDataRight.BestFitColumns();
            this.grvRightDefine.BestFitColumns();
        }

        private void btnAddDataRight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ViewModel.AddDataRight();
        }

        private void btnCopyDataRight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ViewModel.CopyDataRight();
        }

        private void btnDeleteDataRight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ViewModel.DeleteDataRight();
        }

        protected override void OnIndexRowChange()
        {
            base.OnIndexRowChange();
            RefreshOperateAndDataRightCaption();
        }

        protected override void OnAddNew()
        {
            base.OnAddNew();
            RefreshOperateAndDataRightCaption();
        }

        private void RefreshOperateAndDataRightCaption()
        {
            this.ViewModel.MergeBillRightDefine();
            for (int i = 0; i < this.ViewModel._dtDataRightDefine.Rows.Count; i++)
            {
                DataRow define = this.ViewModel._dtDataRightDefine.Rows[i];

                if (define["RightType"].ToString() == "操作权限")
                {
                    var column = this.grvOperateRight.Columns.ColumnByFieldName(define["FieldName"].ToString());
                    if (column != null)
                    {
                        if (!Convert.ToBoolean(define["IsActive"]))
                        {
                            column.Visible = false;
                        }
                        else
                        {
                            column.VisibleIndex = (i > 9 ? i - 9 : i) + 2;
                            column.Caption = define["Caption"].ToString();
                        }
                    }
                }
                else
                {
                    var column = this.grvDataRight.Columns.ColumnByFieldName(define["FieldName"].ToString());
                    if (column != null)
                    {
                        if (!Convert.ToBoolean(define["IsActive"]))
                        {
                            column.Visible = false;
                        }
                        else
                        {
                            column.VisibleIndex = (i > 9 ? i - 9 : i) + 5;
                            column.Caption = define["Caption"].ToString();
                        }
                    }
                }
            }
            this.colIsActive1.Visible = false;
            this.colIsActive1.VisibleIndex = 20;

            this.colIsActive3.Visible = false;
            this.colIsActive3.VisibleIndex = 20;

            this.grvOperateRight.BestFitColumns();
            this.grvDataRight.BestFitColumns();
            this.grvRightDefine.BestFitColumns();

        }

        private void tcDtl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            RefreshOperateAndDataRightCaption();
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            IndexRowChange();
        }
    }
}
