namespace UserInterface.People.Forms
{
    partial class ClientExtra
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
            this.cancel_Button = new System.Windows.Forms.Button();
            this.save_Button = new System.Windows.Forms.Button();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.keywords_TabPage = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.keywords_TabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel_Button
            // 
            this.cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_Button.Location = new System.Drawing.Point(370, 378);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 2;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // save_Button
            // 
            this.save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_Button.Location = new System.Drawing.Point(289, 378);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 3;
            this.save_Button.Text = "Save";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 353);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(457, 60);
            this.footer1.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(457, 30);
            this.header1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.keywords_TabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(457, 323);
            this.tabControl1.TabIndex = 4;
            // 
            // keywords_TabPage
            // 
            this.keywords_TabPage.Controls.Add(this.textBox1);
            this.keywords_TabPage.Controls.Add(this.label1);
            this.keywords_TabPage.Location = new System.Drawing.Point(4, 22);
            this.keywords_TabPage.Name = "keywords_TabPage";
            this.keywords_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.keywords_TabPage.Size = new System.Drawing.Size(449, 297);
            this.keywords_TabPage.TabIndex = 0;
            this.keywords_TabPage.Text = "Keywords";
            this.keywords_TabPage.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 291);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(271, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(9);
            this.label1.Size = new System.Drawing.Size(175, 122);
            this.label1.TabIndex = 1;
            this.label1.Text = "Keywords are used to associate\r\na specific client to related data,\r\nfor example a" +
    " typical entry on\r\na receipt reference from the\r\nclient\r\n\r\n\r\nUse one keyword per" +
    " line.";
            // 
            // ClientExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 413);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClientExtra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Manager";
            this.Load += new System.EventHandler(this.ClientManager_Load);
            this.tabControl1.ResumeLayout(false);
            this.keywords_TabPage.ResumeLayout(false);
            this.keywords_TabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage keywords_TabPage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}