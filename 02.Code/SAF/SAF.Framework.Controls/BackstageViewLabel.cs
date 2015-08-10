using DevExpress.XtraEditors;
using System.ComponentModel;

namespace SAF.Framework.Controls
{
    [ToolboxItem(true)]
    public class BackstageViewLabel : LabelControl
    {
        public BackstageViewLabel()
        {
            Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            LineVisible = true;
            ShowLineShadow = false;
        }
    }
}
