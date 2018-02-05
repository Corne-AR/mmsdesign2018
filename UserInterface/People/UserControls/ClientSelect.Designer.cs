namespace UserInterface.People.UserControls
{
    partial class ClientSelect
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.client_DataGridView = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aClientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientList_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cell_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setupFileInstruciotnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceReminderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceReminderAsQuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aLlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedDatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.keywords_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clientDrag_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.client_DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aClientBindingSource)).BeginInit();
            this.cell_ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.client_DataGridView);
            this.splitContainer1.Panel1.Controls.Add(this.clientList_Label);
            this.splitContainer1.Panel1.Click += new System.EventHandler(this.OpenClose_Event);
            this.splitContainer1.Panel1MinSize = 1;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2MinSize = 1;
            this.splitContainer1.Size = new System.Drawing.Size(220, 367);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 8;
            // 
            // client_DataGridView
            // 
            this.client_DataGridView.AllowUserToAddRows = false;
            this.client_DataGridView.AllowUserToDeleteRows = false;
            this.client_DataGridView.AutoGenerateColumns = false;
            this.client_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.client_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.client_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.client_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.client_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.client_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.accountColumn});
            this.client_DataGridView.DataSource = this.aClientBindingSource;
            this.client_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.client_DataGridView.Location = new System.Drawing.Point(0, 21);
            this.client_DataGridView.MultiSelect = false;
            this.client_DataGridView.Name = "client_DataGridView";
            this.client_DataGridView.ReadOnly = true;
            this.client_DataGridView.RowHeadersVisible = false;
            this.client_DataGridView.Size = new System.Drawing.Size(194, 346);
            this.client_DataGridView.TabIndex = 9;
            this.client_DataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.client_DataGridView_CellMouseClick);
            this.client_DataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.client_DataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "Name";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // accountColumn
            // 
            this.accountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.accountColumn.DataPropertyName = "Account";
            this.accountColumn.HeaderText = "Account";
            this.accountColumn.Name = "accountColumn";
            this.accountColumn.ReadOnly = true;
            this.accountColumn.Width = 72;
            // 
            // aClientBindingSource
            // 
            this.aClientBindingSource.DataSource = typeof(Data.People.Client);
            // 
            // clientList_Label
            // 
            this.clientList_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.clientList_Label.Location = new System.Drawing.Point(0, 0);
            this.clientList_Label.Margin = new System.Windows.Forms.Padding(0);
            this.clientList_Label.Name = "clientList_Label";
            this.clientList_Label.Size = new System.Drawing.Size(194, 21);
            this.clientList_Label.TabIndex = 4;
            this.clientList_Label.Text = "Client List";
            this.clientList_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 367);
            this.label1.TabIndex = 0;
            this.label1.Text = "3";
            this.label1.DoubleClick += new System.EventHandler(this.OpenClose_Event);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // cell_ContextMenuStrip
            // 
            this.cell_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iDToolStripMenuItem,
            this.toolStripMenuItem1,
            this.statementToolStripMenuItem,
            this.toolStripSeparator1,
            this.keywords_ToolStripMenuItem,
            this.viewLogToolStripMenuItem});
            this.cell_ContextMenuStrip.Name = "cell_ContextMenuStrip";
            this.cell_ContextMenuStrip.Size = new System.Drawing.Size(153, 142);
            // 
            // iDToolStripMenuItem
            // 
            this.iDToolStripMenuItem.Name = "iDToolStripMenuItem";
            this.iDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.iDToolStripMenuItem.Text = "ID";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupFileInstruciotnsToolStripMenuItem,
            this.maintenanceReminderToolStripMenuItem,
            this.maintenanceReminderAsQuoteToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Mail";
            // 
            // setupFileInstruciotnsToolStripMenuItem
            // 
            this.setupFileInstruciotnsToolStripMenuItem.Name = "setupFileInstruciotnsToolStripMenuItem";
            this.setupFileInstruciotnsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.setupFileInstruciotnsToolStripMenuItem.Text = "Setup File Instructions";
            this.setupFileInstruciotnsToolStripMenuItem.Click += new System.EventHandler(this.setupFileInstruciotnsToolStripMenuItem_Click);
            // 
            // maintenanceReminderToolStripMenuItem
            // 
            this.maintenanceReminderToolStripMenuItem.Name = "maintenanceReminderToolStripMenuItem";
            this.maintenanceReminderToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.maintenanceReminderToolStripMenuItem.Text = "Maintenance Reminder";
            this.maintenanceReminderToolStripMenuItem.Click += new System.EventHandler(this.maintenanceReminderToolStripMenuItem_Click);
            // 
            // maintenanceReminderAsQuoteToolStripMenuItem
            // 
            this.maintenanceReminderAsQuoteToolStripMenuItem.Name = "maintenanceReminderAsQuoteToolStripMenuItem";
            this.maintenanceReminderAsQuoteToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.maintenanceReminderAsQuoteToolStripMenuItem.Text = "Maintenance Reminder as Quote";
            // 
            // statementToolStripMenuItem
            // 
            this.statementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aLlToolStripMenuItem,
            this.selectedDatesToolStripMenuItem});
            this.statementToolStripMenuItem.Name = "statementToolStripMenuItem";
            this.statementToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.statementToolStripMenuItem.Text = "Statement";
            // 
            // aLlToolStripMenuItem
            // 
            this.aLlToolStripMenuItem.Name = "aLlToolStripMenuItem";
            this.aLlToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aLlToolStripMenuItem.Text = "All Dates";
            this.aLlToolStripMenuItem.Click += new System.EventHandler(this.StatementsALL_Click);
            // 
            // selectedDatesToolStripMenuItem
            // 
            this.selectedDatesToolStripMenuItem.Name = "selectedDatesToolStripMenuItem";
            this.selectedDatesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectedDatesToolStripMenuItem.Text = "Selected Dates";
            this.selectedDatesToolStripMenuItem.Click += new System.EventHandler(this.StatementsSelected_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // keywords_ToolStripMenuItem
            // 
            this.keywords_ToolStripMenuItem.Name = "keywords_ToolStripMenuItem";
            this.keywords_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.keywords_ToolStripMenuItem.Text = "Keywords";
            this.keywords_ToolStripMenuItem.Click += new System.EventHandler(this.keywords_ToolStripMenuItem_Click);
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewLogToolStripMenuItem.Text = "View Log";
            this.viewLogToolStripMenuItem.Click += new System.EventHandler(this.viewLogToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ClientSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ClientSelect";
            this.Size = new System.Drawing.Size(220, 366);
            this.Load += new System.EventHandler(this.RightPanel_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.client_DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aClientBindingSource)).EndInit();
            this.cell_ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView client_DataGridView;
        private System.Windows.Forms.Label clientList_Label;
        private System.Windows.Forms.BindingSource aClientBindingSource;
        private System.Windows.Forms.ContextMenuStrip cell_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem iDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem statementToolStripMenuItem;
        private System.Windows.Forms.ToolTip clientDrag_ToolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountColumn;
        private System.Windows.Forms.ToolStripMenuItem selectedDatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keywords_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aLlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setupFileInstruciotnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem maintenanceReminderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceReminderAsQuoteToolStripMenuItem;
    }
}
