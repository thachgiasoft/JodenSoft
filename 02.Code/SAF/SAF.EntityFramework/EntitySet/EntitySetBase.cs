using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAF.Foundation;
using System.ComponentModel;
using System.Collections;
using SAF.EntityFramework;
using System.Windows.Forms;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class EntitySetBase : DisposableObject, IEntitySetBase, INotifyPropertyChanged
    {
        protected DataTable _table = null;
        private BindingSource _bindingSource = null;

        private EntitySetBaseCollection _childEntitySets = new EntitySetBaseCollection();
        private string _connectionName = string.Empty;

        /// <summary>
        /// 数据库表名
        /// </summary>
        public abstract string TableName { get; set; }

        public abstract string IdenGroup { get; set; }

        /// <summary>
        /// 数据库表的主键名称
        /// </summary>
        public abstract string PrimaryKeyName
        {
            get;
            set;
        }

        #region Page

        private int _CurrentPageIndex = 0;
        public int CurrentPageIndex
        {
            get { return _CurrentPageIndex <= 0 ? 1 : _CurrentPageIndex; }
            set
            {
                _CurrentPageIndex = value;
                RaisePropertyChanged("CurrentPageIndex");
            }
        }

        private int _PageSize = 0;
        public int PageSize
        {
            get { return _PageSize <= 0 ? 0 : _PageSize; }
            set
            {
                _PageSize = value;
                RaisePropertyChanged("PageSize");
            }
        }
        private int _TotalPageCount = 1;

        public int TotalPageCount
        {
            get { return _TotalPageCount <= 0 ? 1 : _TotalPageCount; }
            set
            {
                _TotalPageCount = value;
                RaisePropertyChanged("TotalPageCount");
            }
        }

        private int _TotalRecordCount = 0;
        public int TotalRecordCount
        {
            get { return _TotalRecordCount <= 0 ? 0 : _TotalRecordCount; }
            set
            {
                _TotalRecordCount = value;
                RaisePropertyChanged("TotalRecordCount");
            }
        }

        #endregion

        /// <summary>
        /// 保存更改.如果实体集挂载了缓存器,则将更新脚本写入缓存器;否则直接更新数据库.
        /// </summary>
        public abstract void SaveChanges(DataRowState entityState = DataRowState.Unchanged);
        /// <summary>
        /// 忽略缓存器,直接提交到数据库
        /// </summary>
        public abstract void SubmitToDatabase();
        /// <summary>
        /// 删除当前行
        /// </summary>
        public abstract void DeleteCurrent();
        /// <summary>
        /// 添加新建行
        /// </summary>
        /// <returns></returns>
        protected abstract IEntityBase AddNewData();
        /// <summary>
        /// 获取当前实体
        /// </summary>
        /// <returns></returns>
        protected abstract IEntityBase GetCurrentEntity();
        /// <summary>
        /// 获取实体主键值
        /// </summary>
        /// <returns></returns>
        protected abstract object GetCurrentKey();
        /// <summary>
        /// 获取指定索引的实体
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected abstract IEntityBase GetEntity(int index);
        /// <summary>
        /// 获取枚举接口
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerator GetEntitySetBaseEnumerator();
        /// <summary>
        /// 查询之后触发
        /// </summary>
        public event EventHandler AfterQuery;

        /// <summary>
        /// 内部的DataTable
        /// </summary>
        public DataTable DataTable
        {
            get
            {
                return _table;
            }
        }
        /// <summary>
        /// 内部的DataTable对应的DefaultView
        /// </summary>
        public DataView DefaultView
        {
            get
            {
                if (this._table == null) return null;
                return this._table.DefaultView;
            }
        }
        private string _RowFilter = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RowFilter
        {
            get { return _RowFilter; }
            set
            {
                _RowFilter = value;
                if (this.DefaultView != null)
                    this.DefaultView.RowFilter = value;
            }
        }
        /// <summary>
        /// BindingSource
        /// </summary>
        protected BindingSource BindingSource
        {
            get { return _bindingSource; }
        }
        /// <summary>
        /// ChildEntitySets
        /// </summary>
        public EntitySetBaseCollection ChildEntitySets
        {
            get { return this._childEntitySets; }
        }
        /// <summary>
        /// ConnectionName
        /// </summary>
        public string ConnectionName
        {
            get { return this._connectionName.IsEmpty() ? ConfigContext.DefaultConnection : this._connectionName; }
            set
            {
                if (value.IsEmpty())
                    this._connectionName = ConfigContext.DefaultConnection;
                else
                    this._connectionName = value;
            }
        }

        /// <summary>
        /// 绑定外部CollectionViewSource到本实体
        /// </summary>
        /// <param name="collectionViewSource"></param>
        public void SetBindingSource(BindingSource bindingSource)
        {
            if (bindingSource == null)
            {
                throw new ArgumentNullException("bindingSource");
            }

            this.IsBusy = true;
            try
            {
                this._bindingSource = bindingSource;
                SetupBindingSource();
            }
            finally
            {
                this.IsBusy = false;
            }
        }
        /// <summary>
        /// 设置内部的CollectionViewSource
        /// </summary>
        protected virtual void SetupBindingSource()
        {
            if (this._bindingSource != null)
            {
                this._bindingSource.DataSource = this.DefaultView;
            }
        }

        #region Query

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">查询脚本</param>
        /// <param name="parameterValues">脚本参数</param>
        public void Query(string commandText, params object[] parameterValues)
        {
            if (this.IsBusy) return;

            DataSet ds;

            if (this.PageSize <= 0)
            {
                ds = DataPortal.ExecuteDataset(this.ConnectionName, commandText, parameterValues);
            }
            else
            {
                var PageInfo = new PageInfo();
                PageInfo.PageIndex = this.CurrentPageIndex;
                PageInfo.PageSize = this.PageSize;
                PageInfo.TotalPageCount = this.TotalPageCount;
                PageInfo.TotalRecordCount = this.TotalRecordCount;

                ds = DataPortal.ExecuteDatasetByPage(this.ConnectionName, PageInfo, commandText, parameterValues);

                this.CurrentPageIndex = PageInfo.PageIndex;
                this.PageSize = PageInfo.PageSize;
                this.TotalPageCount = PageInfo.TotalPageCount;
                this.TotalRecordCount = PageInfo.TotalRecordCount;
            }
            if (ds != null && ds.Tables.Count > 0)
            {
                this._table = ds.Tables[0];
                this.RowFilter = this.RowFilter;
                SetupBindingSource();
            }
            this.FireAfterQueryEvent();
        }

        private void FireAfterQueryEvent()
        {
            if (AfterQuery != null)
            {
                var _afterQuery = AfterQuery;
                _afterQuery(this, EventArgs.Empty);
            }
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        public object CurrentKey
        {
            get
            {
                return GetCurrentKey();
            }
        }

        IEntityBase IEntitySetBase.CurrentEntity
        {
            get
            {
                return GetCurrentEntity();
            }
        }

        IEntityBase IEntitySetBase.this[int index]
        {
            get
            {
                return GetEntity(index);
            }
        }

        /// <summary>
        /// 删除数据表中的所有数据
        /// </summary>
        public void DeleteAll()
        {
            if (this.DataTable != null)
            {
                for (int i = this.DataTable.Rows.Count - 1; i >= 0; i--)
                {
                    this.DataTable.Rows[i].Delete();
                }
            }
        }

        /// <summary>
        /// 清空整个数据集
        /// </summary>
        public void Clear()
        {
            if (this._table != null)
            {
                this._table.Clear();
            }
        }

        /// <summary>
        /// 提交自上次调用 System.Data.DataTable.AcceptChanges() 以来对该表进行的所有更改。
        /// </summary>
        public void AcceptChanges()
        {
            if (this.BindingSource != null)
            {
                this.BindingSource.EndEdit();
            }

            if (this.DataTable != null)
            {
                this.DataTable.AcceptChanges();
            }

        }
        /// <summary>
        /// 回滚自该表加载以来或上次调用 System.Data.DataTable.AcceptChanges() 以来对该表进行的所有更改。
        /// </summary>
        private void RejectChanges()
        {
            if (this.DataTable != null)
            {
                this.DataTable.RejectChanges();
            }

            if (this.BindingSource != null)
            {
                this.BindingSource.CancelEdit();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteEntity(EntityBase entity)
        {
            if (entity != null)
            {
                entity.DataRowView.Row.Delete();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void CancelEditEntity(EntityBase entity)
        {
            if (entity != null)
            {
                if (entity.DataRowView.Row.RowState == DataRowState.Added)
                {
                    entity.DataRowView.Delete();
                }
                else if (entity.DataRowView.Row.RowState == DataRowState.Modified)
                {
                    entity.DataRowView.CancelEdit();
                }
            }
        }
        /// <summary>
        /// 实体个数
        /// </summary>
        public int Count
        {
            get
            {
                return this.DefaultView == null ? 0 : this.DefaultView.Count;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int IndexOf(EntityBase entity)
        {
            if (this.Count <= 0 || entity == null || entity.DataRowView == null) return -1;
            return this._table.Rows.IndexOf(entity.DataRowView.Row);
        }

        /// <summary>
        /// 唯一ID
        /// </summary>
        public abstract int UniqueId
        {
            get;
        }

        /// <summary>
        /// 执行缓存
        /// </summary>
        public abstract IExecuteCache ExecuteCache
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Cancel()
        {
            RejectChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsBusy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public void Import(IEntitySetBase es)
        {
            if (es == null) return;
            if (es.DataTable == null) return;

            foreach (DataRow item in es.DataTable.Rows)
            {
                this._table.ImportRow(item);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Import(IEntityBase entity)
        {
            if (entity == null || entity.DataRowView == null)
                return;

            this._table.ImportRow(entity.DataRowView.Row);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public abstract IEntitySetBase Select(string commandText, params object[] parameterValues);

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEntitySetBase IEntitySetBase.GetChanges()
        {
            return DoGetChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract IEntitySetBase DoGetChanges();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStates"></param>
        /// <returns></returns>
        IEntitySetBase IEntitySetBase.GetChanges(DataRowState rowStates)
        {
            return DoGetChanges(rowStates);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStates"></param>
        /// <returns></returns>
        protected abstract IEntitySetBase DoGetChanges(DataRowState rowStates);

        /// <summary>
        /// 结束编辑,提交数据
        /// </summary>
        public void EndEdit()
        {
            if (this.BindingSource != null)
            {
                this.BindingSource.EndEdit();
            }
            else
            {
                foreach (DataRowView item in this.DefaultView)
                {
                    item.EndEdit();
                }
            }
            //提交子数据集
            foreach (var item in this.ChildEntitySets)
            {
                item.EndEdit();
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

            if (this.DataTable == null)
                return false;
            return this.DataTable.Columns.Contains(fieldName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public bool FieldAllowDBNull(string fieldName)
        {
            if (this.DataTable == null)
                throw new Exception("FieldAllowDBNull: DataRowView is null.");
            if (!FieldIsExists(fieldName))
                throw new FieldNotFoundException("字段\"{0}\"不存在.".FormatWith(fieldName));
            return this.DataTable.Columns[fieldName].AllowDBNull;
        }

        /// <summary>
        /// 字段数据类型
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public Type FieldDataType(string fieldName)
        {
            if (this.DataTable == null)
                throw new Exception("FieldDataType: DataRowView is null.");
            if (!FieldIsExists(fieldName))
                throw new FieldNotFoundException("字段\"{0}\"不存在.".FormatWith(fieldName));
            return this.DataTable.Columns[fieldName].DataType;
        }

        /// <summary>
        /// 单据权限
        /// </summary>
        private BillRightInfo BillRightInfo { get; set; }

        /// <summary>
        /// 单据操作权限
        /// </summary>
        public BillOperateRight BillOperateRight
        {
            get
            {
                return BillRightInfo == null || !BillRightInfo.UseOperateRight ? BillOperateRight.All : BillRightInfo.OperateRight;
            }
        }

        /// <summary>
        /// 查询单据权限
        /// </summary>
        /// <param name="billTypeId">单据类型</param>
        /// <param name="organizationId">部门ID(组织架构)</param>
        public void QueryBillRight(int billTypeID, int organizationId = 0)
        {
            if (billTypeID > 0)
                BillRightInfo = BillRight.QueryBillRight(billTypeID, Session.UserInfo.UserId, organizationId);
        }

        /// <summary>
        /// 缓存每一行数据的单据数据权限值
        /// </summary>
        private Dictionary<object, BillDataRight> dictBillRights = new Dictionary<object, BillDataRight>();
        /// <summary>
        /// 计算单据数据权限
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="forceCalc">是否强制重新计算</param>
        /// <returns>数据权限值</returns>
        public BillDataRight CalcBillDataRight(IEntityBase entity, bool forceCalc)
        {
            if (entity == null)
                return BillDataRight.None;
            if (BillRightInfo == null || BillRightInfo.BillTypeId <= 0 || !BillRightInfo.UseDataRight)
                return BillDataRight.All;
            object key = entity.GetFieldValue<object>(entity.PrimaryKeyName);
            if (dictBillRights.ContainsKey(key))
            {
                if (!forceCalc)
                    return dictBillRights[key];
                //强制重新计算
                BillDataRight dr = BillRight.CalcEntityBillDataRight(entity, BillRightInfo);
                dictBillRights[key] = dr;
                return dr;
            }
            else
            {
                BillDataRight dr = BillRight.CalcEntityBillDataRight(entity, BillRightInfo);
                dictBillRights.Add(key, dr);
                return dr;
            }
        }

        public abstract object Clone();


        public abstract bool IsDeleted
        {
            get;
        }

        public abstract bool IsAdded
        {
            get;
        }

        public abstract bool IsModified
        {
            get;
        }

        public abstract bool IsAddedOrModified
        {
            get;
        }
        
        public virtual bool TableIsExists()
        {
            return DataPortal.TableIsExists(this.ConnectionName, this.TableName);
        }
    }
}
