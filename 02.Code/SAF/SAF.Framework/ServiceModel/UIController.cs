using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
using DevExpress.XtraBars.Ribbon;
using SAF.Framework.Controls.TextEditor;
using SAF.Framework.Controls;

namespace SAF.Framework
{
    public static class UIController
    {
        public static void SetupGridControl(GridControl grd)
        {
            var grv = grd.MainView as GridView;
            if (grv != null)
            {
                grv.OptionsBehavior.Editable = false;
                grv.OptionsBehavior.ReadOnly = true;
                grv.OptionsSelection.EnableAppearanceFocusedCell = false;
                grv.OptionsView.ColumnAutoWidth = false;
            }
        }

        public static void SetupTreelist(TreeList tree, bool autoWidth = true)
        {
            tree.OptionsBehavior.Editable = false;
            tree.OptionsSelection.EnableAppearanceFocusedCell = false;
            tree.OptionsView.AutoWidth = autoWidth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aComponent"></param>
        /// <param name="bEnabled"></param>
        public static void RefreshControl(Component aComponent, bool bEnabled)
        {
            if (aComponent == null) return;
            RefreshControl(aComponent, bEnabled, Color.White, Color.WhiteSmoke);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aControl"></param>
        /// <param name="status"></param>
        /// <param name="bRecursion"></param>
        /// <param name="mode"></param>
        public static void RefreshControl(Control aControl, EditState status, bool bRecursion = true, RefreshMode mode = RefreshMode.Normal)
        {
            if (aControl == null)
                return;
            Color colorTrue = Color.White;
            Color colorFalse = Color.WhiteSmoke;
            //正常的是编辑状态下可用
            bool bInEdit = status.In(EditState.Edit, EditState.AddNew);
            bool bControlEnabled = mode == RefreshMode.Normal ? bInEdit : !bInEdit;
            if (aControl is GridControl)
            {
                //Grid列按列自身的RefreshMode处理
                GridControl grid = aControl as GridControl;
                GridView view = grid.MainView as GridView;
                switch (mode)
                {
                    //反向Grid，一般用于索引数据，如Index
                    case RefreshMode.Unnatural: RefreshControl(grid, !bInEdit); break;
                    //正向Grid，一般用于主数据
                    case RefreshMode.Normal: RefreshControl(view, bControlEnabled); break;
                    default: break;
                }
            }
            else if (bRecursion && (aControl is PanelControl || aControl is LayoutControl || aControl is SplitGroupPanel
                 || aControl is Form || aControl is XtraTabPage || aControl is XtraTabControl || aControl is BaseUserControl
                 || aControl is SplitContainerControl))
            {
                foreach (Control c in aControl.Controls)
                {
                    RefreshControl(c, status, bRecursion, mode);
                }
            }
            else
                RefreshControl(aControl, bControlEnabled, colorTrue, colorFalse);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aControl"></param>
        /// <param name="bEnabled"></param>
        /// <param name="bRecursion"></param>
        public static void RefreshControl(Control aControl, bool bEnabled, bool bRecursion)
        {
            if (aControl == null)
                return;
            Color colorTrue = Color.White;
            Color colorFalse = Color.WhiteSmoke;
            if (aControl is GridControl)
            {
                GridControl grid = aControl as GridControl;
                GridView view = grid.MainView as GridView;
                RefreshControl(view, bEnabled);
            }
            else if (bRecursion && (aControl is PanelControl || aControl is LayoutControl || aControl is SplitGroupPanel
                 || aControl is Form || aControl is XtraTabPage || aControl is XtraTabControl || aControl is BaseUserControl
                 || aControl is SplitContainerControl
                ))
            {
                foreach (Control c in aControl.Controls)
                {
                    RefreshControl(c, bEnabled, bRecursion);
                }
            }
            else
                RefreshControl(aControl, bEnabled, colorTrue, colorFalse);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aComponent"></param>
        /// <param name="bEnabled"></param>
        /// <param name="colorTrue"></param>
        /// <param name="colorFalse"></param>
        public static void RefreshControl(Component aComponent, bool bEnabled, Color colorTrue, Color colorFalse)
        {
            if (aComponent == null) return;
            //FakeFocusContainer 用于刷新Layout里加入Tab后无法切换的问题
            if (aComponent is SplitterControl || aComponent is FakeFocusContainer)
                return;

            //GridView转为单个列刷新
            if (aComponent is GridView)
            {
                GridView view = aComponent as GridView;
                foreach (GridColumn col in view.Columns)
                {
                    RefreshControl(col, bEnabled, colorTrue, colorFalse);
                }
                return;
            }
            else if (aComponent is GridColumn)
            {
                GridColumn col = aComponent as GridColumn;
                col.OptionsColumn.ReadOnly = !bEnabled;
                RepositoryItem item = col.ColumnEdit as RepositoryItemButtonEdit;
                if (item != null && item is RepositoryItemButtonEdit)
                {
                    foreach (EditorButton d in (item as RepositoryItemButtonEdit).Buttons)
                    {
                        d.Enabled = bEnabled;
                    }
                }
                return;
            }
            else if (aComponent is Bar)
            {
                var bar = aComponent as Bar;
                foreach (BarItemLink item in bar.ItemLinks)
                {
                    item.Item.Enabled = bEnabled;
                }
                return;
            }
            else if (aComponent is BarItem)
            {
                BarItem item = aComponent as BarItem;
                item.Enabled = bEnabled;
                return;
            }
            else if (aComponent is RibbonPage)
            {
                var item = aComponent as RibbonPage;
                foreach (RibbonPageGroup group in item.Groups)
                {
                    group.Enabled = bEnabled;
                }
                return;
            }
            else if (aComponent is RibbonPageGroup)
            {
                var item = aComponent as RibbonPageGroup;
                item.Enabled = bEnabled;
                return;
            }
            else if (aComponent is StandaloneBarDockControl)
            {
                (aComponent as StandaloneBarDockControl).Enabled = true;
                return;
            }

            //刷新Control
            Control aControl = aComponent as Control;
            if (aControl == null)
                return;
            if (aControl is BaseButton)
            {
                (aControl as BaseButton).Enabled = bEnabled;
            }
            else if (aControl is GridControl)
            {
                GridControl grid = aControl as GridControl;
                grid.Enabled = bEnabled;
            }
            else if (aControl is TreeList)
            {
                TreeList tree = aControl as TreeList;
                tree.Enabled = bEnabled;
            }
            else if (aControl is CheckEdit)
            {
                aControl.Enabled = bEnabled;
            }
            else if (aControl is TextEditorControl)
            {
                (aControl as TextEditorControl).IsReadOnly = !bEnabled;
            }
            else if (aControl is Controls.PropertyGrid)
            {
                (aControl as Controls.PropertyGrid).Editable = bEnabled;
            }
            else if (aControl is ListBoxControl)
            {
                //ListBoxControl 即只读
            }
            //else if (aControl is SAF.Framework.Controls.Charts.MenuChartControl)
            //{
            //    (aControl as SAF.Framework.Controls.Charts.MenuChartControl).ReadOnly = !bEnabled;
            //}
            else
            {
                Color color = bEnabled ? colorTrue : colorFalse;
                aControl.BackColor = color;
                //ComboBoxEdit、TextEdit、MemoEdit、CheckEdit
                RepositoryItem item = aControl.GetProperties<RepositoryItem>(true).FirstOrDefault();
                if (item != null)
                {
                    item.ReadOnly = !bEnabled;
                    if (item is RepositoryItemButtonEdit)
                    {
                        foreach (EditorButton d in (item as RepositoryItemButtonEdit).Buttons)
                        {
                            d.Enabled = bEnabled;
                        }
                    }
                }
                else
                {
                    aControl.Enabled = bEnabled;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="barItems"></param>
        public static void ShowBarItem(bool visible, params BarItem[] barItems)
        {
            if (barItems == null) return;
            foreach (var item in barItems)
            {
                item.Enabled = visible;
                item.Visibility = visible ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }

        public static void ShowRibbonPageGroup(bool visible, params RibbonPageGroup[] groups)
        {
            if (groups == null) return;
            foreach (var group in groups)
            {
                group.Enabled = visible;
                group.Visible = visible;
            }
        }
    }
}