namespace SAF.Framework.Controls.Test
{
    partial class GanttForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ganttControl1 = new SAF.Framework.Controls.GanttChart.GanttControl();
            this.SuspendLayout();
            // 
            // ganttControl1
            // 
            this.ganttControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganttControl1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ganttControl1.GanntView = SAF.Framework.Controls.GanttChart.GanttView.HourView;
            this.ganttControl1.IsReadOnly = false;
            this.ganttControl1.Location = new System.Drawing.Point(0, 0);
            this.ganttControl1.Name = "ganttControl1";
            this.ganttControl1.ShowTooltip = false;
            this.ganttControl1.Size = new System.Drawing.Size(972, 441);
            this.ganttControl1.TabIndex = 0;
            this.ganttControl1.Text = "ganttControl1";
            // 
            // GanttForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 441);
            this.Controls.Add(this.ganttControl1);
            this.Name = "GanttForm";
            this.Text = "GanttForm";
            this.ResumeLayout(false);

        }

        #endregion

        private GanttChart.GanttControl ganttControl1;
    }
}