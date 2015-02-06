using SAF.Framework.Controls.ViewConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SAF.CommonBill
{
    /// <summary>
    /// 通用单据配置
    /// </summary>
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
    /// <summary>
    /// 实体配置
    /// </summary>
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
    /// <summary>
    /// 实体字段
    /// </summary>
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
    /// <summary>
    /// 实体字段类型
    /// </summary>
    public enum EntitySetFieldType
    {
        [Display(Name = "文本")]
        Text = 0,
        [Display(Name = "长文本")]
        Memo = 1,
        [Display(Name = "整数")]
        Integer = 2,
        [Display(Name = "小数")]
        Number = 3,
        [Display(Name = "查找")]
        Lookup = 4,
        [Display(Name = "表格查找")]
        GridSearch = 5
    }
    /// <summary>
    /// 实体控件类型
    /// </summary>
    public enum EntitySetControlType
    {
        [Display(Name = "无")]
        None = 0,
        [Display(Name = "表格控件")]
        GridControl = 1,
        [Display(Name = "树形控件")]
        TreeList = 2
    }
    /// <summary>
    /// 根据类型决定是否显示界面控件
    /// </summary>
    public enum EntitySetType
    {
        None = 0,
        Index = 1,
        Main = 2,
        Detail = 3
    }

}
