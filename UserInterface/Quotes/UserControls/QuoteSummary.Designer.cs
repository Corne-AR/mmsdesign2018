namespace UserInterface.Quotes.UserControls
{
    partial class QuoteSummary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.discount_TextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.email_TextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.account_Textbox = new System.Windows.Forms.Label();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cod_RadioButton = new System.Windows.Forms.RadioButton();
            this.thirtyDay_RadioButton = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tranactionNr_Label = new System.Windows.Forms.Label();
            this.clientName_Label = new System.Windows.Forms.Label();
            this.contact_ComboBox = new System.Windows.Forms.ComboBox();
            this.maint_Panel = new System.Windows.Forms.Panel();
            this.extended_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.maintenance_CheckBox = new System.Windows.Forms.CheckBox();
            this.extendMonths_TextBox = new System.Windows.Forms.TextBox();
            this.months_Label = new System.Windows.Forms.Label();
            this.itemized_CheckBox = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.currency_ComboBox = new System.Windows.Forms.ComboBox();
            this.productList_DataGridView = new System.Windows.Forms.DataGridView();
            this.Description_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceInVat_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPriceInVatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showItemInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemList_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.quoteInfo_Label = new System.Windows.Forms.Label();
            this.totals_DataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totals_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.addCost_TextBox = new System.Windows.Forms.TextBox();
            this.codOnly_checkBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_AbsaFx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ExportFx = new System.Windows.Forms.TextBox();
            this.lblExportFx = new System.Windows.Forms.Label();
            this.lblAbsaFx = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.maint_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productList_DataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemList_BindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totals_DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totals_BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 432);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Currency";
            // 
            // discount_TextBox
            // 
            this.discount_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.discount_TextBox.Location = new System.Drawing.Point(74, 485);
            this.discount_TextBox.Name = "discount_TextBox";
            this.discount_TextBox.Size = new System.Drawing.Size(62, 20);
            this.discount_TextBox.TabIndex = 6;
            this.discount_TextBox.TextChanged += new System.EventHandler(this.UpdateQuote_Event);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Contact";
            // 
            // email_TextBox
            // 
            this.email_TextBox.Location = new System.Drawing.Point(72, 94);
            this.email_TextBox.Name = "email_TextBox";
            this.email_TextBox.Size = new System.Drawing.Size(208, 20);
            this.email_TextBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Email";
            // 
            // account_Textbox
            // 
            this.account_Textbox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.account_Textbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "Account", true));
            this.account_Textbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.account_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_Textbox.Location = new System.Drawing.Point(0, 31);
            this.account_Textbox.Name = "account_Textbox";
            this.account_Textbox.Size = new System.Drawing.Size(152, 31);
            this.account_Textbox.TabIndex = 13;
            this.account_Textbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(Data.People.Client);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.cod_RadioButton);
            this.flowLayoutPanel2.Controls.Add(this.thirtyDay_RadioButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(74, 456);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(110, 25);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // cod_RadioButton
            // 
            this.cod_RadioButton.AutoSize = true;
            this.cod_RadioButton.Location = new System.Drawing.Point(1, 3);
            this.cod_RadioButton.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.cod_RadioButton.Name = "cod_RadioButton";
            this.cod_RadioButton.Size = new System.Drawing.Size(48, 17);
            this.cod_RadioButton.TabIndex = 2;
            this.cod_RadioButton.TabStop = true;
            this.cod_RadioButton.Text = "COD";
            this.cod_RadioButton.UseVisualStyleBackColor = true;
            this.cod_RadioButton.CheckedChanged += new System.EventHandler(this.UpdateQuoteDetails_Event);
            // 
            // thirtyDay_RadioButton
            // 
            this.thirtyDay_RadioButton.AutoSize = true;
            this.thirtyDay_RadioButton.Location = new System.Drawing.Point(51, 3);
            this.thirtyDay_RadioButton.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.thirtyDay_RadioButton.Name = "thirtyDay_RadioButton";
            this.thirtyDay_RadioButton.Size = new System.Drawing.Size(56, 17);
            this.thirtyDay_RadioButton.TabIndex = 3;
            this.thirtyDay_RadioButton.TabStop = true;
            this.thirtyDay_RadioButton.Text = "30Day";
            this.thirtyDay_RadioButton.UseVisualStyleBackColor = true;
            this.thirtyDay_RadioButton.CheckedChanged += new System.EventHandler(this.UpdateQuoteDetails_Event);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 462);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Terms";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tranactionNr_Label);
            this.panel5.Controls.Add(this.account_Textbox);
            this.panel5.Controls.Add(this.clientName_Label);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(304, 62);
            this.panel5.TabIndex = 16;
            // 
            // tranactionNr_Label
            // 
            this.tranactionNr_Label.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tranactionNr_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.tranactionNr_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tranactionNr_Label.Location = new System.Drawing.Point(152, 31);
            this.tranactionNr_Label.Name = "tranactionNr_Label";
            this.tranactionNr_Label.Size = new System.Drawing.Size(152, 31);
            this.tranactionNr_Label.TabIndex = 14;
            this.tranactionNr_Label.Text = "Tranaction";
            this.tranactionNr_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clientName_Label
            // 
            this.clientName_Label.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.clientName_Label.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "Name", true));
            this.clientName_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.clientName_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientName_Label.Location = new System.Drawing.Point(0, 0);
            this.clientName_Label.Name = "clientName_Label";
            this.clientName_Label.Size = new System.Drawing.Size(304, 31);
            this.clientName_Label.TabIndex = 15;
            this.clientName_Label.Text = "Client Name";
            this.clientName_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contact_ComboBox
            // 
            this.contact_ComboBox.FormattingEnabled = true;
            this.contact_ComboBox.Location = new System.Drawing.Point(72, 68);
            this.contact_ComboBox.Name = "contact_ComboBox";
            this.contact_ComboBox.Size = new System.Drawing.Size(208, 21);
            this.contact_ComboBox.TabIndex = 17;
            this.contact_ComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateQuoteDetails_Event);
            // 
            // maint_Panel
            // 
            this.maint_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maint_Panel.Controls.Add(this.extended_DateTimePicker);
            this.maint_Panel.Controls.Add(this.maintenance_CheckBox);
            this.maint_Panel.Controls.Add(this.extendMonths_TextBox);
            this.maint_Panel.Controls.Add(this.months_Label);
            this.maint_Panel.Location = new System.Drawing.Point(0, 119);
            this.maint_Panel.Name = "maint_Panel";
            this.maint_Panel.Size = new System.Drawing.Size(304, 26);
            this.maint_Panel.TabIndex = 44;
            // 
            // extended_DateTimePicker
            // 
            this.extended_DateTimePicker.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.extended_DateTimePicker.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.extended_DateTimePicker.CustomFormat = "dd MMM yy";
            this.extended_DateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.clientBindingSource, "Expirydate", true));
            this.extended_DateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extended_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.extended_DateTimePicker.Location = new System.Drawing.Point(208, 3);
            this.extended_DateTimePicker.Name = "extended_DateTimePicker";
            this.extended_DateTimePicker.Size = new System.Drawing.Size(85, 20);
            this.extended_DateTimePicker.TabIndex = 44;
            this.extended_DateTimePicker.CloseUp += new System.EventHandler(this.UpdateMaintenance_Event);
            // 
            // maintenance_CheckBox
            // 
            this.maintenance_CheckBox.AutoSize = true;
            this.maintenance_CheckBox.Location = new System.Drawing.Point(12, 5);
            this.maintenance_CheckBox.Name = "maintenance_CheckBox";
            this.maintenance_CheckBox.Size = new System.Drawing.Size(88, 17);
            this.maintenance_CheckBox.TabIndex = 45;
            this.maintenance_CheckBox.Text = "Maintenance";
            this.maintenance_CheckBox.UseVisualStyleBackColor = true;
            this.maintenance_CheckBox.CheckedChanged += new System.EventHandler(this.UpdateMaintenance_Event);
            // 
            // extendMonths_TextBox
            // 
            this.extendMonths_TextBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.extendMonths_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.extendMonths_TextBox.Location = new System.Drawing.Point(154, 7);
            this.extendMonths_TextBox.Name = "extendMonths_TextBox";
            this.extendMonths_TextBox.ReadOnly = true;
            this.extendMonths_TextBox.Size = new System.Drawing.Size(42, 13);
            this.extendMonths_TextBox.TabIndex = 48;
            // 
            // months_Label
            // 
            this.months_Label.AutoSize = true;
            this.months_Label.Location = new System.Drawing.Point(106, 7);
            this.months_Label.Name = "months_Label";
            this.months_Label.Size = new System.Drawing.Size(42, 13);
            this.months_Label.TabIndex = 47;
            this.months_Label.Text = "Months";
            // 
            // itemized_CheckBox
            // 
            this.itemized_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.itemized_CheckBox.AutoSize = true;
            this.itemized_CheckBox.Location = new System.Drawing.Point(21, 511);
            this.itemized_CheckBox.Name = "itemized_CheckBox";
            this.itemized_CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.itemized_CheckBox.Size = new System.Drawing.Size(71, 17);
            this.itemized_CheckBox.TabIndex = 49;
            this.itemized_CheckBox.Text = "  Itemized";
            this.itemized_CheckBox.UseVisualStyleBackColor = true;
            this.itemized_CheckBox.CheckedChanged += new System.EventHandler(this.UpdateQuote_Event);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 488);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Discount";
            // 
            // currency_ComboBox
            // 
            this.currency_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currency_ComboBox.FormattingEnabled = true;
            this.currency_ComboBox.Location = new System.Drawing.Point(72, 429);
            this.currency_ComboBox.Name = "currency_ComboBox";
            this.currency_ComboBox.Size = new System.Drawing.Size(112, 21);
            this.currency_ComboBox.TabIndex = 51;
            this.currency_ComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateQuoteDetails_Event);
            // 
            // productList_DataGridView
            // 
            this.productList_DataGridView.AllowUserToAddRows = false;
            this.productList_DataGridView.AllowUserToDeleteRows = false;
            this.productList_DataGridView.AllowUserToOrderColumns = true;
            this.productList_DataGridView.AutoGenerateColumns = false;
            this.productList_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productList_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.productList_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productList_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.productList_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productList_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description_Column,
            this.Price_Column,
            this.PriceInVat_Column});
            this.productList_DataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.productList_DataGridView.DataSource = this.itemList_BindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.productList_DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.productList_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productList_DataGridView.EnableHeadersVisualStyles = false;
            this.productList_DataGridView.Location = new System.Drawing.Point(1, 19);
            this.productList_DataGridView.Name = "productList_DataGridView";
            this.productList_DataGridView.ReadOnly = true;
            this.productList_DataGridView.RowHeadersVisible = false;
            this.productList_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productList_DataGridView.Size = new System.Drawing.Size(302, 127);
            this.productList_DataGridView.TabIndex = 51;
            // 
            // Description_Column
            // 
            this.Description_Column.DataPropertyName = "Description";
            this.Description_Column.FillWeight = 120.5674F;
            this.Description_Column.HeaderText = "Description";
            this.Description_Column.Name = "Description_Column";
            this.Description_Column.ReadOnly = true;
            // 
            // Price_Column
            // 
            this.Price_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Price_Column.DataPropertyName = "ItemTotal";
            this.Price_Column.HeaderText = "Price";
            this.Price_Column.Name = "Price_Column";
            this.Price_Column.ReadOnly = true;
            this.Price_Column.Width = 56;
            // 
            // PriceInVat_Column
            // 
            this.PriceInVat_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PriceInVat_Column.DataPropertyName = "ItemTotalInVat";
            this.PriceInVat_Column.HeaderText = "Price InVat";
            this.PriceInVat_Column.Name = "PriceInVat_Column";
            this.PriceInVat_Column.ReadOnly = true;
            this.PriceInVat_Column.Width = 84;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPriceInVatToolStripMenuItem,
            this.showItemInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 48);
            // 
            // showPriceInVatToolStripMenuItem
            // 
            this.showPriceInVatToolStripMenuItem.Name = "showPriceInVatToolStripMenuItem";
            this.showPriceInVatToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.showPriceInVatToolStripMenuItem.Text = "Show PriceInVat";
            this.showPriceInVatToolStripMenuItem.Click += new System.EventHandler(this.showPriceInVatToolStripMenuItem_Click);
            // 
            // showItemInfoToolStripMenuItem
            // 
            this.showItemInfoToolStripMenuItem.Name = "showItemInfoToolStripMenuItem";
            this.showItemInfoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.showItemInfoToolStripMenuItem.Text = "Show Item Info";
            this.showItemInfoToolStripMenuItem.Click += new System.EventHandler(this.showItemInfoToolStripMenuItem_Click);
            // 
            // itemList_BindingSource
            // 
            this.itemList_BindingSource.DataSource = typeof(Data.Products.Product);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.productList_DataGridView);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.quoteInfo_Label);
            this.panel1.Controls.Add(this.totals_DataGridView);
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(304, 248);
            this.panel1.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 18);
            this.label2.TabIndex = 55;
            this.label2.Text = "Price List";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quoteInfo_Label
            // 
            this.quoteInfo_Label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.quoteInfo_Label.Location = new System.Drawing.Point(1, 146);
            this.quoteInfo_Label.Name = "quoteInfo_Label";
            this.quoteInfo_Label.Size = new System.Drawing.Size(302, 18);
            this.quoteInfo_Label.TabIndex = 53;
            this.quoteInfo_Label.Text = "Totals";
            this.quoteInfo_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totals_DataGridView
            // 
            this.totals_DataGridView.AllowUserToAddRows = false;
            this.totals_DataGridView.AllowUserToDeleteRows = false;
            this.totals_DataGridView.AllowUserToOrderColumns = true;
            this.totals_DataGridView.AutoGenerateColumns = false;
            this.totals_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.totals_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.totals_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.totals_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.totals_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.totals_DataGridView.ColumnHeadersVisible = false;
            this.totals_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.totals_DataGridView.DataSource = this.totals_BindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.totals_DataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.totals_DataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.totals_DataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.totals_DataGridView.EnableHeadersVisualStyles = false;
            this.totals_DataGridView.Location = new System.Drawing.Point(1, 164);
            this.totals_DataGridView.MultiSelect = false;
            this.totals_DataGridView.Name = "totals_DataGridView";
            this.totals_DataGridView.ReadOnly = true;
            this.totals_DataGridView.RowHeadersVisible = false;
            this.totals_DataGridView.Size = new System.Drawing.Size(302, 83);
            this.totals_DataGridView.TabIndex = 52;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ItemTotal";
            this.dataGridViewTextBoxColumn2.HeaderText = "Price";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 5;
            // 
            // totals_BindingSource
            // 
            this.totals_BindingSource.DataSource = typeof(Data.Products.Product);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Add to Cost";
            // 
            // addCost_TextBox
            // 
            this.addCost_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addCost_TextBox.Location = new System.Drawing.Point(72, 403);
            this.addCost_TextBox.Name = "addCost_TextBox";
            this.addCost_TextBox.Size = new System.Drawing.Size(112, 20);
            this.addCost_TextBox.TabIndex = 53;
            // 
            // codOnly_checkBox
            // 
            this.codOnly_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.codOnly_checkBox.AutoSize = true;
            this.codOnly_checkBox.Location = new System.Drawing.Point(98, 511);
            this.codOnly_checkBox.Name = "codOnly_checkBox";
            this.codOnly_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.codOnly_checkBox.Size = new System.Drawing.Size(73, 17);
            this.codOnly_checkBox.TabIndex = 55;
            this.codOnly_checkBox.Text = "COD Only";
            this.codOnly_checkBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(187, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Absa Fx";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_AbsaFx
            // 
            this.txt_AbsaFx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_AbsaFx.Location = new System.Drawing.Point(240, 429);
            this.txt_AbsaFx.Name = "txt_AbsaFx";
            this.txt_AbsaFx.Size = new System.Drawing.Size(61, 20);
            this.txt_AbsaFx.TabIndex = 58;
            this.txt_AbsaFx.TextChanged += new System.EventHandler(this.txt_AbsaFx_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 471);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Export Fx";
            // 
            // txt_ExportFx
            // 
            this.txt_ExportFx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_ExportFx.Location = new System.Drawing.Point(240, 468);
            this.txt_ExportFx.Name = "txt_ExportFx";
            this.txt_ExportFx.Size = new System.Drawing.Size(61, 20);
            this.txt_ExportFx.TabIndex = 60;
            this.txt_ExportFx.TextChanged += new System.EventHandler(this.txt_ExportFx_TextChanged);
            // 
            // lblExportFx
            // 
            this.lblExportFx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExportFx.AutoSize = true;
            this.lblExportFx.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblExportFx.Location = new System.Drawing.Point(242, 452);
            this.lblExportFx.Name = "lblExportFx";
            this.lblExportFx.Size = new System.Drawing.Size(51, 13);
            this.lblExportFx.TabIndex = 62;
            this.lblExportFx.Text = "Export Fx";
            // 
            // lblAbsaFx
            // 
            this.lblAbsaFx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbsaFx.AutoSize = true;
            this.lblAbsaFx.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAbsaFx.Location = new System.Drawing.Point(242, 413);
            this.lblAbsaFx.Name = "lblAbsaFx";
            this.lblAbsaFx.Size = new System.Drawing.Size(45, 13);
            this.lblAbsaFx.TabIndex = 63;
            this.lblAbsaFx.Text = "Absa Fx";
            // 
            // QuoteSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAbsaFx);
            this.Controls.Add(this.lblExportFx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_ExportFx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_AbsaFx);
            this.Controls.Add(this.codOnly_checkBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addCost_TextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.currency_ComboBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.itemized_CheckBox);
            this.Controls.Add(this.maint_Panel);
            this.Controls.Add(this.contact_ComboBox);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.email_TextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.discount_TextBox);
            this.Controls.Add(this.label4);
            this.Name = "QuoteSummary";
            this.Size = new System.Drawing.Size(304, 528);
            this.Load += new System.EventHandler(this.Quote_Summary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.maint_Panel.ResumeLayout(false);
            this.maint_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productList_DataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemList_BindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.totals_DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totals_BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox discount_TextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox email_TextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label account_Textbox;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton cod_RadioButton;
        private System.Windows.Forms.RadioButton thirtyDay_RadioButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox contact_ComboBox;
        private System.Windows.Forms.Label tranactionNr_Label;
        private System.Windows.Forms.Panel maint_Panel;
        private System.Windows.Forms.CheckBox maintenance_CheckBox;
        private System.Windows.Forms.Label months_Label;
        private System.Windows.Forms.DateTimePicker extended_DateTimePicker;
        private System.Windows.Forms.TextBox extendMonths_TextBox;
        private System.Windows.Forms.CheckBox itemized_CheckBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label clientName_Label;
        private System.Windows.Forms.ComboBox currency_ComboBox;
        private System.Windows.Forms.BindingSource itemList_BindingSource;
        private System.Windows.Forms.DataGridView productList_DataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView totals_DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label quoteInfo_Label;
        private System.Windows.Forms.BindingSource totals_BindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addCost_TextBox;
        private System.Windows.Forms.CheckBox codOnly_checkBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceInVat_Column;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPriceInVatToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_AbsaFx;
        private System.Windows.Forms.TextBox txt_ExportFx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblExportFx;
        private System.Windows.Forms.Label lblAbsaFx;
        private System.Windows.Forms.ToolStripMenuItem showItemInfoToolStripMenuItem;
    }
}
