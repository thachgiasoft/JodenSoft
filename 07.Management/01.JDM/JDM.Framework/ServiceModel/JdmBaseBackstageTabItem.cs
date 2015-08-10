using DevExpress.XtraEditors;
using JDM.Framework.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDM.Framework.ServiceModel
{
    public class JdmBaseBackstageTabItem : XtraUserControl, IJdmBackstageTabItem
    {
        public JdmBaseBackstageTabItem()
        {
            InitializeComponent();
        }

        public virtual int Index
        {
            get { return 10; }
        }

        public virtual string Caption
        {
            get { return "JdmBaseBackstageTabItem"; }
        }

        public virtual bool IsSelected
        {
            get { return false; }
        }

        public UserControl View
        {
            get { return this; }
        }

        public virtual bool BeginGroup
        {
            get { return false; }
        }

        public virtual void Init()
        {

        }

        public virtual void RefreshUI()
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // JDMBaseBackstageTabItem
            // 
            this.Name = "JDMBaseBackstageTabItem";
            this.Size = new System.Drawing.Size(314, 249);
            this.ResumeLayout(false);

        }
    }
}
