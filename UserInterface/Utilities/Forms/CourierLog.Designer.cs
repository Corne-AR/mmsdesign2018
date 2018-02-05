namespace UserInterface.Utilities.Forms
{
    partial class CourierLog
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
            this.mail_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.service_ComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.content_TextBox = new System.Windows.Forms.TextBox();
            this.trackingNr_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.address_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.address_ComboBox = new System.Windows.Forms.ComboBox();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.SuspendLayout();
            // 
            // cancel_Button
            // 
            this.cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_Button.Location = new System.Drawing.Point(521, 234);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 2;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // mail_Button
            // 
            this.mail_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mail_Button.Location = new System.Drawing.Point(440, 234);
            this.mail_Button.Name = "mail_Button";
            this.mail_Button.Size = new System.Drawing.Size(75, 23);
            this.mail_Button.TabIndex = 3;
            this.mail_Button.Text = "Mail";
            this.mail_Button.UseVisualStyleBackColor = true;
            this.mail_Button.Click += new System.EventHandler(this.MailInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Content";
            // 
            // service_ComboBox
            // 
            this.service_ComboBox.FormattingEnabled = true;
            this.service_ComboBox.Location = new System.Drawing.Point(130, 54);
            this.service_ComboBox.Name = "service_ComboBox";
            this.service_ComboBox.Size = new System.Drawing.Size(176, 21);
            this.service_ComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Service";
            // 
            // content_TextBox
            // 
            this.content_TextBox.Location = new System.Drawing.Point(371, 54);
            this.content_TextBox.Multiline = true;
            this.content_TextBox.Name = "content_TextBox";
            this.content_TextBox.Size = new System.Drawing.Size(176, 47);
            this.content_TextBox.TabIndex = 7;
            // 
            // trackingNr_TextBox
            // 
            this.trackingNr_TextBox.Location = new System.Drawing.Point(130, 81);
            this.trackingNr_TextBox.Name = "trackingNr_TextBox";
            this.trackingNr_TextBox.Size = new System.Drawing.Size(176, 20);
            this.trackingNr_TextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tracking Nr";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(130, 107);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(176, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Date";
            // 
            // address_TextBox
            // 
            this.address_TextBox.Location = new System.Drawing.Point(371, 128);
            this.address_TextBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.address_TextBox.Multiline = true;
            this.address_TextBox.Name = "address_TextBox";
            this.address_TextBox.Size = new System.Drawing.Size(176, 67);
            this.address_TextBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Address";
            // 
            // address_ComboBox
            // 
            this.address_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.address_ComboBox.FormattingEnabled = true;
            this.address_ComboBox.Items.AddRange(new object[] {
            "Postal",
            "Physical"});
            this.address_ComboBox.Location = new System.Drawing.Point(371, 107);
            this.address_ComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.address_ComboBox.Name = "address_ComboBox";
            this.address_ComboBox.Size = new System.Drawing.Size(176, 21);
            this.address_ComboBox.TabIndex = 14;
            this.address_ComboBox.SelectedIndexChanged += new System.EventHandler(this.address_ComboBox_SelectedIndexChanged);
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 209);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(608, 60);
            this.footer1.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(608, 30);
            this.header1.TabIndex = 0;
            // 
            // CourierLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 269);
            this.Controls.Add(this.address_ComboBox);
            this.Controls.Add(this.address_TextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackingNr_TextBox);
            this.Controls.Add(this.content_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.service_ComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mail_Button);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourierLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Courier Log";
            this.Load += new System.EventHandler(this.CourierLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.Button mail_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox service_ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox content_TextBox;
        private System.Windows.Forms.TextBox trackingNr_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox address_TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox address_ComboBox;
    }
}