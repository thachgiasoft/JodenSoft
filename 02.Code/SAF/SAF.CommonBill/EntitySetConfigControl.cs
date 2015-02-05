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
using DevExpress.XtraLayout.Utils;

namespace SAF.CommonBill
{
    [ToolboxItem(true)]
    public partial class EntitySetConfigControl : BaseUserControl
    {
        private EntitySetType _EntitySetType = EntitySetType.None;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public EntitySetType EntitySetType
        {
            get { return _EntitySetType; }
            set
            {
                _EntitySetType = value;
                lciCaption.Visibility = (_EntitySetType.In(EntitySetType.Index, EntitySetType.Main) ? LayoutVisibility.Never : LayoutVisibility.Always);
            }
        }

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

                this.bsConfig.ResetBindings(false);
                this.bsFields.ResetBindings(false);
            }
        }

        public void ResetBindings()
        {
            this.bsConfig.ResetBindings(false);
            this.bsFields.ResetBindings(false);
        }

        public EntitySetConfigControl()
        {
            InitializeComponent();
            Init();
        }

        protected override void OnInit()
        {
            base.OnInit();

            Converter<EntitySetControlType, string> convertor = p =>
            {
                switch (p)
                {
                    case EntitySetControlType.None:
                        return "无";
                    case EntitySetControlType.GridControl:
                        return "表格控件";
                    case EntitySetControlType.TreeList:
                        return "树形控件";
                    default:
                        return "无";
                }
            };
            this.cbmControlType.Properties.Items.AddEnum(convertor);
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
            this.grvFields.PostEditor();
            this.bsFields.MoveCurrentUp();
        }

        private void btnEntitySetConfigFieldDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.grvFields.PostEditor();
            this.bsFields.MoveCurrentDown();
        }
    }

    public enum EntitySetType
    {
        None = 0,
        Index = 1,
        Main = 2,
        Detail = 3
    }


}
