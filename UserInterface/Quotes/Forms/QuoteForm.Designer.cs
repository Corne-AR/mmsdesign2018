namespace UserInterface.Quotes.Forms
{
    partial class QuoteForm
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
            this.spacerTotals_Label = new System.Windows.Forms.Label();
            this.spacerTerms_Label = new System.Windows.Forms.Label();
            this.catalogList_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.catalogName1 = new UserInterface.Quotes.UserControls.CatalogName();
            this.catalogButtons_Panel = new System.Windows.Forms.Panel();
            this.cataButtons_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.proceed_Button = new System.Windows.Forms.Button();
            this.close_Button = new System.Windows.Forms.Button();
            this.updateQuote_Button = new System.Windows.Forms.Button();
            this.save_Button = new System.Windows.Forms.Button();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnReport = new System.Windows.Forms.Button();
            this.cataGroupButtons_Panel = new System.Windows.Forms.Panel();
            this.group_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cataSearch_Panel = new System.Windows.Forms.Panel();
            this.clearSearch_Label = new System.Windows.Forms.Label();
            this.cataSearch_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.calc_Timer = new System.Windows.Forms.Timer(this.components);
            this.spacerTotalsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.quoteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spacerTermsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.spacers_Label = new System.Windows.Forms.Label();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalog_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewQuotedForexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reload_Button = new System.Windows.Forms.Button();
            this.utiliteis_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.setToClient_Button = new System.Windows.Forms.Button();
            this.newQuote_Button = new System.Windows.Forms.Button();
            this.SelectAll_Button = new System.Windows.Forms.Button();
            this.btnCustomCOD = new System.Windows.Forms.Button();
            this.utilites_Button = new System.Windows.Forms.Button();
            this.status_Label = new System.Windows.Forms.Label();
            this.catalogUC = new UserInterface.Quotes.UserControls.CatalogUC();
            this.quote_Summary = new UserInterface.Quotes.UserControls.QuoteSummary();
            this.catalogList_FlowLayoutPanel.SuspendLayout();
            this.catalogButtons_Panel.SuspendLayout();
            this.cataGroupButtons_Panel.SuspendLayout();
            this.cataSearch_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spacerTotalsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spacerTermsNumericUpDown)).BeginInit();
            this.catalog_ContextMenuStrip.SuspendLayout();
            this.utiliteis_FlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // spacerTotals_Label
            // 
            this.spacerTotals_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spacerTotals_Label.AutoSize = true;
            this.spacerTotals_Label.Location = new System.Drawing.Point(214, 670);
            this.spacerTotals_Label.Name = "spacerTotals_Label";
            this.spacerTotals_Label.Size = new System.Drawing.Size(36, 13);
            this.spacerTotals_Label.TabIndex = 0;
            this.spacerTotals_Label.Text = "Totals";
            // 
            // spacerTerms_Label
            // 
            this.spacerTerms_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spacerTerms_Label.AutoSize = true;
            this.spacerTerms_Label.Location = new System.Drawing.Point(312, 670);
            this.spacerTerms_Label.Name = "spacerTerms_Label";
            this.spacerTerms_Label.Size = new System.Drawing.Size(36, 13);
            this.spacerTerms_Label.TabIndex = 2;
            this.spacerTerms_Label.Text = "Terms";
            // 
            // catalogList_FlowLayoutPanel
            // 
            this.catalogList_FlowLayoutPanel.AutoSize = true;
            this.catalogList_FlowLayoutPanel.Controls.Add(this.catalogName1);
            this.catalogList_FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.catalogList_FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.catalogList_FlowLayoutPanel.Location = new System.Drawing.Point(0, 86);
            this.catalogList_FlowLayoutPanel.Name = "catalogList_FlowLayoutPanel";
            this.catalogList_FlowLayoutPanel.Size = new System.Drawing.Size(294, 554);
            this.catalogList_FlowLayoutPanel.TabIndex = 0;
            // 
            // catalogName1
            // 
            this.catalogName1.AutoSize = true;
            this.catalogName1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.catalogName1.Location = new System.Drawing.Point(3, 3);
            this.catalogName1.Name = "catalogName1";
            this.catalogName1.Size = new System.Drawing.Size(288, 26);
            this.catalogName1.TabIndex = 0;
            // 
            // catalogButtons_Panel
            // 
            this.catalogButtons_Panel.Controls.Add(this.cataButtons_FlowLayoutPanel);
            this.catalogButtons_Panel.Controls.Add(this.label1);
            this.catalogButtons_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.catalogButtons_Panel.Location = new System.Drawing.Point(0, 58);
            this.catalogButtons_Panel.Name = "catalogButtons_Panel";
            this.catalogButtons_Panel.Size = new System.Drawing.Size(1300, 28);
            this.catalogButtons_Panel.TabIndex = 1;
            // 
            // cataButtons_FlowLayoutPanel
            // 
            this.cataButtons_FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cataButtons_FlowLayoutPanel.Location = new System.Drawing.Point(70, 0);
            this.cataButtons_FlowLayoutPanel.Name = "cataButtons_FlowLayoutPanel";
            this.cataButtons_FlowLayoutPanel.Size = new System.Drawing.Size(1230, 28);
            this.cataButtons_FlowLayoutPanel.TabIndex = 0;
            this.cataButtons_FlowLayoutPanel.WrapContents = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catalog";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // proceed_Button
            // 
            this.proceed_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.proceed_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.proceed_Button.Location = new System.Drawing.Point(777, 665);
            this.proceed_Button.Name = "proceed_Button";
            this.proceed_Button.Size = new System.Drawing.Size(75, 23);
            this.proceed_Button.TabIndex = 5;
            this.proceed_Button.Text = "Proceed";
            this.proceed_Button.UseVisualStyleBackColor = true;
            this.proceed_Button.Click += new System.EventHandler(this.Proceed_Click);
            // 
            // close_Button
            // 
            this.close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Button.Location = new System.Drawing.Point(1213, 665);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(75, 23);
            this.close_Button.TabIndex = 7;
            this.close_Button.Text = "Close";
            this.close_Button.UseVisualStyleBackColor = true;
            this.close_Button.Click += new System.EventHandler(this.Close_Click);
            // 
            // updateQuote_Button
            // 
            this.updateQuote_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateQuote_Button.Location = new System.Drawing.Point(1044, 665);
            this.updateQuote_Button.Name = "updateQuote_Button";
            this.updateQuote_Button.Size = new System.Drawing.Size(75, 23);
            this.updateQuote_Button.TabIndex = 12;
            this.updateQuote_Button.Text = "Update";
            this.updateQuote_Button.UseVisualStyleBackColor = true;
            this.updateQuote_Button.Click += new System.EventHandler(this.updateQuote_Button_Click);
            // 
            // save_Button
            // 
            this.save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_Button.Location = new System.Drawing.Point(1125, 665);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 13;
            this.save_Button.Text = "Save";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(1300, 30);
            this.header1.TabIndex = 3;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 640);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(1300, 60);
            this.footer1.TabIndex = 2;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.BackgroundImage = global::UserInterface.Properties.Resources.pdf;
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Location = new System.Drawing.Point(748, 665);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(26, 23);
            this.btnReport.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnReport, "Preview");
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.Report_Click);
            // 
            // cataGroupButtons_Panel
            // 
            this.cataGroupButtons_Panel.Controls.Add(this.group_FlowLayoutPanel);
            this.cataGroupButtons_Panel.Controls.Add(this.label2);
            this.cataGroupButtons_Panel.Controls.Add(this.cataSearch_Panel);
            this.cataGroupButtons_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cataGroupButtons_Panel.Location = new System.Drawing.Point(0, 30);
            this.cataGroupButtons_Panel.Name = "cataGroupButtons_Panel";
            this.cataGroupButtons_Panel.Size = new System.Drawing.Size(1300, 28);
            this.cataGroupButtons_Panel.TabIndex = 17;
            // 
            // group_FlowLayoutPanel
            // 
            this.group_FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_FlowLayoutPanel.Location = new System.Drawing.Point(70, 0);
            this.group_FlowLayoutPanel.Name = "group_FlowLayoutPanel";
            this.group_FlowLayoutPanel.Size = new System.Drawing.Size(1049, 28);
            this.group_FlowLayoutPanel.TabIndex = 0;
            this.group_FlowLayoutPanel.WrapContents = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Group";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cataSearch_Panel
            // 
            this.cataSearch_Panel.Controls.Add(this.clearSearch_Label);
            this.cataSearch_Panel.Controls.Add(this.cataSearch_TextBox);
            this.cataSearch_Panel.Controls.Add(this.label3);
            this.cataSearch_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.cataSearch_Panel.Location = new System.Drawing.Point(1119, 0);
            this.cataSearch_Panel.Name = "cataSearch_Panel";
            this.cataSearch_Panel.Size = new System.Drawing.Size(181, 28);
            this.cataSearch_Panel.TabIndex = 21;
            // 
            // clearSearch_Label
            // 
            this.clearSearch_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.clearSearch_Label.Location = new System.Drawing.Point(153, 0);
            this.clearSearch_Label.Name = "clearSearch_Label";
            this.clearSearch_Label.Size = new System.Drawing.Size(28, 28);
            this.clearSearch_Label.TabIndex = 3;
            this.clearSearch_Label.Text = "X";
            this.clearSearch_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.clearSearch_Label.Click += new System.EventHandler(this.cataSearchClear_Button_Click);
            // 
            // cataSearch_TextBox
            // 
            this.cataSearch_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cataSearch_TextBox.Location = new System.Drawing.Point(47, 5);
            this.cataSearch_TextBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cataSearch_TextBox.Name = "cataSearch_TextBox";
            this.cataSearch_TextBox.Size = new System.Drawing.Size(103, 20);
            this.cataSearch_TextBox.TabIndex = 0;
            this.cataSearch_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cataSearch_TextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Catalog";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // calc_Timer
            // 
            this.calc_Timer.Interval = 500;
            this.calc_Timer.Tick += new System.EventHandler(this.UpdateCatalog_Click);
            // 
            // spacerTotalsNumericUpDown
            // 
            this.spacerTotalsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spacerTotalsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.quoteBindingSource, "SpacerTotals", true));
            this.spacerTotalsNumericUpDown.Location = new System.Drawing.Point(256, 668);
            this.spacerTotalsNumericUpDown.Name = "spacerTotalsNumericUpDown";
            this.spacerTotalsNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.spacerTotalsNumericUpDown.TabIndex = 1;
            this.spacerTotalsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // quoteBindingSource
            // 
            this.quoteBindingSource.DataSource = typeof(Data.Quotes.Quote);
            // 
            // spacerTermsNumericUpDown
            // 
            this.spacerTermsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spacerTermsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.quoteBindingSource, "SpacerTerms", true));
            this.spacerTermsNumericUpDown.Location = new System.Drawing.Point(354, 668);
            this.spacerTermsNumericUpDown.Name = "spacerTermsNumericUpDown";
            this.spacerTermsNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.spacerTermsNumericUpDown.TabIndex = 3;
            this.spacerTermsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spacers_Label
            // 
            this.spacers_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spacers_Label.AutoSize = true;
            this.spacers_Label.Location = new System.Drawing.Point(148, 670);
            this.spacers_Label.Name = "spacers_Label";
            this.spacers_Label.Size = new System.Drawing.Size(46, 13);
            this.spacers_Label.TabIndex = 4;
            this.spacers_Label.Text = "Spacers";
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.MoveItemUp_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.MoveItemDown_Click);
            // 
            // catalog_ContextMenuStrip
            // 
            this.catalog_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.toolStripSeparator1,
            this.refreshListToolStripMenuItem,
            this.toolStripSeparator2,
            this.viewLogToolStripMenuItem,
            this.viewQuotedForexToolStripMenuItem});
            this.catalog_ContextMenuStrip.Name = "catalog_ContextMenuStrip";
            this.catalog_ContextMenuStrip.Size = new System.Drawing.Size(176, 126);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // refreshListToolStripMenuItem
            // 
            this.refreshListToolStripMenuItem.Name = "refreshListToolStripMenuItem";
            this.refreshListToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.refreshListToolStripMenuItem.Text = "Refresh List";
            this.refreshListToolStripMenuItem.Click += new System.EventHandler(this.refreshListToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(172, 6);
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.viewLogToolStripMenuItem.Text = "View Quoted Script";
            this.viewLogToolStripMenuItem.Click += new System.EventHandler(this.ViewQuotedRetailScript_Click);
            // 
            // viewQuotedForexToolStripMenuItem
            // 
            this.viewQuotedForexToolStripMenuItem.Name = "viewQuotedForexToolStripMenuItem";
            this.viewQuotedForexToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.viewQuotedForexToolStripMenuItem.Text = "View Quoted Forex";
            this.viewQuotedForexToolStripMenuItem.Click += new System.EventHandler(this.ViewQuotedForexScript_Click);
            // 
            // reload_Button
            // 
            this.reload_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reload_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reload_Button.Location = new System.Drawing.Point(0, 0);
            this.reload_Button.Margin = new System.Windows.Forms.Padding(0);
            this.reload_Button.Name = "reload_Button";
            this.reload_Button.Size = new System.Drawing.Size(184, 23);
            this.reload_Button.TabIndex = 18;
            this.reload_Button.Text = "Reload";
            this.reload_Button.UseVisualStyleBackColor = true;
            this.reload_Button.Click += new System.EventHandler(this.reload_Button_Click);
            // 
            // utiliteis_FlowLayoutPanel
            // 
            this.utiliteis_FlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.utiliteis_FlowLayoutPanel.AutoSize = true;
            this.utiliteis_FlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.utiliteis_FlowLayoutPanel.Controls.Add(this.reload_Button);
            this.utiliteis_FlowLayoutPanel.Controls.Add(this.setToClient_Button);
            this.utiliteis_FlowLayoutPanel.Controls.Add(this.newQuote_Button);
            this.utiliteis_FlowLayoutPanel.Controls.Add(this.SelectAll_Button);
            this.utiliteis_FlowLayoutPanel.Controls.Add(this.btnCustomCOD);
            this.utiliteis_FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.utiliteis_FlowLayoutPanel.Location = new System.Drawing.Point(600, 544);
            this.utiliteis_FlowLayoutPanel.Name = "utiliteis_FlowLayoutPanel";
            this.utiliteis_FlowLayoutPanel.Size = new System.Drawing.Size(184, 115);
            this.utiliteis_FlowLayoutPanel.TabIndex = 19;
            this.utiliteis_FlowLayoutPanel.Visible = false;
            // 
            // setToClient_Button
            // 
            this.setToClient_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.setToClient_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setToClient_Button.Location = new System.Drawing.Point(0, 23);
            this.setToClient_Button.Margin = new System.Windows.Forms.Padding(0);
            this.setToClient_Button.Name = "setToClient_Button";
            this.setToClient_Button.Size = new System.Drawing.Size(184, 23);
            this.setToClient_Button.TabIndex = 19;
            this.setToClient_Button.Text = "Set to Client";
            this.setToClient_Button.UseVisualStyleBackColor = true;
            this.setToClient_Button.Click += new System.EventHandler(this.setToClient_Button_Click);
            // 
            // newQuote_Button
            // 
            this.newQuote_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newQuote_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newQuote_Button.Location = new System.Drawing.Point(0, 46);
            this.newQuote_Button.Margin = new System.Windows.Forms.Padding(0);
            this.newQuote_Button.Name = "newQuote_Button";
            this.newQuote_Button.Size = new System.Drawing.Size(184, 23);
            this.newQuote_Button.TabIndex = 20;
            this.newQuote_Button.Text = "Duplicate Quote";
            this.newQuote_Button.UseVisualStyleBackColor = true;
            this.newQuote_Button.Click += new System.EventHandler(this.newQuote_Button_Click);
            // 
            // SelectAll_Button
            // 
            this.SelectAll_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectAll_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectAll_Button.Location = new System.Drawing.Point(0, 69);
            this.SelectAll_Button.Margin = new System.Windows.Forms.Padding(0);
            this.SelectAll_Button.Name = "SelectAll_Button";
            this.SelectAll_Button.Size = new System.Drawing.Size(184, 23);
            this.SelectAll_Button.TabIndex = 21;
            this.SelectAll_Button.Text = "Select All";
            this.SelectAll_Button.UseVisualStyleBackColor = true;
            this.SelectAll_Button.Click += new System.EventHandler(this.SelectAll_Button_Click);
            // 
            // btnCustomCOD
            // 
            this.btnCustomCOD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomCOD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomCOD.Location = new System.Drawing.Point(0, 92);
            this.btnCustomCOD.Margin = new System.Windows.Forms.Padding(0);
            this.btnCustomCOD.Name = "btnCustomCOD";
            this.btnCustomCOD.Size = new System.Drawing.Size(184, 23);
            this.btnCustomCOD.TabIndex = 22;
            this.btnCustomCOD.Text = "Custom COD";
            this.btnCustomCOD.UseVisualStyleBackColor = true;
            this.btnCustomCOD.Click += new System.EventHandler(this.btnCustomCOD_Click);
            // 
            // utilites_Button
            // 
            this.utilites_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.utilites_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.utilites_Button.Location = new System.Drawing.Point(600, 665);
            this.utilites_Button.Name = "utilites_Button";
            this.utilites_Button.Size = new System.Drawing.Size(75, 23);
            this.utilites_Button.TabIndex = 20;
            this.utilites_Button.Text = "Utilities";
            this.utilites_Button.UseVisualStyleBackColor = true;
            this.utilites_Button.Click += new System.EventHandler(this.utilites_Button_Click);
            // 
            // status_Label
            // 
            this.status_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.status_Label.AutoSize = true;
            this.status_Label.Location = new System.Drawing.Point(863, 664);
            this.status_Label.Name = "status_Label";
            this.status_Label.Size = new System.Drawing.Size(37, 26);
            this.status_Label.TabIndex = 21;
            this.status_Label.Text = "Status\r\nDate";
            // 
            // catalogUC
            // 
            this.catalogUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogUC.Location = new System.Drawing.Point(294, 86);
            this.catalogUC.Name = "catalogUC";
            this.catalogUC.Size = new System.Drawing.Size(702, 554);
            this.catalogUC.TabIndex = 16;
            // 
            // quote_Summary
            // 
            this.quote_Summary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.quote_Summary.Dock = System.Windows.Forms.DockStyle.Right;
            this.quote_Summary.Location = new System.Drawing.Point(996, 86);
            this.quote_Summary.Name = "quote_Summary";
            this.quote_Summary.Size = new System.Drawing.Size(304, 554);
            this.quote_Summary.TabIndex = 10;
            // 
            // QuoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.status_Label);
            this.Controls.Add(this.utiliteis_FlowLayoutPanel);
            this.Controls.Add(this.spacers_Label);
            this.Controls.Add(this.spacerTerms_Label);
            this.Controls.Add(this.catalogUC);
            this.Controls.Add(this.spacerTermsNumericUpDown);
            this.Controls.Add(this.spacerTotals_Label);
            this.Controls.Add(this.spacerTotalsNumericUpDown);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.updateQuote_Button);
            this.Controls.Add(this.utilites_Button);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.proceed_Button);
            this.Controls.Add(this.quote_Summary);
            this.Controls.Add(this.catalogList_FlowLayoutPanel);
            this.Controls.Add(this.catalogButtons_Panel);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.cataGroupButtons_Panel);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuoteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quotes";
            this.Load += new System.EventHandler(this.Quotes_Load);
            this.catalogList_FlowLayoutPanel.ResumeLayout(false);
            this.catalogList_FlowLayoutPanel.PerformLayout();
            this.catalogButtons_Panel.ResumeLayout(false);
            this.cataGroupButtons_Panel.ResumeLayout(false);
            this.cataSearch_Panel.ResumeLayout(false);
            this.cataSearch_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spacerTotalsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spacerTermsNumericUpDown)).EndInit();
            this.catalog_ContextMenuStrip.ResumeLayout(false);
            this.utiliteis_FlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel catalogList_FlowLayoutPanel;
        private System.Windows.Forms.Panel catalogButtons_Panel;
        private System.Windows.Forms.FlowLayoutPanel cataButtons_FlowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private AMS.UserInterface.UserControls.Header header1;
        private System.Windows.Forms.Button proceed_Button;
        private System.Windows.Forms.Button close_Button;
        private UserControls.QuoteSummary quote_Summary;
        private System.Windows.Forms.Button updateQuote_Button;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.ToolTip toolTip1;
        private UserControls.CatalogUC catalogUC;
        private UserControls.CatalogName catalogName1;
        private System.Windows.Forms.Panel cataGroupButtons_Panel;
        private System.Windows.Forms.FlowLayoutPanel group_FlowLayoutPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer calc_Timer;
        private System.Windows.Forms.BindingSource quoteBindingSource;
        private System.Windows.Forms.NumericUpDown spacerTotalsNumericUpDown;
        private System.Windows.Forms.NumericUpDown spacerTermsNumericUpDown;
        private System.Windows.Forms.Label spacerTotals_Label;
        private System.Windows.Forms.Label spacerTerms_Label;
        private System.Windows.Forms.Label spacers_Label;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip catalog_ContextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem refreshListToolStripMenuItem;
        private System.Windows.Forms.Button reload_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewQuotedForexToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel utiliteis_FlowLayoutPanel;
        private System.Windows.Forms.Button utilites_Button;
        private System.Windows.Forms.Button setToClient_Button;
        private System.Windows.Forms.Button newQuote_Button;
        private System.Windows.Forms.Panel cataSearch_Panel;
        private System.Windows.Forms.TextBox cataSearch_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label clearSearch_Label;
        private System.Windows.Forms.Label status_Label;
        private System.Windows.Forms.Button SelectAll_Button;
        private System.Windows.Forms.Button btnCustomCOD;
        private System.Windows.Forms.Button btnReport;
    }
}