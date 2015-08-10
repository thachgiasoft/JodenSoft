using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using SAF.Foundation;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class EntityBase : DisposableObject, IEntityBase
    {
        private string _TableName = string.Empty;
        private string _PrimaryKeyName = string.Empty;
        private string _IdenGroup = string.Empty;

        /// <summary>
        /// 数据库表名
        /// </summary>
        public string TableName
        {
            get { return IsInner ? _TableName : OwnerEntitySet.TableName; }
            set { _TableName = value; }
        }

        public string IdenGroup
        {
            get
            {
                var result = IsInner ? _IdenGroup : OwnerEntitySet.IdenGroup;
                if (result.IsEmpty())
                    result = this.TableName;
                return result;
            }
            set { _IdenGroup = value; }
        }
        /// <summary>
        /// 主键名称
        /// </summary>
        public string PrimaryKeyName
        {
            get { return IsInner ? _PrimaryKeyName : OwnerEntitySet.PrimaryKeyName; }
            set { _PrimaryKeyName = value; }
        }

        internal bool IsInner = false;

        /// <summary>
        /// 对应数据集的行
        /// </summary>
        public DataRowView DataRowView { get; set; }

        private EntitySetBase _OwnerEntitySet;
        /// <summary>
        /// 
        /// </summary>
        public EntitySetBase OwnerEntitySet
        {
            get { return _OwnerEntitySet; }
            internal set { this._OwnerEntitySet = value; }
        }

        #region 设置字段值
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        public void SetFieldValue(string fieldName, object value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new NullReferenceException("fieldName Is Null Or WhiteSpace.");
            if (this.FieldIsExists(fieldName))
            {
                if (value == null || value == DBNull.Value)
                {
                    if (this.DataRowView.Row.Table.Columns[fieldName].AllowDBNull)
                    {
                        this.DataRowView.Row.SetField(fieldName, value);
                    }
                    else
                    {
                        var t = this.DataRowView.Row.Table.Columns[fieldName].DataType;
                        this.DataRowView.Row.SetField(fieldName, t.DefaultValue());
                    }
                }
                else
                {
                    this.DataRowView.Row.SetField(fieldName, value);
                }
                this.DataRowView.EndEdit();
                NotifyPropertyChanged(fieldName);
            }
            else
            {
                throw new FieldNotFoundException(string.Format("字段\"{0}\"未找到,请检查字段名是否正确", fieldName));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public TResult GetFieldValue<TResult>(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new NullReferenceException("fieldName Is Null Or WhiteSpace.");
            if (this.FieldIsExists(fieldName))
            {
                return (DataRowView == null || DataRowView.Row == null || DataRowView.Row.RowState.In(DataRowState.Deleted, DataRowState.Detached) || DataRowView.Row.IsNull(fieldName)) ? default(TResult) : DataRowView.Row.Field<TResult>(fieldName);
            }
            else
            {
                throw new FieldNotFoundException(string.Format("字段{0}未找到,请检查字段名是否正确", fieldName));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public TResult GetFieldValue<TResult>(string fieldName, TResult defaultValue)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new NullReferenceException("fieldName Is Null Or WhiteSpace.");
            if (this.FieldIsExists(fieldName))
            {
                return GetFieldValue<TResult>(fieldName);
            }
            else
            {
                return defaultValue;
            }
        }

        #endregion


        /// <summary>
        /// 判断字段是否为空
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public bool FieldIsNull(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new NullReferenceException("FieldIsNull: fieldName Is Null Or WhiteSpace.");
            if (this.DataRowView == null || this.DataRowView.Row == null || this.DataRowView.Row.Table == null)
                throw new Exception("FieldIsNull: DataRowView is null.");
            if (!OwnerEntitySet.FieldIsExists(fieldName)) return false;
            return this.DataRowView.Row.IsNull(fieldName);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Delete()
        {
            if (this.OwnerEntitySet != null)
            {
                this.OwnerEntitySet.DeleteEntity(this);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Cancel()
        {
            if (this.OwnerEntitySet != null)
            {
                this.OwnerEntitySet.CancelEditEntity(this);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DataRowState EntityState
        {
            get
            {
                return this.DataRowView == null ? DataRowState.Unchanged : this.DataRowView.Row.RowState;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null && !string.IsNullOrWhiteSpace(propertyName))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.DataRowView = null;
            }

            base.Dispose(disposing);
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceEntity"></param>
        public void Copy(IEntityBase sourceEntity)
        {
            if (sourceEntity == null) return;

            foreach (DataColumn item in DataRowView.Row.Table.Columns)
            {
                if (!item.ColumnName.Equals("ROWSTAT", StringComparison.InvariantCultureIgnoreCase) && sourceEntity.FieldIsExists(item.ColumnName))
                {
                    this.SetFieldValue(item.ColumnName, sourceEntity.GetFieldValue<object>(item.ColumnName));
                }
            }
        }

        /// <summary>
        /// 判断字段是否存在
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public bool FieldIsExists(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new NullReferenceException("FieldIsExists: fieldName Is Null Or WhiteSpace.");

            if (this.DataRowView == null || this.DataRowView.Row == null || this.DataRowView.Row.Table == null)
                return false;
            return this.DataRowView.Row.Table.Columns.Contains(fieldName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public bool FieldAllowDBNull(string fieldName)
        {
            if (this.DataRowView == null || this.DataRowView.Row == null || this.DataRowView.Row.Table == null)
                throw new Exception("FieldAllowDBNull: DataRowView is null.");
            if (!FieldIsExists(fieldName))
                throw new FieldNotFoundException("字段\"{0}\"不存在.".FormatWith(fieldName));
            return this.DataRowView.Row.Table.Columns[fieldName].AllowDBNull;
        }

        /// <summary>
        /// 字段数据类型
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public Type FieldDataType(string fieldName)
        {
            if (this.DataRowView == null || this.DataRowView.Row == null || this.DataRowView.Row.Table == null)
                throw new Exception("FieldDataType: DataRowView is null.");
            if (!FieldIsExists(fieldName))
                throw new FieldNotFoundException("字段\"{0}\"不存在.".FormatWith(fieldName));
            return this.DataRowView.Row.Table.Columns[fieldName].DataType;
        }

        /// <summary>
        /// 数据权限
        /// </summary>
        public BillDataRight BillDataRight
        {
            get { return this.OwnerEntitySet.CalcBillDataRight(this, false); }
        }

        /// <summary>
        /// 设置为修改状态
        /// </summary>
        public void SetModified()
        {
            if (this.DataRowView != null)
                this.DataRowView.Row.SetModified();
        }
        /// <summary>
        /// 设置为新增状态
        /// </summary>
        public void SetAdded()
        {
            if (this.DataRowView != null)
                this.DataRowView.Row.SetAdded();
        }

        /// <summary>
        /// 单据状态
        /// </summary>
        public BillState BillState
        {
            get
            {
                if (!this.FieldIsExists("BillState")) return BillState.None;
                return (BillState)this.GetFieldValue<int>("BillState");
            }
        }

        /// <summary>
        /// 时间戳是否一致
        /// </summary>
        public abstract bool VersionNumberIsSync
        {
            get;
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public abstract int? CreatedBy
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public abstract DateTime? CreatedOn
        {
            get;
            set;
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public abstract int? ModifiedBy
        {
            get;
            set;
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public abstract DateTime? ModifiedOn
        {
            get;
            set;
        }
        /// <summary>
        /// 时间戳
        /// </summary>
        public abstract VersionNumber VersionNumber
        {
            get;
        }
    }
}
