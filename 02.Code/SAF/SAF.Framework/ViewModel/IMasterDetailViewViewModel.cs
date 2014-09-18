using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.ViewModel
{
    public interface IMasterDetailViewViewModel : ISingleViewViewModel
    {
        IEntitySetBase DetailEntitySet { get; }
    }
}
