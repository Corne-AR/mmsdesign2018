namespace UserInterface.Quotes.UserControls
{
    partial class CatalogUC
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
            System.Windows.Forms.Label defaultExchangeScriptLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.catalogItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.catalogItemDataGridView = new System.Windows.Forms.DataGridView();
            this.catalog_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showListPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.addRow_Button = new System.Windows.Forms.Button();
            this.singleProduct_Label = new System.Windows.Forms.Label();
            this.maint_Label = new System.Windows.Forms.Label();
            this.exchangeScriptComboBox = new System.Windows.Forms.ComboBox();
            this.international_Label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.stolen_CheckBox = new System.Windows.Forms.CheckBox();
            this.priceIncVAT_Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cataItemized_CheckBox1 = new System.Windows.Forms.CheckBox();
            this.cataDiscount_TextBox = new System.Windows.Forms.TextBox();
            this.catalogSpecific_Label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cell_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showListPriceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListPrice_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailPrice_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            defaultExchangeScriptLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemDataGridView)).BeginInit();
            this.catalog_ContextMenuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cell_ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultExchangeScriptLabel
            // 
            defaultExchangeScriptLabel.AutoSize = true;
            defaultExchangeScriptLabel.Location = new System.Drawing.Point(82, 39);
            defaultExchangeScriptLabel.Name = "defaultExchangeScriptLabel";
            defaultExchangeScriptLabel.Size = new System.Drawing.Size(85, 13);
            defaultExchangeScriptLabel.TabIndex = 9;
            defaultExchangeScriptLabel.Text = "Exchange Script";
            // 
            // catalogItemBindingSource
            // 
            this.catalogItemBindingSource.DataSource = typeof(Data.Catalogs.CatalogItem);
            // 
            // catalogItemDataGridView
            // 
            this.catalogItemDataGridView.AllowUserToAddRows = false;
            this.catalogItemDataGridView.AllowUserToDeleteRows = false;
            this.catalogItemDataGridView.AutoGenerateColumns = false;
            this.catalogItemDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.catalogItemDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.catalogItemDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.catalogItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catalogItemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Version,
            this.Quantity,
            this.ListPrice_Column,
            this.RetailPrice_Column,
            this.SelectedColumn});
            this.catalogItemDataGridView.ContextMenuStrip = this.catalog_ContextMenuStrip;
            this.catalogItemDataGridView.DataSource = this.catalogItemBindingSource;
            this.catalogItemDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogItemDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.catalogItemDataGridView.Location = new System.Drawing.Point(0, 0);
            this.catalogItemDataGridView.Name = "catalogItemDataGridView";
            this.catalogItemDataGridView.RowHeadersWidth = 10;
            this.catalogItemDataGridView.Size = new System.Drawing.Size(972, 437);
            this.catalogItemDataGridView.TabIndex = 1;
            this.catalogItemDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Item_CellClick);
            this.catalogItemDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Item_CellMouseClick);
            this.catalogItemDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Item_CellValueChanged);
            this.catalogItemDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.catalogItemDataGridView_DataError);
            // 
            // catalog_ContextMenuStrip
            // 
            this.catalog_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showListPriceToolStripMenuItem});
            this.catalog_ContextMenuStrip.Name = "catalog_ContextMenuStrip";
            this.catalog_ContextMenuStrip.Size = new System.Drawing.Size(154, 26);
            // 
            // showListPriceToolStripMenuItem
            // 
            this.showListPriceToolStripMenuItem.Name = "showListPriceToolStripMenuItem";
            this.showListPriceToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.showListPriceToolStripMenuItem.Text = "Show List Price";
            this.showListPriceToolStripMenuItem.Click += new System.EventHandler(this.ShowListPrice_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.addRow_Button);
            this.panel2.Controls.Add(this.singleProduct_Label);
            this.panel2.Controls.Add(this.maint_Label);
            this.panel2.Controls.Add(defaultExchangeScriptLabel);
            this.panel2.Controls.Add(this.exchangeScriptComboBox);
            this.panel2.Controls.Add(this.international_Label);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.stolen_CheckBox);
            this.panel2.Controls.Add(this.priceIncVAT_Label);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cataItemized_CheckBox1);
            this.panel2.Controls.Add(this.cataDiscount_TextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 467);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel2.Size = new System.Drawing.Size(976, 63);
            this.panel2.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(43, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "-Vat";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "+VAT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addRow_Button
            // 
            this.addRow_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRow_Button.Location = new System.Drawing.Point(3, 5);
            this.addRow_Button.Name = "addRow_Button";
            this.addRow_Button.Size = new System.Drawing.Size(75, 23);
            this.addRow_Button.TabIndex = 2;
            this.addRow_Button.Text = "Custom Item";
            this.addRow_Button.UseVisualStyleBackColor = true;
            this.addRow_Button.Click += new System.EventHandler(this.AddCustomItem_Click);
            // 
            // singleProduct_Label
            // 
            this.singleProduct_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.singleProduct_Label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.singleProduct_Label.Location = new System.Drawing.Point(857, 46);
            this.singleProduct_Label.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.singleProduct_Label.Name = "singleProduct_Label";
            this.singleProduct_Label.Size = new System.Drawing.Size(119, 13);
            this.singleProduct_Label.TabIndex = 12;
            this.singleProduct_Label.Text = "Single Product";
            // 
            // maint_Label
            // 
            this.maint_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maint_Label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.maint_Label.Location = new System.Drawing.Point(857, 16);
            this.maint_Label.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.maint_Label.Name = "maint_Label";
            this.maint_Label.Size = new System.Drawing.Size(119, 13);
            this.maint_Label.TabIndex = 11;
            this.maint_Label.Text = "Maintenance";
            // 
            // exchangeScriptComboBox
            // 
            this.exchangeScriptComboBox.FormattingEnabled = true;
            this.exchangeScriptComboBox.Location = new System.Drawing.Point(173, 36);
            this.exchangeScriptComboBox.Name = "exchangeScriptComboBox";
            this.exchangeScriptComboBox.Size = new System.Drawing.Size(107, 21);
            this.exchangeScriptComboBox.TabIndex = 10;
            // 
            // international_Label
            // 
            this.international_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.international_Label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.international_Label.Location = new System.Drawing.Point(857, 1);
            this.international_Label.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.international_Label.Name = "international_Label";
            this.international_Label.Size = new System.Drawing.Size(119, 13);
            this.international_Label.TabIndex = 8;
            this.international_Label.Text = "Info";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Stolen Replacement";
            // 
            // stolen_CheckBox
            // 
            this.stolen_CheckBox.AutoSize = true;
            this.stolen_CheckBox.Location = new System.Drawing.Point(395, 39);
            this.stolen_CheckBox.Name = "stolen_CheckBox";
            this.stolen_CheckBox.Size = new System.Drawing.Size(15, 14);
            this.stolen_CheckBox.TabIndex = 6;
            this.stolen_CheckBox.UseVisualStyleBackColor = true;
            this.stolen_CheckBox.Click += new System.EventHandler(this.CatalogUpdate_Event);
            // 
            // priceIncVAT_Label
            // 
            this.priceIncVAT_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priceIncVAT_Label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.priceIncVAT_Label.Location = new System.Drawing.Point(857, 31);
            this.priceIncVAT_Label.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.priceIncVAT_Label.Name = "priceIncVAT_Label";
            this.priceIncVAT_Label.Size = new System.Drawing.Size(119, 13);
            this.priceIncVAT_Label.TabIndex = 5;
            this.priceIncVAT_Label.Text = "Prices Inc. VAT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Itemized";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Discount";
            // 
            // cataItemized_CheckBox1
            // 
            this.cataItemized_CheckBox1.AutoSize = true;
            this.cataItemized_CheckBox1.Location = new System.Drawing.Point(395, 10);
            this.cataItemized_CheckBox1.Name = "cataItemized_CheckBox1";
            this.cataItemized_CheckBox1.Size = new System.Drawing.Size(15, 14);
            this.cataItemized_CheckBox1.TabIndex = 1;
            this.cataItemized_CheckBox1.UseVisualStyleBackColor = true;
            this.cataItemized_CheckBox1.Click += new System.EventHandler(this.CatalogUpdate_Event);
            // 
            // cataDiscount_TextBox
            // 
            this.cataDiscount_TextBox.Location = new System.Drawing.Point(173, 7);
            this.cataDiscount_TextBox.Name = "cataDiscount_TextBox";
            this.cataDiscount_TextBox.Size = new System.Drawing.Size(107, 20);
            this.cataDiscount_TextBox.TabIndex = 0;
            this.cataDiscount_TextBox.TextChanged += new System.EventHandler(this.CatalogUpdate_Event);
            // 
            // catalogSpecific_Label
            // 
            this.catalogSpecific_Label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.catalogSpecific_Label.Location = new System.Drawing.Point(0, 441);
            this.catalogSpecific_Label.Name = "catalogSpecific_Label";
            this.catalogSpecific_Label.Size = new System.Drawing.Size(976, 26);
            this.catalogSpecific_Label.TabIndex = 3;
            this.catalogSpecific_Label.Text = "Catalog Specific";
            this.catalogSpecific_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.catalogItemDataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 441);
            this.panel1.TabIndex = 17;
            // 
            // cell_ContextMenuStrip
            // 
            this.cell_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showListPriceToolStripMenuItem1,
            this.showScriptToolStripMenuItem,
            this.viewDetailsToolStripMenuItem,
            this.viewContentToolStripMenuItem,
            this.editContentToolStripMenuItem});
            this.cell_ContextMenuStrip.Name = "cell_ContextMenuStrip";
            this.cell_ContextMenuStrip.Size = new System.Drawing.Size(154, 114);
            // 
            // showListPriceToolStripMenuItem1
            // 
            this.showListPriceToolStripMenuItem1.Name = "showListPriceToolStripMenuItem1";
            this.showListPriceToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.showListPriceToolStripMenuItem1.Text = "Show List Price";
            this.showListPriceToolStripMenuItem1.Click += new System.EventHandler(this.ShowListPrice_Click);
            // 
            // showScriptToolStripMenuItem
            // 
            this.showScriptToolStripMenuItem.Name = "showScriptToolStripMenuItem";
            this.showScriptToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.showScriptToolStripMenuItem.Text = "Show Script";
            this.showScriptToolStripMenuItem.Click += new System.EventHandler(this.ShowScript_Click);
            // 
            // viewDetailsToolStripMenuItem
            // 
            this.viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            this.viewDetailsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.viewDetailsToolStripMenuItem.Text = "View Details";
            this.viewDetailsToolStripMenuItem.Click += new System.EventHandler(this.ItemDetails_Click);
            // 
            // viewContentToolStripMenuItem
            // 
            this.viewContentToolStripMenuItem.Name = "viewContentToolStripMenuItem";
            this.viewContentToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.viewContentToolStripMenuItem.Text = "View Content";
            this.viewContentToolStripMenuItem.Click += new System.EventHandler(this.ItemContent_Click);
            // 
            // editContentToolStripMenuItem
            // 
            this.editContentToolStripMenuItem.Name = "editContentToolStripMenuItem";
            this.editContentToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.editContentToolStripMenuItem.Text = "Edit Content";
            this.editContentToolStripMenuItem.Click += new System.EventHandler(this.editContentToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 57;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Version
            // 
            this.Version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.MinimumWidth = 100;
            this.Version.Name = "Version";
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Qty";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 48;
            // 
            // ListPrice_Column
            // 
            this.ListPrice_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ListPrice_Column.DataPropertyName = "ListPrice";
            dataGridViewCellStyle1.Format = "# ### ##0.00";
            this.ListPrice_Column.DefaultCellStyle = dataGridViewCellStyle1;
            this.ListPrice_Column.HeaderText = "ListPrice";
            this.ListPrice_Column.Name = "ListPrice_Column";
            this.ListPrice_Column.Width = 72;
            // 
            // RetailPrice_Column
            // 
            this.RetailPrice_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RetailPrice_Column.DataPropertyName = "RetailPrice";
            dataGridViewCellStyle2.Format = "# ### ##0.00";
            this.RetailPrice_Column.DefaultCellStyle = dataGridViewCellStyle2;
            this.RetailPrice_Column.HeaderText = "RetailPrice";
            this.RetailPrice_Column.Name = "RetailPrice_Column";
            this.RetailPrice_Column.ReadOnly = true;
            this.RetailPrice_Column.Width = 83;
            // 
            // SelectedColumn
            // 
            this.SelectedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SelectedColumn.DataPropertyName = "Selected";
            this.SelectedColumn.HeaderText = "";
            this.SelectedColumn.Name = "SelectedColumn";
            this.SelectedColumn.Width = 5;
            // 
            // CatalogUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.catalogSpecific_Label);
            this.Controls.Add(this.panel2);
            this.Name = "CatalogUC";
            this.Size = new System.Drawing.Size(976, 530);
            this.Load += new System.EventHandler(this.CatalogUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemDataGridView)).EndInit();
            this.catalog_ContextMenuStrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.cell_ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource catalogItemBindingSource;
        private System.Windows.Forms.DataGridView catalogItemDataGridView;
        private System.Windows.Forms.ContextMenuStrip catalog_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showListPriceToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox exchangeScriptComboBox;
        private System.Windows.Forms.Label international_Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox stolen_CheckBox;
        private System.Windows.Forms.Label priceIncVAT_Label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cataItemized_CheckBox1;
        private System.Windows.Forms.TextBox cataDiscount_TextBox;
        private System.Windows.Forms.Label catalogSpecific_Label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cell_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showListPriceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
        private System.Windows.Forms.Label maint_Label;
        private System.Windows.Forms.Label singleProduct_Label;
        private System.Windows.Forms.ToolStripMenuItem viewContentToolStripMenuItem;
        private System.Windows.Forms.Button addRow_Button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem editContentToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListPrice_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailPrice_Column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectedColumn;
    }
}
