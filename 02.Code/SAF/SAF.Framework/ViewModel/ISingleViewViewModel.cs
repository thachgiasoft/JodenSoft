using SAF.EntityFramework;
using SAF.Framework.Controls.ViewConfig;
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

        void Query(string sCondition, params object[] parameterValues);
        void QueryChild(object key);

        void AddNew();
        bool AllowDelete();
        void Delete();
        bool AllowEdit();
        void Edit();
        void Cancel();
        void Save();

        void SendToAudit();
        void Approval();
        void Reject();

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

    }
}
