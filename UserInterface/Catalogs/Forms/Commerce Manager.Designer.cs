namespace UserInterface.Catalogs.Forms
{
    partial class Commerce_Manager
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
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exchangeFactorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.facktorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.group_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.catalog_ComboBox = new System.Windows.Forms.ComboBox();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.save_Button = new System.Windows.Forms.Button();
            this.paste_Button = new System.Windows.Forms.Button();
            this.copy_Button = new System.Windows.Forms.Button();
            this.catalogUC = new UserInterface.Catalogs.UserControls.CatalogDataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxReport = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1186, 665);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Close_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.catalogToolStripMenuItem,
            this.exchangeFactorToolStripMenuItem,
            this.facktorsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 30);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1300, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGroupToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.toolStripSeparator3,
            this.closeToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catalogToolStripMenuItem1,
            this.groupToolStripMenuItem});
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.addGroupToolStripMenuItem.Text = "New";
            // 
            // catalogToolStripMenuItem1
            // 
            this.catalogToolStripMenuItem1.Name = "catalogToolStripMenuItem1";
            this.catalogToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.catalogToolStripMenuItem1.Text = "Catalog";
            this.catalogToolStripMenuItem1.Click += new System.EventHandler(this.AddCatalog_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.groupToolStripMenuItem.Text = "Group";
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.AddGroup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(100, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(100, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.Close_Click);
            // 
            // catalogToolStripMenuItem
            // 
            this.catalogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripSeparator5,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripSeparator4,
            this.removeSelectedToolStripMenuItem,
            this.renameSelectedToolStripMenuItem});
            this.catalogToolStripMenuItem.Name = "catalogToolStripMenuItem";
            this.catalogToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.catalogToolStripMenuItem.Text = "Edit";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem2.Text = "Refresh Data";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.LoadCatalogs_Event);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(158, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem3.Text = "Remove Group";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem4.Text = "Rename Group";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.RenameGroup_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(158, 6);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Catalog";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.RemoveCatalog_Click);
            // 
            // renameSelectedToolStripMenuItem
            // 
            this.renameSelectedToolStripMenuItem.Name = "renameSelectedToolStripMenuItem";
            this.renameSelectedToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.renameSelectedToolStripMenuItem.Text = "Rename Catalog";
            this.renameSelectedToolStripMenuItem.Click += new System.EventHandler(this.RenameCatalog_Click);
            // 
            // exchangeFactorToolStripMenuItem
            // 
            this.exchangeFactorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.toolStripSeparator1});
            this.exchangeFactorToolStripMenuItem.Name = "exchangeFactorToolStripMenuItem";
            this.exchangeFactorToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.exchangeFactorToolStripMenuItem.Text = "Scripts";
            this.exchangeFactorToolStripMenuItem.Click += new System.EventHandler(this.ScriptEditor_Event);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.addToolStripMenuItem1.Text = "Add Script";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.ScriptEditor_Event);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // facktorsToolStripMenuItem
            // 
            this.facktorsToolStripMenuItem.Name = "facktorsToolStripMenuItem";
            this.facktorsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.facktorsToolStripMenuItem.Text = "Factors";
            this.facktorsToolStripMenuItem.Click += new System.EventHandler(this.facktorsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 640);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(1300, 60);
            this.footer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboxReport);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.group_ComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.catalog_ComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(1300, 35);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Group";
            // 
            // group_ComboBox
            // 
            this.group_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.group_ComboBox.FormattingEnabled = true;
            this.group_ComboBox.Location = new System.Drawing.Point(53, 6);
            this.group_ComboBox.Name = "group_ComboBox";
            this.group_ComboBox.Size = new System.Drawing.Size(190, 21);
            this.group_ComboBox.TabIndex = 2;
            this.group_ComboBox.SelectedIndexChanged += new System.EventHandler(this.group_ComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(573, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Calalog";
            // 
            // catalog_ComboBox
            // 
            this.catalog_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.catalog_ComboBox.FormattingEnabled = true;
            this.catalog_ComboBox.Location = new System.Drawing.Point(654, 6);
            this.catalog_ComboBox.Name = "catalog_ComboBox";
            this.catalog_ComboBox.Size = new System.Drawing.Size(190, 21);
            this.catalog_ComboBox.TabIndex = 0;
            this.catalog_ComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectCatalog_Event);
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(1300, 30);
            this.header1.TabIndex = 12;
            // 
            // save_Button
            // 
            this.save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_Button.Location = new System.Drawing.Point(1105, 665);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 13;
            this.save_Button.Text = "Save";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // paste_Button
            // 
            this.paste_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paste_Button.Location = new System.Drawing.Point(916, 665);
            this.paste_Button.Name = "paste_Button";
            this.paste_Button.Size = new System.Drawing.Size(75, 23);
            this.paste_Button.TabIndex = 14;
            this.paste_Button.Text = "Paste";
            this.paste_Button.UseVisualStyleBackColor = true;
            this.paste_Button.Click += new System.EventHandler(this.paste_Button_Click);
            // 
            // copy_Button
            // 
            this.copy_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copy_Button.Location = new System.Drawing.Point(997, 665);
            this.copy_Button.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.copy_Button.Name = "copy_Button";
            this.copy_Button.Size = new System.Drawing.Size(75, 23);
            this.copy_Button.TabIndex = 15;
            this.copy_Button.Text = "Copy";
            this.copy_Button.UseVisualStyleBackColor = true;
            this.copy_Button.Click += new System.EventHandler(this.copy_Button_Click);
            // 
            // catalogUC
            // 
            this.catalogUC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.catalogUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogUC.Location = new System.Drawing.Point(0, 89);
            this.catalogUC.Name = "catalogUC";
            this.catalogUC.Size = new System.Drawing.Size(1300, 551);
            this.catalogUC.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Report";
            // 
            // cboxReport
            // 
            this.cboxReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxReport.FormattingEnabled = true;
            this.cboxReport.Location = new System.Drawing.Point(294, 6);
            this.cboxReport.Name = "cboxReport";
            this.cboxReport.Size = new System.Drawing.Size(190, 21);
            this.cboxReport.TabIndex = 4;
            // 
            // Commerce_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.copy_Button);
            this.Controls.Add(this.paste_Button);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.catalogUC);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Commerce_Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Commerce Manager";
            this.Load += new System.EventHandler(this.Commerce_Manager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem catalogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private UserControls.CatalogDataGrid catalogUC;
        private System.Windows.Forms.Panel panel1;
        private AMS.UserInterface.UserControls.Header header1;
        private System.Windows.Forms.ToolStripMenuItem exchangeFactorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox catalog_ComboBox;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button paste_Button;
        private System.Windows.Forms.Button copy_Button;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facktorsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox group_ComboBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxReport;
    }
}