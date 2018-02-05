namespace AMS.UserInterface.UserControls
{
    partial class TabControl
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
            this.tabControl_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl_flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_flowLayoutPanel
            // 
            this.tabControl_flowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabControl_flowLayoutPanel.Controls.Add(this.label1);
            this.tabControl_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tabControl_flowLayoutPanel.Name = "tabControl_flowLayoutPanel";
            this.tabControl_flowLayoutPanel.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.tabControl_flowLayoutPanel.Size = new System.Drawing.Size(800, 26);
            this.tabControl_flowLayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu Item";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 3);
            this.panel1.TabIndex = 1;
            // 
            // TabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl_flowLayoutPanel);
            this.Name = "TabControl";
            this.Size = new System.Drawing.Size(800, 26);
            this.tabControl_flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.FlowLayoutPanel tabControl_flowLayoutPanel;
        private System.Windows.Forms.Panel panel1;
    }
}
