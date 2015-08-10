using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace JDM.Framework.ServiceModel
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class JdmExportMenuCommandAttribute : ExportAttribute, IJdmMenuCommandMetadata
    {
        public JdmExportMenuCommandAttribute()
            : base("MainMenuCommand", typeof(IJdmMenuCommand))
        {
            this.Id = Guid.NewGuid().ToString("D");
            this.Order = 0;
        }

        public string Id
        {
            get;
            private set;
        }

        public string Header
        {
            get;
            set;
        }

        public JdmMenuCategory Category
        {
            get;
            set;
        }

        public double Order
        {
            get;
            set;
        }
    }
}
