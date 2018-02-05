namespace UserInterface.Products.UserControls
{
    partial class ProductListUC
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
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.CatalogName_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceExVat_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserCount_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDate_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierID_Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SupplierName_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rightclick_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iD_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Transfer_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exchangeKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplier_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upgradeQuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMaintSelected_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenance2YearInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summary_Panel = new System.Windows.Forms.Panel();
            this.showPanelButton_Label = new System.Windows.Forms.Label();
            this.summary_Label = new System.Windows.Forms.Label();
            this.products_Label = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightClick_MenuItem_ChangedContactDetails = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.rightclick_ContextMenuStrip.SuspendLayout();
            this.summary_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // productDataGridView
            // 
            this.productDataGridView.AllowUserToAddRows = false;
            this.productDataGridView.AllowUserToDeleteRows = false;
            this.productDataGridView.AllowUserToOrderColumns = true;
            this.productDataGridView.AutoGenerateColumns = false;
            this.productDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.productDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CatalogName_Column,
            this.Name_Column,
            this.PriceExVat_Column,
            this.Version_Column,
            this.UserCount_Column,
            this.Content_Column,
            this.ExpiryDate_Column,
            this.ClientExpiryDate,
            this.ClientName,
            this.Notes_Column,
            this.SupplierID_Column,
            this.SupplierName_Column});
            this.productDataGridView.DataSource = this.productBindingSource;
            this.productDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.productDataGridView.Location = new System.Drawing.Point(0, 36);
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.RowHeadersVisible = false;
            this.productDataGridView.RowHeadersWidth = 20;
            this.productDataGridView.Size = new System.Drawing.Size(748, 390);
            this.productDataGridView.TabIndex = 0;
            this.productDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productDataGridView_CellContentDoubleClick);
            this.productDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.productDataGridView_CellMouseClick);
            this.productDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.productDataGridView_CellValueChanged);
            this.productDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.productDataGridView_DataError);
            // 
            // CatalogName_Column
            // 
            this.CatalogName_Column.DataPropertyName = "CatalogName";
            this.CatalogName_Column.HeaderText = "CatalogName";
            this.CatalogName_Column.Name = "CatalogName_Column";
            this.CatalogName_Column.ReadOnly = true;
            this.CatalogName_Column.Width = 96;
            // 
            // Name_Column
            // 
            this.Name_Column.DataPropertyName = "Name";
            this.Name_Column.HeaderText = "Name";
            this.Name_Column.Name = "Name_Column";
            this.Name_Column.ReadOnly = true;
            this.Name_Column.Width = 60;
            // 
            // PriceExVat_Column
            // 
            this.PriceExVat_Column.DataPropertyName = "PriceExVat";
            this.PriceExVat_Column.HeaderText = "PriceExVat";
            this.PriceExVat_Column.Name = "PriceExVat_Column";
            this.PriceExVat_Column.ReadOnly = true;
            this.PriceExVat_Column.Width = 84;
            // 
            // Version_Column
            // 
            this.Version_Column.DataPropertyName = "Version";
            this.Version_Column.HeaderText = "Version";
            this.Version_Column.Name = "Version_Column";
            this.Version_Column.ReadOnly = true;
            this.Version_Column.Width = 67;
            // 
            // UserCount_Column
            // 
            this.UserCount_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.UserCount_Column.DataPropertyName = "UserCount";
            this.UserCount_Column.HeaderText = "UserCount";
            this.UserCount_Column.Name = "UserCount_Column";
            this.UserCount_Column.ReadOnly = true;
            this.UserCount_Column.Width = 5;
            // 
            // Content_Column
            // 
            this.Content_Column.DataPropertyName = "ContentSummary";
            this.Content_Column.HeaderText = "Content";
            this.Content_Column.Name = "Content_Column";
            this.Content_Column.ReadOnly = true;
            this.Content_Column.Width = 69;
            // 
            // ExpiryDate_Column
            // 
            this.ExpiryDate_Column.DataPropertyName = "ExpiryDate";
            this.ExpiryDate_Column.HeaderText = "ExpiryDate";
            this.ExpiryDate_Column.Name = "ExpiryDate_Column";
            this.ExpiryDate_Column.ReadOnly = true;
            this.ExpiryDate_Column.Width = 83;
            // 
            // ClientExpiryDate
            // 
            this.ClientExpiryDate.DataPropertyName = "ClientExpiryDate";
            this.ClientExpiryDate.HeaderText = "ClientExpiryDate";
            this.ClientExpiryDate.Name = "ClientExpiryDate";
            this.ClientExpiryDate.ReadOnly = true;
            this.ClientExpiryDate.Width = 109;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "ClientName";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.Width = 86;
            // 
            // Notes_Column
            // 
            this.Notes_Column.DataPropertyName = "Notes";
            this.Notes_Column.HeaderText = "Notes";
            this.Notes_Column.Name = "Notes_Column";
            this.Notes_Column.ReadOnly = true;
            this.Notes_Column.Width = 60;
            // 
            // SupplierID_Column
            // 
            this.SupplierID_Column.DataPropertyName = "SupplierID";
            this.SupplierID_Column.HeaderText = "SupplierID";
            this.SupplierID_Column.Name = "SupplierID_Column";
            this.SupplierID_Column.Width = 62;
            // 
            // SupplierName_Column
            // 
            this.SupplierName_Column.DataPropertyName = "SupplierName";
            this.SupplierName_Column.HeaderText = "SupplierName";
            this.SupplierName_Column.Name = "SupplierName_Column";
            this.SupplierName_Column.ReadOnly = true;
            this.SupplierName_Column.Width = 98;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(Data.Products.Product);
            // 
            // rightclick_ContextMenuStrip
            // 
            this.rightclick_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iD_ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.Transfer_ToolStripMenuItem,
            this.exchangeKeyToolStripMenuItem,
            this.toolStripSeparator2,
            this.mailToolStripMenuItem,
            this.toolStripSeparator1,
            this.maintenanceToolStripMenuItem,
            this.toolStripSeparator3,
            this.viewLogToolStripMenuItem,
            this.removeItemToolStripMenuItem});
            this.rightclick_ContextMenuStrip.Name = "rightclick_ContextMenuStrip";
            this.rightclick_ContextMenuStrip.Size = new System.Drawing.Size(153, 220);
            this.rightclick_ContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.rightclick_ContextMenuStrip_Opening);
            // 
            // iD_ToolStripMenuItem
            // 
            this.iD_ToolStripMenuItem.Name = "iD_ToolStripMenuItem";
            this.iD_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.iD_ToolStripMenuItem.Text = "ID";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Edit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Transfer_ToolStripMenuItem
            // 
            this.Transfer_ToolStripMenuItem.Name = "Transfer_ToolStripMenuItem";
            this.Transfer_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Transfer_ToolStripMenuItem.Text = "Transfer";
            this.Transfer_ToolStripMenuItem.Click += new System.EventHandler(this.Transfer_ToolStripMenuItem_Click);
            // 
            // exchangeKeyToolStripMenuItem
            // 
            this.exchangeKeyToolStripMenuItem.Name = "exchangeKeyToolStripMenuItem";
            this.exchangeKeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exchangeKeyToolStripMenuItem.Text = "Exchange Key";
            this.exchangeKeyToolStripMenuItem.Click += new System.EventHandler(this.exchangeKeyToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // mailToolStripMenuItem
            // 
            this.mailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplier_ToolStripMenuItem,
            this.upgradeQuoteToolStripMenuItem,
            this.rightClick_MenuItem_ChangedContactDetails});
            this.mailToolStripMenuItem.Name = "mailToolStripMenuItem";
            this.mailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mailToolStripMenuItem.Text = "Mail";
            this.mailToolStripMenuItem.Click += new System.EventHandler(this.mailToolStripMenuItem_Click);
            // 
            // supplier_ToolStripMenuItem
            // 
            this.supplier_ToolStripMenuItem.Name = "supplier_ToolStripMenuItem";
            this.supplier_ToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.supplier_ToolStripMenuItem.Text = "Setup File";
            this.supplier_ToolStripMenuItem.Click += new System.EventHandler(this.SetupFileRequest_Click);
            // 
            // upgradeQuoteToolStripMenuItem
            // 
            this.upgradeQuoteToolStripMenuItem.Name = "upgradeQuoteToolStripMenuItem";
            this.upgradeQuoteToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.upgradeQuoteToolStripMenuItem.Text = "Upgrade Quote";
            this.upgradeQuoteToolStripMenuItem.Click += new System.EventHandler(this.UpgradeQuoteRequest_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateMaintSelected_ToolStripMenuItem,
            this.maintenanceInvoiceToolStripMenuItem,
            this.maintenance2YearInvoiceToolStripMenuItem});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.maintenanceToolStripMenuItem.Text = "Maintenance";
            this.maintenanceToolStripMenuItem.Click += new System.EventHandler(this.maintenanceToolStripMenuItem_Click);
            // 
            // updateMaintSelected_ToolStripMenuItem
            // 
            this.updateMaintSelected_ToolStripMenuItem.Name = "updateMaintSelected_ToolStripMenuItem";
            this.updateMaintSelected_ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.updateMaintSelected_ToolStripMenuItem.Text = "Update Selected";
            this.updateMaintSelected_ToolStripMenuItem.Click += new System.EventHandler(this.RenewMaintenance_Click);
            // 
            // maintenanceInvoiceToolStripMenuItem
            // 
            this.maintenanceInvoiceToolStripMenuItem.Name = "maintenanceInvoiceToolStripMenuItem";
            this.maintenanceInvoiceToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.maintenanceInvoiceToolStripMenuItem.Text = "Maintenance Invoice";
            this.maintenanceInvoiceToolStripMenuItem.Click += new System.EventHandler(this.maintenanceInvoiceToolStripMenuItem_Click);
            // 
            // maintenance2YearInvoiceToolStripMenuItem
            // 
            this.maintenance2YearInvoiceToolStripMenuItem.Name = "maintenance2YearInvoiceToolStripMenuItem";
            this.maintenance2YearInvoiceToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.maintenance2YearInvoiceToolStripMenuItem.Text = "Maintenance 2 Year Invoice";
            this.maintenance2YearInvoiceToolStripMenuItem.Click += new System.EventHandler(this.maintenance2YearInvoiceToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewLogToolStripMenuItem.Text = "View Log";
            this.viewLogToolStripMenuItem.Click += new System.EventHandler(this.ItemLog_Click);
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeItemToolStripMenuItem.Text = "Remove Item";
            this.removeItemToolStripMenuItem.Click += new System.EventHandler(this.RemoveItem_Click);
            // 
            // summary_Panel
            // 
            this.summary_Panel.AutoSize = true;
            this.summary_Panel.Controls.Add(this.showPanelButton_Label);
            this.summary_Panel.Controls.Add(this.summary_Label);
            this.summary_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.summary_Panel.Location = new System.Drawing.Point(0, 18);
            this.summary_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.summary_Panel.Name = "summary_Panel";
            this.summary_Panel.Size = new System.Drawing.Size(748, 18);
            this.summary_Panel.TabIndex = 4;
            // 
            // showPanelButton_Label
            // 
            this.showPanelButton_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.showPanelButton_Label.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.showPanelButton_Label.Location = new System.Drawing.Point(723, 0);
            this.showPanelButton_Label.Name = "showPanelButton_Label";
            this.showPanelButton_Label.Size = new System.Drawing.Size(25, 18);
            this.showPanelButton_Label.TabIndex = 2;
            this.showPanelButton_Label.Text = "o";
            this.showPanelButton_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // summary_Label
            // 
            this.summary_Label.Location = new System.Drawing.Point(0, 0);
            this.summary_Label.Margin = new System.Windows.Forms.Padding(0);
            this.summary_Label.Name = "summary_Label";
            this.summary_Label.Size = new System.Drawing.Size(511, 18);
            this.summary_Label.TabIndex = 1;
            this.summary_Label.Text = "Summary";
            this.summary_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // products_Label
            // 
            this.products_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.products_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.products_Label.Location = new System.Drawing.Point(0, 0);
            this.products_Label.Margin = new System.Windows.Forms.Padding(0);
            this.products_Label.Name = "products_Label";
            this.products_Label.Size = new System.Drawing.Size(748, 18);
            this.products_Label.TabIndex = 5;
            this.products_Label.Text = "Products";
            this.products_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SupplierName";
            this.dataGridViewTextBoxColumn1.HeaderText = "SupplierName";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 98;
            // 
            // rightClick_MenuItem_ChangedContactDetails
            // 
            this.rightClick_MenuItem_ChangedContactDetails.Name = "rightClick_MenuItem_ChangedContactDetails";
            this.rightClick_MenuItem_ChangedContactDetails.Size = new System.Drawing.Size(205, 22);
            this.rightClick_MenuItem_ChangedContactDetails.Text = "Changed Contact Details";
            this.rightClick_MenuItem_ChangedContactDetails.Click += new System.EventHandler(this.rightClick_MenuItem_ChangedContactDetails_Click);
            // 
            // ProductListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.productDataGridView);
            this.Controls.Add(this.summary_Panel);
            this.Controls.Add(this.products_Label);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ProductListUC";
            this.Size = new System.Drawing.Size(748, 426);
            this.Load += new System.EventHandler(this.ProductListUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.rightclick_ContextMenuStrip.ResumeLayout(false);
            this.summary_Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView productDataGridView;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.ContextMenuStrip rightclick_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem iD_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel summary_Panel;
        private System.Windows.Forms.Label showPanelButton_Label;
        private System.Windows.Forms.Label summary_Label;
        private System.Windows.Forms.Label products_Label;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplier_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem upgradeQuoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateMaintSelected_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem Transfer_ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripMenuItem maintenanceInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenance2YearInvoiceToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatalogName_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceExVat_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserCount_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDate_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes_Column;
        private System.Windows.Forms.DataGridViewComboBoxColumn SupplierID_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName_Column;
        private System.Windows.Forms.ToolStripMenuItem exchangeKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightClick_MenuItem_ChangedContactDetails;
    }
}
