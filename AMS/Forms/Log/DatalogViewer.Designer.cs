namespace AMS.Forms.Log
{
    partial class DatalogViewer
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
            this.close_Button = new System.Windows.Forms.Button();
            this.dataLog1 = new AMS.Forms.Log.DataLog();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // close_Button
            // 
            this.close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Button.Location = new System.Drawing.Point(732, 537);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(75, 23);
            this.close_Button.TabIndex = 4;
            this.close_Button.Text = "Close";
            this.close_Button.UseVisualStyleBackColor = true;
            this.close_Button.Click += new System.EventHandler(this.close_Button_Click);
            // 
            // dataLog1
            // 
            this.dataLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLog1.Location = new System.Drawing.Point(0, 30);
            this.dataLog1.Name = "dataLog1";
            this.dataLog1.Size = new System.Drawing.Size(819, 482);
            this.dataLog1.TabIndex = 5;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 512);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(819, 60);
            this.footer1.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(819, 30);
            this.header1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(651, 537);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DatalogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 572);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataLog1);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DatalogViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataLogForm";
            this.Load += new System.EventHandler(this.DatalogViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserInterface.UserControls.Header header1;
        private UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button close_Button;
        private DataLog dataLog1;
        private System.Windows.Forms.Button button1;
    }
}