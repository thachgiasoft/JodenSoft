using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.About;
using SAF.Foundation.ServiceModel;
using SAF.Foundation;
using SAF.EntityFramework;
using SAF.Framework.Controls;
using System.ComponentModel.Composition;
using System.Linq;

namespace SAF.Framework.Component
{
    [ToolboxItem(true)]
    [Export(typeof(IBackstageViewTabItem))]
    public partial class HelpControl : BaseBackstageViewTabItem
    {

        public HelpControl()
        {
            InitializeComponent();

            this.BackColor = Color.Transparent;
        }

        protected override void OnInit()
        {
            this.picLogo.Image = AssemblyInfoHelper.ApplicationImage;
            InitVersionInfo();
        }

        private void InitVersionInfo()
        {
            string productName = AssemblyInfoHelper.ProductName;
            string productId = Session.ProductCode;

            var shell = ApplicationService.Current.MainForm as IShellBase;
            if (shell != null)
            {
                lblProductInclude.Text = "����Ʒ������{0}.".FormatEx(shell.SubProductInfos.OrderBy(p => p.OrderIndex).Select(p => "{0}({1})".FormatEx(p.Title, p.Name)).JoinText(", "));
            }
            else
            {
                lblProductInclude.Text = "����Ʒ������{0}.".FormatEx(productName);
            }

            lblInfo.Text = AssemblyInfoHelper.AllVersionInfo;
            lblProductId.Text = "��ƷID��{0}".FormatEx(productId);
            lblAbout.Text = "���� {0}".FormatEx(productName);
            lblSetTool.Text = "���� {0} �Ĺ���".FormatEx(productName);


        }

        private void galleryControlGallery1_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            MessageService.ShowMessage("�������ڿ�����...");
            //string link = string.Format("{0}", e.Item.Tag);
            //switch (link)
            //{
            //    case "LinkHelp": link = AssemblyInfo.DXLinkHelp; break;
            //    case "LinkGetSupport": link = AssemblyInfo.DXLinkGetSupport; break;
            //}
            //if (!string.IsNullOrEmpty(link)) ObjectHelper.StartProcess(link);
        }

        private void galleryControlGallery1_ItemClick_1(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            fmFileUpgrade.ShowForm();
        }

        private void lblProductKey_Click(object sender, EventArgs e)
        {
            if (fmRegister.ShowRegister() == DialogResult.OK)
            {
                MessageService.ShowMessage("ע��ɹ�!");
            }
        }

        private void lblAboutBox_Click(object sender, EventArgs e)
        {
            var shell = ApplicationService.Current.MainForm as IShellBase;

            AboutBox about = new AboutBox(shell == null ? null : shell.SubProductInfos);
            about.Owner = this.FindForm();
            about.ShowDialog();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = Color.Transparent;
        }

        public override string Caption
        {
            get { return "����"; }
        }

        public override bool IsSelected
        {
            get
            {
                return true;
            }
        }

        public override int Index
        {
            get
            {
                return 100;
            }
        }
    }
}
