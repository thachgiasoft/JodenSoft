using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Design;
using DevExpress.XtraRichEdit.UI;
namespace SAF.Framework.Controls.Charts
{
    partial class DescriptionControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DescriptionControl));
            this.richEditControl = new DevExpress.XtraRichEdit.RichEditControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.fontBar1 = new FontBar();
            this.toggleFontBoldItem1 = new ToggleFontBoldItem();
            this.toggleFontItalicItem1 = new ToggleFontItalicItem();
            this.toggleFontUnderlineItem1 = new ToggleFontUnderlineItem();
            this.toggleFontDoubleUnderlineItem1 = new ToggleFontDoubleUnderlineItem();
            this.toggleFontStrikeoutItem1 = new ToggleFontStrikeoutItem();
            this.toggleFontDoubleStrikeoutItem1 = new ToggleFontDoubleStrikeoutItem();
            this.toggleFontSuperscriptItem1 = new ToggleFontSuperscriptItem();
            this.toggleFontSubscriptItem1 = new ToggleFontSubscriptItem();
            this.showFontFormItem1 = new ShowFontFormItem();
            this.changeFontColorItem1 = new ChangeFontColorItem();
            this.changeParagraphBackColorItem1 = new ChangeParagraphBackColorItem();
            this.fontSizeIncreaseItem1 = new FontSizeIncreaseItem();
            this.fontSizeDecreaseItem1 = new FontSizeDecreaseItem();
            this.toggleBulletedListItem1 = new ToggleBulletedListItem();
            this.toggleNumberingListItem1 = new ToggleNumberingListItem();
            this.toggleMultiLevelListItem1 = new ToggleMultiLevelListItem();
            this.toggleParagraphAlignmentLeftItem1 = new ToggleParagraphAlignmentLeftItem();
            this.toggleParagraphAlignmentCenterItem1 = new ToggleParagraphAlignmentCenterItem();
            this.toggleParagraphAlignmentRightItem1 = new ToggleParagraphAlignmentRightItem();
            this.toggleParagraphAlignmentJustifyItem1 = new ToggleParagraphAlignmentJustifyItem();
            this.clearFormattingItem1 = new ClearFormattingItem();
            this.insertTableItem1 = new InsertTableItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.insertPageBreakItem1 = new InsertPageBreakItem();
            this.insertPictureItem1 = new InsertPictureItem();
            this.insertFloatingPictureItem1 = new InsertFloatingPictureItem();
            this.insertBookmarkItem1 = new InsertBookmarkItem();
            this.insertHyperlinkItem1 = new InsertHyperlinkItem();
            this.editPageHeaderItem1 = new EditPageHeaderItem();
            this.editPageFooterItem1 = new EditPageFooterItem();
            this.insertPageNumberItem1 = new InsertPageNumberItem();
            this.insertPageCountItem1 = new InsertPageCountItem();
            this.insertTextBoxItem1 = new InsertTextBoxItem();
            this.insertSymbolItem1 = new InsertSymbolItem();
            this.pasteItem1 = new PasteItem();
            this.cutItem1 = new CutItem();
            this.copyItem1 = new CopyItem();
            this.pasteSpecialItem1 = new PasteSpecialItem();
            this.makeTextUpperCaseItem1 = new MakeTextUpperCaseItem();
            this.makeTextLowerCaseItem1 = new MakeTextLowerCaseItem();
            this.toggleTextCaseItem1 = new ToggleTextCaseItem();
            this.setSingleParagraphSpacingItem1 = new SetSingleParagraphSpacingItem();
            this.setSesquialteralParagraphSpacingItem1 = new SetSesquialteralParagraphSpacingItem();
            this.setDoubleParagraphSpacingItem1 = new SetDoubleParagraphSpacingItem();
            this.showLineSpacingFormItem1 = new ShowLineSpacingFormItem();
            this.addSpacingBeforeParagraphItem1 = new AddSpacingBeforeParagraphItem();
            this.removeSpacingBeforeParagraphItem1 = new RemoveSpacingBeforeParagraphItem();
            this.addSpacingAfterParagraphItem1 = new AddSpacingAfterParagraphItem();
            this.removeSpacingAfterParagraphItem1 = new RemoveSpacingAfterParagraphItem();
            this.changeStyleItem1 = new ChangeStyleItem();
            this.repositoryItemRichEditStyleEdit1 = new RepositoryItemRichEditStyleEdit();
            this.showEditStyleFormItem1 = new ShowEditStyleFormItem();
            this.findItem1 = new FindItem();
            this.replaceItem1 = new ReplaceItem();
            this.repositoryItemFontEdit1 = new RepositoryItemFontEdit();
            this.repositoryItemRichEditFontSizeEdit1 = new RepositoryItemRichEditFontSizeEdit();
            this.richEditBarController1 = new RichEditBarController();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditFontSizeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).BeginInit();
            this.SuspendLayout();
            // 
            // richEditControl
            // 
            this.richEditControl.ActiveViewType = RichEditViewType.Simple;
            this.richEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControl.Location = new System.Drawing.Point(0, 31);
            this.richEditControl.MenuManager = this.barManager1;
            this.richEditControl.Name = "richEditControl";
            this.richEditControl.Options.Fields.UseCurrentCultureDateTimeFormat = false;
            this.richEditControl.Options.MailMerge.KeepLastParagraph = false;
            this.richEditControl.Size = new System.Drawing.Size(639, 267);
            this.richEditControl.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.Bars.AddRange(new Bar[] {
            this.fontBar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] {
            this.insertPageBreakItem1,
            this.insertTableItem1,
            this.insertPictureItem1,
            this.insertFloatingPictureItem1,
            this.insertBookmarkItem1,
            this.insertHyperlinkItem1,
            this.editPageHeaderItem1,
            this.editPageFooterItem1,
            this.insertPageNumberItem1,
            this.insertPageCountItem1,
            this.insertTextBoxItem1,
            this.insertSymbolItem1,
            this.pasteItem1,
            this.cutItem1,
            this.copyItem1,
            this.pasteSpecialItem1,
            this.fontSizeIncreaseItem1,
            this.fontSizeDecreaseItem1,
            this.toggleFontBoldItem1,
            this.toggleFontItalicItem1,
            this.toggleFontUnderlineItem1,
            this.toggleFontDoubleUnderlineItem1,
            this.toggleFontStrikeoutItem1,
            this.toggleFontDoubleStrikeoutItem1,
            this.toggleFontSuperscriptItem1,
            this.toggleFontSubscriptItem1,
            this.changeFontColorItem1,
            this.makeTextUpperCaseItem1,
            this.makeTextLowerCaseItem1,
            this.toggleTextCaseItem1,
            this.clearFormattingItem1,
            this.showFontFormItem1,
            this.toggleBulletedListItem1,
            this.toggleNumberingListItem1,
            this.toggleMultiLevelListItem1,
            this.toggleParagraphAlignmentLeftItem1,
            this.toggleParagraphAlignmentCenterItem1,
            this.toggleParagraphAlignmentRightItem1,
            this.toggleParagraphAlignmentJustifyItem1,
            this.setSingleParagraphSpacingItem1,
            this.setSesquialteralParagraphSpacingItem1,
            this.setDoubleParagraphSpacingItem1,
            this.showLineSpacingFormItem1,
            this.addSpacingBeforeParagraphItem1,
            this.removeSpacingBeforeParagraphItem1,
            this.addSpacingAfterParagraphItem1,
            this.removeSpacingAfterParagraphItem1,
            this.changeParagraphBackColorItem1,
            this.changeStyleItem1,
            this.showEditStyleFormItem1,
            this.findItem1,
            this.replaceItem1});
            this.barManager1.MaxItemId = 61;
            this.barManager1.RepositoryItems.AddRange(new RepositoryItem[] {
            this.repositoryItemFontEdit1,
            this.repositoryItemRichEditFontSizeEdit1,
            this.repositoryItemRichEditStyleEdit1});
            // 
            // fontBar1
            // 
            this.fontBar1.Control = this.richEditControl;
            this.fontBar1.DockCol = 0;
            this.fontBar1.DockRow = 0;
            this.fontBar1.DockStyle = BarDockStyle.Top;
            this.fontBar1.LinksPersistInfo.AddRange(new LinkPersistInfo[] {
            new LinkPersistInfo(this.toggleFontBoldItem1),
            new LinkPersistInfo(this.toggleFontItalicItem1),
            new LinkPersistInfo(this.toggleFontUnderlineItem1),
            new LinkPersistInfo(this.toggleFontDoubleUnderlineItem1),
            new LinkPersistInfo(this.toggleFontStrikeoutItem1),
            new LinkPersistInfo(this.toggleFontDoubleStrikeoutItem1),
            new LinkPersistInfo(this.toggleFontSuperscriptItem1),
            new LinkPersistInfo(this.toggleFontSubscriptItem1),
            new LinkPersistInfo(this.showFontFormItem1),
            new LinkPersistInfo(this.changeFontColorItem1),
            new LinkPersistInfo(this.changeParagraphBackColorItem1),
            new LinkPersistInfo(this.fontSizeIncreaseItem1),
            new LinkPersistInfo(this.fontSizeDecreaseItem1),
            new LinkPersistInfo(this.toggleBulletedListItem1, true),
            new LinkPersistInfo(this.toggleNumberingListItem1),
            new LinkPersistInfo(this.toggleMultiLevelListItem1),
            new LinkPersistInfo(this.toggleParagraphAlignmentLeftItem1, true),
            new LinkPersistInfo(this.toggleParagraphAlignmentCenterItem1),
            new LinkPersistInfo(this.toggleParagraphAlignmentRightItem1),
            new LinkPersistInfo(this.toggleParagraphAlignmentJustifyItem1),
            new LinkPersistInfo(this.clearFormattingItem1, true),
            new LinkPersistInfo(this.insertTableItem1, true)});
            this.fontBar1.OptionsBar.DrawDragBorder = false;
            // 
            // toggleFontBoldItem1
            // 
            this.toggleFontBoldItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontBoldItem1.Glyph")));
            this.toggleFontBoldItem1.Id = 20;
            this.toggleFontBoldItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontBoldItem1.LargeGlyph")));
            this.toggleFontBoldItem1.Name = "toggleFontBoldItem1";
            // 
            // toggleFontItalicItem1
            // 
            this.toggleFontItalicItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontItalicItem1.Glyph")));
            this.toggleFontItalicItem1.Id = 21;
            this.toggleFontItalicItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontItalicItem1.LargeGlyph")));
            this.toggleFontItalicItem1.Name = "toggleFontItalicItem1";
            // 
            // toggleFontUnderlineItem1
            // 
            this.toggleFontUnderlineItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontUnderlineItem1.Glyph")));
            this.toggleFontUnderlineItem1.Id = 22;
            this.toggleFontUnderlineItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontUnderlineItem1.LargeGlyph")));
            this.toggleFontUnderlineItem1.Name = "toggleFontUnderlineItem1";
            // 
            // toggleFontDoubleUnderlineItem1
            // 
            this.toggleFontDoubleUnderlineItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontDoubleUnderlineItem1.Glyph")));
            this.toggleFontDoubleUnderlineItem1.Id = 23;
            this.toggleFontDoubleUnderlineItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontDoubleUnderlineItem1.LargeGlyph")));
            this.toggleFontDoubleUnderlineItem1.Name = "toggleFontDoubleUnderlineItem1";
            // 
            // toggleFontStrikeoutItem1
            // 
            this.toggleFontStrikeoutItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontStrikeoutItem1.Glyph")));
            this.toggleFontStrikeoutItem1.Id = 24;
            this.toggleFontStrikeoutItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontStrikeoutItem1.LargeGlyph")));
            this.toggleFontStrikeoutItem1.Name = "toggleFontStrikeoutItem1";
            // 
            // toggleFontDoubleStrikeoutItem1
            // 
            this.toggleFontDoubleStrikeoutItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontDoubleStrikeoutItem1.Glyph")));
            this.toggleFontDoubleStrikeoutItem1.Id = 25;
            this.toggleFontDoubleStrikeoutItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontDoubleStrikeoutItem1.LargeGlyph")));
            this.toggleFontDoubleStrikeoutItem1.Name = "toggleFontDoubleStrikeoutItem1";
            // 
            // toggleFontSuperscriptItem1
            // 
            this.toggleFontSuperscriptItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontSuperscriptItem1.Glyph")));
            this.toggleFontSuperscriptItem1.Id = 26;
            this.toggleFontSuperscriptItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontSuperscriptItem1.LargeGlyph")));
            this.toggleFontSuperscriptItem1.Name = "toggleFontSuperscriptItem1";
            // 
            // toggleFontSubscriptItem1
            // 
            this.toggleFontSubscriptItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontSubscriptItem1.Glyph")));
            this.toggleFontSubscriptItem1.Id = 27;
            this.toggleFontSubscriptItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontSubscriptItem1.LargeGlyph")));
            this.toggleFontSubscriptItem1.Name = "toggleFontSubscriptItem1";
            // 
            // showFontFormItem1
            // 
            this.showFontFormItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("showFontFormItem1.Glyph")));
            this.showFontFormItem1.Id = 31;
            this.showFontFormItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("showFontFormItem1.LargeGlyph")));
            this.showFontFormItem1.Name = "showFontFormItem1";
            // 
            // changeFontColorItem1
            // 
            this.changeFontColorItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("changeFontColorItem1.Glyph")));
            this.changeFontColorItem1.Id = 28;
            this.changeFontColorItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("changeFontColorItem1.LargeGlyph")));
            this.changeFontColorItem1.Name = "changeFontColorItem1";
            // 
            // changeParagraphBackColorItem1
            // 
            this.changeParagraphBackColorItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("changeParagraphBackColorItem1.Glyph")));
            this.changeParagraphBackColorItem1.Id = 41;
            this.changeParagraphBackColorItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("changeParagraphBackColorItem1.LargeGlyph")));
            this.changeParagraphBackColorItem1.Name = "changeParagraphBackColorItem1";
            // 
            // fontSizeIncreaseItem1
            // 
            this.fontSizeIncreaseItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("fontSizeIncreaseItem1.Glyph")));
            this.fontSizeIncreaseItem1.Id = 18;
            this.fontSizeIncreaseItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("fontSizeIncreaseItem1.LargeGlyph")));
            this.fontSizeIncreaseItem1.Name = "fontSizeIncreaseItem1";
            // 
            // fontSizeDecreaseItem1
            // 
            this.fontSizeDecreaseItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("fontSizeDecreaseItem1.Glyph")));
            this.fontSizeDecreaseItem1.Id = 19;
            this.fontSizeDecreaseItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("fontSizeDecreaseItem1.LargeGlyph")));
            this.fontSizeDecreaseItem1.Name = "fontSizeDecreaseItem1";
            // 
            // toggleBulletedListItem1
            // 
            this.toggleBulletedListItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleBulletedListItem1.Glyph")));
            this.toggleBulletedListItem1.Id = 32;
            this.toggleBulletedListItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleBulletedListItem1.LargeGlyph")));
            this.toggleBulletedListItem1.Name = "toggleBulletedListItem1";
            // 
            // toggleNumberingListItem1
            // 
            this.toggleNumberingListItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleNumberingListItem1.Glyph")));
            this.toggleNumberingListItem1.Id = 33;
            this.toggleNumberingListItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleNumberingListItem1.LargeGlyph")));
            this.toggleNumberingListItem1.Name = "toggleNumberingListItem1";
            // 
            // toggleMultiLevelListItem1
            // 
            this.toggleMultiLevelListItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleMultiLevelListItem1.Glyph")));
            this.toggleMultiLevelListItem1.Id = 34;
            this.toggleMultiLevelListItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleMultiLevelListItem1.LargeGlyph")));
            this.toggleMultiLevelListItem1.Name = "toggleMultiLevelListItem1";
            // 
            // toggleParagraphAlignmentLeftItem1
            // 
            this.toggleParagraphAlignmentLeftItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleParagraphAlignmentLeftItem1.Glyph")));
            this.toggleParagraphAlignmentLeftItem1.Id = 37;
            this.toggleParagraphAlignmentLeftItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleParagraphAlignmentLeftItem1.LargeGlyph")));
            this.toggleParagraphAlignmentLeftItem1.Name = "toggleParagraphAlignmentLeftItem1";
            // 
            // toggleParagraphAlignmentCenterItem1
            // 
            this.toggleParagraphAlignmentCenterItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleParagraphAlignmentCenterItem1.Glyph")));
            this.toggleParagraphAlignmentCenterItem1.Id = 38;
            this.toggleParagraphAlignmentCenterItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleParagraphAlignmentCenterItem1.LargeGlyph")));
            this.toggleParagraphAlignmentCenterItem1.Name = "toggleParagraphAlignmentCenterItem1";
            // 
            // toggleParagraphAlignmentRightItem1
            // 
            this.toggleParagraphAlignmentRightItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleParagraphAlignmentRightItem1.Glyph")));
            this.toggleParagraphAlignmentRightItem1.Id = 39;
            this.toggleParagraphAlignmentRightItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleParagraphAlignmentRightItem1.LargeGlyph")));
            this.toggleParagraphAlignmentRightItem1.Name = "toggleParagraphAlignmentRightItem1";
            // 
            // toggleParagraphAlignmentJustifyItem1
            // 
            this.toggleParagraphAlignmentJustifyItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleParagraphAlignmentJustifyItem1.Glyph")));
            this.toggleParagraphAlignmentJustifyItem1.Id = 40;
            this.toggleParagraphAlignmentJustifyItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleParagraphAlignmentJustifyItem1.LargeGlyph")));
            this.toggleParagraphAlignmentJustifyItem1.Name = "toggleParagraphAlignmentJustifyItem1";
            // 
            // clearFormattingItem1
            // 
            this.clearFormattingItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("clearFormattingItem1.Glyph")));
            this.clearFormattingItem1.Id = 30;
            this.clearFormattingItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("clearFormattingItem1.LargeGlyph")));
            this.clearFormattingItem1.Name = "clearFormattingItem1";
            // 
            // insertTableItem1
            // 
            this.insertTableItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("insertTableItem1.Glyph")));
            this.insertTableItem1.Id = 1;
            this.insertTableItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("insertTableItem1.LargeGlyph")));
            this.insertTableItem1.Name = "insertTableItem1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(639, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 298);
            this.barDockControlBottom.Size = new System.Drawing.Size(639, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 267);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(639, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 267);
            // 
            // insertPageBreakItem1
            // 
            this.insertPageBreakItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("insertPageBreakItem1.Glyph")));
            this.insertPageBreakItem1.Id = 0;
            this.insertPageBreakItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("insertPageBreakItem1.LargeGlyph")));
            this.insertPageBreakItem1.Name = "insertPageBreakItem1";
            // 
            // insertPictureItem1
            // 
            this.insertPictureItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("insertPictureItem1.Glyph")));
            this.insertPictureItem1.Id = 2;
            this.insertPictureItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("insertPictureItem1.LargeGlyph")));
            this.insertPictureItem1.Name = "insertPictureItem1";
            // 
            // insertFloatingPictureItem1
            // 
            this.insertFloatingPictureItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("insertFloatingPictureItem1.Glyph")));
            this.insertFloatingPictureItem1.Id = 3;
            this.insertFloatingPictureItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("insertFloatingPictureItem1.LargeGlyph")));
            this.insertFloatingPictureItem1.Name = "insertFloatingPictureItem1";
            // 
            // insertBookmarkItem1
            // 
            this.insertBookmarkItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("insertBookmarkItem1.Glyph")));
            this.insertBookmarkItem1.Id = 4;
            this.insertBookmarkItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("insertBookmarkItem1.LargeGlyph")));
            this.insertBookmarkItem1.Name = "insertBookmarkItem1";
            // 
            // insertHyperlinkItem1
            // 
            this.insertHyperlinkItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("insertHyperlinkItem1.Glyph")));
            this.insertHyperlinkItem1.Id = 5;
            this.insertHyperlinkItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("insertHyperlinkItem1.LargeGlyph")));
            this.insertHyperlinkItem1.Name = "insertHyperlinkItem1";
            // 
            // editPageHeaderItem1
            // 
            this.editPageHeaderItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("editPageHeaderItem1.Glyph")));
            this.editPageHeaderItem1.Id = 6;
            this.editPageHeaderItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("editPageHeaderItem1.LargeGlyph")));
            this.editPageHeaderItem1.Name = "editPageHeaderItem1";
            // 
            // editPageFooterItem1
            // 
            this.editPageFooterItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("editPageFooterItem1.Glyph")));
            this.editPageFooterItem1.Id = 7;
            this.editPageFooterItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("editPageFooterItem1.LargeGlyph")));
            this.editPageFooterItem1.Name = "editPageFooterItem1";
            // 
            // insertPageNumberItem1
            // 
            this.insertPageNumberItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("insertPageNumberItem1.Glyph")));
            this.insertPageNumberItem1.Id = 8;
            this.insertPageNumberItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("insertPageNumberItem1.LargeGlyph")));
            this.insertPageNumberItem1.Name = "insertPageNumberItem1";
            // 
            // insertPageCountItem1
            // 
            this.insertPageCountItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("insertPageCountItem1.Glyph")));
            this.insertPageCountItem1.Id = 9;
            this.insertPageCountItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("insertPageCountItem1.LargeGlyph")));
            this.insertPageCountItem1.Name = "insertPageCountItem1";
            // 
            // insertTextBoxItem1
            // 
            this.insertTextBoxItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("insertTextBoxItem1.Glyph")));
            this.insertTextBoxItem1.Id = 10;
            this.insertTextBoxItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("insertTextBoxItem1.LargeGlyph")));
            this.insertTextBoxItem1.Name = "insertTextBoxItem1";
            // 
            // insertSymbolItem1
            // 
            this.insertSymbolItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("insertSymbolItem1.Glyph")));
            this.insertSymbolItem1.Id = 11;
            this.insertSymbolItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("insertSymbolItem1.LargeGlyph")));
            this.insertSymbolItem1.Name = "insertSymbolItem1";
            // 
            // pasteItem1
            // 
            this.pasteItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("pasteItem1.Glyph")));
            this.pasteItem1.Id = 42;
            this.pasteItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("pasteItem1.LargeGlyph")));
            this.pasteItem1.Name = "pasteItem1";
            // 
            // cutItem1
            // 
            this.cutItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("cutItem1.Glyph")));
            this.cutItem1.Id = 43;
            this.cutItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("cutItem1.LargeGlyph")));
            this.cutItem1.Name = "cutItem1";
            // 
            // copyItem1
            // 
            this.copyItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("copyItem1.Glyph")));
            this.copyItem1.Id = 44;
            this.copyItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("copyItem1.LargeGlyph")));
            this.copyItem1.Name = "copyItem1";
            // 
            // pasteSpecialItem1
            // 
            this.pasteSpecialItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("pasteSpecialItem1.Glyph")));
            this.pasteSpecialItem1.Id = 45;
            this.pasteSpecialItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("pasteSpecialItem1.LargeGlyph")));
            this.pasteSpecialItem1.Name = "pasteSpecialItem1";
            // 
            // makeTextUpperCaseItem1
            // 
            this.makeTextUpperCaseItem1.Id = 46;
            this.makeTextUpperCaseItem1.Name = "makeTextUpperCaseItem1";
            // 
            // makeTextLowerCaseItem1
            // 
            this.makeTextLowerCaseItem1.Id = 47;
            this.makeTextLowerCaseItem1.Name = "makeTextLowerCaseItem1";
            // 
            // toggleTextCaseItem1
            // 
            this.toggleTextCaseItem1.Id = 48;
            this.toggleTextCaseItem1.Name = "toggleTextCaseItem1";
            // 
            // setSingleParagraphSpacingItem1
            // 
            this.setSingleParagraphSpacingItem1.Id = 49;
            this.setSingleParagraphSpacingItem1.Name = "setSingleParagraphSpacingItem1";
            // 
            // setSesquialteralParagraphSpacingItem1
            // 
            this.setSesquialteralParagraphSpacingItem1.Id = 50;
            this.setSesquialteralParagraphSpacingItem1.Name = "setSesquialteralParagraphSpacingItem1";
            // 
            // setDoubleParagraphSpacingItem1
            // 
            this.setDoubleParagraphSpacingItem1.Id = 51;
            this.setDoubleParagraphSpacingItem1.Name = "setDoubleParagraphSpacingItem1";
            // 
            // showLineSpacingFormItem1
            // 
            this.showLineSpacingFormItem1.Id = 52;
            this.showLineSpacingFormItem1.Name = "showLineSpacingFormItem1";
            // 
            // addSpacingBeforeParagraphItem1
            // 
            this.addSpacingBeforeParagraphItem1.Id = 53;
            this.addSpacingBeforeParagraphItem1.Name = "addSpacingBeforeParagraphItem1";
            // 
            // removeSpacingBeforeParagraphItem1
            // 
            this.removeSpacingBeforeParagraphItem1.Id = 54;
            this.removeSpacingBeforeParagraphItem1.Name = "removeSpacingBeforeParagraphItem1";
            // 
            // addSpacingAfterParagraphItem1
            // 
            this.addSpacingAfterParagraphItem1.Id = 55;
            this.addSpacingAfterParagraphItem1.Name = "addSpacingAfterParagraphItem1";
            // 
            // removeSpacingAfterParagraphItem1
            // 
            this.removeSpacingAfterParagraphItem1.Id = 56;
            this.removeSpacingAfterParagraphItem1.Name = "removeSpacingAfterParagraphItem1";
            // 
            // changeStyleItem1
            // 
            this.changeStyleItem1.Edit = this.repositoryItemRichEditStyleEdit1;
            this.changeStyleItem1.Id = 57;
            this.changeStyleItem1.Name = "changeStyleItem1";
            // 
            // repositoryItemRichEditStyleEdit1
            // 
            this.repositoryItemRichEditStyleEdit1.AutoHeight = false;
            this.repositoryItemRichEditStyleEdit1.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.repositoryItemRichEditStyleEdit1.Control = this.richEditControl;
            this.repositoryItemRichEditStyleEdit1.Name = "repositoryItemRichEditStyleEdit1";
            // 
            // showEditStyleFormItem1
            // 
            this.showEditStyleFormItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("showEditStyleFormItem1.Glyph")));
            this.showEditStyleFormItem1.Id = 58;
            this.showEditStyleFormItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("showEditStyleFormItem1.LargeGlyph")));
            this.showEditStyleFormItem1.Name = "showEditStyleFormItem1";
            // 
            // findItem1
            // 
            this.findItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("findItem1.Glyph")));
            this.findItem1.Id = 59;
            this.findItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("findItem1.LargeGlyph")));
            this.findItem1.Name = "findItem1";
            // 
            // replaceItem1
            // 
            this.replaceItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("replaceItem1.Glyph")));
            this.replaceItem1.Id = 60;
            this.replaceItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("replaceItem1.LargeGlyph")));
            this.replaceItem1.Name = "replaceItem1";
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // repositoryItemRichEditFontSizeEdit1
            // 
            this.repositoryItemRichEditFontSizeEdit1.AutoHeight = false;
            this.repositoryItemRichEditFontSizeEdit1.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.repositoryItemRichEditFontSizeEdit1.Control = this.richEditControl;
            this.repositoryItemRichEditFontSizeEdit1.Name = "repositoryItemRichEditFontSizeEdit1";
            // 
            // richEditBarController1
            // 
            this.richEditBarController1.BarItems.Add(this.insertPageBreakItem1);
            this.richEditBarController1.BarItems.Add(this.insertTableItem1);
            this.richEditBarController1.BarItems.Add(this.insertPictureItem1);
            this.richEditBarController1.BarItems.Add(this.insertFloatingPictureItem1);
            this.richEditBarController1.BarItems.Add(this.insertBookmarkItem1);
            this.richEditBarController1.BarItems.Add(this.insertHyperlinkItem1);
            this.richEditBarController1.BarItems.Add(this.editPageHeaderItem1);
            this.richEditBarController1.BarItems.Add(this.editPageFooterItem1);
            this.richEditBarController1.BarItems.Add(this.insertPageNumberItem1);
            this.richEditBarController1.BarItems.Add(this.insertPageCountItem1);
            this.richEditBarController1.BarItems.Add(this.insertTextBoxItem1);
            this.richEditBarController1.BarItems.Add(this.insertSymbolItem1);
            this.richEditBarController1.BarItems.Add(this.pasteItem1);
            this.richEditBarController1.BarItems.Add(this.cutItem1);
            this.richEditBarController1.BarItems.Add(this.copyItem1);
            this.richEditBarController1.BarItems.Add(this.pasteSpecialItem1);
            this.richEditBarController1.BarItems.Add(this.fontSizeIncreaseItem1);
            this.richEditBarController1.BarItems.Add(this.fontSizeDecreaseItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontBoldItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontItalicItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontUnderlineItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontDoubleUnderlineItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontStrikeoutItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontDoubleStrikeoutItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontSuperscriptItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontSubscriptItem1);
            this.richEditBarController1.BarItems.Add(this.changeFontColorItem1);
            this.richEditBarController1.BarItems.Add(this.makeTextUpperCaseItem1);
            this.richEditBarController1.BarItems.Add(this.makeTextLowerCaseItem1);
            this.richEditBarController1.BarItems.Add(this.toggleTextCaseItem1);
            this.richEditBarController1.BarItems.Add(this.clearFormattingItem1);
            this.richEditBarController1.BarItems.Add(this.showFontFormItem1);
            this.richEditBarController1.BarItems.Add(this.toggleBulletedListItem1);
            this.richEditBarController1.BarItems.Add(this.toggleNumberingListItem1);
            this.richEditBarController1.BarItems.Add(this.toggleMultiLevelListItem1);
            this.richEditBarController1.BarItems.Add(this.toggleParagraphAlignmentLeftItem1);
            this.richEditBarController1.BarItems.Add(this.toggleParagraphAlignmentCenterItem1);
            this.richEditBarController1.BarItems.Add(this.toggleParagraphAlignmentRightItem1);
            this.richEditBarController1.BarItems.Add(this.toggleParagraphAlignmentJustifyItem1);
            this.richEditBarController1.BarItems.Add(this.setSingleParagraphSpacingItem1);
            this.richEditBarController1.BarItems.Add(this.setSesquialteralParagraphSpacingItem1);
            this.richEditBarController1.BarItems.Add(this.setDoubleParagraphSpacingItem1);
            this.richEditBarController1.BarItems.Add(this.showLineSpacingFormItem1);
            this.richEditBarController1.BarItems.Add(this.addSpacingBeforeParagraphItem1);
            this.richEditBarController1.BarItems.Add(this.removeSpacingBeforeParagraphItem1);
            this.richEditBarController1.BarItems.Add(this.addSpacingAfterParagraphItem1);
            this.richEditBarController1.BarItems.Add(this.removeSpacingAfterParagraphItem1);
            this.richEditBarController1.BarItems.Add(this.changeParagraphBackColorItem1);
            this.richEditBarController1.BarItems.Add(this.changeStyleItem1);
            this.richEditBarController1.BarItems.Add(this.showEditStyleFormItem1);
            this.richEditBarController1.BarItems.Add(this.findItem1);
            this.richEditBarController1.BarItems.Add(this.replaceItem1);
            this.richEditBarController1.Control = this.richEditControl;
            // 
            // DescriptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richEditControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "DescriptionControl";
            this.Size = new System.Drawing.Size(639, 298);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditFontSizeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RichEditControl richEditControl;
        private BarManager barManager1;
        private InsertPageBreakItem insertPageBreakItem1;
        private InsertTableItem insertTableItem1;
        private InsertPictureItem insertPictureItem1;
        private InsertFloatingPictureItem insertFloatingPictureItem1;
        private InsertBookmarkItem insertBookmarkItem1;
        private InsertHyperlinkItem insertHyperlinkItem1;
        private EditPageHeaderItem editPageHeaderItem1;
        private EditPageFooterItem editPageFooterItem1;
        private InsertPageNumberItem insertPageNumberItem1;
        private InsertPageCountItem insertPageCountItem1;
        private InsertTextBoxItem insertTextBoxItem1;
        private InsertSymbolItem insertSymbolItem1;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private RichEditBarController richEditBarController1;
        private FontBar fontBar1;
        private FontSizeIncreaseItem fontSizeIncreaseItem1;
        private FontSizeDecreaseItem fontSizeDecreaseItem1;
        private ToggleFontBoldItem toggleFontBoldItem1;
        private ToggleFontItalicItem toggleFontItalicItem1;
        private ToggleFontUnderlineItem toggleFontUnderlineItem1;
        private ToggleFontDoubleUnderlineItem toggleFontDoubleUnderlineItem1;
        private ToggleFontStrikeoutItem toggleFontStrikeoutItem1;
        private ToggleFontDoubleStrikeoutItem toggleFontDoubleStrikeoutItem1;
        private ToggleFontSuperscriptItem toggleFontSuperscriptItem1;
        private ToggleFontSubscriptItem toggleFontSubscriptItem1;
        private ChangeFontColorItem changeFontColorItem1;
        private ClearFormattingItem clearFormattingItem1;
        private ShowFontFormItem showFontFormItem1;
        private ToggleBulletedListItem toggleBulletedListItem1;
        private ToggleNumberingListItem toggleNumberingListItem1;
        private ToggleMultiLevelListItem toggleMultiLevelListItem1;
        private ToggleParagraphAlignmentLeftItem toggleParagraphAlignmentLeftItem1;
        private ToggleParagraphAlignmentCenterItem toggleParagraphAlignmentCenterItem1;
        private ToggleParagraphAlignmentRightItem toggleParagraphAlignmentRightItem1;
        private ToggleParagraphAlignmentJustifyItem toggleParagraphAlignmentJustifyItem1;
        private ChangeParagraphBackColorItem changeParagraphBackColorItem1;
        private PasteItem pasteItem1;
        private CutItem cutItem1;
        private CopyItem copyItem1;
        private PasteSpecialItem pasteSpecialItem1;
        private MakeTextUpperCaseItem makeTextUpperCaseItem1;
        private MakeTextLowerCaseItem makeTextLowerCaseItem1;
        private ToggleTextCaseItem toggleTextCaseItem1;
        private SetSingleParagraphSpacingItem setSingleParagraphSpacingItem1;
        private SetSesquialteralParagraphSpacingItem setSesquialteralParagraphSpacingItem1;
        private SetDoubleParagraphSpacingItem setDoubleParagraphSpacingItem1;
        private ShowLineSpacingFormItem showLineSpacingFormItem1;
        private AddSpacingBeforeParagraphItem addSpacingBeforeParagraphItem1;
        private RemoveSpacingBeforeParagraphItem removeSpacingBeforeParagraphItem1;
        private AddSpacingAfterParagraphItem addSpacingAfterParagraphItem1;
        private RemoveSpacingAfterParagraphItem removeSpacingAfterParagraphItem1;
        private ChangeStyleItem changeStyleItem1;
        private RepositoryItemRichEditStyleEdit repositoryItemRichEditStyleEdit1;
        private ShowEditStyleFormItem showEditStyleFormItem1;
        private FindItem findItem1;
        private ReplaceItem replaceItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit repositoryItemRichEditFontSizeEdit1;

    }
}
