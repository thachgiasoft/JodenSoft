using SAF.Framework.Controls.ViewConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.CommonConfig.CommonBill
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
        public Guid UniqueId { get; set; }
        public EntitySetControlType ControlType { get; set; }
        public string ControlKeyFieldName { get; set; }
        public string ControlParentFieldName { get; set; }

        public string DbTableName { get; set; }
        public string PrimaryKeyName { get; set; }
        public string ForeignKey { get; set; }
        public string SqlScript { get; set; }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public List<EntitySetField> Fields { get; set; }
        public bool IsReadOnly { get; set; }

        public string Caption { get; set; }

        public void Validate(EntitySetType entitySetType)
        {
            var configName = entitySetType.GetDisplayName();

            ControlType.Required(p => p != EntitySetControlType.None, "{0}控件类型不能为'无'".FormatWith(configName));
            DbTableName.CheckNotNullOrEmpty("{0}表名".FormatWith(configName));
            PrimaryKeyName.CheckNotNullOrEmpty("{0}主键名".FormatWith(configName));
            SqlScript.CheckNotNullOrEmpty("{0}查询脚本");

            if (entitySetType == EntitySetType.Detail)
            {
                Caption.CheckNotNullOrEmpty("{0}实体标题".FormatWith(configName));
            }

            //验证树需要的字段
            if (ControlType == EntitySetControlType.TreeList)
            {
                ControlKeyFieldName.CheckNotNullOrEmpty("{0}控件主字段".FormatWith(configName));
                ControlParentFieldName.CheckNotNullOrEmpty("{0}控件父字段".FormatWith(configName));
            }
            Fields.CheckNotNullOrEmpty("{0}字段列表".FormatWith(configName));
            Fields.Required(p => !p.Any(a => a.Caption.IsEmpty() || a.FieldName.IsEmpty()), "{0}字段标题或字段名不能为空。".FormatWith(configName));
            Fields.Required(p => !p.Any(a => a.FieldType.In(EntitySetFieldType.GridSearch, EntitySetFieldType.Lookup) && a.SqlScript.IsEmpty()), "{0}字段类型为‘查找或表格查找’，但没有配置查询脚本。".FormatWith(configName));
        }

        public EntitySetConfig()
        {
            this.UniqueId = Guid.NewGuid();

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
        public string SqlScript { get; set; }
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
            this.SqlScript = string.Empty;
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
        TreeList = 2,
        [Display(Name = "布局控件")]
        LayoutControl = 3
    }
    /// <summary>
    /// 根据类型决定是否显示界面控件
    /// </summary>
    public enum EntitySetType
    {
        [Display(Name = "无")]
        None = 0,
        [Display(Name = "索引配置")]
        Index = 1,
        [Display(Name = "主数据配置")]
        Main = 2,
        [Display(Name = "明细数据配置")]
        Detail = 3
    }

}
