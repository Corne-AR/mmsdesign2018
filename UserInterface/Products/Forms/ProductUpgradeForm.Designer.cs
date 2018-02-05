namespace UserInterface.Products.Forms
{
    partial class ProductUpgradeForm
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
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.upgrade_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.existingProduct_Llabel = new System.Windows.Forms.Label();
            this.upgradeProduct_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.result_Label = new System.Windows.Forms.Label();
            this.resultProduct_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(809, 30);
            this.header1.TabIndex = 0;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 383);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(809, 60);
            this.footer1.TabIndex = 1;
            // 
            // upgrade_Button
            // 
            this.upgrade_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.upgrade_Button.Location = new System.Drawing.Point(367, 404);
            this.upgrade_Button.Name = "upgrade_Button";
            this.upgrade_Button.Size = new System.Drawing.Size(75, 23);
            this.upgrade_Button.TabIndex = 2;
            this.upgrade_Button.Text = "Close";
            this.upgrade_Button.UseVisualStyleBackColor = true;
            this.upgrade_Button.Click += new System.EventHandler(this.Upgrade_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.existingProduct_Llabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.upgradeProduct_Label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.result_Label, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.resultProduct_Label, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 61);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.467742F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.53226F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(809, 322);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // existingProduct_Llabel
            // 
            this.existingProduct_Llabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.existingProduct_Llabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.existingProduct_Llabel.Location = new System.Drawing.Point(243, 27);
            this.existingProduct_Llabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 9);
            this.existingProduct_Llabel.Name = "existingProduct_Llabel";
            this.existingProduct_Llabel.Size = new System.Drawing.Size(234, 286);
            this.existingProduct_Llabel.TabIndex = 3;
            this.existingProduct_Llabel.Text = "No valid data found";
            // 
            // upgradeProduct_Label
            // 
            this.upgradeProduct_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upgradeProduct_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upgradeProduct_Label.Location = new System.Drawing.Point(9, 27);
            this.upgradeProduct_Label.Margin = new System.Windows.Forms.Padding(9, 0, 3, 9);
            this.upgradeProduct_Label.Name = "upgradeProduct_Label";
            this.upgradeProduct_Label.Size = new System.Drawing.Size(228, 286);
            this.upgradeProduct_Label.TabIndex = 2;
            this.upgradeProduct_Label.Text = "label3";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(243, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exsisting Product";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Upgrade";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // result_Label
            // 
            this.result_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.result_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.result_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_Label.Location = new System.Drawing.Point(492, 0);
            this.result_Label.Margin = new System.Windows.Forms.Padding(3, 0, 9, 0);
            this.result_Label.Name = "result_Label";
            this.result_Label.Size = new System.Drawing.Size(308, 27);
            this.result_Label.TabIndex = 4;
            this.result_Label.Text = "Result";
            this.result_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resultProduct_Label
            // 
            this.resultProduct_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultProduct_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultProduct_Label.Location = new System.Drawing.Point(492, 27);
            this.resultProduct_Label.Margin = new System.Windows.Forms.Padding(3, 0, 9, 9);
            this.resultProduct_Label.Name = "resultProduct_Label";
            this.resultProduct_Label.Size = new System.Drawing.Size(308, 286);
            this.resultProduct_Label.TabIndex = 4;
            this.resultProduct_Label.Text = "No valid data found";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(809, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirm changes to existing product with new upgrades";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductUpgradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 443);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.upgrade_Button);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductUpgradeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductUpgradeForm";
            this.Load += new System.EventHandler(this.ProductUpgradeForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button upgrade_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label existingProduct_Llabel;
        private System.Windows.Forms.Label upgradeProduct_Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label result_Label;
        private System.Windows.Forms.Label resultProduct_Label;
        private System.Windows.Forms.Label label3;
    }
}