using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.ViewConfig
{
    public class QueryField
    {
        public string Caption { get; set; }
        public string FieldName { get; set; }
        public bool IsDefault { get; set; }

        public QueryField()
        { }

        public QueryField(string fieldName, string caption)
            : this()
        {
            this.Caption = caption;
            this.FieldName = fieldName;
        }
        public QueryField(string fieldName, string caption, bool isDefault)
            : this()
        {
            this.Caption = caption;
            this.FieldName = fieldName;
            this.IsDefault = isDefault;
        }
    }
}
