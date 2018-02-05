namespace AMS.UserInterface.UserControls
{
    partial class Header
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
            this.theme_Panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.minimize_Label = new System.Windows.Forms.Label();
            this.close_Label = new System.Windows.Forms.Label();
            this.maximize_Label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // theme_Panel
            // 
            this.theme_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(146)))), ((int)(((byte)(47)))));
            this.theme_Panel.Location = new System.Drawing.Point(0, 18);
            this.theme_Panel.Name = "theme_Panel";
            this.theme_Panel.Size = new System.Drawing.Size(60, 3);
            this.theme_Panel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(48, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 30);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(36, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(6, 30);
            this.panel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.maximize_Label);
            this.panel1.Controls.Add(this.minimize_Label);
            this.panel1.Controls.Add(this.close_Label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 30);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // minimize_Label
            // 
            this.minimize_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimize_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimize_Label.Location = new System.Drawing.Point(955, 0);
            this.minimize_Label.Name = "minimize_Label";
            this.minimize_Label.Size = new System.Drawing.Size(30, 30);
            this.minimize_Label.TabIndex = 1;
            this.minimize_Label.Text = "─";
            this.minimize_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minimize_Label.Visible = false;
            this.minimize_Label.Click += new System.EventHandler(this.Minimize_click);
            // 
            // close_Label
            // 
            this.close_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_Label.Location = new System.Drawing.Point(985, 0);
            this.close_Label.Name = "close_Label";
            this.close_Label.Size = new System.Drawing.Size(30, 30);
            this.close_Label.TabIndex = 0;
            this.close_Label.Text = "X";
            this.close_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.close_Label.Visible = false;
            this.close_Label.Click += new System.EventHandler(this.Close_Click);
            // 
            // maximize_Label
            // 
            this.maximize_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximize_Label.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.maximize_Label.Location = new System.Drawing.Point(925, 0);
            this.maximize_Label.Name = "maximize_Label";
            this.maximize_Label.Size = new System.Drawing.Size(30, 30);
            this.maximize_Label.TabIndex = 2;
            this.maximize_Label.Text = "q";
            this.maximize_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maximize_Label.Visible = false;
            this.maximize_Label.Click += new System.EventHandler(this.Maximize_Click);
            // 
            // Header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.theme_Panel);
            this.Controls.Add(this.panel1);
            this.Name = "Header";
            this.Size = new System.Drawing.Size(1015, 30);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel theme_Panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label close_Label;
        private System.Windows.Forms.Label minimize_Label;
        private System.Windows.Forms.Label maximize_Label;
    }
}
