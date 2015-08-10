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
using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using System.IO;
using SAF.Foundation.ServiceModel;

namespace JDM.SystemModule
{
    [BusinessObject("RegistrationInfoView")]
    public partial class RegistrationInfoView : SingleView
    {
        public RegistrationInfoView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new RegistrationInfoViewViewModel();
        }

        public new RegistrationInfoViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as RegistrationInfoViewViewModel;
            }
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            this.AccessFocusControl = this.cbxCustomer;
        }

        protected override void OnInitViewParam()
        {
            //base.OnInitViewParam();
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);
            UIController.RefreshControl(this.txtActivationResponse, false);
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            InitEdit();

            var group = this.grvIndex.Columns["CustomerName"];
            if (group != null)
                group.GroupIndex = 0;

            this.grvIndex.ExpandAllGroups();
            this.grvIndex.OptionsView.ShowGroupedColumns = true;
            this.grvIndex.OptionsView.ShowGroupPanel = false;
        }

        private void InitEdit()
        {
            this.cbxCustomer.Properties.CommandText = @"
SELECT a.Iden,a.Name 
FROM dbo.sysCustomer a WITH(NOLOCK) 
WHERE a.IsActive=1 AND a.IsDeleted=0 and ({0})
ORDER BY [Iden]";
            this.cbxCustomer.Properties.DisplayMember = "Name";
            this.cbxCustomer.Properties.AutoFillEntitySet = this.ViewModel.MainEntitySet;
            this.cbxCustomer.Properties.AutoFillFieldNames = "CustomerId=Iden,CustomerName=Name";
            this.cbxCustomer.Properties.ColumnHeaders = "客户序号,客户名称";
            this.cbxCustomer.Properties.Query();

            this.cbxVersion.Properties.Items.AddEnum(typeof(ApplicationVersion), true);
        }

        protected override void OnInitEvent()
        {
            base.OnInitEvent();
            this.grvIndex.FocusedRowChanged += grvIndex_FocusedRowChanged;
            this.ViewModel.MainEntitySet.AfterQuery += MainEntitySet_AfterQuery;

        }

        void MainEntitySet_AfterQuery(object sender, EventArgs e)
        {
            this.grvIndex.ExpandAllGroups();
        }

        void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }


        protected override void OnInitCustomRibbonMenuCommands(RibbonMenuCommandCollection cmds)
        {
            base.OnInitCustomRibbonMenuCommands(cmds);

            var cmd = new RibbonMenuCommand("导出授权文件", OnExportActivationResponse, OnCanExportActivationResponse)
            {
                LargeGlyph = SAF.Framework.Properties.Resources.Action_Export_32x32
            };
            cmds.Add(cmd);
        }

        private bool OnCanExportActivationResponse(object obj)
        {
            return this.ViewModel.MainEntitySet.Count > 0 && this.IsBrowse;
        }

        private void OnExportActivationResponse(object obj)
        {
            var fileName = FileDialogHelper.SaveFile("导出授权文件", "授权文件(*.lic)|*.lic", "lic", "license");
            if (fileName.IsEmpty()) return;
            File.WriteAllText(fileName, this.ViewModel.MainEntitySet.CurrentEntity.ActivationResponse, Encoding.UTF8);
            MessageService.ShowMessage("导出成功.");
        }
    }
}
