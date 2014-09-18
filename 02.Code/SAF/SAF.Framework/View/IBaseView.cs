using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.View
{
    public interface IBaseView
    {
        /// <summary>
        /// UIController惟一标识
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// 
        /// </summary>
        bool IsDirty { get; }

        /// <summary>
        /// 
        /// </summary>
        void Close();
        /// <summary>
        /// 
        /// </summary>
        void RefreshUI();
        /// <summary>
        /// 
        /// </summary>
        void Init();
        /// <summary>
        /// 
        /// </summary>
        string Text { get; set; }
    }
}
