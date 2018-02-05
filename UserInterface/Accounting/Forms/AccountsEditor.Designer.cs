namespace UserInterface.Accounting.Forms
{
    partial class AccountsEditor
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
            this.close_Button = new System.Windows.Forms.Button();
            this.save_Button = new System.Windows.Forms.Button();
            this.reload_Button = new System.Windows.Forms.Button();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.receiptGridView1 = new UserInterface.Accounting.UserControls.ReceiptGridView();
            this.transactionGridView1 = new UserInterface.Transactions.UserControls.TransactionGridView();
            this.SuspendLayout();
            // 
            // close_Button
            // 
            this.close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Button.Location = new System.Drawing.Point(759, 517);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(75, 23);
            this.close_Button.TabIndex = 2;
            this.close_Button.Text = "Close";
            this.close_Button.UseVisualStyleBackColor = true;
            this.close_Button.Click += new System.EventHandler(this.close_Button_Click);
            // 
            // save_Button
            // 
            this.save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_Button.Enabled = false;
            this.save_Button.Location = new System.Drawing.Point(678, 517);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 3;
            this.save_Button.Text = "Save";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // reload_Button
            // 
            this.reload_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reload_Button.Enabled = false;
            this.reload_Button.Location = new System.Drawing.Point(597, 517);
            this.reload_Button.Name = "reload_Button";
            this.reload_Button.Size = new System.Drawing.Size(75, 23);
            this.reload_Button.TabIndex = 4;
            this.reload_Button.Text = "Reload";
            this.reload_Button.UseVisualStyleBackColor = true;
            this.reload_Button.Click += new System.EventHandler(this.reload_Button_Click);
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 492);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(846, 60);
            this.footer1.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(846, 30);
            this.header1.TabIndex = 0;
            // 
            // receiptGridView1
            // 
            this.receiptGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receiptGridView1.IsLinksVisible = true;
            this.receiptGridView1.Location = new System.Drawing.Point(0, 274);
            this.receiptGridView1.Name = "receiptGridView1";
            this.receiptGridView1.SearchData = null;
            this.receiptGridView1.Size = new System.Drawing.Size(846, 218);
            this.receiptGridView1.TabIndex = 6;
            // 
            // transactionGridView1
            // 
            this.transactionGridView1.AccountingOnly = true;
            this.transactionGridView1.CanFilter = false;
            this.transactionGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.transactionGridView1.IsLinksVisible = true;
            this.transactionGridView1.Location = new System.Drawing.Point(0, 30);
            this.transactionGridView1.Name = "transactionGridView1";
            this.transactionGridView1.SearchData = null;
            this.transactionGridView1.Size = new System.Drawing.Size(846, 244);
            this.transactionGridView1.TabIndex = 5;
            // 
            // AccountsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 552);
            this.Controls.Add(this.receiptGridView1);
            this.Controls.Add(this.transactionGridView1);
            this.Controls.Add(this.reload_Button);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountsEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounts Editor";
            this.Load += new System.EventHandler(this.AccountsEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button close_Button;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button reload_Button;
        private Transactions.UserControls.TransactionGridView transactionGridView1;
        private UserControls.ReceiptGridView receiptGridView1;
    }
}