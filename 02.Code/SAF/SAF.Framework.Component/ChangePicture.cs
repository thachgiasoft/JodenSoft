using DevExpress.XtraEditors;
using SAF.EntityFramework;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Component
{
    public partial class ChangePicture : XtraForm
    {
        private EntitySet<sysUser> userSet = new EntitySet<sysUser>();

        public ChangePicture()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Icon = ApplicationService.Current.MainForm.Icon;

            userSet.Query("SELECT Iden,UserImage,UserSignImage FROM dbo.sysUser where Iden=:UserId", Session.Current.UserId);

            if (this.userSet.Count > 0)
            {
                if (this.userSet.CurrentEntity.UserImage != null)
                    this.picUser.Image = new Bitmap(new MemoryStream(this.userSet.CurrentEntity.UserImage));

                if (this.userSet.CurrentEntity.UserSignImage != null)
                    this.picSign.Image = new Bitmap(new MemoryStream(this.userSet.CurrentEntity.UserSignImage));
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.picUser.Image != null)
            {
                var stream = new MemoryStream();
                this.picUser.Image.Save(stream, ImageFormat.Png);
                this.userSet.CurrentEntity.UserImage = stream.ToArray();
            }

            if (this.picSign.Image != null)
            {
                var stream = new MemoryStream();
                this.picSign.Image.Save(stream, ImageFormat.Png);
                this.userSet.CurrentEntity.UserSignImage = stream.ToArray();
            }

            this.userSet.SaveChanges();
            OnAfterPictureChanged();
            MessageService.ShowMessage("图片修改成功.");
            this.Close();
        }

        private static readonly object AfterPictureChangedEvent = new object();

        public event EventHandler AfterPictureChanged
        {
            add { this.Events.AddHandler(AfterPictureChangedEvent, value); }
            remove { this.Events.RemoveHandler(AfterPictureChangedEvent, value); }
        }

        private void OnAfterPictureChanged()
        {
            var handler = this.Events[AfterPictureChangedEvent] as EventHandler;

            if (handler != null)
                handler(this, EventArgs.Empty);
        }

    }
}
