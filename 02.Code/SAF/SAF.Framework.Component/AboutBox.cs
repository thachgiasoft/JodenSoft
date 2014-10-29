using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text;
using SAF.Foundation;

namespace SAF.Framework.Component
{
    public partial class AboutBox : XtraForm
    {
        private AboutBox()
        {
            InitializeComponent();
        }

        private List<ISubProductInfo> SubSystemInfos = new List<ISubProductInfo>();

        public AboutBox(IEnumerable<ISubProductInfo> subSystemInfos)
            : this()
        {

            this.Text = String.Format("关于 {0}", AssemblyInfoHelper.ProductName);
            this.txtVersionInfo.Text = AssemblyInfoHelper.AllVersionInfo;
            this.txtWarningMessage.Text = AssemblyInfoHelper.WarningMessage;

            this.picLogo.Image = AssemblyInfoHelper.ApplicationImage;

            if (subSystemInfos != null)
                SubSystemInfos.AddRange(subSystemInfos.OrderBy(p => p.OrderIndex));

            this.bsMain.DataSource = this.SubSystemInfos;

            this.listBoxProducts.DataSource = this.bsMain;
            this.listBoxProducts.DisplayMember = "DisplayName";
            this.txtProductDetailInfo.DataBindings.Add(new Binding("EditValue", this.bsMain, "Description"));
        }

        private void btnCopyVersionInfo_Click(object sender, EventArgs e)
        {
            CopyVersionInfo();
        }

        private void CopyVersionInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(AssemblyInfoHelper.AllVersionInfo);

            foreach (var com in SubSystemInfos.OrderBy(p => p.OrderIndex))
            {
                if (com != null)
                {
                    sb.AppendLine(com.Name + " — " + com.Title);
                    sb.AppendLine(com.Description);
                    sb.AppendLine();
                }
            }

            sb.AppendLine(AssemblyInfoHelper.WarningMessage);
            sb.AppendLine();
            Clipboard.SetText(sb.ToString());
        }
    }


}
