﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDM.Framework.ServiceModel
{
    public interface IJdmMenuCommand
    {
        void Execute(object parameter);
        bool CanExecute(object parameter);
    }

}
