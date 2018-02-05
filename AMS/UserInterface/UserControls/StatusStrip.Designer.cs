namespace AMS.UserInterface.UserControls
{
    partial class StatusStrip
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.seactionOne_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.dataInfo_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.top_Panel = new System.Windows.Forms.Panel();
            this.area_statusStrip = new System.Windows.Forms.StatusStrip();
            this.AMS_ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.area_statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip2
            // 
            this.seactionOne_StatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(146)))), ((int)(((byte)(47)))));
            this.seactionOne_StatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seactionOne_StatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.seactionOne_StatusStrip.Location = new System.Drawing.Point(54, 3);
            this.seactionOne_StatusStrip.Name = "statusStrip2";
            this.seactionOne_StatusStrip.Size = new System.Drawing.Size(765, 22);
            this.seactionOne_StatusStrip.SizingGrip = false;
            this.seactionOne_StatusStrip.TabIndex = 0;
            this.seactionOne_StatusStrip.Text = "statusStrip2";
            // 
            // statusStrip3
            // 
            this.dataInfo_StatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(146)))), ((int)(((byte)(47)))));
            this.dataInfo_StatusStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataInfo_StatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.dataInfo_StatusStrip.Location = new System.Drawing.Point(819, 3);
            this.dataInfo_StatusStrip.Name = "statusStrip3";
            this.dataInfo_StatusStrip.Size = new System.Drawing.Size(202, 22);
            this.dataInfo_StatusStrip.SizingGrip = false;
            this.dataInfo_StatusStrip.TabIndex = 0;
            this.dataInfo_StatusStrip.Text = "statusStrip3";
            // 
            // top_Panel
            // 
            this.top_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_Panel.Location = new System.Drawing.Point(0, 0);
            this.top_Panel.Name = "top_Panel";
            this.top_Panel.Size = new System.Drawing.Size(1021, 3);
            this.top_Panel.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.area_statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(146)))), ((int)(((byte)(47)))));
            this.area_statusStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.area_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AMS_ToolStripStatusLabel});
            this.area_statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.area_statusStrip.Location = new System.Drawing.Point(0, 3);
            this.area_statusStrip.Name = "statusStrip1";
            this.area_statusStrip.Size = new System.Drawing.Size(54, 22);
            this.area_statusStrip.SizingGrip = false;
            this.area_statusStrip.TabIndex = 2;
            this.area_statusStrip.Text = "statusStrip1";
            // 
            // AMS_ToolStripStatusLabel
            // 
            this.AMS_ToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.AMS_ToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.AMS_ToolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AMS_ToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.AMS_ToolStripStatusLabel.Name = "AMS_ToolStripStatusLabel";
            this.AMS_ToolStripStatusLabel.Size = new System.Drawing.Size(37, 17);
            this.AMS_ToolStripStatusLabel.Text = "AMS";
            // 
            // StatusStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.seactionOne_StatusStrip);
            this.Controls.Add(this.dataInfo_StatusStrip);
            this.Controls.Add(this.area_statusStrip);
            this.Controls.Add(this.top_Panel);
            this.Name = "StatusStrip";
            this.Size = new System.Drawing.Size(1021, 25);
            this.area_statusStrip.ResumeLayout(false);
            this.area_statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip seactionOne_StatusStrip;
        private System.Windows.Forms.StatusStrip dataInfo_StatusStrip;
        private System.Windows.Forms.Panel top_Panel;
        private System.Windows.Forms.StatusStrip area_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel AMS_ToolStripStatusLabel;
    }
}
