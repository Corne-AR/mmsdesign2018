namespace AMS.Utilities.Forms
{
    partial class FileUtils
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
            this.location_TextBox = new System.Windows.Forms.TextBox();
            this.removeEmptyFolders_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.SuspendLayout();
            // 
            // location_TextBox
            // 
            this.location_TextBox.Location = new System.Drawing.Point(225, 183);
            this.location_TextBox.Name = "location_TextBox";
            this.location_TextBox.Size = new System.Drawing.Size(327, 20);
            this.location_TextBox.TabIndex = 0;
            // 
            // removeEmptyFolders_Button
            // 
            this.removeEmptyFolders_Button.Location = new System.Drawing.Point(144, 181);
            this.removeEmptyFolders_Button.Name = "removeEmptyFolders_Button";
            this.removeEmptyFolders_Button.Size = new System.Drawing.Size(75, 23);
            this.removeEmptyFolders_Button.TabIndex = 1;
            this.removeEmptyFolders_Button.Text = "Remove";
            this.removeEmptyFolders_Button.UseVisualStyleBackColor = true;
            this.removeEmptyFolders_Button.Click += new System.EventHandler(this.removeEmptyFolders_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Removes empty folders from location";
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 340);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(697, 60);
            this.footer1.TabIndex = 3;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(697, 30);
            this.header1.TabIndex = 4;
            // 
            // FileUtils
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 400);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeEmptyFolders_Button);
            this.Controls.Add(this.location_TextBox);
            this.Name = "FileUtils";
            this.Text = "FileUtils";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox location_TextBox;
        private System.Windows.Forms.Button removeEmptyFolders_Button;
        private System.Windows.Forms.Label label1;
        private UserInterface.UserControls.Footer footer1;
        private UserInterface.UserControls.Header header1;
    }
}