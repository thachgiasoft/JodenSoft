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

        public ViewParameterControlType ControlType { get; private set; }

        public string SqlScript { get; set; }
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public string ParentMember { get; set; }

        public ViewParameterAttribute(string description, ViewParameterControlType controlType = ViewParameterControlType.TextEdit)
        {
            this.Desctiption = description;
            this.ControlType = controlType;
        }
    }

    public enum ViewParameterControlType
    {
        TextEdit = 0,
        RichTextEdit = 1,
        CheckEdit = 2,
        IntSpinEdit = 3,
        FloatSpinEdit = 4,
        ComboboxEdit = 5
    }
}
