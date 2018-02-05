namespace UserInterface.Products.Forms
{
    partial class ProductEditor
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
            System.Windows.Forms.Label accountLabel;
            System.Windows.Forms.Label catalogNameLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label expiryDateLabel;
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label priceLabel;
            System.Windows.Forms.Label userCountLabel;
            System.Windows.Forms.Label versionLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.accountComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.expiryDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.iDTextBox = new System.Windows.Forms.TextBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.stolenCheckBox = new System.Windows.Forms.CheckBox();
            this.userCountTextBox = new System.Windows.Forms.TextBox();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.save_Button = new System.Windows.Forms.Button();
            this.catalog_ComboBox = new System.Windows.Forms.ComboBox();
            this.items_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.remove_Button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.supplier_Label = new System.Windows.Forms.Label();
            this.supplierInfo_Label = new System.Windows.Forms.Label();
            this.supplier_ComboBox = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataLog1 = new AMS.Forms.Log.DataLog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.priceNumbox = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            accountLabel = new System.Windows.Forms.Label();
            catalogNameLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            expiryDateLabel = new System.Windows.Forms.Label();
            iDLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            userCountLabel = new System.Windows.Forms.Label();
            versionLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumbox)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountLabel
            // 
            accountLabel.AutoSize = true;
            accountLabel.Location = new System.Drawing.Point(278, 43);
            accountLabel.Name = "accountLabel";
            accountLabel.Size = new System.Drawing.Size(47, 13);
            accountLabel.TabIndex = 0;
            accountLabel.Text = "Account";
            // 
            // catalogNameLabel
            // 
            catalogNameLabel.AutoSize = true;
            catalogNameLabel.Location = new System.Drawing.Point(6, 57);
            catalogNameLabel.Margin = new System.Windows.Forms.Padding(6, 7, 3, 0);
            catalogNameLabel.Name = "catalogNameLabel";
            catalogNameLabel.Size = new System.Drawing.Size(43, 13);
            catalogNameLabel.TabIndex = 0;
            catalogNameLabel.Text = "Catalog";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(6, 32);
            descriptionLabel.Margin = new System.Windows.Forms.Padding(6, 7, 3, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(60, 13);
            descriptionLabel.TabIndex = 0;
            descriptionLabel.Text = "Description";
            // 
            // expiryDateLabel
            // 
            expiryDateLabel.AutoSize = true;
            expiryDateLabel.Location = new System.Drawing.Point(6, 7);
            expiryDateLabel.Margin = new System.Windows.Forms.Padding(6, 7, 3, 0);
            expiryDateLabel.Name = "expiryDateLabel";
            expiryDateLabel.Size = new System.Drawing.Size(61, 13);
            expiryDateLabel.TabIndex = 0;
            expiryDateLabel.Text = "Expiry Date";
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(6, 7);
            iDLabel.Margin = new System.Windows.Forms.Padding(6, 7, 3, 0);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(75, 13);
            iDLabel.TabIndex = 0;
            iDLabel.Text = "Product Name";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(6, 27);
            priceLabel.Margin = new System.Windows.Forms.Padding(6, 7, 3, 0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(31, 13);
            priceLabel.TabIndex = 0;
            priceLabel.Text = "Price";
            // 
            // userCountLabel
            // 
            userCountLabel.AutoSize = true;
            userCountLabel.Location = new System.Drawing.Point(6, 67);
            userCountLabel.Margin = new System.Windows.Forms.Padding(6, 7, 3, 0);
            userCountLabel.Name = "userCountLabel";
            userCountLabel.Size = new System.Drawing.Size(60, 13);
            userCountLabel.TabIndex = 0;
            userCountLabel.Text = "User Count";
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Location = new System.Drawing.Point(6, 47);
            versionLabel.Margin = new System.Windows.Forms.Padding(6, 7, 3, 0);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new System.Drawing.Size(42, 13);
            versionLabel.TabIndex = 0;
            versionLabel.Text = "Version";
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 520);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 13);
            label1.TabIndex = 0;
            label1.Text = "Stolen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 178);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(44, 13);
            label2.TabIndex = 0;
            label2.Text = "Content";
            // 
            // accountComboBox
            // 
            this.accountComboBox.FormattingEnabled = true;
            this.accountComboBox.Location = new System.Drawing.Point(331, 40);
            this.accountComboBox.Name = "accountComboBox";
            this.accountComboBox.Size = new System.Drawing.Size(338, 21);
            this.accountComboBox.TabIndex = 1;
            this.accountComboBox.SelectedIndexChanged += new System.EventHandler(this.accountComboBox_SelectedIndexChanged);
            this.accountComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.accountComboBox_KeyDown);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(103, 28);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(174, 20);
            this.descriptionTextBox.TabIndex = 3;
            // 
            // expiryDateDateTimePicker
            // 
            this.expiryDateDateTimePicker.Location = new System.Drawing.Point(103, 3);
            this.expiryDateDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.expiryDateDateTimePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.expiryDateDateTimePicker.Name = "expiryDateDateTimePicker";
            this.expiryDateDateTimePicker.Size = new System.Drawing.Size(174, 20);
            this.expiryDateDateTimePicker.TabIndex = 5;
            // 
            // iDTextBox
            // 
            this.iDTextBox.Location = new System.Drawing.Point(103, 3);
            this.iDTextBox.Name = "iDTextBox";
            this.iDTextBox.Size = new System.Drawing.Size(174, 20);
            this.iDTextBox.TabIndex = 2;
            this.iDTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.iDTextBox_KeyDown);
            // 
            // notesTextBox
            // 
            this.notesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notesTextBox.Location = new System.Drawing.Point(3, 3);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(905, 262);
            this.notesTextBox.TabIndex = 11;
            // 
            // stolenCheckBox
            // 
            this.stolenCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stolenCheckBox.AutoSize = true;
            this.stolenCheckBox.Location = new System.Drawing.Point(55, 520);
            this.stolenCheckBox.Name = "stolenCheckBox";
            this.stolenCheckBox.Size = new System.Drawing.Size(15, 14);
            this.stolenCheckBox.TabIndex = 9;
            this.stolenCheckBox.UseVisualStyleBackColor = true;
            // 
            // userCountTextBox
            // 
            this.userCountTextBox.Location = new System.Drawing.Point(103, 63);
            this.userCountTextBox.Name = "userCountTextBox";
            this.userCountTextBox.Size = new System.Drawing.Size(174, 20);
            this.userCountTextBox.TabIndex = 8;
            // 
            // versionTextBox
            // 
            this.versionTextBox.Location = new System.Drawing.Point(103, 43);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(174, 20);
            this.versionTextBox.TabIndex = 7;
            // 
            // cancel_Button
            // 
            this.cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_Button.Location = new System.Drawing.Point(859, 565);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 14;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // save_Button
            // 
            this.save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_Button.Location = new System.Drawing.Point(697, 565);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 12;
            this.save_Button.Text = "Save";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // catalog_ComboBox
            // 
            this.catalog_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.catalog_ComboBox.FormattingEnabled = true;
            this.catalog_ComboBox.Location = new System.Drawing.Point(103, 53);
            this.catalog_ComboBox.Name = "catalog_ComboBox";
            this.catalog_ComboBox.Size = new System.Drawing.Size(174, 21);
            this.catalog_ComboBox.TabIndex = 4;
            this.catalog_ComboBox.SelectedIndexChanged += new System.EventHandler(this.catalog_ComboBox_SelectedIndexChanged);
            // 
            // items_FlowLayoutPanel
            // 
            this.items_FlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.items_FlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.items_FlowLayoutPanel.Location = new System.Drawing.Point(12, 194);
            this.items_FlowLayoutPanel.Name = "items_FlowLayoutPanel";
            this.items_FlowLayoutPanel.Size = new System.Drawing.Size(922, 20);
            this.items_FlowLayoutPanel.TabIndex = 10;
            // 
            // remove_Button
            // 
            this.remove_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remove_Button.Location = new System.Drawing.Point(778, 565);
            this.remove_Button.Name = "remove_Button";
            this.remove_Button.Size = new System.Drawing.Size(75, 23);
            this.remove_Button.TabIndex = 13;
            this.remove_Button.Text = "Remove";
            this.remove_Button.UseVisualStyleBackColor = true;
            this.remove_Button.Click += new System.EventHandler(this.remove_Button_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // supplier_Label
            // 
            this.supplier_Label.AutoSize = true;
            this.supplier_Label.Location = new System.Drawing.Point(6, 7);
            this.supplier_Label.Margin = new System.Windows.Forms.Padding(6, 7, 3, 0);
            this.supplier_Label.Name = "supplier_Label";
            this.supplier_Label.Size = new System.Drawing.Size(45, 13);
            this.supplier_Label.TabIndex = 15;
            this.supplier_Label.Text = "Supplier";
            // 
            // supplierInfo_Label
            // 
            this.supplierInfo_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.supplierInfo_Label.Location = new System.Drawing.Point(619, 100);
            this.supplierInfo_Label.Margin = new System.Windows.Forms.Padding(3);
            this.supplierInfo_Label.Name = "supplierInfo_Label";
            this.supplierInfo_Label.Size = new System.Drawing.Size(280, 70);
            this.supplierInfo_Label.TabIndex = 16;
            this.supplierInfo_Label.Text = "Supplier Info";
            // 
            // supplier_ComboBox
            // 
            this.supplier_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplier_ComboBox.FormattingEnabled = true;
            this.supplier_ComboBox.Location = new System.Drawing.Point(103, 3);
            this.supplier_ComboBox.Name = "supplier_ComboBox";
            this.supplier_ComboBox.Size = new System.Drawing.Size(174, 21);
            this.supplier_ComboBox.TabIndex = 18;
            this.supplier_ComboBox.SelectedIndexChanged += new System.EventHandler(this.supplier_ComboBox_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 220);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(919, 294);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.notesTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(911, 268);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Notes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataLog1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(911, 268);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataLog1
            // 
            this.dataLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLog1.Location = new System.Drawing.Point(3, 3);
            this.dataLog1.Name = "dataLog1";
            this.dataLog1.Size = new System.Drawing.Size(905, 262);
            this.dataLog1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.Controls.Add(iDLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.iDTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(descriptionLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.descriptionTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(catalogNameLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.catalog_ComboBox, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(47, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 100);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(expiryDateLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.expiryDateDateTimePicker, 1, 0);
            this.tableLayoutPanel2.Controls.Add(priceLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(versionLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.versionTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(userCountLabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.userCountTextBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.priceNumbox, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(333, 70);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(280, 100);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // priceNumbox
            // 
            this.priceNumbox.DecimalPlaces = 2;
            this.priceNumbox.Location = new System.Drawing.Point(103, 23);
            this.priceNumbox.Name = "priceNumbox";
            this.priceNumbox.Size = new System.Drawing.Size(174, 20);
            this.priceNumbox.TabIndex = 9;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.supplier_Label, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.supplier_ComboBox, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(619, 70);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(280, 27);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 540);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(946, 60);
            this.footer1.TabIndex = 0;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(946, 30);
            this.header1.TabIndex = 0;
            // 
            // ProductEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 600);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.supplierInfo_Label);
            this.Controls.Add(this.remove_Button);
            this.Controls.Add(label2);
            this.Controls.Add(this.items_FlowLayoutPanel);
            this.Controls.Add(label1);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(accountLabel);
            this.Controls.Add(this.accountComboBox);
            this.Controls.Add(this.stolenCheckBox);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Editor";
            this.Load += new System.EventHandler(this.ProductEditor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumbox)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.ComboBox accountComboBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.DateTimePicker expiryDateDateTimePicker;
        private System.Windows.Forms.TextBox iDTextBox;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.CheckBox stolenCheckBox;
        private System.Windows.Forms.TextBox userCountTextBox;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.ComboBox catalog_ComboBox;
        private System.Windows.Forms.FlowLayoutPanel items_FlowLayoutPanel;
        private System.Windows.Forms.Button remove_Button;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label supplier_Label;
        private System.Windows.Forms.Label supplierInfo_Label;
        private System.Windows.Forms.ComboBox supplier_ComboBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private AMS.Forms.Log.DataLog dataLog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown priceNumbox;
    }
}