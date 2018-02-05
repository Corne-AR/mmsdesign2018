namespace UserInterface.Quotes.Forms
{
    partial class QuoteConfirmation
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
            System.Windows.Forms.Label accountLabel;
            System.Windows.Forms.Label contactLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label internationalLabel;
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.save_Button = new System.Windows.Forms.Button();
            this.close_Button = new System.Windows.Forms.Button();
            this.reload_Button = new System.Windows.Forms.Button();
            this.accountTextBox = new System.Windows.Forms.TextBox();
            this.quoteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.internationalCheckBox = new System.Windows.Forms.CheckBox();
            this.quote_productListUC = new UserInterface.Products.UserControls.ProductListUC();
            this.validate_Button = new System.Windows.Forms.Button();
            accountLabel = new System.Windows.Forms.Label();
            contactLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            internationalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quoteBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountLabel
            // 
            accountLabel.AutoSize = true;
            accountLabel.Location = new System.Drawing.Point(20, 13);
            accountLabel.Name = "accountLabel";
            accountLabel.Size = new System.Drawing.Size(50, 13);
            accountLabel.TabIndex = 7;
            accountLabel.Text = "Account:";
            // 
            // contactLabel
            // 
            contactLabel.AutoSize = true;
            contactLabel.Location = new System.Drawing.Point(23, 39);
            contactLabel.Name = "contactLabel";
            contactLabel.Size = new System.Drawing.Size(47, 13);
            contactLabel.TabIndex = 8;
            contactLabel.Text = "Contact:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(35, 65);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 10;
            emailLabel.Text = "Email:";
            // 
            // internationalLabel
            // 
            internationalLabel.AutoSize = true;
            internationalLabel.Location = new System.Drawing.Point(45, 85);
            internationalLabel.Name = "internationalLabel";
            internationalLabel.Size = new System.Drawing.Size(68, 13);
            internationalLabel.TabIndex = 15;
            internationalLabel.Text = "International:";
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(900, 30);
            this.header1.TabIndex = 0;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 640);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(900, 60);
            this.footer1.TabIndex = 1;
            // 
            // save_Button
            // 
            this.save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_Button.Location = new System.Drawing.Point(737, 665);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 3;
            this.save_Button.Text = "Save";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // close_Button
            // 
            this.close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Button.Location = new System.Drawing.Point(818, 665);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(70, 23);
            this.close_Button.TabIndex = 4;
            this.close_Button.Text = "Cancel";
            this.close_Button.UseVisualStyleBackColor = true;
            this.close_Button.Click += new System.EventHandler(this.close_Button_Click);
            // 
            // reload_Button
            // 
            this.reload_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reload_Button.Location = new System.Drawing.Point(612, 665);
            this.reload_Button.Name = "reload_Button";
            this.reload_Button.Size = new System.Drawing.Size(75, 23);
            this.reload_Button.TabIndex = 5;
            this.reload_Button.Text = "Reload";
            this.reload_Button.UseVisualStyleBackColor = true;
            this.reload_Button.Click += new System.EventHandler(this.reload_Button_Click);
            // 
            // accountTextBox
            // 
            this.accountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quoteBindingSource, "Account", true));
            this.accountTextBox.Location = new System.Drawing.Point(76, 10);
            this.accountTextBox.Name = "accountTextBox";
            this.accountTextBox.Size = new System.Drawing.Size(100, 20);
            this.accountTextBox.TabIndex = 8;
            // 
            // quoteBindingSource
            // 
            this.quoteBindingSource.DataSource = typeof(Data.Quotes.Quote);
            // 
            // contactTextBox
            // 
            this.contactTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quoteBindingSource, "Contact", true));
            this.contactTextBox.Location = new System.Drawing.Point(76, 36);
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(100, 20);
            this.contactTextBox.TabIndex = 9;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quoteBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(76, 62);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(100, 20);
            this.emailTextBox.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(internationalLabel);
            this.panel1.Controls.Add(this.internationalCheckBox);
            this.panel1.Controls.Add(accountLabel);
            this.panel1.Controls.Add(emailLabel);
            this.panel1.Controls.Add(this.accountTextBox);
            this.panel1.Controls.Add(this.emailTextBox);
            this.panel1.Controls.Add(this.contactTextBox);
            this.panel1.Controls.Add(contactLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 610);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 270);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // internationalCheckBox
            // 
            this.internationalCheckBox.AutoSize = true;
            this.internationalCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quoteBindingSource, "International", true));
            this.internationalCheckBox.Location = new System.Drawing.Point(119, 85);
            this.internationalCheckBox.Name = "internationalCheckBox";
            this.internationalCheckBox.Size = new System.Drawing.Size(15, 14);
            this.internationalCheckBox.TabIndex = 16;
            this.internationalCheckBox.UseVisualStyleBackColor = true;
            // 
            // quote_productListUC
            // 
            this.quote_productListUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quote_productListUC.Location = new System.Drawing.Point(179, 30);
            this.quote_productListUC.Margin = new System.Windows.Forms.Padding(0);
            this.quote_productListUC.Name = "quote_productListUC";
            this.quote_productListUC.Size = new System.Drawing.Size(721, 610);
            this.quote_productListUC.TabIndex = 2;
            // 
            // validate_Button
            // 
            this.validate_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.validate_Button.Location = new System.Drawing.Point(531, 665);
            this.validate_Button.Name = "validate_Button";
            this.validate_Button.Size = new System.Drawing.Size(75, 23);
            this.validate_Button.TabIndex = 13;
            this.validate_Button.Text = "Validate";
            this.validate_Button.UseVisualStyleBackColor = true;
            this.validate_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuoteConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.validate_Button);
            this.Controls.Add(this.quote_productListUC);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reload_Button);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuoteConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductManager";
            this.Load += new System.EventHandler(this.ProductManager_Load);
            this.Shown += new System.EventHandler(this.QuoteConfirmation_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.quoteBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private UserInterface.Products.UserControls.ProductListUC quote_productListUC;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button close_Button;
        private System.Windows.Forms.Button reload_Button;
        private System.Windows.Forms.BindingSource quoteBindingSource;
        private System.Windows.Forms.TextBox accountTextBox;
        private System.Windows.Forms.TextBox contactTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox internationalCheckBox;
        private System.Windows.Forms.Button validate_Button;
        private System.Windows.Forms.Label label1;
    }
}