namespace UserInterface.Transactions.UserControls
{
    partial class TransactionGridView
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
            this.transactionList_DataGridView = new System.Windows.Forms.DataGridView();
            this.Select_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlagPaid_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlagPOMissing_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlagMailed_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptListColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetClientInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.id_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miMultiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.acounts_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.override_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.duplicate_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delete_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.void_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLinks_LoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelTrans_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sendMail_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.viewLog_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.size_Button = new System.Windows.Forms.Button();
            this.quote_CheckBox = new System.Windows.Forms.CheckBox();
            this.profroma_CheckBox = new System.Windows.Forms.CheckBox();
            this.order_CheckBox = new System.Windows.Forms.CheckBox();
            this.invoice_CheckBox = new System.Windows.Forms.CheckBox();
            this.creditNote_CheckBox = new System.Windows.Forms.CheckBox();
            this.cancelTrans_CheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.paid_CheckBox = new System.Windows.Forms.CheckBox();
            this.unpaid_CheckBox = new System.Windows.Forms.CheckBox();
            this.mailed_ChkBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.processing_CheckBox = new System.Windows.Forms.CheckBox();
            this.summary_Panel = new System.Windows.Forms.Panel();
            this.receipt_Label = new System.Windows.Forms.Label();
            this.summary_Label = new System.Windows.Forms.Label();
            this.showPanelButton_Label = new System.Windows.Forms.Label();
            this.transacions_Label = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.transactionList_DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.summary_Panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // transactionList_DataGridView
            // 
            this.transactionList_DataGridView.AllowUserToAddRows = false;
            this.transactionList_DataGridView.AllowUserToDeleteRows = false;
            this.transactionList_DataGridView.AllowUserToOrderColumns = true;
            this.transactionList_DataGridView.AutoGenerateColumns = false;
            this.transactionList_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transactionList_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.transactionList_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select_Column,
            this.FlagPaid_Column,
            this.FlagPOMissing_Column,
            this.FlagMailed_Column,
            this.IDColumn,
            this.AccountColumn,
            this.DateColumn,
            this.ReceiptListColumn,
            this.Currency,
            this.TotalColumn,
            this.TotalDueColumn,
            this.GetClientInfo,
            this.LinkedColumn,
            this.ContactColumn,
            this.EmailColumn,
            this.SupplierColumn});
            this.transactionList_DataGridView.DataSource = this.transactionBindingSource;
            this.transactionList_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionList_DataGridView.Location = new System.Drawing.Point(0, 58);
            this.transactionList_DataGridView.Name = "transactionList_DataGridView";
            this.transactionList_DataGridView.ReadOnly = true;
            this.transactionList_DataGridView.RowHeadersVisible = false;
            this.transactionList_DataGridView.RowHeadersWidth = 25;
            this.transactionList_DataGridView.Size = new System.Drawing.Size(745, 370);
            this.transactionList_DataGridView.TabIndex = 0;
            this.transactionList_DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClick);
            this.transactionList_DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
            this.transactionList_DataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.transactionList_DataGridView_CellMouseClick);
            this.transactionList_DataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseUp);
            // 
            // Select_Column
            // 
            this.Select_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Select_Column.Frozen = true;
            this.Select_Column.HeaderText = "";
            this.Select_Column.Name = "Select_Column";
            this.Select_Column.ReadOnly = true;
            this.Select_Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Select_Column.Width = 10;
            // 
            // FlagPaid_Column
            // 
            this.FlagPaid_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FlagPaid_Column.Frozen = true;
            this.FlagPaid_Column.HeaderText = "";
            this.FlagPaid_Column.Name = "FlagPaid_Column";
            this.FlagPaid_Column.ReadOnly = true;
            this.FlagPaid_Column.ToolTipText = "Paid";
            this.FlagPaid_Column.Width = 5;
            // 
            // FlagPOMissing_Column
            // 
            this.FlagPOMissing_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FlagPOMissing_Column.DataPropertyName = "POGenerated";
            this.FlagPOMissing_Column.Frozen = true;
            this.FlagPOMissing_Column.HeaderText = "";
            this.FlagPOMissing_Column.Name = "FlagPOMissing_Column";
            this.FlagPOMissing_Column.ReadOnly = true;
            this.FlagPOMissing_Column.ToolTipText = "PO Generated";
            this.FlagPOMissing_Column.Width = 5;
            // 
            // FlagMailed_Column
            // 
            this.FlagMailed_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FlagMailed_Column.Frozen = true;
            this.FlagMailed_Column.HeaderText = "";
            this.FlagMailed_Column.Name = "FlagMailed_Column";
            this.FlagMailed_Column.ReadOnly = true;
            this.FlagMailed_Column.ToolTipText = "Mailed";
            this.FlagMailed_Column.Width = 5;
            // 
            // IDColumn
            // 
            this.IDColumn.DataPropertyName = "ID";
            this.IDColumn.Frozen = true;
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 43;
            // 
            // AccountColumn
            // 
            this.AccountColumn.DataPropertyName = "Account";
            this.AccountColumn.HeaderText = "Account";
            this.AccountColumn.Name = "AccountColumn";
            this.AccountColumn.ReadOnly = true;
            this.AccountColumn.Width = 72;
            // 
            // DateColumn
            // 
            this.DateColumn.DataPropertyName = "GetTransactionDate";
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            this.DateColumn.Width = 55;
            // 
            // ReceiptListColumn
            // 
            this.ReceiptListColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ReceiptListColumn.DataPropertyName = "GetReceiptIDList";
            this.ReceiptListColumn.HeaderText = "Receipt List";
            this.ReceiptListColumn.Name = "ReceiptListColumn";
            this.ReceiptListColumn.ReadOnly = true;
            this.ReceiptListColumn.Width = 88;
            // 
            // Currency
            // 
            this.Currency.DataPropertyName = "Currency";
            this.Currency.FillWeight = 70F;
            this.Currency.HeaderText = "";
            this.Currency.Name = "Currency";
            this.Currency.ReadOnly = true;
            this.Currency.Width = 30;
            // 
            // TotalColumn
            // 
            this.TotalColumn.DataPropertyName = "Total";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.TotalColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.TotalColumn.HeaderText = "Total";
            this.TotalColumn.Name = "TotalColumn";
            this.TotalColumn.ReadOnly = true;
            this.TotalColumn.Width = 56;
            // 
            // TotalDueColumn
            // 
            this.TotalDueColumn.DataPropertyName = "TotalDue";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.TotalDueColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.TotalDueColumn.HeaderText = "TotalDue";
            this.TotalDueColumn.Name = "TotalDueColumn";
            this.TotalDueColumn.ReadOnly = true;
            this.TotalDueColumn.Width = 76;
            // 
            // GetClientInfo
            // 
            this.GetClientInfo.DataPropertyName = "GetClientInfo";
            this.GetClientInfo.HeaderText = "GetClientInfo";
            this.GetClientInfo.Name = "GetClientInfo";
            this.GetClientInfo.ReadOnly = true;
            // 
            // LinkedColumn
            // 
            this.LinkedColumn.DataPropertyName = "GetLinkedIDList";
            this.LinkedColumn.HeaderText = "Linked";
            this.LinkedColumn.Name = "LinkedColumn";
            this.LinkedColumn.ReadOnly = true;
            this.LinkedColumn.Width = 64;
            // 
            // ContactColumn
            // 
            this.ContactColumn.DataPropertyName = "Contact";
            this.ContactColumn.HeaderText = "Contact";
            this.ContactColumn.Name = "ContactColumn";
            this.ContactColumn.ReadOnly = true;
            this.ContactColumn.Width = 69;
            // 
            // EmailColumn
            // 
            this.EmailColumn.DataPropertyName = "Email";
            this.EmailColumn.HeaderText = "Email";
            this.EmailColumn.Name = "EmailColumn";
            this.EmailColumn.ReadOnly = true;
            this.EmailColumn.Width = 57;
            // 
            // SupplierColumn
            // 
            this.SupplierColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SupplierColumn.DataPropertyName = "SupplierId";
            this.SupplierColumn.HeaderText = "Supplier";
            this.SupplierColumn.Name = "SupplierColumn";
            this.SupplierColumn.ReadOnly = true;
            this.SupplierColumn.Width = 70;
            // 
            // transactionBindingSource
            // 
            this.transactionBindingSource.DataSource = typeof(Data.Transactions.Transaction);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.id_ToolStripMenuItem,
            this.edit_ToolStripMenuItem,
            this.miMultiEdit,
            this.acounts_ToolStripMenuItem,
            this.override_ToolStripMenuItem,
            this.toolStripSeparator2,
            this.duplicate_MenuItem,
            this.delete_ToolStripMenuItem,
            this.void_ToolStripMenuItem,
            this.removeLinks_LoolStripMenuItem,
            this.cancelTrans_ToolStripMenuItem,
            this.toolStripSeparator3,
            this.sendMail_ToolStripMenuItem,
            this.toolStripSeparator4,
            this.viewLog_ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(174, 286);
            // 
            // id_ToolStripMenuItem
            // 
            this.id_ToolStripMenuItem.Name = "id_ToolStripMenuItem";
            this.id_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.id_ToolStripMenuItem.Text = "ID";
            // 
            // edit_ToolStripMenuItem
            // 
            this.edit_ToolStripMenuItem.Name = "edit_ToolStripMenuItem";
            this.edit_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.edit_ToolStripMenuItem.Text = "Edit";
            this.edit_ToolStripMenuItem.Click += new System.EventHandler(this.Edit_Click);
            // 
            // miMultiEdit
            // 
            this.miMultiEdit.Name = "miMultiEdit";
            this.miMultiEdit.Size = new System.Drawing.Size(173, 22);
            this.miMultiEdit.Text = "Multi Edit";
            this.miMultiEdit.Click += new System.EventHandler(this.MultiEdit_Click);
            // 
            // acounts_ToolStripMenuItem
            // 
            this.acounts_ToolStripMenuItem.Name = "acounts_ToolStripMenuItem";
            this.acounts_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.acounts_ToolStripMenuItem.Text = "Search Linked";
            this.acounts_ToolStripMenuItem.Click += new System.EventHandler(this.acounts_ToolStripMenuItem_Click);
            // 
            // override_ToolStripMenuItem
            // 
            this.override_ToolStripMenuItem.Name = "override_ToolStripMenuItem";
            this.override_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.override_ToolStripMenuItem.Text = "Override";
            this.override_ToolStripMenuItem.Click += new System.EventHandler(this.Override_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // duplicate_MenuItem
            // 
            this.duplicate_MenuItem.Name = "duplicate_MenuItem";
            this.duplicate_MenuItem.Size = new System.Drawing.Size(173, 22);
            this.duplicate_MenuItem.Text = "Duplicate";
            this.duplicate_MenuItem.Click += new System.EventHandler(this.duplicate_MenuItem_Click);
            // 
            // delete_ToolStripMenuItem
            // 
            this.delete_ToolStripMenuItem.Name = "delete_ToolStripMenuItem";
            this.delete_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.delete_ToolStripMenuItem.Text = "Delete";
            this.delete_ToolStripMenuItem.Click += new System.EventHandler(this.Delete_Click);
            // 
            // void_ToolStripMenuItem
            // 
            this.void_ToolStripMenuItem.Name = "void_ToolStripMenuItem";
            this.void_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.void_ToolStripMenuItem.Text = "Void";
            this.void_ToolStripMenuItem.Click += new System.EventHandler(this.Void_Click);
            // 
            // removeLinks_LoolStripMenuItem
            // 
            this.removeLinks_LoolStripMenuItem.Name = "removeLinks_LoolStripMenuItem";
            this.removeLinks_LoolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.removeLinks_LoolStripMenuItem.Text = "Remove Links";
            this.removeLinks_LoolStripMenuItem.ToolTipText = "Will Require Save";
            this.removeLinks_LoolStripMenuItem.Click += new System.EventHandler(this.removeLinks_LoolStripMenuItem_Click);
            // 
            // cancelTrans_ToolStripMenuItem
            // 
            this.cancelTrans_ToolStripMenuItem.Name = "cancelTrans_ToolStripMenuItem";
            this.cancelTrans_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cancelTrans_ToolStripMenuItem.Text = "Cancel Transaction";
            this.cancelTrans_ToolStripMenuItem.Click += new System.EventHandler(this.CancelTrans_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // sendMail_ToolStripMenuItem
            // 
            this.sendMail_ToolStripMenuItem.Name = "sendMail_ToolStripMenuItem";
            this.sendMail_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.sendMail_ToolStripMenuItem.Text = "Send Mail";
            this.sendMail_ToolStripMenuItem.Click += new System.EventHandler(this.SendMail_Event);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(170, 6);
            // 
            // viewLog_ToolStripMenuItem
            // 
            this.viewLog_ToolStripMenuItem.Name = "viewLog_ToolStripMenuItem";
            this.viewLog_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.viewLog_ToolStripMenuItem.Text = "View Log";
            this.viewLog_ToolStripMenuItem.Click += new System.EventHandler(this.ViewLog_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.size_Button);
            this.flowLayoutPanel1.Controls.Add(this.quote_CheckBox);
            this.flowLayoutPanel1.Controls.Add(this.profroma_CheckBox);
            this.flowLayoutPanel1.Controls.Add(this.order_CheckBox);
            this.flowLayoutPanel1.Controls.Add(this.invoice_CheckBox);
            this.flowLayoutPanel1.Controls.Add(this.creditNote_CheckBox);
            this.flowLayoutPanel1.Controls.Add(this.cancelTrans_CheckBox);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.paid_CheckBox);
            this.flowLayoutPanel1.Controls.Add(this.unpaid_CheckBox);
            this.flowLayoutPanel1.Controls.Add(this.mailed_ChkBox);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.processing_CheckBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(745, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(103, 370);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // size_Button
            // 
            this.size_Button.Location = new System.Drawing.Point(3, 0);
            this.size_Button.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.size_Button.Name = "size_Button";
            this.size_Button.Size = new System.Drawing.Size(97, 23);
            this.size_Button.TabIndex = 11;
            this.size_Button.Text = "Auto Size";
            this.size_Button.UseVisualStyleBackColor = true;
            this.size_Button.Click += new System.EventHandler(this.SizeGrid_Click);
            // 
            // quote_CheckBox
            // 
            this.quote_CheckBox.AutoSize = true;
            this.quote_CheckBox.Checked = true;
            this.quote_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.quote_CheckBox.Location = new System.Drawing.Point(3, 29);
            this.quote_CheckBox.Name = "quote_CheckBox";
            this.quote_CheckBox.Size = new System.Drawing.Size(55, 17);
            this.quote_CheckBox.TabIndex = 2;
            this.quote_CheckBox.Text = "Quote";
            this.quote_CheckBox.UseVisualStyleBackColor = true;
            this.quote_CheckBox.CheckedChanged += new System.EventHandler(this.Filter_Event);
            // 
            // profroma_CheckBox
            // 
            this.profroma_CheckBox.AutoSize = true;
            this.profroma_CheckBox.Checked = true;
            this.profroma_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.profroma_CheckBox.Location = new System.Drawing.Point(3, 52);
            this.profroma_CheckBox.Name = "profroma_CheckBox";
            this.profroma_CheckBox.Size = new System.Drawing.Size(68, 17);
            this.profroma_CheckBox.TabIndex = 3;
            this.profroma_CheckBox.Text = "Profroma";
            this.profroma_CheckBox.UseVisualStyleBackColor = true;
            this.profroma_CheckBox.CheckedChanged += new System.EventHandler(this.Filter_Event);
            // 
            // order_CheckBox
            // 
            this.order_CheckBox.AutoSize = true;
            this.order_CheckBox.Checked = true;
            this.order_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.order_CheckBox.Location = new System.Drawing.Point(3, 75);
            this.order_CheckBox.Name = "order_CheckBox";
            this.order_CheckBox.Size = new System.Drawing.Size(52, 17);
            this.order_CheckBox.TabIndex = 4;
            this.order_CheckBox.Text = "Order";
            this.order_CheckBox.UseVisualStyleBackColor = true;
            this.order_CheckBox.CheckedChanged += new System.EventHandler(this.Filter_Event);
            // 
            // invoice_CheckBox
            // 
            this.invoice_CheckBox.AutoSize = true;
            this.invoice_CheckBox.Checked = true;
            this.invoice_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.invoice_CheckBox.Location = new System.Drawing.Point(3, 98);
            this.invoice_CheckBox.Name = "invoice_CheckBox";
            this.invoice_CheckBox.Size = new System.Drawing.Size(61, 17);
            this.invoice_CheckBox.TabIndex = 5;
            this.invoice_CheckBox.Text = "Invoice";
            this.invoice_CheckBox.UseVisualStyleBackColor = true;
            this.invoice_CheckBox.CheckedChanged += new System.EventHandler(this.Filter_Event);
            // 
            // creditNote_CheckBox
            // 
            this.creditNote_CheckBox.AutoSize = true;
            this.creditNote_CheckBox.Checked = true;
            this.creditNote_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.creditNote_CheckBox.Location = new System.Drawing.Point(3, 121);
            this.creditNote_CheckBox.Name = "creditNote_CheckBox";
            this.creditNote_CheckBox.Size = new System.Drawing.Size(79, 17);
            this.creditNote_CheckBox.TabIndex = 12;
            this.creditNote_CheckBox.Text = "Credit Note";
            this.creditNote_CheckBox.UseVisualStyleBackColor = true;
            this.creditNote_CheckBox.CheckedChanged += new System.EventHandler(this.Filter_Event);
            // 
            // cancelTrans_CheckBox
            // 
            this.cancelTrans_CheckBox.AutoSize = true;
            this.cancelTrans_CheckBox.Checked = true;
            this.cancelTrans_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cancelTrans_CheckBox.Location = new System.Drawing.Point(3, 144);
            this.cancelTrans_CheckBox.Name = "cancelTrans_CheckBox";
            this.cancelTrans_CheckBox.Size = new System.Drawing.Size(88, 17);
            this.cancelTrans_CheckBox.TabIndex = 14;
            this.cancelTrans_CheckBox.Text = "Cancel Order";
            this.cancelTrans_CheckBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(3, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 3);
            this.panel1.TabIndex = 7;
            // 
            // paid_CheckBox
            // 
            this.paid_CheckBox.AutoSize = true;
            this.paid_CheckBox.Location = new System.Drawing.Point(3, 176);
            this.paid_CheckBox.Name = "paid_CheckBox";
            this.paid_CheckBox.Size = new System.Drawing.Size(47, 17);
            this.paid_CheckBox.TabIndex = 8;
            this.paid_CheckBox.Text = "Paid";
            this.paid_CheckBox.UseVisualStyleBackColor = true;
            this.paid_CheckBox.CheckedChanged += new System.EventHandler(this.Filter_Event);
            // 
            // unpaid_CheckBox
            // 
            this.unpaid_CheckBox.AutoSize = true;
            this.unpaid_CheckBox.Location = new System.Drawing.Point(3, 199);
            this.unpaid_CheckBox.Name = "unpaid_CheckBox";
            this.unpaid_CheckBox.Size = new System.Drawing.Size(60, 17);
            this.unpaid_CheckBox.TabIndex = 6;
            this.unpaid_CheckBox.Text = "Unpaid";
            this.unpaid_CheckBox.UseVisualStyleBackColor = true;
            this.unpaid_CheckBox.CheckedChanged += new System.EventHandler(this.Filter_Event);
            // 
            // mailed_ChkBox
            // 
            this.mailed_ChkBox.AutoSize = true;
            this.mailed_ChkBox.Checked = true;
            this.mailed_ChkBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.mailed_ChkBox.Location = new System.Drawing.Point(3, 222);
            this.mailed_ChkBox.Name = "mailed_ChkBox";
            this.mailed_ChkBox.Size = new System.Drawing.Size(57, 17);
            this.mailed_ChkBox.TabIndex = 13;
            this.mailed_ChkBox.Text = "Mailed";
            this.mailed_ChkBox.ThreeState = true;
            this.mailed_ChkBox.UseVisualStyleBackColor = true;
            this.mailed_ChkBox.CheckStateChanged += new System.EventHandler(this.Filter_Event);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(3, 245);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 3);
            this.panel2.TabIndex = 9;
            // 
            // processing_CheckBox
            // 
            this.processing_CheckBox.AutoSize = true;
            this.processing_CheckBox.Location = new System.Drawing.Point(3, 254);
            this.processing_CheckBox.Name = "processing_CheckBox";
            this.processing_CheckBox.Size = new System.Drawing.Size(78, 17);
            this.processing_CheckBox.TabIndex = 10;
            this.processing_CheckBox.Text = "Processing";
            this.processing_CheckBox.UseVisualStyleBackColor = true;
            this.processing_CheckBox.CheckedChanged += new System.EventHandler(this.Filter_Event);
            // 
            // summary_Panel
            // 
            this.summary_Panel.AutoSize = true;
            this.summary_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.summary_Panel.Controls.Add(this.receipt_Label);
            this.summary_Panel.Controls.Add(this.summary_Label);
            this.summary_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.summary_Panel.Location = new System.Drawing.Point(0, 18);
            this.summary_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.summary_Panel.Name = "summary_Panel";
            this.summary_Panel.Size = new System.Drawing.Size(848, 40);
            this.summary_Panel.TabIndex = 2;
            // 
            // receipt_Label
            // 
            this.receipt_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.receipt_Label.Location = new System.Drawing.Point(0, 20);
            this.receipt_Label.Margin = new System.Windows.Forms.Padding(0);
            this.receipt_Label.Name = "receipt_Label";
            this.receipt_Label.Padding = new System.Windows.Forms.Padding(3);
            this.receipt_Label.Size = new System.Drawing.Size(848, 20);
            this.receipt_Label.TabIndex = 2;
            this.receipt_Label.Text = "Credit";
            this.receipt_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // summary_Label
            // 
            this.summary_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.summary_Label.Location = new System.Drawing.Point(0, 0);
            this.summary_Label.Margin = new System.Windows.Forms.Padding(0);
            this.summary_Label.Name = "summary_Label";
            this.summary_Label.Padding = new System.Windows.Forms.Padding(3);
            this.summary_Label.Size = new System.Drawing.Size(848, 20);
            this.summary_Label.TabIndex = 1;
            this.summary_Label.Text = "Invoice Summary";
            this.summary_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // showPanelButton_Label
            // 
            this.showPanelButton_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.showPanelButton_Label.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.showPanelButton_Label.Location = new System.Drawing.Point(821, 2);
            this.showPanelButton_Label.Margin = new System.Windows.Forms.Padding(0);
            this.showPanelButton_Label.Name = "showPanelButton_Label";
            this.showPanelButton_Label.Size = new System.Drawing.Size(25, 14);
            this.showPanelButton_Label.TabIndex = 2;
            this.showPanelButton_Label.Text = "o";
            this.showPanelButton_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.showPanelButton_Label.Click += new System.EventHandler(this.ShowPanel_Event);
            // 
            // transacions_Label
            // 
            this.transacions_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.transacions_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transacions_Label.Location = new System.Drawing.Point(2, 2);
            this.transacions_Label.Margin = new System.Windows.Forms.Padding(0);
            this.transacions_Label.Name = "transacions_Label";
            this.transacions_Label.Size = new System.Drawing.Size(819, 18);
            this.transacions_Label.TabIndex = 3;
            this.transacions_Label.Text = "Transactions";
            this.transacions_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.transacions_Label);
            this.panel3.Controls.Add(this.showPanelButton_Label);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(848, 18);
            this.panel3.TabIndex = 4;
            // 
            // TransactionGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.transactionList_DataGridView);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.summary_Panel);
            this.Controls.Add(this.panel3);
            this.Name = "TransactionGridView";
            this.Size = new System.Drawing.Size(848, 428);
            this.Load += new System.EventHandler(this.TransactionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactionList_DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.summary_Panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView transactionList_DataGridView;
        private System.Windows.Forms.BindingSource transactionBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem edit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delete_ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox quote_CheckBox;
        private System.Windows.Forms.CheckBox profroma_CheckBox;
        private System.Windows.Forms.CheckBox order_CheckBox;
        private System.Windows.Forms.CheckBox invoice_CheckBox;
        private System.Windows.Forms.Panel summary_Panel;
        private System.Windows.Forms.Label summary_Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn quoteNrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proformaNrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseNr;
        private System.Windows.Forms.ToolStripMenuItem sendMail_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem id_ToolStripMenuItem;
        private System.Windows.Forms.Label showPanelButton_Label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox unpaid_CheckBox;
        private System.Windows.Forms.ToolStripMenuItem viewLog_ToolStripMenuItem;
        private System.Windows.Forms.Label transacions_Label;
        private System.Windows.Forms.ToolStripMenuItem void_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem override_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.CheckBox paid_CheckBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox processing_CheckBox;
        private System.Windows.Forms.Button size_Button;
        private System.Windows.Forms.ToolStripMenuItem removeLinks_LoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acounts_ToolStripMenuItem;
        private System.Windows.Forms.Label receipt_Label;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem duplicate_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelTrans_ToolStripMenuItem;
        private System.Windows.Forms.CheckBox creditNote_CheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Select_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlagPaid_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlagPOMissing_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlagMailed_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptListColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetClientInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierColumn;
        private System.Windows.Forms.CheckBox mailed_ChkBox;
        private System.Windows.Forms.ToolStripMenuItem miMultiEdit;
        private System.Windows.Forms.CheckBox cancelTrans_CheckBox;
    }
}
