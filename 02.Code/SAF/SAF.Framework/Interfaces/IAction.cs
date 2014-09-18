using SAF.Framework.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework
{
    public interface IAction
    {
        Keys[] Keys
        {
            get;
            set;
        }

        void Execute(BaseView view);
    }

    public abstract class AbstractAction : IAction
    {
        Keys[] keys = null;

        public Keys[] Keys
        {
            get
            {
                return keys;
            }
            set
            {
                keys = value;
            }
        }

        public abstract void Execute(BaseView view);
    }
}
