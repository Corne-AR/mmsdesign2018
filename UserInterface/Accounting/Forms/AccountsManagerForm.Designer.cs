namespace UserInterface.Accounting.Forms
{
    partial class AccountsManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountsManagerForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.transactionGridView1 = new UserInterface.Transactions.UserControls.TransactionGridView();
            this.receiptGridView1 = new UserInterface.Accounting.UserControls.ReceiptGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.main_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.refresh_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.link_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.process_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.reload_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.options_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.filterClient_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.filterRange_ToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.saveTransactions_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveReceipts_ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.saveAccount_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.save_ToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMMSReceipt = new System.Windows.Forms.ToolStripButton();
            this.paste_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addReceipt_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.suppliers_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.currentPayment_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AllPayable_Button = new System.Windows.Forms.ToolStripButton();
            this.selectedPayements_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.paymentsReport_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.customProfit_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lastMonthProfilt_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.profit_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ToDoListLabel = new System.Windows.Forms.Label();
            this.link_Label = new System.Windows.Forms.Label();
            this.clientSelect1 = new UserInterface.People.UserControls.ClientSelect();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.main_ToolStrip.SuspendLayout();
            this.suppliers_ToolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(222, 67);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.transactionGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.receiptGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(912, 585);
            this.splitContainer1.SplitterDistance = 305;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // transactionGridView1
            // 
            this.transactionGridView1.AccountingOnly = true;
            this.transactionGridView1.CanFilter = true;
            this.transactionGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionGridView1.IsLinksVisible = true;
            this.transactionGridView1.Location = new System.Drawing.Point(0, 0);
            this.transactionGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.transactionGridView1.Name = "transactionGridView1";
            this.transactionGridView1.SearchData = null;
            this.transactionGridView1.Size = new System.Drawing.Size(305, 585);
            this.transactionGridView1.TabIndex = 0;
            this.transactionGridView1.Load += new System.EventHandler(this.transactionGridView1_Load);
            // 
            // receiptGridView1
            // 
            this.receiptGridView1.AutoScroll = true;
            this.receiptGridView1.AutoSize = true;
            this.receiptGridView1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.receiptGridView1.CanFilter = false;
            this.receiptGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receiptGridView1.IsLinksVisible = true;
            this.receiptGridView1.Location = new System.Drawing.Point(0, 0);
            this.receiptGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.receiptGridView1.Name = "receiptGridView1";
            this.receiptGridView1.SearchData = null;
            this.receiptGridView1.Size = new System.Drawing.Size(601, 585);
            this.receiptGridView1.TabIndex = 1;
            // 
            // main_ToolStrip
            // 
            this.main_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.main_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator5,
            this.refresh_ToolStripButton,
            this.link_ToolStripButton,
            this.process_ToolStripButton,
            this.reload_ToolStripButton,
            this.toolStripSeparator6,
            this.options_ToolStripButton,
            this.toolStripLabel6,
            this.toolStripLabel5,
            this.toolStripSeparator11,
            this.filterClient_ToolStripButton,
            this.toolStripSeparator10,
            this.toolStripLabel2,
            this.filterRange_ToolStripComboBox,
            this.saveTransactions_ToolStripButton,
            this.saveReceipts_ToolStripButton1,
            this.saveAccount_ToolStripButton,
            this.save_ToolStripLabel,
            this.toolStripSeparator3,
            this.btnMMSReceipt,
            this.paste_ToolStripButton,
            this.addReceipt_ToolStripButton,
            this.toolStripSeparator4,
            this.toolStripLabel3,
            this.toolStripLabel8,
            this.toolStripLabel9,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.main_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.main_ToolStrip.Name = "main_ToolStrip";
            this.main_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.main_ToolStrip.Size = new System.Drawing.Size(1134, 25);
            this.main_ToolStrip.TabIndex = 1;
            this.main_ToolStrip.Text = "toolStrip1";
            this.main_ToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.main_ToolStrip_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Enabled = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(57, 22);
            this.toolStripLabel1.Text = "Accounts";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // refresh_ToolStripButton
            // 
            this.refresh_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refresh_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refresh_ToolStripButton.Image")));
            this.refresh_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refresh_ToolStripButton.Name = "refresh_ToolStripButton";
            this.refresh_ToolStripButton.Size = new System.Drawing.Size(50, 22);
            this.refresh_ToolStripButton.Text = "Refresh";
            this.refresh_ToolStripButton.Click += new System.EventHandler(this.LoadTransactions_Click);
            // 
            // link_ToolStripButton
            // 
            this.link_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.link_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("link_ToolStripButton.Image")));
            this.link_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.link_ToolStripButton.Name = "link_ToolStripButton";
            this.link_ToolStripButton.Size = new System.Drawing.Size(33, 22);
            this.link_ToolStripButton.Text = "Link";
            this.link_ToolStripButton.Click += new System.EventHandler(this.LinkReceipts_Button);
            // 
            // process_ToolStripButton
            // 
            this.process_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.process_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("process_ToolStripButton.Image")));
            this.process_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.process_ToolStripButton.Name = "process_ToolStripButton";
            this.process_ToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.process_ToolStripButton.Text = "Process";
            this.process_ToolStripButton.Click += new System.EventHandler(this.Process_Click);
            // 
            // reload_ToolStripButton
            // 
            this.reload_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.reload_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("reload_ToolStripButton.Image")));
            this.reload_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reload_ToolStripButton.Name = "reload_ToolStripButton";
            this.reload_ToolStripButton.Size = new System.Drawing.Size(88, 22);
            this.reload_ToolStripButton.Text = "Reload/Cancel";
            this.reload_ToolStripButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // options_ToolStripButton
            // 
            this.options_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.options_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("options_ToolStripButton.Image")));
            this.options_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.options_ToolStripButton.Name = "options_ToolStripButton";
            this.options_ToolStripButton.Size = new System.Drawing.Size(53, 22);
            this.options_ToolStripButton.Text = "Options";
            this.options_ToolStripButton.Click += new System.EventHandler(this.ProcessPrefrences_Click);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel6.Text = "              ";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Enabled = false;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel5.Text = "Filters";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // filterClient_ToolStripButton
            // 
            this.filterClient_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filterClient_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("filterClient_ToolStripButton.Image")));
            this.filterClient_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filterClient_ToolStripButton.Name = "filterClient_ToolStripButton";
            this.filterClient_ToolStripButton.Size = new System.Drawing.Size(89, 22);
            this.filterClient_ToolStripButton.Text = "Selected Client";
            this.filterClient_ToolStripButton.Click += new System.EventHandler(this.FilterClient_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Enabled = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel2.Text = "Range";
            // 
            // filterRange_ToolStripComboBox
            // 
            this.filterRange_ToolStripComboBox.Name = "filterRange_ToolStripComboBox";
            this.filterRange_ToolStripComboBox.Size = new System.Drawing.Size(110, 25);
            this.filterRange_ToolStripComboBox.ToolTipText = "Date Filter";
            this.filterRange_ToolStripComboBox.Click += new System.EventHandler(this.filterRange_ToolStripComboBox_Click);
            // 
            // saveTransactions_ToolStripButton
            // 
            this.saveTransactions_ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveTransactions_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveTransactions_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveTransactions_ToolStripButton.Image")));
            this.saveTransactions_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveTransactions_ToolStripButton.Name = "saveTransactions_ToolStripButton";
            this.saveTransactions_ToolStripButton.Size = new System.Drawing.Size(76, 22);
            this.saveTransactions_ToolStripButton.Text = "Transactions";
            this.saveTransactions_ToolStripButton.Click += new System.EventHandler(this.saveAll_Button_Click);
            // 
            // saveReceipts_ToolStripButton1
            // 
            this.saveReceipts_ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveReceipts_ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveReceipts_ToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("saveReceipts_ToolStripButton1.Image")));
            this.saveReceipts_ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveReceipts_ToolStripButton1.Name = "saveReceipts_ToolStripButton1";
            this.saveReceipts_ToolStripButton1.Size = new System.Drawing.Size(55, 22);
            this.saveReceipts_ToolStripButton1.Text = "Receipts";
            this.saveReceipts_ToolStripButton1.Click += new System.EventHandler(this.SaveReceipts_Click);
            // 
            // saveAccount_ToolStripButton
            // 
            this.saveAccount_ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveAccount_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveAccount_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAccount_ToolStripButton.Image")));
            this.saveAccount_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAccount_ToolStripButton.Name = "saveAccount_ToolStripButton";
            this.saveAccount_ToolStripButton.Size = new System.Drawing.Size(56, 22);
            this.saveAccount_ToolStripButton.Text = "Account";
            this.saveAccount_ToolStripButton.Click += new System.EventHandler(this.saveAccount_Button_Click);
            // 
            // save_ToolStripLabel
            // 
            this.save_ToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.save_ToolStripLabel.Enabled = false;
            this.save_ToolStripLabel.Name = "save_ToolStripLabel";
            this.save_ToolStripLabel.Size = new System.Drawing.Size(31, 22);
            this.save_ToolStripLabel.Text = "Save";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnMMSReceipt
            // 
            this.btnMMSReceipt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnMMSReceipt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMMSReceipt.Image = ((System.Drawing.Image)(resources.GetObject("btnMMSReceipt.Image")));
            this.btnMMSReceipt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMMSReceipt.Name = "btnMMSReceipt";
            this.btnMMSReceipt.Size = new System.Drawing.Size(81, 22);
            this.btnMMSReceipt.Text = "MMS Receipt";
            // 
            // paste_ToolStripButton
            // 
            this.paste_ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.paste_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.paste_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("paste_ToolStripButton.Image")));
            this.paste_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paste_ToolStripButton.Name = "paste_ToolStripButton";
            this.paste_ToolStripButton.Size = new System.Drawing.Size(39, 22);
            this.paste_ToolStripButton.Text = "Paste";
            this.paste_ToolStripButton.Click += new System.EventHandler(this.PasteReceipts_Click);
            // 
            // addReceipt_ToolStripButton
            // 
            this.addReceipt_ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.addReceipt_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addReceipt_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addReceipt_ToolStripButton.Image")));
            this.addReceipt_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addReceipt_ToolStripButton.Name = "addReceipt_ToolStripButton";
            this.addReceipt_ToolStripButton.Size = new System.Drawing.Size(33, 22);
            this.addReceipt_ToolStripButton.Text = "Add";
            this.addReceipt_ToolStripButton.Click += new System.EventHandler(this.addReceipt_Button_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Enabled = false;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel3.Text = "Recipts";
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(49, 15);
            this.toolStripLabel8.Text = "              ";
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.Enabled = false;
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(43, 15);
            this.toolStripLabel9.Text = "Layout";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(39, 19);
            this.toolStripButton1.Text = "Swap";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // suppliers_ToolStrip
            // 
            this.suppliers_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.suppliers_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripSeparator8,
            this.currentPayment_ToolStripButton,
            this.AllPayable_Button,
            this.selectedPayements_ToolStripButton,
            this.paymentsReport_ToolStripButton,
            this.customProfit_ToolStripButton,
            this.lastMonthProfilt_ToolStripButton,
            this.profit_ToolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel7});
            this.suppliers_ToolStrip.Location = new System.Drawing.Point(0, 25);
            this.suppliers_ToolStrip.Name = "suppliers_ToolStrip";
            this.suppliers_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.suppliers_ToolStrip.Size = new System.Drawing.Size(1134, 25);
            this.suppliers_ToolStrip.TabIndex = 2;
            this.suppliers_ToolStrip.Text = "toolStrip2";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Enabled = false;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel4.Text = "Supplier Payment";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // currentPayment_ToolStripButton
            // 
            this.currentPayment_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.currentPayment_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("currentPayment_ToolStripButton.Image")));
            this.currentPayment_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.currentPayment_ToolStripButton.Name = "currentPayment_ToolStripButton";
            this.currentPayment_ToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.currentPayment_ToolStripButton.Text = "Current";
            this.currentPayment_ToolStripButton.Click += new System.EventHandler(this.currentPayment_ToolStripButton_Click);
            // 
            // AllPayable_Button
            // 
            this.AllPayable_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AllPayable_Button.Image = ((System.Drawing.Image)(resources.GetObject("AllPayable_Button.Image")));
            this.AllPayable_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AllPayable_Button.Name = "AllPayable_Button";
            this.AllPayable_Button.Size = new System.Drawing.Size(69, 22);
            this.AllPayable_Button.Text = "All Payable";
            this.AllPayable_Button.Click += new System.EventHandler(this.AllPayable_Button_Click);
            // 
            // selectedPayements_ToolStripButton
            // 
            this.selectedPayements_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectedPayements_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("selectedPayements_ToolStripButton.Image")));
            this.selectedPayements_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectedPayements_ToolStripButton.Name = "selectedPayements_ToolStripButton";
            this.selectedPayements_ToolStripButton.Size = new System.Drawing.Size(55, 22);
            this.selectedPayements_ToolStripButton.Text = "Selected";
            this.selectedPayements_ToolStripButton.Click += new System.EventHandler(this.selectedPayements_ToolStripButton_Click);
            // 
            // paymentsReport_ToolStripButton
            // 
            this.paymentsReport_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.paymentsReport_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("paymentsReport_ToolStripButton.Image")));
            this.paymentsReport_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paymentsReport_ToolStripButton.Name = "paymentsReport_ToolStripButton";
            this.paymentsReport_ToolStripButton.Size = new System.Drawing.Size(46, 22);
            this.paymentsReport_ToolStripButton.Text = "Report";
            this.paymentsReport_ToolStripButton.Click += new System.EventHandler(this.paymentsReport_ToolStripButton_Click);
            // 
            // customProfit_ToolStripButton
            // 
            this.customProfit_ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.customProfit_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.customProfit_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("customProfit_ToolStripButton.Image")));
            this.customProfit_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.customProfit_ToolStripButton.Name = "customProfit_ToolStripButton";
            this.customProfit_ToolStripButton.Size = new System.Drawing.Size(112, 22);
            this.customProfit_ToolStripButton.Text = "Custom Date Profit";
            this.customProfit_ToolStripButton.Click += new System.EventHandler(this.customProfit_ToolStripButton_Click);
            // 
            // lastMonthProfilt_ToolStripButton
            // 
            this.lastMonthProfilt_ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lastMonthProfilt_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lastMonthProfilt_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("lastMonthProfilt_ToolStripButton.Image")));
            this.lastMonthProfilt_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lastMonthProfilt_ToolStripButton.Name = "lastMonthProfilt_ToolStripButton";
            this.lastMonthProfilt_ToolStripButton.Size = new System.Drawing.Size(103, 22);
            this.lastMonthProfilt_ToolStripButton.Text = "Last Month Profit";
            this.lastMonthProfilt_ToolStripButton.Click += new System.EventHandler(this.lastMonthProfilt_ToolStripButton_Click);
            // 
            // profit_ToolStripButton
            // 
            this.profit_ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.profit_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.profit_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("profit_ToolStripButton.Image")));
            this.profit_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.profit_ToolStripButton.Name = "profit_ToolStripButton";
            this.profit_ToolStripButton.Size = new System.Drawing.Size(83, 22);
            this.profit_ToolStripButton.Text = "Current Profit";
            this.profit_ToolStripButton.Click += new System.EventHandler(this.profit_ToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel7.Enabled = false;
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel7.Text = "Admin";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.ToDoListLabel);
            this.panel1.Controls.Add(this.link_Label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(222, 50);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 17);
            this.panel1.TabIndex = 1;
            // 
            // ToDoListLabel
            // 
            this.ToDoListLabel.AutoSize = true;
            this.ToDoListLabel.Location = new System.Drawing.Point(4, 4);
            this.ToDoListLabel.Name = "ToDoListLabel";
            this.ToDoListLabel.Size = new System.Drawing.Size(68, 13);
            this.ToDoListLabel.TabIndex = 0;
            this.ToDoListLabel.Text = "TODO Panel";
            // 
            // link_Label
            // 
            this.link_Label.AutoSize = true;
            this.link_Label.Location = new System.Drawing.Point(422, 2);
            this.link_Label.Name = "link_Label";
            this.link_Label.Size = new System.Drawing.Size(57, 13);
            this.link_Label.TabIndex = 1;
            this.link_Label.Text = "Link Panel";
            // 
            // clientSelect1
            // 
            this.clientSelect1.AutoSize = true;
            this.clientSelect1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clientSelect1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientSelect1.Dock = System.Windows.Forms.DockStyle.Left;
            this.clientSelect1.Location = new System.Drawing.Point(0, 50);
            this.clientSelect1.Margin = new System.Windows.Forms.Padding(0);
            this.clientSelect1.Name = "clientSelect1";
            this.clientSelect1.Size = new System.Drawing.Size(222, 602);
            this.clientSelect1.TabIndex = 4;
            // 
            // AccountsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 652);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clientSelect1);
            this.Controls.Add(this.suppliers_ToolStrip);
            this.Controls.Add(this.main_ToolStrip);
            this.Name = "AccountsManagerForm";
            this.Text = "Accounting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AccountingManager_Load);
            this.Enter += new System.EventHandler(this.AccountingManager_Enter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.main_ToolStrip.ResumeLayout(false);
            this.main_ToolStrip.PerformLayout();
            this.suppliers_ToolStrip.ResumeLayout(false);
            this.suppliers_ToolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Transactions.UserControls.TransactionGridView transactionGridView1;
        private UserControls.ReceiptGridView receiptGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private UserInterface.People.UserControls.ClientSelect clientSelect1;
        private System.Windows.Forms.ToolStrip main_ToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton refresh_ToolStripButton;
        private System.Windows.Forms.ToolStripButton link_ToolStripButton;
        private System.Windows.Forms.ToolStripButton process_ToolStripButton;
        private System.Windows.Forms.ToolStripButton reload_ToolStripButton;
        private System.Windows.Forms.ToolStripButton options_ToolStripButton;
        private System.Windows.Forms.ToolStripButton filterClient_ToolStripButton;
        private System.Windows.Forms.ToolStripButton saveTransactions_ToolStripButton;
        private System.Windows.Forms.ToolStripButton saveReceipts_ToolStripButton1;
        private System.Windows.Forms.ToolStripButton saveAccount_ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton addReceipt_ToolStripButton;
        private System.Windows.Forms.ToolStripButton paste_ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel save_ToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStrip suppliers_ToolStrip;
        private System.Windows.Forms.ToolStripButton paymentsReport_ToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton currentPayment_ToolStripButton;
        private System.Windows.Forms.ToolStripButton selectedPayements_ToolStripButton;
        private System.Windows.Forms.ToolStripComboBox filterRange_ToolStripComboBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton profit_ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripButton lastMonthProfilt_ToolStripButton;
        private System.Windows.Forms.ToolStripButton customProfit_ToolStripButton;
        private System.Windows.Forms.ToolStripButton AllPayable_Button;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ToDoListLabel;
        private System.Windows.Forms.ToolStripButton btnMMSReceipt;
        private System.Windows.Forms.Label link_Label;
    }
}