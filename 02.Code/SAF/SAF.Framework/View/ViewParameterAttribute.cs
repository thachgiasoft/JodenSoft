using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class ViewParameterAttribute : Attribute
    {
        public string Desctiption { get; private set; }

        public ViewParameterAttribute(string description)
        {
            this.Desctiption = description;
        }
    }
}
