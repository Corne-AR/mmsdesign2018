namespace UserInterface.Transactions.UserControls
{
    partial class TransactionFooter
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.existingCredit_Label = new System.Windows.Forms.Label();
            this.total_Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totalDue_button = new System.Windows.Forms.Button();
            this.vat_Label = new System.Windows.Forms.Label();
            this.totalDue_Label = new System.Windows.Forms.Label();
            this.subTotal_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.transaction_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.notes_TabPage = new System.Windows.Forms.TabPage();
            this.mmsdesignNotes_tabPage = new System.Windows.Forms.TabPage();
            this.clientNotes_TextBox = new System.Windows.Forms.TextBox();
            this.summary_TabPage = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transaction_BindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.notes_TabPage.SuspendLayout();
            this.mmsdesignNotes_tabPage.SuspendLayout();
            this.summary_TabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.existingCredit_Label);
            this.panel1.Controls.Add(this.total_Label);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.totalDue_button);
            this.panel1.Controls.Add(this.vat_Label);
            this.panel1.Controls.Add(this.totalDue_Label);
            this.panel1.Controls.Add(this.subTotal_Label);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(810, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 150);
            this.panel1.TabIndex = 0;
            // 
            // existingCredit_Label
            // 
            this.existingCredit_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.existingCredit_Label.ForeColor = System.Drawing.Color.Green;
            this.existingCredit_Label.Location = new System.Drawing.Point(0, 85);
            this.existingCredit_Label.Margin = new System.Windows.Forms.Padding(3);
            this.existingCredit_Label.Name = "existingCredit_Label";
            this.existingCredit_Label.Size = new System.Drawing.Size(155, 15);
            this.existingCredit_Label.TabIndex = 9;
            this.existingCredit_Label.Text = "0.00";
            this.existingCredit_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // total_Label
            // 
            this.total_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_Label.Location = new System.Drawing.Point(81, 41);
            this.total_Label.Margin = new System.Windows.Forms.Padding(3);
            this.total_Label.Name = "total_Label";
            this.total_Label.Size = new System.Drawing.Size(74, 13);
            this.total_Label.TabIndex = 8;
            this.total_Label.Text = "1 717.58";
            this.total_Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "TOTAL";
            // 
            // totalDue_button
            // 
            this.totalDue_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalDue_button.Location = new System.Drawing.Point(0, 59);
            this.totalDue_button.Name = "totalDue_button";
            this.totalDue_button.Size = new System.Drawing.Size(75, 24);
            this.totalDue_button.TabIndex = 6;
            this.totalDue_button.Text = "Total Due";
            this.totalDue_button.UseVisualStyleBackColor = true;
            this.totalDue_button.Click += new System.EventHandler(this.GetTotals_Event);
            // 
            // vat_Label
            // 
            this.vat_Label.Location = new System.Drawing.Point(81, 22);
            this.vat_Label.Margin = new System.Windows.Forms.Padding(3);
            this.vat_Label.Name = "vat_Label";
            this.vat_Label.Size = new System.Drawing.Size(74, 13);
            this.vat_Label.TabIndex = 5;
            this.vat_Label.Text = "1 717.58";
            this.vat_Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalDue_Label
            // 
            this.totalDue_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDue_Label.Location = new System.Drawing.Point(81, 62);
            this.totalDue_Label.Margin = new System.Windows.Forms.Padding(3);
            this.totalDue_Label.Name = "totalDue_Label";
            this.totalDue_Label.Size = new System.Drawing.Size(74, 15);
            this.totalDue_Label.TabIndex = 4;
            this.totalDue_Label.Text = "13 986.00";
            this.totalDue_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // subTotal_Label
            // 
            this.subTotal_Label.Location = new System.Drawing.Point(81, 3);
            this.subTotal_Label.Margin = new System.Windows.Forms.Padding(3);
            this.subTotal_Label.Name = "subTotal_Label";
            this.subTotal_Label.Size = new System.Drawing.Size(74, 13);
            this.subTotal_Label.TabIndex = 3;
            this.subTotal_Label.Text = "12 268.42";
            this.subTotal_Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sub Total";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "Notes", true));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(803, 124);
            this.textBox1.TabIndex = 2;
            // 
            // transaction_BindingSource
            // 
            this.transaction_BindingSource.DataSource = typeof(Data.Transactions.Transaction);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.notes_TabPage);
            this.tabControl1.Controls.Add(this.mmsdesignNotes_tabPage);
            this.tabControl1.Controls.Add(this.summary_TabPage);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0, 0, 38, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(811, 150);
            this.tabControl1.TabIndex = 3;
            // 
            // notes_TabPage
            // 
            this.notes_TabPage.Controls.Add(this.textBox1);
            this.notes_TabPage.Location = new System.Drawing.Point(4, 22);
            this.notes_TabPage.Name = "notes_TabPage";
            this.notes_TabPage.Size = new System.Drawing.Size(803, 124);
            this.notes_TabPage.TabIndex = 1;
            this.notes_TabPage.Text = "Notes";
            this.notes_TabPage.UseVisualStyleBackColor = true;
            // 
            // clientNotes_tabPage
            // 
            this.mmsdesignNotes_tabPage.Controls.Add(this.clientNotes_TextBox);
            this.mmsdesignNotes_tabPage.Location = new System.Drawing.Point(4, 22);
            this.mmsdesignNotes_tabPage.Name = "clientNotes_tabPage";
            this.mmsdesignNotes_tabPage.Size = new System.Drawing.Size(803, 124);
            this.mmsdesignNotes_tabPage.TabIndex = 2;
            this.mmsdesignNotes_tabPage.Text = "MMSDesign Notes";
            this.mmsdesignNotes_tabPage.UseVisualStyleBackColor = true;
            // 
            // clientNotes_TextBox
            // 
            this.clientNotes_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "ClientNotes", true));
            this.clientNotes_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientNotes_TextBox.Location = new System.Drawing.Point(0, 0);
            this.clientNotes_TextBox.Multiline = true;
            this.clientNotes_TextBox.Name = "clientNotes_TextBox";
            this.clientNotes_TextBox.Size = new System.Drawing.Size(803, 124);
            this.clientNotes_TextBox.TabIndex = 0;
            // 
            // summary_TabPage
            // 
            this.summary_TabPage.Controls.Add(this.textBox2);
            this.summary_TabPage.Location = new System.Drawing.Point(4, 22);
            this.summary_TabPage.Margin = new System.Windows.Forms.Padding(0);
            this.summary_TabPage.Name = "summary_TabPage";
            this.summary_TabPage.Size = new System.Drawing.Size(803, 124);
            this.summary_TabPage.TabIndex = 0;
            this.summary_TabPage.Text = "Summary";
            this.summary_TabPage.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaction_BindingSource, "GetSummary", true));
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(803, 124);
            this.textBox2.TabIndex = 3;
            // 
            // TransactionFooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "TransactionFooter";
            this.Size = new System.Drawing.Size(968, 150);
            this.Load += new System.EventHandler(this.TransactionFooter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transaction_BindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.notes_TabPage.ResumeLayout(false);
            this.notes_TabPage.PerformLayout();
            this.mmsdesignNotes_tabPage.ResumeLayout(false);
            this.mmsdesignNotes_tabPage.PerformLayout();
            this.summary_TabPage.ResumeLayout(false);
            this.summary_TabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label vat_Label;
        private System.Windows.Forms.Label totalDue_Label;
        private System.Windows.Forms.Label subTotal_Label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource transaction_BindingSource;
        private System.Windows.Forms.Button totalDue_button;
        private System.Windows.Forms.Label total_Label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage summary_TabPage;
        private System.Windows.Forms.TabPage notes_TabPage;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TabPage mmsdesignNotes_tabPage;
        private System.Windows.Forms.TextBox clientNotes_TextBox;
        private System.Windows.Forms.Label existingCredit_Label;
    }
}
