using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.View
{
    public interface IBaseView
    {
        /// <summary>
        /// 单据类型ID
        /// </summary>
        int BillTypeId { get; }
        /// <summary>
        /// UI唯一标识
        /// </summary>
        object UniqueId { get; }
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
        event FormClosedEventHandler Closed;
        /// <summary>
        /// 触发关闭事件
        /// </summary>
        /// <param name="args"></param>
        void OnClosed(FormClosedEventArgs args);
        /// <summary>
        /// 
        /// </summary>
        event FormClosingEventHandler Closing;
        /// <summary>
        /// 触发关闭前事件
        /// </summary>
        /// <param name="args"></param>
        void OnClosing(FormClosingEventArgs args);
        /// <summary>
        /// 
        /// </summary>
        event EventHandler Shown;
        /// <summary>
        /// 触发显示事件
        /// </summary>
        void OnShown();
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
        /// <summary>
        /// 
        /// </summary>
        RibbonControl Ribbon { get; }
    }
}
