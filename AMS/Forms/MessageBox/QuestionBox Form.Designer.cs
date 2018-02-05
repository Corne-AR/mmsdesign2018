namespace AMS.Forms.MessageBox
{
    partial class QuestionBox_Form
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
            this.yes_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.no_Button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.message_textBox = new System.Windows.Forms.TextBox();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // yes_button
            // 
            this.yes_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yes_button.Location = new System.Drawing.Point(3, 6);
            this.yes_button.Name = "yes_button";
            this.yes_button.Size = new System.Drawing.Size(75, 23);
            this.yes_button.TabIndex = 0;
            this.yes_button.Text = "Yes";
            this.yes_button.UseVisualStyleBackColor = true;
            this.yes_button.Click += new System.EventHandler(this.yes_button_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.message_textBox);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 127);
            this.panel2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 84);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(359, 20);
            this.textBox1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 104);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(359, 23);
            this.panel3.TabIndex = 7;
            // 
            // no_Button
            // 
            this.no_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.no_Button.Location = new System.Drawing.Point(84, 6);
            this.no_Button.Name = "no_Button";
            this.no_Button.Size = new System.Drawing.Size(75, 23);
            this.no_Button.TabIndex = 1;
            this.no_Button.Text = "No";
            this.no_Button.UseVisualStyleBackColor = true;
            this.no_Button.Click += new System.EventHandler(this.no_Button_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.yes_button);
            this.panel1.Controls.Add(this.no_Button);
            this.panel1.Location = new System.Drawing.Point(110, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 32);
            this.panel1.TabIndex = 6;
            // 
            // message_textBox
            // 
            this.message_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.message_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.message_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message_textBox.Location = new System.Drawing.Point(0, 0);
            this.message_textBox.Multiline = true;
            this.message_textBox.Name = "message_textBox";
            this.message_textBox.ReadOnly = true;
            this.message_textBox.Size = new System.Drawing.Size(359, 84);
            this.message_textBox.TabIndex = 8;
            this.message_textBox.Text = "Message";
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(383, 30);
            this.header1.TabIndex = 0;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 169);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(383, 60);
            this.footer1.TabIndex = 1;
            // 
            // QuestionBox_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(383, 229);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.footer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionBox_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            this.Load += new System.EventHandler(this.MessageBox_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserInterface.UserControls.Header header1;
        private UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button yes_button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button no_Button;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox message_textBox;
    }
}