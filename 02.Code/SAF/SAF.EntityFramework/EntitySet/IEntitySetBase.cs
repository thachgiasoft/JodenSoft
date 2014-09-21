using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.ComponentModel;
using SAF.EntityFramework.Server;
using System.Windows.Forms;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEntitySetBase
    {
        #region 分页
        /// <summary>
        /// 当前页
        /// </summary>
        int CurrentPageIndex { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        int TotalPageCount { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        int TotalRecordCount { get; set; }

        #endregion

        /// <summary>
        /// 子实体集
        /// </summary>
        EntitySetBaseCollection ChildEntitySets { get; }

        /// <summary>
        /// 
        /// </summary>
        int Count { get; }
        /// <summary>
        /// 实体集的唯一ID
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// 
        /// </summary>
        DataTable DataTable { get; }
        /// <summary>
        /// 
        /// </summary>
        DataView DefaultView { get; }
        /// <summary>
        /// 实体集所属缓存
        /// </summary>
        IExecuteCache ExecuteCache { get; }
        /// <summary>
        /// 数据库连接名称
        /// </summary>
        string ConnectionName { get; }
        /// <summary>
        /// 指示数据集是否只读
        /// </summary>
        bool IsReadOnly { get; set; }
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameterValues"></param>
        void Query(string query, params object[] parameterValues);

        /// <summary>
        /// 检索数据,返回新的EntitySet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        IEntitySetBase Select(string commandText, params object[] parameterValues);
        /// <summary>
        /// 当前实体
        /// </summary>
        IEntityBase CurrentEntity { get; }
        /// <summary>
        /// 
        /// </summary>
        object CurrentKey { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        void SetBindingSource(BindingSource bs);
        /// <summary>
        /// 实体集的索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IEntityBase this[int index] { get; }
        /// <summary>
        /// 删除所有记录
        /// </summary>
        void DeleteAll();
        /// <summary>
        /// 清空所有数据,只清空不删除
        /// </summary>
        void Clear();
        /// <summary>
        /// 如果有缓存器,则生成SQL脚本提交到缓存器;否则直接提交到数据库
        /// </summary>
        void SaveChanges(DataRowState entityState = DataRowState.Unchanged);
        /// <summary>
        /// 删除当前实体
        /// </summary>
        void DeleteCurrent();
        /// <summary>
        /// 
        /// </summary>
        void Cancel();

        /// <summary>
        /// 查询之后发生
        /// </summary>
        event EventHandler AfterQuery;
        /// <summary>
        /// 提交数据
        /// </summary>
        void EndEdit();
        /// <summary>
        /// 
        /// </summary>
        bool IsBusy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEntitySetBase GetChanges();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStates"></param>
        /// <returns></returns>
        IEntitySetBase GetChanges(DataRowState rowStates);
        /// <summary>
        /// 判断字段是否存在
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        bool FieldIsExists(string fieldName);
        /// <summary>
        /// 字段是否可为空
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        bool FieldAllowDBNull(string fieldName);
        /// <summary>
        /// 字段的数据类型
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        Type FieldDataType(string fieldName);
        /// <summary>
        /// 提交自上次调用 System.Data.DataTable.AcceptChanges() 以来对该表进行的所有更改。
        /// </summary>
        void AcceptChanges();

    }
}
