using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDM.Framework.ServiceModel
{
    public interface IMenuCommand
    {
        void Execute(Form mdiParent, object parameter);
        bool CanExecute(Form mdiParent, object parameter);
    }

    public abstract class MenuCommand
    {
        public abstract void Execute(Form mdiParent, object parameter);

        public virtual bool CanExecute(Form mdiParent, object parameter)
        {
            return true;
        }
    }
}
