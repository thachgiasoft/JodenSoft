using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDM.Framework.ServiceModel
{
   
    public abstract class JdmMenuCommand : IJdmMenuCommand
    {
        public abstract void Execute(object parameter);

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
