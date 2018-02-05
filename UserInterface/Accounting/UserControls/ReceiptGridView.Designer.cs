namespace UserInterface.Accounting.UserControls
{
    partial class ReceiptGridView
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
            this.summary_Panel = new System.Windows.Forms.Panel();
            this.showPanelButton_Label = new System.Windows.Forms.Label();
            this.summary_Label = new System.Windows.Forms.Label();
            this.right_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.size_Button = new System.Windows.Forms.Button();
            this.paid_CheckBox = new System.Windows.Forms.CheckBox();
            this.unpiad_CheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.processed_CheckBox = new System.Windows.Forms.CheckBox();
            this.noAccount_CheckBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clientInfo_CheckBox = new System.Windows.Forms.CheckBox();
            this.processInfo_CheckBox = new System.Windows.Forms.CheckBox();
            this.receipts_Label = new System.Windows.Forms.Label();
            this.receiptDataGridView = new System.Windows.Forms.DataGridView();
            this.Selected_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlagProcessed_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountRemaining_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceListColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientInfoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeingProcessedReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFinalizedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iD_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLinks_LoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.createInvoice_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceInvoice_lToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summary_Panel.SuspendLayout();
            this.right_flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptBindingSource)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.summary_Panel.Size = new System.Drawing.Size(771, 18);
            this.summary_Panel.TabIndex = 3;
            // 
            // showPanelButton_Label
            // 
            this.showPanelButton_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.showPanelButton_Label.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.showPanelButton_Label.Location = new System.Drawing.Point(746, 0);
            this.showPanelButton_Label.Name = "showPanelButton_Label";
            this.showPanelButton_Label.Size = new System.Drawing.Size(25, 18);
            this.showPanelButton_Label.TabIndex = 2;
            this.showPanelButton_Label.Text = "o";
            this.showPanelButton_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showPanelButton_Label.Click += new System.EventHandler(this.showPanelButton_Label_Click);
            // 
            // summary_Label
            // 
            this.summary_Label.Location = new System.Drawing.Point(0, 0);
            this.summary_Label.Margin = new System.Windows.Forms.Padding(0);
            this.summary_Label.Name = "summary_Label";
            this.summary_Label.Size = new System.Drawing.Size(511, 18);
            this.summary_Label.TabIndex = 1;
            this.summary_Label.Text = "Transaction Summary";
            this.summary_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // right_flowLayoutPanel
            // 
            this.right_flowLayoutPanel.Controls.Add(this.size_Button);
            this.right_flowLayoutPanel.Controls.Add(this.paid_CheckBox);
            this.right_flowLayoutPanel.Controls.Add(this.unpiad_CheckBox);
            this.right_flowLayoutPanel.Controls.Add(this.panel1);
            this.right_flowLayoutPanel.Controls.Add(this.processed_CheckBox);
            this.right_flowLayoutPanel.Controls.Add(this.noAccount_CheckBox);
            this.right_flowLayoutPanel.Controls.Add(this.panel2);
            this.right_flowLayoutPanel.Controls.Add(this.clientInfo_CheckBox);
            this.right_flowLayoutPanel.Controls.Add(this.processInfo_CheckBox);
            this.right_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.right_flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.right_flowLayoutPanel.Location = new System.Drawing.Point(668, 36);
            this.right_flowLayoutPanel.Name = "right_flowLayoutPanel";
            this.right_flowLayoutPanel.Size = new System.Drawing.Size(103, 490);
            this.right_flowLayoutPanel.TabIndex = 4;
            // 
            // size_Button
            // 
            this.size_Button.Location = new System.Drawing.Point(3, 0);
            this.size_Button.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.size_Button.Name = "size_Button";
            this.size_Button.Size = new System.Drawing.Size(97, 23);
            this.size_Button.TabIndex = 13;
            this.size_Button.Text = "Auto Size";
            this.size_Button.UseVisualStyleBackColor = true;
            this.size_Button.Click += new System.EventHandler(this.size_Button_Click);
            // 
            // paid_CheckBox
            // 
            this.paid_CheckBox.AutoSize = true;
            this.paid_CheckBox.Checked = true;
            this.paid_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.paid_CheckBox.Location = new System.Drawing.Point(3, 29);
            this.paid_CheckBox.Name = "paid_CheckBox";
            this.paid_CheckBox.Size = new System.Drawing.Size(47, 17);
            this.paid_CheckBox.TabIndex = 2;
            this.paid_CheckBox.Text = "Paid";
            this.paid_CheckBox.UseVisualStyleBackColor = true;
            this.paid_CheckBox.CheckedChanged += new System.EventHandler(this.LoadReceipts_Event);
            // 
            // unpiad_CheckBox
            // 
            this.unpiad_CheckBox.AutoSize = true;
            this.unpiad_CheckBox.Location = new System.Drawing.Point(3, 52);
            this.unpiad_CheckBox.Name = "unpiad_CheckBox";
            this.unpiad_CheckBox.Size = new System.Drawing.Size(60, 17);
            this.unpiad_CheckBox.TabIndex = 6;
            this.unpiad_CheckBox.Text = "Unpaid";
            this.unpiad_CheckBox.UseVisualStyleBackColor = true;
            this.unpiad_CheckBox.CheckedChanged += new System.EventHandler(this.LoadReceipts_Event);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(3, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 3);
            this.panel1.TabIndex = 7;
            // 
            // processed_CheckBox
            // 
            this.processed_CheckBox.AutoSize = true;
            this.processed_CheckBox.Location = new System.Drawing.Point(3, 84);
            this.processed_CheckBox.Name = "processed_CheckBox";
            this.processed_CheckBox.Size = new System.Drawing.Size(78, 17);
            this.processed_CheckBox.TabIndex = 8;
            this.processed_CheckBox.Text = "Processing";
            this.processed_CheckBox.UseVisualStyleBackColor = true;
            this.processed_CheckBox.CheckedChanged += new System.EventHandler(this.LoadReceipts_Event);
            // 
            // noAccount_CheckBox
            // 
            this.noAccount_CheckBox.AutoSize = true;
            this.noAccount_CheckBox.Location = new System.Drawing.Point(3, 107);
            this.noAccount_CheckBox.Name = "noAccount_CheckBox";
            this.noAccount_CheckBox.Size = new System.Drawing.Size(83, 17);
            this.noAccount_CheckBox.TabIndex = 11;
            this.noAccount_CheckBox.Text = "No Account";
            this.noAccount_CheckBox.UseVisualStyleBackColor = true;
            this.noAccount_CheckBox.CheckedChanged += new System.EventHandler(this.LoadReceipts_Event);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(3, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 3);
            this.panel2.TabIndex = 9;
            // 
            // clientInfo_CheckBox
            // 
            this.clientInfo_CheckBox.AutoSize = true;
            this.clientInfo_CheckBox.Location = new System.Drawing.Point(3, 139);
            this.clientInfo_CheckBox.Name = "clientInfo_CheckBox";
            this.clientInfo_CheckBox.Size = new System.Drawing.Size(73, 17);
            this.clientInfo_CheckBox.TabIndex = 10;
            this.clientInfo_CheckBox.Text = "Client Info";
            this.clientInfo_CheckBox.UseVisualStyleBackColor = true;
            this.clientInfo_CheckBox.CheckedChanged += new System.EventHandler(this.LoadReceipts_Event);
            // 
            // processInfo_CheckBox
            // 
            this.processInfo_CheckBox.AutoSize = true;
            this.processInfo_CheckBox.Location = new System.Drawing.Point(3, 162);
            this.processInfo_CheckBox.Name = "processInfo_CheckBox";
            this.processInfo_CheckBox.Size = new System.Drawing.Size(85, 17);
            this.processInfo_CheckBox.TabIndex = 12;
            this.processInfo_CheckBox.Text = "Process Info";
            this.processInfo_CheckBox.UseVisualStyleBackColor = true;
            this.processInfo_CheckBox.CheckedChanged += new System.EventHandler(this.LoadReceipts_Event);
            // 
            // receipts_Label
            // 
            this.receipts_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.receipts_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receipts_Label.Location = new System.Drawing.Point(0, 0);
            this.receipts_Label.Margin = new System.Windows.Forms.Padding(0);
            this.receipts_Label.Name = "receipts_Label";
            this.receipts_Label.Size = new System.Drawing.Size(771, 18);
            this.receipts_Label.TabIndex = 5;
            this.receipts_Label.Text = "Receipts";
            this.receipts_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // receiptDataGridView
            // 
            this.receiptDataGridView.AllowUserToAddRows = false;
            this.receiptDataGridView.AllowUserToDeleteRows = false;
            this.receiptDataGridView.AllowUserToOrderColumns = true;
            this.receiptDataGridView.AutoGenerateColumns = false;
            this.receiptDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.receiptDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.receiptDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected_Column,
            this.FlagProcessed_Column,
            this.IDColumn,
            this.AccountColumn,
            this.ReceiptDateColumn,
            this.DescriptionColumn,
            this.AmountColumn,
            this.AmountRemaining_Column,
            this.InvoiceListColumn,
            this.ClientInfoColumn,
            this.BeingProcessedReference,
            this.NotesColumn,
            this.DateFinalizedColumn});
            this.receiptDataGridView.DataSource = this.receiptBindingSource;
            this.receiptDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receiptDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.receiptDataGridView.Location = new System.Drawing.Point(0, 36);
            this.receiptDataGridView.MultiSelect = false;
            this.receiptDataGridView.Name = "receiptDataGridView";
            this.receiptDataGridView.RowHeadersVisible = false;
            this.receiptDataGridView.RowHeadersWidth = 25;
            this.receiptDataGridView.Size = new System.Drawing.Size(668, 490);
            this.receiptDataGridView.TabIndex = 6;
            this.receiptDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Receipt_CellClick);
            this.receiptDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.receiptDataGridView_CellMouseClick);
            this.receiptDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.receiptDataGridView_DataBindingComplete);
            this.receiptDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.receiptDataGridView_RowValidating);
            // 
            // Selected_Column
            // 
            this.Selected_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Selected_Column.Frozen = true;
            this.Selected_Column.HeaderText = "";
            this.Selected_Column.Name = "Selected_Column";
            this.Selected_Column.ReadOnly = true;
            this.Selected_Column.Width = 10;
            // 
            // FlagProcessed_Column
            // 
            this.FlagProcessed_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FlagProcessed_Column.Frozen = true;
            this.FlagProcessed_Column.HeaderText = "";
            this.FlagProcessed_Column.Name = "FlagProcessed_Column";
            this.FlagProcessed_Column.ReadOnly = true;
            this.FlagProcessed_Column.ToolTipText = "Processed";
            this.FlagProcessed_Column.Width = 5;
            // 
            // IDColumn
            // 
            this.IDColumn.DataPropertyName = "ID";
            this.IDColumn.Frozen = true;
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 70;
            // 
            // AccountColumn
            // 
            this.AccountColumn.DataPropertyName = "Account";
            this.AccountColumn.HeaderText = "Account";
            this.AccountColumn.Name = "AccountColumn";
            this.AccountColumn.Width = 80;
            // 
            // ReceiptDateColumn
            // 
            this.ReceiptDateColumn.DataPropertyName = "ReceiptDate";
            this.ReceiptDateColumn.HeaderText = "Date";
            this.ReceiptDateColumn.Name = "ReceiptDateColumn";
            this.ReceiptDateColumn.Width = 80;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.DataPropertyName = "Description";
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.Width = 150;
            // 
            // AmountColumn
            // 
            this.AmountColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle1.Format = "C2";
            this.AmountColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.AmountColumn.HeaderText = "Amount";
            this.AmountColumn.Name = "AmountColumn";
            this.AmountColumn.Width = 80;
            // 
            // AmountRemaining_Column
            // 
            this.AmountRemaining_Column.DataPropertyName = "AmountRemaining";
            dataGridViewCellStyle2.Format = "C2";
            this.AmountRemaining_Column.DefaultCellStyle = dataGridViewCellStyle2;
            this.AmountRemaining_Column.HeaderText = "Remaining";
            this.AmountRemaining_Column.Name = "AmountRemaining_Column";
            this.AmountRemaining_Column.ReadOnly = true;
            // 
            // InvoiceListColumn
            // 
            this.InvoiceListColumn.DataPropertyName = "GetInvoiceIDList";
            this.InvoiceListColumn.HeaderText = "Invoice ID List";
            this.InvoiceListColumn.Name = "InvoiceListColumn";
            this.InvoiceListColumn.ReadOnly = true;
            // 
            // ClientInfoColumn
            // 
            this.ClientInfoColumn.DataPropertyName = "ClientInfo";
            this.ClientInfoColumn.HeaderText = "ClientInfo";
            this.ClientInfoColumn.Name = "ClientInfoColumn";
            this.ClientInfoColumn.ReadOnly = true;
            this.ClientInfoColumn.Width = 150;
            // 
            // BeingProcessedReference
            // 
            this.BeingProcessedReference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BeingProcessedReference.DataPropertyName = "BeingProcessedReference";
            this.BeingProcessedReference.HeaderText = "BeingProcessedReference";
            this.BeingProcessedReference.Name = "BeingProcessedReference";
            this.BeingProcessedReference.ReadOnly = true;
            this.BeingProcessedReference.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BeingProcessedReference.Width = 159;
            // 
            // NotesColumn
            // 
            this.NotesColumn.DataPropertyName = "Notes";
            this.NotesColumn.HeaderText = "Notes";
            this.NotesColumn.Name = "NotesColumn";
            this.NotesColumn.Width = 150;
            // 
            // DateFinalizedColumn
            // 
            this.DateFinalizedColumn.DataPropertyName = "DateFinalized";
            this.DateFinalizedColumn.HeaderText = "DateFinalized";
            this.DateFinalizedColumn.Name = "DateFinalizedColumn";
            this.DateFinalizedColumn.ReadOnly = true;
            this.DateFinalizedColumn.Width = 80;
            // 
            // receiptBindingSource
            // 
            this.receiptBindingSource.DataSource = typeof(Data.Accounts.Receipt);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iD_ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.removeLinks_LoolStripMenuItem,
            this.toolStripSeparator1,
            this.createInvoice_ToolStripMenuItem,
            this.maintenanceInvoice_lToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(185, 120);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // iD_ToolStripMenuItem
            // 
            this.iD_ToolStripMenuItem.Name = "iD_ToolStripMenuItem";
            this.iD_ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.iD_ToolStripMenuItem.Text = "ID";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem1.Text = "Search Linked";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // removeLinks_LoolStripMenuItem
            // 
            this.removeLinks_LoolStripMenuItem.Name = "removeLinks_LoolStripMenuItem";
            this.removeLinks_LoolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.removeLinks_LoolStripMenuItem.Text = "Remove Links";
            this.removeLinks_LoolStripMenuItem.ToolTipText = "Will Require Save";
            this.removeLinks_LoolStripMenuItem.Click += new System.EventHandler(this.removeLinks_LoolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // createInvoice_ToolStripMenuItem
            // 
            this.createInvoice_ToolStripMenuItem.Name = "createInvoice_ToolStripMenuItem";
            this.createInvoice_ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.createInvoice_ToolStripMenuItem.Text = "Create Invoice";
            this.createInvoice_ToolStripMenuItem.Click += new System.EventHandler(this.CreateInvoice_Click);
            // 
            // maintenanceInvoice_lToolStripMenuItem
            // 
            this.maintenanceInvoice_lToolStripMenuItem.Name = "maintenanceInvoice_lToolStripMenuItem";
            this.maintenanceInvoice_lToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.maintenanceInvoice_lToolStripMenuItem.Text = "Maintenance Invoice";
            this.maintenanceInvoice_lToolStripMenuItem.ToolTipText = "Only available if there are no allocated links";
            this.maintenanceInvoice_lToolStripMenuItem.Click += new System.EventHandler(this.MaintenanceInvoice_Click);
            // 
            // ReceiptGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.receiptDataGridView);
            this.Controls.Add(this.right_flowLayoutPanel);
            this.Controls.Add(this.summary_Panel);
            this.Controls.Add(this.receipts_Label);
            this.Name = "ReceiptGridView";
            this.Size = new System.Drawing.Size(771, 526);
            this.Load += new System.EventHandler(this.ReceiptGridView_Load);
            this.summary_Panel.ResumeLayout(false);
            this.right_flowLayoutPanel.ResumeLayout(false);
            this.right_flowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptBindingSource)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel summary_Panel;
        private System.Windows.Forms.Label showPanelButton_Label;
        private System.Windows.Forms.Label summary_Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.FlowLayoutPanel right_flowLayoutPanel;
        private System.Windows.Forms.CheckBox paid_CheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox unpiad_CheckBox;
        private System.Windows.Forms.Label receipts_Label;
        private System.Windows.Forms.BindingSource receiptBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem iD_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceInvoice_lToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem createInvoice_ToolStripMenuItem;
        private System.Windows.Forms.CheckBox processed_CheckBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox clientInfo_CheckBox;
        private System.Windows.Forms.CheckBox noAccount_CheckBox;
        private System.Windows.Forms.CheckBox processInfo_CheckBox;
        private System.Windows.Forms.Button size_Button;
        private System.Windows.Forms.ToolStripMenuItem removeLinks_LoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Selected_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlagProcessed_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountRemaining_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceListColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientInfoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeingProcessedReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFinalizedColumn;
        public System.Windows.Forms.DataGridView receiptDataGridView;
    }
}
