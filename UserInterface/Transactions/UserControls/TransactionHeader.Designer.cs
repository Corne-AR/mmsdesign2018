namespace UserInterface.Transactions.UserControls
{
    partial class TransactionHeader
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
            this.components = new System.ComponentModel.Container();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.transactionNrTextBox = new System.Windows.Forms.TextBox();
            this.transaction_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.useVatCheckBox = new System.Windows.Forms.CheckBox();
            this.currency_TextBox = new System.Windows.Forms.TextBox();
            this.account_TextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.telephone_TextBox = new System.Windows.Forms.TextBox();
            this.date_Label = new System.Windows.Forms.Label();
            this.email_TextBox = new System.Windows.Forms.TextBox();
            this.contact_ComboBox = new System.Windows.Forms.ComboBox();
            this.type_TextBox = new System.Windows.Forms.TextBox();
            this.clientRef_Textbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.void_CheckBox = new System.Windows.Forms.CheckBox();
            this.paid_CheckBox = new System.Windows.Forms.CheckBox();
            this.audit_CheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.vat_TextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.due_Label = new System.Windows.Forms.Label();
            this.date_Button = new System.Windows.Forms.Button();
            this.due_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.payementTerms_Label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.afr_checkBox = new System.Windows.Forms.CheckBox();
            this.mailed_checkBox = new System.Windows.Forms.CheckBox();
            this.ClientID_textBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.transaction_BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(689, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Terms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(551, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(689, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Currency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Contact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Tel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Client Ref";
            // 
            // transactionNrTextBox
            // 
            this.transactionNrTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transactionNrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "ID", true));
            this.transactionNrTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.transactionNrTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionNrTextBox.Location = new System.Drawing.Point(0, 0);
            this.transactionNrTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.transactionNrTextBox.Name = "transactionNrTextBox";
            this.transactionNrTextBox.ReadOnly = true;
            this.transactionNrTextBox.Size = new System.Drawing.Size(968, 17);
            this.transactionNrTextBox.TabIndex = 2;
            this.transactionNrTextBox.Text = "Transaction Nr";
            this.transactionNrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // transaction_BindingSource
            // 
            this.transaction_BindingSource.DataSource = typeof(Data.Transactions.Transaction);
            // 
            // useVatCheckBox
            // 
            this.useVatCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.useVatCheckBox.AutoSize = true;
            this.useVatCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.transaction_BindingSource, "UseVat", true));
            this.useVatCheckBox.Location = new System.Drawing.Point(843, 69);
            this.useVatCheckBox.Margin = new System.Windows.Forms.Padding(1);
            this.useVatCheckBox.Name = "useVatCheckBox";
            this.useVatCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.useVatCheckBox.Size = new System.Drawing.Size(42, 17);
            this.useVatCheckBox.TabIndex = 13;
            this.useVatCheckBox.Text = "Vat";
            this.useVatCheckBox.UseVisualStyleBackColor = true;
            this.useVatCheckBox.CheckedChanged += new System.EventHandler(this.useVatCheckBox_CheckedChanged);
            // 
            // currency_TextBox
            // 
            this.currency_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currency_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "Currency", true));
            this.currency_TextBox.Location = new System.Drawing.Point(742, 72);
            this.currency_TextBox.Margin = new System.Windows.Forms.Padding(1);
            this.currency_TextBox.Name = "currency_TextBox";
            this.currency_TextBox.Size = new System.Drawing.Size(56, 13);
            this.currency_TextBox.TabIndex = 14;
            this.currency_TextBox.Text = "EURO";
            this.currency_TextBox.TextChanged += new System.EventHandler(this.currency_TextBox_TextChanged);
            // 
            // account_TextBox
            // 
            this.account_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.account_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "Account", true));
            this.account_TextBox.Location = new System.Drawing.Point(66, 45);
            this.account_TextBox.Margin = new System.Windows.Forms.Padding(1);
            this.account_TextBox.Name = "account_TextBox";
            this.account_TextBox.Size = new System.Drawing.Size(114, 20);
            this.account_TextBox.TabIndex = 18;
            this.account_TextBox.Text = "AE0120";
            this.account_TextBox.TextChanged += new System.EventHandler(this.TransactionLoad_Event);
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "Client.Name", true));
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(3, 22);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(303, 20);
            this.nameTextBox.TabIndex = 24;
            this.nameTextBox.Text = "Company Info";
            this.nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // telephone_TextBox
            // 
            this.telephone_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.telephone_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "Client.Telephone", true));
            this.telephone_TextBox.Location = new System.Drawing.Point(375, 48);
            this.telephone_TextBox.Margin = new System.Windows.Forms.Padding(1);
            this.telephone_TextBox.Name = "telephone_TextBox";
            this.telephone_TextBox.ReadOnly = true;
            this.telephone_TextBox.Size = new System.Drawing.Size(141, 13);
            this.telephone_TextBox.TabIndex = 25;
            this.telephone_TextBox.Text = "+27 82 000 1234";
            // 
            // date_Label
            // 
            this.date_Label.AutoSize = true;
            this.date_Label.Location = new System.Drawing.Point(583, 47);
            this.date_Label.Name = "date_Label";
            this.date_Label.Size = new System.Drawing.Size(89, 13);
            this.date_Label.TabIndex = 26;
            this.date_Label.Text = "20 Janurary 2013\r\n";
            // 
            // email_TextBox
            // 
            this.email_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "Email", true));
            this.email_TextBox.Location = new System.Drawing.Point(375, 68);
            this.email_TextBox.Margin = new System.Windows.Forms.Padding(1);
            this.email_TextBox.Name = "email_TextBox";
            this.email_TextBox.Size = new System.Drawing.Size(141, 20);
            this.email_TextBox.TabIndex = 29;
            this.email_TextBox.Text = "somelongemail@looooooooog.com";
            // 
            // contact_ComboBox
            // 
            this.contact_ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "Contact", true));
            this.contact_ComboBox.FormattingEnabled = true;
            this.contact_ComboBox.Location = new System.Drawing.Point(375, 22);
            this.contact_ComboBox.Margin = new System.Windows.Forms.Padding(1);
            this.contact_ComboBox.Name = "contact_ComboBox";
            this.contact_ComboBox.Size = new System.Drawing.Size(141, 21);
            this.contact_ComboBox.TabIndex = 31;
            this.contact_ComboBox.Text = "Koos Boos van Tonder";
            this.contact_ComboBox.SelectedIndexChanged += new System.EventHandler(this.ContactSelect_Event);
            this.contact_ComboBox.TextChanged += new System.EventHandler(this.contact_ComboBox_TextChanged);
            // 
            // type_TextBox
            // 
            this.type_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.type_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "Type", true));
            this.type_TextBox.Location = new System.Drawing.Point(586, 25);
            this.type_TextBox.Margin = new System.Windows.Forms.Padding(1);
            this.type_TextBox.Name = "type_TextBox";
            this.type_TextBox.ReadOnly = true;
            this.type_TextBox.Size = new System.Drawing.Size(61, 13);
            this.type_TextBox.TabIndex = 32;
            this.type_TextBox.Text = "Proforma";
            // 
            // clientRef_Textbox
            // 
            this.clientRef_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientRef_Textbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "ClientRef", true));
            this.clientRef_Textbox.Location = new System.Drawing.Point(66, 68);
            this.clientRef_Textbox.Margin = new System.Windows.Forms.Padding(1);
            this.clientRef_Textbox.Name = "clientRef_Textbox";
            this.clientRef_Textbox.Size = new System.Drawing.Size(60, 20);
            this.clientRef_Textbox.TabIndex = 34;
            this.clientRef_Textbox.Text = "PO098475031";
            this.clientRef_Textbox.TextChanged += new System.EventHandler(this.TransactionLoad_Event);
            this.clientRef_Textbox.Leave += new System.EventHandler(this.clientRef_Textbox_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(315, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 50);
            this.panel1.TabIndex = 36;
            // 
            // void_CheckBox
            // 
            this.void_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.void_CheckBox.AutoSize = true;
            this.void_CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.transaction_BindingSource, "IsVoid", true));
            this.void_CheckBox.Location = new System.Drawing.Point(915, 25);
            this.void_CheckBox.Margin = new System.Windows.Forms.Padding(1);
            this.void_CheckBox.Name = "void_CheckBox";
            this.void_CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.void_CheckBox.Size = new System.Drawing.Size(47, 17);
            this.void_CheckBox.TabIndex = 37;
            this.void_CheckBox.Text = "Void";
            this.void_CheckBox.UseVisualStyleBackColor = true;
            this.void_CheckBox.CheckedChanged += new System.EventHandler(this.Void_Event);
            // 
            // paid_CheckBox
            // 
            this.paid_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paid_CheckBox.AutoSize = true;
            this.paid_CheckBox.Location = new System.Drawing.Point(838, 24);
            this.paid_CheckBox.Margin = new System.Windows.Forms.Padding(1);
            this.paid_CheckBox.Name = "paid_CheckBox";
            this.paid_CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.paid_CheckBox.Size = new System.Drawing.Size(47, 17);
            this.paid_CheckBox.TabIndex = 38;
            this.paid_CheckBox.Text = "Paid";
            this.paid_CheckBox.UseVisualStyleBackColor = true;
            this.paid_CheckBox.CheckedChanged += new System.EventHandler(this.Paid_Event);
            // 
            // audit_CheckBox
            // 
            this.audit_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.audit_CheckBox.AutoSize = true;
            this.audit_CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.transaction_BindingSource, "IsAudit", true));
            this.audit_CheckBox.Location = new System.Drawing.Point(835, 46);
            this.audit_CheckBox.Margin = new System.Windows.Forms.Padding(1);
            this.audit_CheckBox.Name = "audit_CheckBox";
            this.audit_CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.audit_CheckBox.Size = new System.Drawing.Size(50, 17);
            this.audit_CheckBox.TabIndex = 39;
            this.audit_CheckBox.Text = "Audit";
            this.audit_CheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Vat Nr";
            // 
            // vat_TextBox
            // 
            this.vat_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vat_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "Client.VatNr", true));
            this.vat_TextBox.Location = new System.Drawing.Point(225, 48);
            this.vat_TextBox.Margin = new System.Windows.Forms.Padding(1);
            this.vat_TextBox.Name = "vat_TextBox";
            this.vat_TextBox.ReadOnly = true;
            this.vat_TextBox.Size = new System.Drawing.Size(81, 13);
            this.vat_TextBox.TabIndex = 42;
            this.vat_TextBox.Text = "460019875235";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "Forex", true));
            this.textBox3.Location = new System.Drawing.Point(743, 45);
            this.textBox3.Margin = new System.Windows.Forms.Padding(1);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(56, 20);
            this.textBox3.TabIndex = 44;
            this.textBox3.Text = "10.57";
            this.textBox3.TextChanged += new System.EventHandler(this.TransactionLoad_Event);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Location = new System.Drawing.Point(523, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 50);
            this.panel2.TabIndex = 45;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Location = new System.Drawing.Point(805, 24);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 50);
            this.panel3.TabIndex = 46;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(692, 45);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 20);
            this.button3.TabIndex = 47;
            this.button3.Text = "Forex";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // due_Label
            // 
            this.due_Label.AutoSize = true;
            this.due_Label.Location = new System.Drawing.Point(583, 72);
            this.due_Label.Name = "due_Label";
            this.due_Label.Size = new System.Drawing.Size(89, 13);
            this.due_Label.TabIndex = 49;
            this.due_Label.Text = "27 Janurary 2013\r\n";
            // 
            // date_Button
            // 
            this.date_Button.Location = new System.Drawing.Point(530, 45);
            this.date_Button.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.date_Button.Name = "date_Button";
            this.date_Button.Size = new System.Drawing.Size(47, 20);
            this.date_Button.TabIndex = 50;
            this.date_Button.Text = "Date";
            this.date_Button.UseVisualStyleBackColor = true;
            this.date_Button.Click += new System.EventHandler(this.SetDate_Event);
            // 
            // due_Button
            // 
            this.due_Button.Location = new System.Drawing.Point(530, 68);
            this.due_Button.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.due_Button.Name = "due_Button";
            this.due_Button.Size = new System.Drawing.Size(47, 20);
            this.due_Button.TabIndex = 51;
            this.due_Button.Text = "Due";
            this.due_Button.UseVisualStyleBackColor = true;
            this.due_Button.Click += new System.EventHandler(this.SetDueDate_Event);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Account";
            // 
            // payementTerms_Label
            // 
            this.payementTerms_Label.AutoSize = true;
            this.payementTerms_Label.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "PaymentTerms", true));
            this.payementTerms_Label.Location = new System.Drawing.Point(740, 24);
            this.payementTerms_Label.Name = "payementTerms_Label";
            this.payementTerms_Label.Size = new System.Drawing.Size(36, 13);
            this.payementTerms_Label.TabIndex = 54;
            this.payementTerms_Label.Text = "Terms";
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.LoadTransaction_Tick);
            // 
            // afr_checkBox
            // 
            this.afr_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.afr_checkBox.AutoSize = true;
            this.afr_checkBox.Location = new System.Drawing.Point(893, 70);
            this.afr_checkBox.Name = "afr_checkBox";
            this.afr_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.afr_checkBox.Size = new System.Drawing.Size(70, 17);
            this.afr_checkBox.TabIndex = 55;
            this.afr_checkBox.Text = "Afrikaans";
            this.afr_checkBox.UseVisualStyleBackColor = true;
            this.afr_checkBox.Click += new System.EventHandler(this.afr_checkBox_Click);
            // 
            // mailed_checkBox
            // 
            this.mailed_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mailed_checkBox.AutoSize = true;
            this.mailed_checkBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.transaction_BindingSource, "IsMailed", true));
            this.mailed_checkBox.Location = new System.Drawing.Point(905, 49);
            this.mailed_checkBox.Margin = new System.Windows.Forms.Padding(1);
            this.mailed_checkBox.Name = "mailed_checkBox";
            this.mailed_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mailed_checkBox.Size = new System.Drawing.Size(57, 17);
            this.mailed_checkBox.TabIndex = 57;
            this.mailed_checkBox.Text = "Mailed";
            this.mailed_checkBox.UseVisualStyleBackColor = true;
            // 
            // ClientID_textBox
            // 
            this.ClientID_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClientID_textBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "ClientID", true));
            this.ClientID_textBox.Location = new System.Drawing.Point(225, 68);
            this.ClientID_textBox.Margin = new System.Windows.Forms.Padding(1);
            this.ClientID_textBox.Name = "ClientID_textBox";
            this.ClientID_textBox.Size = new System.Drawing.Size(62, 20);
            this.ClientID_textBox.TabIndex = 58;
            this.ClientID_textBox.Text = "AC0411";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(165, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Ref. Client";
            // 
            // TransactionHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ClientID_textBox);
            this.Controls.Add(this.mailed_checkBox);
            this.Controls.Add(this.afr_checkBox);
            this.Controls.Add(this.payementTerms_Label);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.due_Button);
            this.Controls.Add(this.date_Button);
            this.Controls.Add(this.due_Label);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vat_TextBox);
            this.Controls.Add(this.audit_CheckBox);
            this.Controls.Add(this.paid_CheckBox);
            this.Controls.Add(this.void_CheckBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clientRef_Textbox);
            this.Controls.Add(this.type_TextBox);
            this.Controls.Add(this.contact_ComboBox);
            this.Controls.Add(this.email_TextBox);
            this.Controls.Add(this.date_Label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.telephone_TextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.account_TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.currency_TextBox);
            this.Controls.Add(this.useVatCheckBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.transactionNrTextBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TransactionHeader";
            this.Size = new System.Drawing.Size(968, 90);
            this.Load += new System.EventHandler(this.TransactionHeader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transaction_BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource transaction_BindingSource;
        private System.Windows.Forms.TextBox transactionNrTextBox;
        private System.Windows.Forms.CheckBox useVatCheckBox;
        private System.Windows.Forms.TextBox currency_TextBox;
        private System.Windows.Forms.TextBox account_TextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox telephone_TextBox;
        private System.Windows.Forms.Label date_Label;
        private System.Windows.Forms.TextBox email_TextBox;
        private System.Windows.Forms.ComboBox contact_ComboBox;
        private System.Windows.Forms.TextBox type_TextBox;
        private System.Windows.Forms.TextBox clientRef_Textbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox void_CheckBox;
        private System.Windows.Forms.CheckBox paid_CheckBox;
        private System.Windows.Forms.CheckBox audit_CheckBox;
        private System.Windows.Forms.TextBox vat_TextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label due_Label;
        private System.Windows.Forms.Button date_Button;
        private System.Windows.Forms.Button due_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label payementTerms_Label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox afr_checkBox;
        private System.Windows.Forms.CheckBox mailed_checkBox;
        private System.Windows.Forms.TextBox ClientID_textBox;
        private System.Windows.Forms.Label label10;
    }
}
