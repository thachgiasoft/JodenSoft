using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using System.Windows.Forms;

namespace SAF.Foundation.ServiceModel
{
    public class FileDragDropManager
    {
        private Form ucOwner;
        private bool ActiveOwner = false;

        public event FileDroppedEventHandler FileDropped;

        public FileDragDropManager(Form owner) :
            this(owner, false)
        {
        }

        public FileDragDropManager(Form owner, bool activeOwner)
        {
            this.ActiveOwner = activeOwner;

            if (owner == null)
            {
                throw new ArgumentNullException("FileDragDropManager.owner");
            }
            ucOwner = owner;
            ucOwner.AllowDrop = true;
            ucOwner.DragEnter += ucOwner_DragEnter;
            ucOwner.DragDrop += ucOwner_Drop;
        }

        void ucOwner_Drop(object sender, DragEventArgs e)
        {
            string[] a = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (a != null)
            {
                if (FileDropped != null)
                {
                    FileDropped(this, new FileDroppedEventArgs(a.ToList()));

                    if (ActiveOwner)
                    {
                        var win = this.ucOwner.FindForm();
                        if (win != null)
                            win.Activate();
                    }
                }
            }
        }

        void ucOwner_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
    }

    public delegate void FileDroppedEventHandler(object sender, FileDroppedEventArgs e);

    public class FileDroppedEventArgs : EventArgs
    {
        public List<string> Files { get; private set; }

        public FileDroppedEventArgs(List<string> files)
        {
            this.Files = files;
            if (this.Files == null)
                this.Files = new List<string>();
        }

    }
}
