using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    /// <summary>
    /// 主数据编辑接口
    /// </summary>
    public interface IMasterDataEdit
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="args"></param>
        void Query(string condition, params object[] args);
        /// <summary>
        /// 新增
        /// </summary>
        void AddNew();
        /// <summary>
        /// 编辑
        /// </summary>
        void Edit();
        /// <summary>
        /// 删除
        /// </summary>
        void Delete();
    }
    /// <summary>
    /// 详细数据编辑接口
    /// </summary>
    public interface IDetailDataEdit
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="key"></param>
        void Query(object key);
        /// <summary>
        /// 取消
        /// </summary>
        void Cancel();
        /// <summary>
        /// 保存
        /// </summary>
        void Save();
        /// <summary>
        /// 删除
        /// </summary>
        void Delete();
    }

    /// <summary>
    /// 常规界面数据编辑接口
    /// </summary>
    public interface IDataEdit : IMasterDataEdit
    {
        /// <summary>
        /// 取消
        /// </summary>
        void Cancel();
        /// <summary>
        /// 保存
        /// </summary>
        void Save();
    }
}
