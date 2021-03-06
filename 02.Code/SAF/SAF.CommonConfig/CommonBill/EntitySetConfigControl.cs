﻿using System;
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
using DevExpress.XtraEditors;

namespace SAF.CommonConfig.CommonBill
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
                lciForeignKey.Visibility = (_EntitySetType.In(EntitySetType.Index, EntitySetType.Main) ? LayoutVisibility.Never : LayoutVisibility.Always);

                if (_EntitySetType.In(EntitySetType.Index, EntitySetType.Main))
                {
                    txtForeignKey.EditValue = string.Empty;
                }
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

                ResetBindingSource();
            }
        }

        public void ResetBindingSource()
        {
            this.bsConfig.ResetBindings(true);
            this.bsFields.ResetBindings(true);
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
                return p.GetDisplayName();
            };
            this.cbmControlType.Properties.Items.AddEnum(convertor);


            Converter<EntitySetFieldType, string> fieldTypeConvertor = p =>
            {
                return p.GetDisplayName();
            };

            this.cbxFieldType.Items.AddEnum(fieldTypeConvertor);
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

        private void cbmControlType_EditValueChanged(object sender, EventArgs e)
        {
            var editor = sender as ImageComboBoxEdit;
            if (editor == null) return;

            if (!editor.EditValue.IsEmpty() && ((EntitySetControlType)editor.EditValue).In(EntitySetControlType.GridControl, EntitySetControlType.None, EntitySetControlType.LayoutControl))
            {
                lciControlKeyField.Visibility = LayoutVisibility.Never;
                lciControlParentField.Visibility = LayoutVisibility.Never;

                txtControlKeyField.EditValue = string.Empty;
                txtControlParentField.EditValue = string.Empty;
            }
            else
            {
                lciControlKeyField.Visibility = LayoutVisibility.Always;
                lciControlParentField.Visibility = LayoutVisibility.Always;
            }
        }
    }

}
