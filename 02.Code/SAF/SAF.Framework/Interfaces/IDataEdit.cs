using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    public interface IDataEdit
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
        /// 取消
        /// </summary>
        void Cancel();
        /// <summary>
        /// 删除
        /// </summary>
        void Delete();
        /// <summary>
        /// 保存
        /// </summary>
        void Save();


    }
}
