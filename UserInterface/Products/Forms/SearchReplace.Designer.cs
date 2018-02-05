namespace UserInterface.Products.Forms
{
    partial class SearchReplace
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
            this.NameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NewNameTextBox = new System.Windows.Forms.TextBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.WriteToDiskCheckBox = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameComboBox
            // 
            this.NameComboBox.FormattingEnabled = true;
            this.NameComboBox.Location = new System.Drawing.Point(12, 30);
            this.NameComboBox.Name = "NameComboBox";
            this.NameComboBox.Size = new System.Drawing.Size(121, 21);
            this.NameComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catalog Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Name";
            // 
            // NewNameTextBox
            // 
            this.NewNameTextBox.Location = new System.Drawing.Point(148, 30);
            this.NewNameTextBox.Name = "NewNameTextBox";
            this.NewNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NewNameTextBox.TabIndex = 3;
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(12, 80);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 4;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            // 
            // WriteToDiskCheckBox
            // 
            this.WriteToDiskCheckBox.AutoSize = true;
            this.WriteToDiskCheckBox.Checked = true;
            this.WriteToDiskCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WriteToDiskCheckBox.Location = new System.Drawing.Point(12, 57);
            this.WriteToDiskCheckBox.Name = "WriteToDiskCheckBox";
            this.WriteToDiskCheckBox.Size = new System.Drawing.Size(85, 17);
            this.WriteToDiskCheckBox.TabIndex = 5;
            this.WriteToDiskCheckBox.Text = "Write to disk";
            this.WriteToDiskCheckBox.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(148, 89);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 4);
            this.progressBar.TabIndex = 6;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(15, 110);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(25, 13);
            this.infoLabel.TabIndex = 7;
            this.infoLabel.Text = "Info";
            // 
            // SearchReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(313, 145);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.WriteToDiskCheckBox);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.NewNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameComboBox);
            this.Name = "SearchReplace";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchReplace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox NameComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NewNameTextBox;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.CheckBox WriteToDiskCheckBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label infoLabel;
    }
}