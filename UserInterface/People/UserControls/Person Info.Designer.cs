namespace UserInterface.People.UserControls
{
    partial class Person_Info
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
            this.email_LinkLabel = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.person_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainContact_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMainContact_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAccount_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAccountant_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPurchaseOrderContact_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePurchaseOrderContact_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.remove_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delete_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.name_Label = new System.Windows.Forms.Label();
            this.contactNumber_Label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // email_LinkLabel
            // 
            this.email_LinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.email_LinkLabel.ContextMenuStrip = this.contextMenuStrip1;
            this.email_LinkLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "Email", true));
            this.email_LinkLabel.Location = new System.Drawing.Point(353, 4);
            this.email_LinkLabel.Margin = new System.Windows.Forms.Padding(4);
            this.email_LinkLabel.Name = "email_LinkLabel";
            this.email_LinkLabel.Size = new System.Drawing.Size(336, 16);
            this.email_LinkLabel.TabIndex = 1;
            this.email_LinkLabel.TabStop = true;
            this.email_LinkLabel.Text = "email";
            this.email_LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Email_LinkClicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.person_ToolStripMenuItem,
            this.edit_ToolStripMenuItem,
            this.toolStripSeparator2,
            this.mainContact_ToolStripMenuItem,
            this.removeMainContact_toolStripMenuItem,
            this.setAccount_ToolStripMenuItem,
            this.removeAccountant_ToolStripMenuItem,
            this.setPurchaseOrderContact_ToolStripMenuItem,
            this.removePurchaseOrderContact_ToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 214);
            this.contextMenuStrip1.Text = "Edit";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // person_ToolStripMenuItem
            // 
            this.person_ToolStripMenuItem.Name = "person_ToolStripMenuItem";
            this.person_ToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.person_ToolStripMenuItem.Text = "Person";
            // 
            // edit_ToolStripMenuItem
            // 
            this.edit_ToolStripMenuItem.Name = "edit_ToolStripMenuItem";
            this.edit_ToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.edit_ToolStripMenuItem.Text = "Edit";
            this.edit_ToolStripMenuItem.Click += new System.EventHandler(this.EditPerson_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // mainContact_ToolStripMenuItem
            // 
            this.mainContact_ToolStripMenuItem.Name = "mainContact_ToolStripMenuItem";
            this.mainContact_ToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.mainContact_ToolStripMenuItem.Text = "Main Contact";
            this.mainContact_ToolStripMenuItem.Click += new System.EventHandler(this.SetMainContact_Click);
            // 
            // removeMainContact_toolStripMenuItem
            // 
            this.removeMainContact_toolStripMenuItem.Name = "removeMainContact_toolStripMenuItem";
            this.removeMainContact_toolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.removeMainContact_toolStripMenuItem.Text = "Remove Main Contact";
            this.removeMainContact_toolStripMenuItem.Click += new System.EventHandler(this.RemoveMainPerson_Click);
            // 
            // setAccount_ToolStripMenuItem
            // 
            this.setAccount_ToolStripMenuItem.Name = "setAccount_ToolStripMenuItem";
            this.setAccount_ToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.setAccount_ToolStripMenuItem.Text = "Accountant";
            this.setAccount_ToolStripMenuItem.Click += new System.EventHandler(this.SetAccountant_Click);
            // 
            // removeAccountant_ToolStripMenuItem
            // 
            this.removeAccountant_ToolStripMenuItem.Name = "removeAccountant_ToolStripMenuItem";
            this.removeAccountant_ToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.removeAccountant_ToolStripMenuItem.Text = "Remove Accountant";
            this.removeAccountant_ToolStripMenuItem.Click += new System.EventHandler(this.RemoveAccountatnt_click);
            // 
            // setPurchaseOrderContact_ToolStripMenuItem
            // 
            this.setPurchaseOrderContact_ToolStripMenuItem.Name = "setPurchaseOrderContact_ToolStripMenuItem";
            this.setPurchaseOrderContact_ToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.setPurchaseOrderContact_ToolStripMenuItem.Text = "PO Contact";
            this.setPurchaseOrderContact_ToolStripMenuItem.Click += new System.EventHandler(this.SetPurchaseOrderContact_Click);
            // 
            // removePurchaseOrderContact_ToolStripMenuItem
            // 
            this.removePurchaseOrderContact_ToolStripMenuItem.Name = "removePurchaseOrderContact_ToolStripMenuItem";
            this.removePurchaseOrderContact_ToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.removePurchaseOrderContact_ToolStripMenuItem.Text = "Remove PO Contact";
            this.removePurchaseOrderContact_ToolStripMenuItem.Click += new System.EventHandler(this.RemovePOContact_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remove_ToolStripMenuItem,
            this.delete_ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem1.Text = "Delete";
            // 
            // remove_ToolStripMenuItem
            // 
            this.remove_ToolStripMenuItem.Name = "remove_ToolStripMenuItem";
            this.remove_ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.remove_ToolStripMenuItem.Text = "Remove from list";
            this.remove_ToolStripMenuItem.Click += new System.EventHandler(this.RemoveFromList_Click);
            // 
            // delete_ToolStripMenuItem
            // 
            this.delete_ToolStripMenuItem.Name = "delete_ToolStripMenuItem";
            this.delete_ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.delete_ToolStripMenuItem.Text = "Delete from database";
            this.delete_ToolStripMenuItem.Click += new System.EventHandler(this.DeleteFromDB_Click);
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(Data.People.Person);
            // 
            // name_Label
            // 
            this.name_Label.AutoSize = true;
            this.name_Label.ContextMenuStrip = this.contextMenuStrip1;
            this.name_Label.Location = new System.Drawing.Point(4, 5);
            this.name_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name_Label.Name = "name_Label";
            this.name_Label.Size = new System.Drawing.Size(181, 16);
            this.name_Label.TabIndex = 3;
            this.name_Label.Text = "Proff. Eugene Albertus Ahlers";
            // 
            // contactNumber_Label1
            // 
            this.contactNumber_Label1.AutoSize = true;
            this.contactNumber_Label1.ContextMenuStrip = this.contextMenuStrip1;
            this.contactNumber_Label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "ContactNumber", true));
            this.contactNumber_Label1.Location = new System.Drawing.Point(209, 5);
            this.contactNumber_Label1.Margin = new System.Windows.Forms.Padding(1);
            this.contactNumber_Label1.Name = "contactNumber_Label1";
            this.contactNumber_Label1.Size = new System.Drawing.Size(108, 16);
            this.contactNumber_Label1.TabIndex = 1;
            this.contactNumber_Label1.Text = "0027 82 353 6346";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.ContextMenuStrip = this.contextMenuStrip1;
            this.panel2.Location = new System.Drawing.Point(203, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 23);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.ContextMenuStrip = this.contextMenuStrip1;
            this.panel3.Location = new System.Drawing.Point(344, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4, 23);
            this.panel3.TabIndex = 9;
            // 
            // Person_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.email_LinkLabel);
            this.Controls.Add(this.contactNumber_Label1);
            this.Controls.Add(this.name_Label);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Person_Info";
            this.Size = new System.Drawing.Size(693, 26);
            this.Load += new System.EventHandler(this.Person_Info_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.LinkLabel email_LinkLabel;
        private System.Windows.Forms.Label name_Label;
        private System.Windows.Forms.Label contactNumber_Label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem edit_ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainContact_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem remove_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delete_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem person_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMainContact_toolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem setAccount_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAccountant_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem setPurchaseOrderContact_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePurchaseOrderContact_ToolStripMenuItem;
    }
}
