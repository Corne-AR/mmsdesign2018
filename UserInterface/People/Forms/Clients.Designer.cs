namespace UserInterface.People.Forms
{
    partial class Clients
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.people_Info_List1 = new UserInterface.People.UserControls.People_Info_List();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clientMaintenanceValue_Label = new System.Windows.Forms.Label();
            this.transProd_SplitContainer = new System.Windows.Forms.SplitContainer();
            this.transactionList1 = new UserInterface.Transactions.UserControls.TransactionGridView();
            this.productListUC1 = new UserInterface.Products.UserControls.ProductListUC();
            this.clientInfo_Panel = new System.Windows.Forms.Panel();
            this.clientEditor = new UserInterface.People.UserControls.ClientEditor();
            this.courier_Button = new System.Windows.Forms.Button();
            this.product_Button = new System.Windows.Forms.Button();
            this.invoice_Button = new System.Windows.Forms.Button();
            this.quickQuote_Button = new System.Windows.Forms.Button();
            this.quote_Button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.proforma_Button = new System.Windows.Forms.Button();
            this.toobar_Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.purchaseOrder_Button = new System.Windows.Forms.Button();
            this.clientSelect = new UserInterface.People.UserControls.ClientSelect();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transProd_SplitContainer)).BeginInit();
            this.transProd_SplitContainer.Panel1.SuspendLayout();
            this.transProd_SplitContainer.Panel2.SuspendLayout();
            this.transProd_SplitContainer.SuspendLayout();
            this.clientInfo_Panel.SuspendLayout();
            this.toobar_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 359);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.people_Info_List1);
            this.splitContainer1.Panel1MinSize = 58;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(553, 230);
            this.splitContainer1.SplitterDistance = 58;
            this.splitContainer1.SplitterIncrement = 23;
            this.splitContainer1.SplitterWidth = 9;
            this.splitContainer1.TabIndex = 2;
            // 
            // people_Info_List1
            // 
            this.people_Info_List1.AutoSize = true;
            this.people_Info_List1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.people_Info_List1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.people_Info_List1.Location = new System.Drawing.Point(0, 0);
            this.people_Info_List1.Margin = new System.Windows.Forms.Padding(4);
            this.people_Info_List1.Name = "people_Info_List1";
            this.people_Info_List1.Size = new System.Drawing.Size(553, 58);
            this.people_Info_List1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.clientMaintenanceValue_Label);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(553, 163);
            this.panel3.TabIndex = 1;
            // 
            // clientMaintenanceValue_Label
            // 
            this.clientMaintenanceValue_Label.AutoSize = true;
            this.clientMaintenanceValue_Label.Location = new System.Drawing.Point(6, 8);
            this.clientMaintenanceValue_Label.Margin = new System.Windows.Forms.Padding(3);
            this.clientMaintenanceValue_Label.Name = "clientMaintenanceValue_Label";
            this.clientMaintenanceValue_Label.Size = new System.Drawing.Size(35, 13);
            this.clientMaintenanceValue_Label.TabIndex = 0;
            this.clientMaintenanceValue_Label.Text = "label1";
            // 
            // transProd_SplitContainer
            // 
            this.transProd_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transProd_SplitContainer.Location = new System.Drawing.Point(787, 27);
            this.transProd_SplitContainer.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.transProd_SplitContainer.Name = "transProd_SplitContainer";
            this.transProd_SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // transProd_SplitContainer.Panel1
            // 
            this.transProd_SplitContainer.Panel1.AutoScroll = true;
            this.transProd_SplitContainer.Panel1.Controls.Add(this.transactionList1);
            this.transProd_SplitContainer.Panel1MinSize = 40;
            // 
            // transProd_SplitContainer.Panel2
            // 
            this.transProd_SplitContainer.Panel2.Controls.Add(this.productListUC1);
            this.transProd_SplitContainer.Size = new System.Drawing.Size(567, 589);
            this.transProd_SplitContainer.SplitterDistance = 149;
            this.transProd_SplitContainer.SplitterWidth = 9;
            this.transProd_SplitContainer.TabIndex = 4;
            // 
            // transactionList1
            // 
            this.transactionList1.AccountingOnly = false;
            this.transactionList1.CanFilter = true;
            this.transactionList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionList1.IsLinksVisible = true;
            this.transactionList1.Location = new System.Drawing.Point(0, 0);
            this.transactionList1.Margin = new System.Windows.Forms.Padding(4);
            this.transactionList1.Name = "transactionList1";
            this.transactionList1.SearchData = null;
            this.transactionList1.Size = new System.Drawing.Size(567, 149);
            this.transactionList1.TabIndex = 0;
            // 
            // productListUC1
            // 
            this.productListUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productListUC1.Location = new System.Drawing.Point(0, 0);
            this.productListUC1.Margin = new System.Windows.Forms.Padding(0);
            this.productListUC1.Name = "productListUC1";
            this.productListUC1.Size = new System.Drawing.Size(567, 431);
            this.productListUC1.TabIndex = 0;
            // 
            // clientInfo_Panel
            // 
            this.clientInfo_Panel.Controls.Add(this.splitContainer1);
            this.clientInfo_Panel.Controls.Add(this.clientEditor);
            this.clientInfo_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.clientInfo_Panel.Location = new System.Drawing.Point(228, 27);
            this.clientInfo_Panel.Name = "clientInfo_Panel";
            this.clientInfo_Panel.Size = new System.Drawing.Size(553, 589);
            this.clientInfo_Panel.TabIndex = 5;
            // 
            // clientEditor
            // 
            this.clientEditor.AutoScroll = true;
            this.clientEditor.AutoSize = true;
            this.clientEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clientEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.clientEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.clientEditor.Location = new System.Drawing.Point(0, 0);
            this.clientEditor.Margin = new System.Windows.Forms.Padding(6);
            this.clientEditor.Name = "clientEditor";
            this.clientEditor.Size = new System.Drawing.Size(553, 359);
            this.clientEditor.TabIndex = 0;
            this.clientEditor.Load += new System.EventHandler(this.clientEditor_Load);
            // 
            // courier_Button
            // 
            this.courier_Button.Location = new System.Drawing.Point(470, 3);
            this.courier_Button.Name = "courier_Button";
            this.courier_Button.Size = new System.Drawing.Size(75, 21);
            this.courier_Button.TabIndex = 11;
            this.courier_Button.Text = "Courier";
            this.courier_Button.UseVisualStyleBackColor = true;
            this.courier_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // product_Button
            // 
            this.product_Button.Location = new System.Drawing.Point(389, 3);
            this.product_Button.Name = "product_Button";
            this.product_Button.Size = new System.Drawing.Size(75, 21);
            this.product_Button.TabIndex = 10;
            this.product_Button.Text = "Product";
            this.product_Button.UseVisualStyleBackColor = true;
            this.product_Button.Click += new System.EventHandler(this.product_Button_Click);
            // 
            // invoice_Button
            // 
            this.invoice_Button.Location = new System.Drawing.Point(227, 3);
            this.invoice_Button.Name = "invoice_Button";
            this.invoice_Button.Size = new System.Drawing.Size(75, 21);
            this.invoice_Button.TabIndex = 7;
            this.invoice_Button.Text = "Invoice";
            this.invoice_Button.UseVisualStyleBackColor = true;
            this.invoice_Button.Click += new System.EventHandler(this.invoice_Button_Click);
            // 
            // quickQuote_Button
            // 
            this.quickQuote_Button.Location = new System.Drawing.Point(3, 3);
            this.quickQuote_Button.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.quickQuote_Button.Name = "quickQuote_Button";
            this.quickQuote_Button.Size = new System.Drawing.Size(22, 21);
            this.quickQuote_Button.TabIndex = 6;
            this.quickQuote_Button.Text = "Q";
            this.quickQuote_Button.UseVisualStyleBackColor = true;
            this.quickQuote_Button.Click += new System.EventHandler(this.quickQuote_Button_Click);
            // 
            // quote_Button
            // 
            this.quote_Button.Location = new System.Drawing.Point(25, 3);
            this.quote_Button.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.quote_Button.Name = "quote_Button";
            this.quote_Button.Size = new System.Drawing.Size(75, 21);
            this.quote_Button.TabIndex = 4;
            this.quote_Button.Text = "Quote";
            this.quote_Button.UseVisualStyleBackColor = true;
            this.quote_Button.Click += new System.EventHandler(this.quote_Button_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(781, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6, 589);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(222, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 589);
            this.panel2.TabIndex = 2;
            // 
            // proforma_Button
            // 
            this.proforma_Button.Location = new System.Drawing.Point(308, 3);
            this.proforma_Button.Name = "proforma_Button";
            this.proforma_Button.Size = new System.Drawing.Size(75, 21);
            this.proforma_Button.TabIndex = 12;
            this.proforma_Button.Text = "Pro-Forma";
            this.proforma_Button.UseVisualStyleBackColor = true;
            this.proforma_Button.Click += new System.EventHandler(this.proforma_Button_Click);
            // 
            // toobar_Panel
            // 
            this.toobar_Panel.AutoSize = true;
            this.toobar_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toobar_Panel.Controls.Add(this.quickQuote_Button);
            this.toobar_Panel.Controls.Add(this.quote_Button);
            this.toobar_Panel.Controls.Add(this.button1);
            this.toobar_Panel.Controls.Add(this.invoice_Button);
            this.toobar_Panel.Controls.Add(this.proforma_Button);
            this.toobar_Panel.Controls.Add(this.product_Button);
            this.toobar_Panel.Controls.Add(this.courier_Button);
            this.toobar_Panel.Controls.Add(this.purchaseOrder_Button);
            this.toobar_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toobar_Panel.Location = new System.Drawing.Point(0, 0);
            this.toobar_Panel.Name = "toobar_Panel";
            this.toobar_Panel.Size = new System.Drawing.Size(1354, 27);
            this.toobar_Panel.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 21);
            this.button1.TabIndex = 14;
            this.button1.Text = "MMS Upgr Quote";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // purchaseOrder_Button
            // 
            this.purchaseOrder_Button.Location = new System.Drawing.Point(551, 3);
            this.purchaseOrder_Button.Name = "purchaseOrder_Button";
            this.purchaseOrder_Button.Size = new System.Drawing.Size(90, 21);
            this.purchaseOrder_Button.TabIndex = 13;
            this.purchaseOrder_Button.Text = "Purchase Order";
            this.purchaseOrder_Button.UseVisualStyleBackColor = true;
            this.purchaseOrder_Button.Click += new System.EventHandler(this.purchaseOrder_Button_Click);
            // 
            // clientSelect
            // 
            this.clientSelect.AutoSize = true;
            this.clientSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clientSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.clientSelect.Location = new System.Drawing.Point(0, 27);
            this.clientSelect.Margin = new System.Windows.Forms.Padding(0);
            this.clientSelect.Name = "clientSelect";
            this.clientSelect.Size = new System.Drawing.Size(222, 589);
            this.clientSelect.TabIndex = 3;
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 616);
            this.Controls.Add(this.transProd_SplitContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clientInfo_Panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.clientSelect);
            this.Controls.Add(this.toobar_Panel);
            this.Name = "Clients";
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.Clients_Load);
            this.Enter += new System.EventHandler(this.Clients_Enter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.transProd_SplitContainer.Panel1.ResumeLayout(false);
            this.transProd_SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transProd_SplitContainer)).EndInit();
            this.transProd_SplitContainer.ResumeLayout(false);
            this.clientInfo_Panel.ResumeLayout(false);
            this.clientInfo_Panel.PerformLayout();
            this.toobar_Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserInterface.People.UserControls.People_Info_List people_Info_List1;
        private UserInterface.Transactions.UserControls.TransactionGridView transactionList1;
        private UserInterface.People.UserControls.ClientEditor clientEditor;
        private System.Windows.Forms.SplitContainer transProd_SplitContainer;
        private UserInterface.Products.UserControls.ProductListUC productListUC1;
        private System.Windows.Forms.Panel clientInfo_Panel;
        private UserInterface.People.UserControls.ClientSelect clientSelect;
        private System.Windows.Forms.Button invoice_Button;
        private System.Windows.Forms.Button quickQuote_Button;
        private System.Windows.Forms.Button quote_Button;
        private System.Windows.Forms.Button product_Button;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label clientMaintenanceValue_Label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button courier_Button;
        private System.Windows.Forms.FlowLayoutPanel toobar_Panel;
        private System.Windows.Forms.Button proforma_Button;
        private System.Windows.Forms.Button purchaseOrder_Button;
        private System.Windows.Forms.Button button1;
    }
}