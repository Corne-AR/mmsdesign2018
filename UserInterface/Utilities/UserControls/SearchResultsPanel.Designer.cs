namespace UserInterface.Utilities.UserControls
{
    partial class SearchResultsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchResultsPanel));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resultsSummary_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchResults_Label = new System.Windows.Forms.Label();
            this.showHide_Label = new System.Windows.Forms.Label();
            this.credit_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.allStatements_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.selectedStatements_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.searchDataDataGridView = new System.Windows.Forms.DataGridView();
            this.maint_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.allReminders_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.selectedReminders_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.reminderasQuote_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.searchDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Account_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionID_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptID_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuoteID_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Results_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.credit_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataDataGridView)).BeginInit();
            this.maint_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1MinSize = 20;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.credit_ToolStrip);
            this.splitContainer1.Panel2.Controls.Add(this.searchDataDataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.maint_ToolStrip);
            this.splitContainer1.Panel2MinSize = 20;
            this.splitContainer1.Size = new System.Drawing.Size(908, 300);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.resultsSummary_Label);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.searchResults_Label);
            this.panel1.Controls.Add(this.showHide_Label);
            this.panel1.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(906, 20);
            this.panel1.TabIndex = 1;
            this.panel1.DoubleClick += new System.EventHandler(this.SetCollaped_Click);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // resultsSummary_Label
            // 
            this.resultsSummary_Label.AutoSize = true;
            this.resultsSummary_Label.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.resultsSummary_Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.resultsSummary_Label.Location = new System.Drawing.Point(132, 3);
            this.resultsSummary_Label.Margin = new System.Windows.Forms.Padding(3);
            this.resultsSummary_Label.Name = "resultsSummary_Label";
            this.resultsSummary_Label.Size = new System.Drawing.Size(0, 13);
            this.resultsSummary_Label.TabIndex = 2;
            this.resultsSummary_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resultsSummary_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.resultsSummary_Label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.resultsSummary_Label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(116, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "   ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // searchResults_Label
            // 
            this.searchResults_Label.AutoSize = true;
            this.searchResults_Label.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.searchResults_Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchResults_Label.Location = new System.Drawing.Point(37, 3);
            this.searchResults_Label.Margin = new System.Windows.Forms.Padding(3);
            this.searchResults_Label.Name = "searchResults_Label";
            this.searchResults_Label.Size = new System.Drawing.Size(79, 13);
            this.searchResults_Label.TabIndex = 1;
            this.searchResults_Label.Text = "Search Results";
            this.searchResults_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchResults_Label.DoubleClick += new System.EventHandler(this.SetCollaped_Click);
            this.searchResults_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.searchResults_Label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.searchResults_Label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // showHide_Label
            // 
            this.showHide_Label.AutoSize = true;
            this.showHide_Label.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.showHide_Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.showHide_Label.Location = new System.Drawing.Point(3, 3);
            this.showHide_Label.Margin = new System.Windows.Forms.Padding(3);
            this.showHide_Label.Name = "showHide_Label";
            this.showHide_Label.Size = new System.Drawing.Size(34, 13);
            this.showHide_Label.TabIndex = 0;
            this.showHide_Label.Text = "Show";
            this.showHide_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showHide_Label.DoubleClick += new System.EventHandler(this.SetCollaped_Click);
            this.showHide_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.showHide_Label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.showHide_Label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // credit_ToolStrip
            // 
            this.credit_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.credit_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator2,
            this.allStatements_ToolStripButton,
            this.selectedStatements_ToolStripButton});
            this.credit_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.credit_ToolStrip.Name = "credit_ToolStrip";
            this.credit_ToolStrip.Size = new System.Drawing.Size(907, 20);
            this.credit_ToolStrip.TabIndex = 2;
            this.credit_ToolStrip.Text = "toolStrip1";
            this.credit_ToolStrip.Visible = false;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(66, 17);
            this.toolStripLabel2.Text = "Statements";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 20);
            // 
            // allStatements_ToolStripButton
            // 
            this.allStatements_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.allStatements_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("allStatements_ToolStripButton.Image")));
            this.allStatements_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.allStatements_ToolStripButton.Name = "allStatements_ToolStripButton";
            this.allStatements_ToolStripButton.Size = new System.Drawing.Size(25, 17);
            this.allStatements_ToolStripButton.Text = "All";
            this.allStatements_ToolStripButton.Click += new System.EventHandler(this.SendAllStatements_ToolStripButton_Click);
            // 
            // selectedStatements_ToolStripButton
            // 
            this.selectedStatements_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectedStatements_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("selectedStatements_ToolStripButton.Image")));
            this.selectedStatements_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectedStatements_ToolStripButton.Name = "selectedStatements_ToolStripButton";
            this.selectedStatements_ToolStripButton.Size = new System.Drawing.Size(55, 17);
            this.selectedStatements_ToolStripButton.Text = "Selected";
            this.selectedStatements_ToolStripButton.Click += new System.EventHandler(this.selectedStatements_ToolStripButton_Click);
            // 
            // searchDataDataGridView
            // 
            this.searchDataDataGridView.AllowUserToAddRows = false;
            this.searchDataDataGridView.AllowUserToDeleteRows = false;
            this.searchDataDataGridView.AutoGenerateColumns = false;
            this.searchDataDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.searchDataDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.searchDataDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchDataDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Account_Column,
            this.ClientName_Column,
            this.ProductID_Column,
            this.TransactionID_Column,
            this.ReceiptID_Column,
            this.QuoteID_Column,
            this.Contact_Column,
            this.Results_Column,
            this.Amount_Column});
            this.searchDataDataGridView.DataSource = this.searchDataBindingSource;
            this.searchDataDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchDataDataGridView.Location = new System.Drawing.Point(0, 0);
            this.searchDataDataGridView.Name = "searchDataDataGridView";
            this.searchDataDataGridView.ReadOnly = true;
            this.searchDataDataGridView.RowHeadersVisible = false;
            this.searchDataDataGridView.Size = new System.Drawing.Size(906, 272);
            this.searchDataDataGridView.TabIndex = 0;
            this.searchDataDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SearchCel_CellClick);
            this.searchDataDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SearchCel_CellDoubleClick);
            // 
            // maint_ToolStrip
            // 
            this.maint_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.maint_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.allReminders_ToolStripButton,
            this.selectedReminders_ToolStripButton,
            this.reminderasQuote_ToolStripButton});
            this.maint_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.maint_ToolStrip.Name = "maint_ToolStrip";
            this.maint_ToolStrip.Size = new System.Drawing.Size(907, 20);
            this.maint_ToolStrip.TabIndex = 1;
            this.maint_ToolStrip.Text = "toolStrip1";
            this.maint_ToolStrip.Visible = false;
            this.maint_ToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.maint_ToolStrip_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 17);
            this.toolStripLabel1.Text = "Reminders";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 20);
            // 
            // allReminders_ToolStripButton
            // 
            this.allReminders_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.allReminders_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("allReminders_ToolStripButton.Image")));
            this.allReminders_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.allReminders_ToolStripButton.Name = "allReminders_ToolStripButton";
            this.allReminders_ToolStripButton.Size = new System.Drawing.Size(25, 17);
            this.allReminders_ToolStripButton.Text = "All";
            this.allReminders_ToolStripButton.Click += new System.EventHandler(this.SendAllMaintReminders_Click);
            // 
            // selectedReminders_ToolStripButton
            // 
            this.selectedReminders_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectedReminders_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("selectedReminders_ToolStripButton.Image")));
            this.selectedReminders_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectedReminders_ToolStripButton.Name = "selectedReminders_ToolStripButton";
            this.selectedReminders_ToolStripButton.Size = new System.Drawing.Size(55, 17);
            this.selectedReminders_ToolStripButton.Text = "Selected";
            this.selectedReminders_ToolStripButton.Click += new System.EventHandler(this.SendSelectedMaintReminders_Click);
            // 
            // reminderasQuote_ToolStripButton
            // 
            this.reminderasQuote_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.reminderasQuote_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("reminderasQuote_ToolStripButton.Image")));
            this.reminderasQuote_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reminderasQuote_ToolStripButton.Name = "reminderasQuote_ToolStripButton";
            this.reminderasQuote_ToolStripButton.Size = new System.Drawing.Size(105, 17);
            this.reminderasQuote_ToolStripButton.Text = "Selected as Quote";
            this.reminderasQuote_ToolStripButton.Click += new System.EventHandler(this.reminderasQuote_ToolStripButton_Click);
            // 
            // searchDataBindingSource
            // 
            this.searchDataBindingSource.DataSource = typeof(Data.Search.SearchData);
            // 
            // Account_Column
            // 
            this.Account_Column.DataPropertyName = "Account";
            this.Account_Column.HeaderText = "Account";
            this.Account_Column.Name = "Account_Column";
            this.Account_Column.ReadOnly = true;
            this.Account_Column.Width = 72;
            // 
            // ClientName_Column
            // 
            this.ClientName_Column.DataPropertyName = "ClientName";
            this.ClientName_Column.HeaderText = "ClientName";
            this.ClientName_Column.Name = "ClientName_Column";
            this.ClientName_Column.ReadOnly = true;
            this.ClientName_Column.Width = 86;
            // 
            // ProductID_Column
            // 
            this.ProductID_Column.DataPropertyName = "ProductID";
            this.ProductID_Column.HeaderText = "ProductID";
            this.ProductID_Column.Name = "ProductID_Column";
            this.ProductID_Column.ReadOnly = true;
            this.ProductID_Column.Width = 80;
            // 
            // TransactionID_Column
            // 
            this.TransactionID_Column.DataPropertyName = "TransactionID";
            this.TransactionID_Column.HeaderText = "TransactionID";
            this.TransactionID_Column.Name = "TransactionID_Column";
            this.TransactionID_Column.ReadOnly = true;
            this.TransactionID_Column.Width = 99;
            // 
            // ReceiptID_Column
            // 
            this.ReceiptID_Column.DataPropertyName = "ReceiptID";
            this.ReceiptID_Column.HeaderText = "ReceiptID";
            this.ReceiptID_Column.Name = "ReceiptID_Column";
            this.ReceiptID_Column.ReadOnly = true;
            this.ReceiptID_Column.Width = 80;
            // 
            // QuoteID_Column
            // 
            this.QuoteID_Column.DataPropertyName = "QuoteID";
            this.QuoteID_Column.HeaderText = "QuoteID";
            this.QuoteID_Column.Name = "QuoteID_Column";
            this.QuoteID_Column.ReadOnly = true;
            this.QuoteID_Column.Width = 72;
            // 
            // Contact_Column
            // 
            this.Contact_Column.DataPropertyName = "Contact";
            this.Contact_Column.HeaderText = "Contact";
            this.Contact_Column.Name = "Contact_Column";
            this.Contact_Column.ReadOnly = true;
            this.Contact_Column.Width = 69;
            // 
            // Results_Column
            // 
            this.Results_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Results_Column.DataPropertyName = "Results";
            this.Results_Column.HeaderText = "Results";
            this.Results_Column.Name = "Results_Column";
            this.Results_Column.ReadOnly = true;
            // 
            // Amount_Column
            // 
            this.Amount_Column.DataPropertyName = "Amount";
            this.Amount_Column.HeaderText = "Amount";
            this.Amount_Column.Name = "Amount_Column";
            this.Amount_Column.ReadOnly = true;
            this.Amount_Column.Width = 68;
            // 
            // SearchResultsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SearchResultsPanel";
            this.Size = new System.Drawing.Size(908, 300);
            this.Load += new System.EventHandler(this.SearchResultsPanel_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.credit_ToolStrip.ResumeLayout(false);
            this.credit_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataDataGridView)).EndInit();
            this.maint_ToolStrip.ResumeLayout(false);
            this.maint_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label showHide_Label;
        private System.Windows.Forms.DataGridView searchDataDataGridView;
        private System.Windows.Forms.BindingSource searchDataBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStrip maint_ToolStrip;
        private System.Windows.Forms.ToolStripButton selectedReminders_ToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton allReminders_ToolStripButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label resultsSummary_Label;
        private System.Windows.Forms.Label searchResults_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton reminderasQuote_ToolStripButton;
        private System.Windows.Forms.ToolStrip credit_ToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton allStatements_ToolStripButton;
        private System.Windows.Forms.ToolStripButton selectedStatements_ToolStripButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionID_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuoteID_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Results_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount_Column;
    }
}
