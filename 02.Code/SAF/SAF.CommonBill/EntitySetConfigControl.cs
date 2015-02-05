using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.Controls;
using SAF.Foundation;

namespace SAF.CommonBill
{
    [ToolboxItem(true)]
    public partial class EntitySetConfigControl : BaseUserControl
    {
        private EntitySetConfig _EntitySetConfig = new EntitySetConfig();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public EntitySetConfig EntitySetConfig
        {
            get { return _EntitySetConfig; }
            set
            {
                if (value == null)
                    _EntitySetConfig = new EntitySetConfig();
                else
                    _EntitySetConfig = value;

                this.bsConfig.DataSource = _EntitySetConfig;
                this.bsFields.DataSource = _EntitySetConfig.Fields;
            }
        }

        public EntitySetConfigControl()
        {
            InitializeComponent();
            Init();
        }

        protected override void OnInit()
        {
            base.OnInit();

            this.cbmControlType.Properties.Items.AddEnum(typeof(EntitySetControlType));
        }

        private void btnEntitySetConfigFieldParse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnEntitySetConfigFieldAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.bsFields.AddNew();
        }

        private void btnEntitySetConfigFieldDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bsFields.Count > 0)
                this.bsFields.RemoveCurrent();
        }

        private void btnEntitySetConfigFieldUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.bsFields.MoveCurrentUp();
        }

        private void btnEntitySetConfigFieldDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.bsFields.MoveCurrentDown();
        }


    }
}
