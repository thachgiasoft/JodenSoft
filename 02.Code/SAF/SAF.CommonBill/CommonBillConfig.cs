﻿using SAF.Framework.Controls.ViewConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.CommonBill
{
    [Serializable]
    public sealed class CommonBillConfig
    {
        public QueryConfig QueryConfig { get; set; }

        public EntitySetConfig IndexEntitySetConfig { get; set; }
        public EntitySetConfig MainEntitySetConfig { get; set; }
        public List<EntitySetConfig> DetailEntitySetConfigs { get; set; }

        public CommonBillConfig()
        {
            QueryConfig = new Framework.Controls.ViewConfig.QueryConfig();
            IndexEntitySetConfig = new EntitySetConfig();
            MainEntitySetConfig = new EntitySetConfig();
            DetailEntitySetConfigs = new List<EntitySetConfig>();

        }
    }
    [Serializable]
    public sealed class EntitySetConfig
    {
        public EntitySetControlType ControlType { get; set; }
        public string ControlKeyFieldName { get; set; }
        public string ControlParentFieldName { get; set; }

        public string DbTableName { get; set; }
        public string PrimaryKeyName { get; set; }
        public string SqlScript { get; set; }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public List<EntitySetField> Fields { get; set; }
        public bool IsReadOnly { get; set; }

        public string Caption { get; set; }

        public EntitySetConfig()
        {
            ControlType = EntitySetControlType.GridControl;
            ControlKeyFieldName = string.Empty;
            ControlParentFieldName = string.Empty;

            Fields = new List<EntitySetField>();
            SqlScript = string.Empty;
            PrimaryKeyName = "Iden";
            IsReadOnly = false;
            Caption = string.Empty;
        }
    }
    [Serializable]
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

    public enum EntitySetControlType
    {
        None = 0,
        GridControl = 1,
        TreeList = 2
    }
}
