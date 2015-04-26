using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace JDM.Framework.ServiceModel
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportMenuCommandAttribute : ExportAttribute, IMenuCommandMetadata
    {
        public ExportMenuCommandAttribute()
            : base("MainMenuCommand", typeof(IMenuCommand))
        {
            this.MenuId = Guid.NewGuid();
            this.MenuOrder = 0;
        }

        public Guid MenuId
        {
            get;
            private set;
        }

        public string Menu
        {
            get;
            set;
        }

        public string MenuCategory
        {
            get;
            set;
        }

        public double MenuOrder
        {
            get;
            set;
        }

        public Type MenuType
        {
            get;
            set;
        }
    }
}
