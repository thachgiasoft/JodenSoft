using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDM.Framework.ServiceModel
{
    public interface IMenuCommand
    {
        void Execute(object parameter);
        bool CanExecute(object parameter);
    }

    public abstract class MenuCommand : IMenuCommand
    {
        public abstract void Execute(object parameter);

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
