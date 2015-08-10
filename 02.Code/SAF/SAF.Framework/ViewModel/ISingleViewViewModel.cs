using SAF.EntityFramework;
using SAF.Framework.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.ViewModel
{
    public interface ISingleViewViewModel : IBusinessViewViewModel
    {
        IEntitySetBase MainEntitySet { get; }
        IEntitySetBase IndexEntitySet { get; }

        /// <summary>
        /// Index仅用于分组显示
        /// </summary>
        bool IndexUseForGroup { get; }

        void Query(string sCondition, params object[] parameterValues);
        void QueryChild(object key);

        void AddNew();
        bool AllowDelete();
        void Delete();
        bool AllowEdit();
        void Edit();
        void Cancel();
        bool Save();

        /// <summary>
        /// 送审
        /// </summary>
        void SendToAudit();
        /// <summary>
        /// 取消送审
        /// </summary>
        void UnSendToAudit();

        /// <summary>
        /// 保存后事件
        /// </summary>
        event EventHandler<AfterSaveEventArgs> AfterSave;
        /// <summary>
        /// 结束编辑
        /// </summary>
        void EndEdit();
        /// <summary>
        /// 查询配置
        /// </summary>
        QueryConfig QueryConfig { get; }
        /// <summary>
        /// 初始查询配置
        /// </summary>
        void InitQueryConfig();

    }
}
