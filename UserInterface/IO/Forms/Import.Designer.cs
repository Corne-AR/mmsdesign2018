namespace MMS_Design.IO.Forms
{
    partial class Import
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
            this.access13DB_Button = new System.Windows.Forms.Button();
            this.client_Label = new System.Windows.Forms.Label();
            this.close_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.people_Label = new System.Windows.Forms.Label();
            this.dongles_Label = new System.Windows.Forms.Label();
            this.invoice_Label = new System.Windows.Forms.Label();
            this.id_Label = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.keywords_CheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // access13DB_Button
            // 
            this.access13DB_Button.Location = new System.Drawing.Point(48, 105);
            this.access13DB_Button.Name = "access13DB_Button";
            this.access13DB_Button.Size = new System.Drawing.Size(88, 23);
            this.access13DB_Button.TabIndex = 2;
            this.access13DB_Button.Text = "Clients";
            this.access13DB_Button.UseVisualStyleBackColor = true;
            this.access13DB_Button.Click += new System.EventHandler(this.GetClientData_Click);
            // 
            // client_Label
            // 
            this.client_Label.AutoSize = true;
            this.client_Label.Location = new System.Drawing.Point(143, 110);
            this.client_Label.Name = "client_Label";
            this.client_Label.Size = new System.Drawing.Size(33, 13);
            this.client_Label.TabIndex = 3;
            this.client_Label.Text = "Client";
            // 
            // close_Button
            // 
            this.close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Button.Location = new System.Drawing.Point(581, 208);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(80, 23);
            this.close_Button.TabIndex = 4;
            this.close_Button.Text = "Close";
            this.close_Button.UseVisualStyleBackColor = true;
            this.close_Button.Click += new System.EventHandler(this.close_Button_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(673, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Get Data from Old Access Datanase";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(673, 30);
            this.header1.TabIndex = 1;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 183);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(673, 60);
            this.footer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "People";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GetPeople_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Dongles";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.GetProducts_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(301, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Transactions";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // people_Label
            // 
            this.people_Label.AutoSize = true;
            this.people_Label.Location = new System.Drawing.Point(143, 139);
            this.people_Label.Name = "people_Label";
            this.people_Label.Size = new System.Drawing.Size(40, 13);
            this.people_Label.TabIndex = 9;
            this.people_Label.Text = "People";
            // 
            // dongles_Label
            // 
            this.dongles_Label.AutoSize = true;
            this.dongles_Label.Location = new System.Drawing.Point(394, 110);
            this.dongles_Label.Name = "dongles_Label";
            this.dongles_Label.Size = new System.Drawing.Size(41, 13);
            this.dongles_Label.TabIndex = 10;
            this.dongles_Label.Text = "Dongle";
            // 
            // invoice_Label
            // 
            this.invoice_Label.AutoSize = true;
            this.invoice_Label.Location = new System.Drawing.Point(395, 139);
            this.invoice_Label.Name = "invoice_Label";
            this.invoice_Label.Size = new System.Drawing.Size(42, 13);
            this.invoice_Label.TabIndex = 11;
            this.invoice_Label.Text = "Invoice";
            // 
            // id_Label
            // 
            this.id_Label.AutoSize = true;
            this.id_Label.Location = new System.Drawing.Point(395, 81);
            this.id_Label.Name = "id_Label";
            this.id_Label.Size = new System.Drawing.Size(18, 13);
            this.id_Label.TabIndex = 13;
            this.id_Label.Text = "ID";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(301, 76);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "New ID List";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.NewIDList_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(495, 208);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Connect";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Connect_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(551, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 129);
            this.label2.TabIndex = 15;
            this.label2.Text = "WARNING!\r\nThis will override data";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(49, 76);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 23);
            this.button6.TabIndex = 16;
            this.button6.Text = "All";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.GetAllDate_Event);
            // 
            // keywords_CheckBox
            // 
            this.keywords_CheckBox.AutoSize = true;
            this.keywords_CheckBox.Location = new System.Drawing.Point(182, 109);
            this.keywords_CheckBox.Name = "keywords_CheckBox";
            this.keywords_CheckBox.Size = new System.Drawing.Size(99, 17);
            this.keywords_CheckBox.TabIndex = 17;
            this.keywords_CheckBox.Text = "Extra Keywords";
            this.keywords_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 243);
            this.Controls.Add(this.keywords_CheckBox);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.id_Label);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.invoice_Label);
            this.Controls.Add(this.dongles_Label);
            this.Controls.Add(this.people_Label);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.client_Label);
            this.Controls.Add(this.access13DB_Button);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.footer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Import";
            this.Text = "Import";
            this.Load += new System.EventHandler(this.Import_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.UserInterface.UserControls.Footer footer1;
        private AMS.UserInterface.UserControls.Header header1;
        private System.Windows.Forms.Button access13DB_Button;
        private System.Windows.Forms.Label client_Label;
        private System.Windows.Forms.Button close_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label people_Label;
        private System.Windows.Forms.Label dongles_Label;
        private System.Windows.Forms.Label invoice_Label;
        private System.Windows.Forms.Label id_Label;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox keywords_CheckBox;
    }
}