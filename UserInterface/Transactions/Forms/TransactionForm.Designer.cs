namespace UserInterface.Transactions.Forms
{
    partial class TransactionForm
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
            this.components = new System.ComponentModel.Container();
            this.save_Button = new System.Windows.Forms.Button();
            this.close_Button = new System.Windows.Forms.Button();
            this.mail_Button = new System.Windows.Forms.Button();
            this.generate_Button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.preview_Button = new System.Windows.Forms.Button();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.clientNotes_CheckBox = new System.Windows.Forms.CheckBox();
            this.accountant_CheckBox = new System.Windows.Forms.CheckBox();
            this.supplierInfo_checkBox = new System.Windows.Forms.CheckBox();
            this.itemListEditor = new UserInterface.Transactions.UserControls.ItemListEditor();
            this.transactionFooter1 = new UserInterface.Transactions.UserControls.TransactionFooter();
            this.transactionHeader1 = new UserInterface.Transactions.UserControls.TransactionHeader();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.saveAndClose_Button = new System.Windows.Forms.Button();
            this.convertToZAR_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // save_Button
            // 
            this.save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_Button.Location = new System.Drawing.Point(818, 565);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 7;
            this.save_Button.Text = "Save";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.Save_Click);
            // 
            // close_Button
            // 
            this.close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_Button.Location = new System.Drawing.Point(899, 565);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(75, 23);
            this.close_Button.TabIndex = 8;
            this.close_Button.Text = "Close";
            this.close_Button.UseVisualStyleBackColor = true;
            this.close_Button.Click += new System.EventHandler(this.Close_Click);
            // 
            // mail_Button
            // 
            this.mail_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mail_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mail_Button.Location = new System.Drawing.Point(151, 565);
            this.mail_Button.Name = "mail_Button";
            this.mail_Button.Size = new System.Drawing.Size(75, 23);
            this.mail_Button.TabIndex = 10;
            this.mail_Button.Text = "Mail";
            this.mail_Button.UseVisualStyleBackColor = true;
            this.mail_Button.Click += new System.EventHandler(this.Mail_Click);
            // 
            // generate_Button
            // 
            this.generate_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.generate_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generate_Button.Location = new System.Drawing.Point(73, 565);
            this.generate_Button.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.generate_Button.Name = "generate_Button";
            this.generate_Button.Size = new System.Drawing.Size(75, 23);
            this.generate_Button.TabIndex = 11;
            this.generate_Button.Text = "Generate";
            this.generate_Button.UseVisualStyleBackColor = true;
            this.generate_Button.Click += new System.EventHandler(this.Generate_Click);
            // 
            // preview_Button
            // 
            this.preview_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.preview_Button.BackgroundImage = global::UserInterface.Properties.Resources.pdf;
            this.preview_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.preview_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preview_Button.Location = new System.Drawing.Point(232, 565);
            this.preview_Button.Name = "preview_Button";
            this.preview_Button.Size = new System.Drawing.Size(28, 23);
            this.preview_Button.TabIndex = 14;
            this.preview_Button.UseVisualStyleBackColor = true;
            this.preview_Button.Click += new System.EventHandler(this.preview_Button_Click);
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 540);
            this.footer1.Margin = new System.Windows.Forms.Padding(4);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(986, 60);
            this.footer1.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Margin = new System.Windows.Forms.Padding(0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(986, 30);
            this.header1.TabIndex = 0;
            // 
            // clientNotes_CheckBox
            // 
            this.clientNotes_CheckBox.AutoSize = true;
            this.clientNotes_CheckBox.Location = new System.Drawing.Point(353, 569);
            this.clientNotes_CheckBox.Name = "clientNotes_CheckBox";
            this.clientNotes_CheckBox.Size = new System.Drawing.Size(83, 17);
            this.clientNotes_CheckBox.TabIndex = 16;
            this.clientNotes_CheckBox.Text = "Client Notes";
            this.clientNotes_CheckBox.UseVisualStyleBackColor = true;
            // 
            // accountant_CheckBox
            // 
            this.accountant_CheckBox.AutoSize = true;
            this.accountant_CheckBox.Location = new System.Drawing.Point(266, 569);
            this.accountant_CheckBox.Name = "accountant_CheckBox";
            this.accountant_CheckBox.Size = new System.Drawing.Size(81, 17);
            this.accountant_CheckBox.TabIndex = 17;
            this.accountant_CheckBox.Text = "Accountant";
            this.accountant_CheckBox.UseVisualStyleBackColor = true;
            // 
            // supplierInfo_checkBox
            // 
            this.supplierInfo_checkBox.AutoSize = true;
            this.supplierInfo_checkBox.Location = new System.Drawing.Point(442, 569);
            this.supplierInfo_checkBox.Name = "supplierInfo_checkBox";
            this.supplierInfo_checkBox.Size = new System.Drawing.Size(132, 17);
            this.supplierInfo_checkBox.TabIndex = 18;
            this.supplierInfo_checkBox.Text = "Use Our Info not client";
            this.supplierInfo_checkBox.UseVisualStyleBackColor = true;
            this.supplierInfo_checkBox.CheckedChanged += new System.EventHandler(this.supplierInfo_checkBox_CheckedChanged);
            // 
            // itemListEditor
            // 
            this.itemListEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemListEditor.Location = new System.Drawing.Point(0, 0);
            this.itemListEditor.Margin = new System.Windows.Forms.Padding(4);
            this.itemListEditor.Name = "itemListEditor";
            this.itemListEditor.Padding = new System.Windows.Forms.Padding(3);
            this.itemListEditor.Size = new System.Drawing.Size(986, 299);
            this.itemListEditor.TabIndex = 4;
            // 
            // transactionFooter1
            // 
            this.transactionFooter1.AutoSize = true;
            this.transactionFooter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionFooter1.Location = new System.Drawing.Point(0, 0);
            this.transactionFooter1.Margin = new System.Windows.Forms.Padding(4);
            this.transactionFooter1.Name = "transactionFooter1";
            this.transactionFooter1.Size = new System.Drawing.Size(986, 117);
            this.transactionFooter1.TabIndex = 12;
            // 
            // transactionHeader1
            // 
            this.transactionHeader1.AutoSize = true;
            this.transactionHeader1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.transactionHeader1.BackColor = System.Drawing.SystemColors.Control;
            this.transactionHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.transactionHeader1.Location = new System.Drawing.Point(0, 30);
            this.transactionHeader1.Margin = new System.Windows.Forms.Padding(0);
            this.transactionHeader1.Name = "transactionHeader1";
            this.transactionHeader1.Size = new System.Drawing.Size(986, 90);
            this.transactionHeader1.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 120);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.itemListEditor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.transactionFooter1);
            this.splitContainer1.Size = new System.Drawing.Size(986, 420);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.TabIndex = 19;
            // 
            // saveAndClose_Button
            // 
            this.saveAndClose_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAndClose_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveAndClose_Button.Location = new System.Drawing.Point(711, 565);
            this.saveAndClose_Button.Name = "saveAndClose_Button";
            this.saveAndClose_Button.Size = new System.Drawing.Size(101, 23);
            this.saveAndClose_Button.TabIndex = 20;
            this.saveAndClose_Button.Text = "Save and Close";
            this.saveAndClose_Button.UseVisualStyleBackColor = true;
            this.saveAndClose_Button.Click += new System.EventHandler(this.saveAndClose_Button_Click);
            // 
            // convertToZAR_button
            // 
            this.convertToZAR_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.convertToZAR_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.convertToZAR_button.Location = new System.Drawing.Point(608, 565);
            this.convertToZAR_button.Name = "convertToZAR_button";
            this.convertToZAR_button.Size = new System.Drawing.Size(97, 23);
            this.convertToZAR_button.TabIndex = 21;
            this.convertToZAR_button.Text = "Convert to ZAR";
            this.convertToZAR_button.UseVisualStyleBackColor = true;
            this.convertToZAR_button.Click += new System.EventHandler(this.convertToZAR_Click);
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 600);
            this.Controls.Add(this.convertToZAR_button);
            this.Controls.Add(this.saveAndClose_Button);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.supplierInfo_checkBox);
            this.Controls.Add(this.accountant_CheckBox);
            this.Controls.Add(this.clientNotes_CheckBox);
            this.Controls.Add(this.preview_Button);
            this.Controls.Add(this.generate_Button);
            this.Controls.Add(this.mail_Button);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.transactionHeader1);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "TransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transaction";
            this.Load += new System.EventHandler(this.Transaction_Load);
            this.Shown += new System.EventHandler(this.TransactionForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private Transactions.UserControls.ItemListEditor itemListEditor;
        private Transactions.UserControls.TransactionHeader transactionHeader1;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button close_Button;
        private System.Windows.Forms.Button mail_Button;
        private System.Windows.Forms.Button generate_Button;
        private Transactions.UserControls.TransactionFooter transactionFooter1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button preview_Button;
        private System.Windows.Forms.CheckBox clientNotes_CheckBox;
        private System.Windows.Forms.CheckBox accountant_CheckBox;
        private System.Windows.Forms.CheckBox supplierInfo_checkBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button saveAndClose_Button;
        private System.Windows.Forms.Button convertToZAR_button;
    }
}