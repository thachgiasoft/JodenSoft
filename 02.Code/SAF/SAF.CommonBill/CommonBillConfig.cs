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
        public IList<EntitySetConfig> DetailEntitySetConfigs { get; set; }

        public CommonBillConfig()
        {
            IndexEntitySetConfig = new EntitySetConfig();
            MainEntitySetConfig = new EntitySetConfig();
            DetailEntitySetConfigs = new List<EntitySetConfig>();
        }
    }

    public sealed class EntitySetConfig
    {
        public EntitySetControlSetting ControlSetting { get; set; }
        public string DbTableName { get; set; }
        public string PrimaryKeyName { get; set; }
        public string Sql { get; set; }
        public List<EntitySetField> Fields { get; set; }
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// 主要针对明细区的TabContainer
        /// </summary>
        public string Caption { get; set; }

        public EntitySetConfig()
        {
            ControlSetting = new EntitySetControlSetting();
            Fields = new List<EntitySetField>();
            Sql = string.Empty;
            PrimaryKeyName = "Iden";
            IsReadOnly = false;
            Caption = string.Empty;
        }
    }

    public sealed class EntitySetField
    {
        public string FieldName { get; set; }
        public string Caption { get; set; }
        public EntitySetFieldType FieldType { get; set; }
        public string Sql { get; set; }
        public bool IsReadOnly { get; set; }

        public EntitySetField()
            : this(string.Empty, string.Empty)
        { }

        public EntitySetField(string fieldName, string caption)
            : this(fieldName, caption, false)
        {
        }

        public EntitySetField(string fieldName, string caption, bool isReadOnly)
            : this(fieldName, caption, isReadOnly, EntitySetFieldType.Text)
        {
        }

        public EntitySetField(string fieldName, string caption, bool isReadOnly, EntitySetFieldType fieldType)
        {
            this.FieldName = fieldName;
            this.Caption = caption;
            this.FieldType = fieldType;
            this.Sql = string.Empty;
            this.IsReadOnly = isReadOnly;
        }

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

    public class EntitySetControlSetting
    {
        public EntitySetControlType ControlType { get; set; }
        public string KeyFieldName { get; set; }
        public string ParentFieldName { get; set; }

        public EntitySetControlSetting()
        {
            ControlType = EntitySetControlType.GridControl;
        }
    }

    public enum EntitySetControlType
    {
        GridControl = 0,
        TreeList = 1
    }
}
