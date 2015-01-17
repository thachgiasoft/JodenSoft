using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.CommonBill
{
    public sealed class CommonBillConfig
    {
        public EntitySetConfig IndexEntitySetConfig { get; set; }
        public EntitySetConfig MainEntitySetConfig { get; set; }
        public List<EntitySetConfig> DetailEntitySetConfig { get; set; }
    }

    public sealed class EntitySetConfig
    {
        public EntitySetControl EntitySetControl { get; set; }
        public string Sql { get; set; }
        public List<EntitySetField> Fields { get; set; }
    }

    public sealed class EntitySetField
    {
        public string FieldName { get; set; }
        public string Caption { get; set; }
        public EntitySetFieldType FieldType { get; set; }
        public string Sql { get; set; }

    }

    public enum EntitySetFieldType
    {
        Text = 0,
        Memo = 1,
        Integer = 2,
        Number = 3,
        Lookup = 4,
        GridSearch = 5
    }

    public class EntitySetControl
    {
        public EntitySetControlType ControlType{get;set;}
        public string KeyFieldName{get;set;}
        public string ParentFieldName{get;set;}
    }

    public enum EntitySetControlType
    {
        GridControl=0,
        TreeList=1
    }
}
