namespace UserInterface.Accounting.Forms
{
    partial class MultiCreatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiCreatorForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TransactionsListBox = new System.Windows.Forms.ListBox();
            this.transactionHeader1 = new UserInterface.Transactions.UserControls.TransactionHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.itemListEditor1 = new UserInterface.Transactions.UserControls.ItemListEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.AccountsComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnAddPlus = new System.Windows.Forms.ToolStripButton();
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnGenerate);
            this.flowLayoutPanel1.Controls.Add(this.typeComboBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 660);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1201, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1123, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(1042, 3);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(915, 3);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(121, 21);
            this.typeComboBox.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TransactionsListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.transactionHeader1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.dueDatePicker);
            this.splitContainer1.Panel2.Controls.Add(this.datePicker);
            this.splitContainer1.Panel2.Controls.Add(this.itemListEditor1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.AccountsComboBox);
            this.splitContainer1.Size = new System.Drawing.Size(1201, 635);
            this.splitContainer1.SplitterDistance = 236;
            this.splitContainer1.TabIndex = 1;
            // 
            // TransactionsListBox
            // 
            this.TransactionsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TransactionsListBox.FormattingEnabled = true;
            this.TransactionsListBox.Location = new System.Drawing.Point(0, 0);
            this.TransactionsListBox.Name = "TransactionsListBox";
            this.TransactionsListBox.Size = new System.Drawing.Size(236, 635);
            this.TransactionsListBox.TabIndex = 0;
            // 
            // transactionHeader1
            // 
            this.transactionHeader1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.transactionHeader1.BackColor = System.Drawing.SystemColors.Control;
            this.transactionHeader1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.transactionHeader1.Location = new System.Drawing.Point(0, 98);
            this.transactionHeader1.Margin = new System.Windows.Forms.Padding(0);
            this.transactionHeader1.Name = "transactionHeader1";
            this.transactionHeader1.Size = new System.Drawing.Size(961, 100);
            this.transactionHeader1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Due";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Date";
            // 
            // dueDatePicker
            // 
            this.dueDatePicker.Location = new System.Drawing.Point(56, 58);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(200, 20);
            this.dueDatePicker.TabIndex = 5;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(56, 31);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 4;
            // 
            // itemListEditor1
            // 
            this.itemListEditor1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.itemListEditor1.Location = new System.Drawing.Point(0, 198);
            this.itemListEditor1.Name = "itemListEditor1";
            this.itemListEditor1.Size = new System.Drawing.Size(961, 437);
            this.itemListEditor1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account";
            // 
            // AccountsComboBox
            // 
            this.AccountsComboBox.FormattingEnabled = true;
            this.AccountsComboBox.Location = new System.Drawing.Point(56, 3);
            this.AccountsComboBox.Name = "AccountsComboBox";
            this.AccountsComboBox.Size = new System.Drawing.Size(441, 21);
            this.AccountsComboBox.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnAddPlus,
            this.btnRemove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1201, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 22);
            this.btnAdd.Text = "Add";
            // 
            // btnAddPlus
            // 
            this.btnAddPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddPlus.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPlus.Image")));
            this.btnAddPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPlus.Name = "btnAddPlus";
            this.btnAddPlus.Size = new System.Drawing.Size(41, 22);
            this.btnAddPlus.Text = "Add+";
            this.btnAddPlus.ToolTipText = "Copy last transaction\'s items to the new transaction.";
            // 
            // btnRemove
            // 
            this.btnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(54, 22);
            this.btnRemove.Text = "Remove";
            // 
            // MultiCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 689);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MultiCreatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transactions Creator";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListBox TransactionsListBox;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AccountsComboBox;
        private Transactions.UserControls.ItemListEditor itemListEditor1;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ToolStripButton btnAddPlus;
        private Transactions.UserControls.TransactionHeader transactionHeader1;
        private System.Windows.Forms.ToolStripButton btnRemove;
    }
}