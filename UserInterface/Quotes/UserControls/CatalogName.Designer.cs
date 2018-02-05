namespace UserInterface.Quotes.UserControls
{
    partial class CatalogName
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
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.Remove_Button = new System.Windows.Forms.Button();
            this.Duplicate_Button = new System.Windows.Forms.Button();
            this.productName_TextBox = new System.Windows.Forms.TextBox();
            this.existingProductColor_Panel = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.catalogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel1
            // 
            this.nameLabel1.AutoSize = true;
            this.nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.catalogBindingSource, "Name", true));
            this.nameLabel1.Enabled = false;
            this.nameLabel1.Location = new System.Drawing.Point(3, 5);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(69, 13);
            this.nameLabel1.TabIndex = 0;
            this.nameLabel1.Text = "Model Maker";
            // 
            // Remove_Button
            // 
            this.Remove_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Remove_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remove_Button.Location = new System.Drawing.Point(205, 3);
            this.Remove_Button.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.Remove_Button.Name = "Remove_Button";
            this.Remove_Button.Size = new System.Drawing.Size(22, 20);
            this.Remove_Button.TabIndex = 4;
            this.Remove_Button.Text = "-";
            this.Remove_Button.UseVisualStyleBackColor = true;
            // 
            // Duplicate_Button
            // 
            this.Duplicate_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Duplicate_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Duplicate_Button.Location = new System.Drawing.Point(183, 3);
            this.Duplicate_Button.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.Duplicate_Button.Name = "Duplicate_Button";
            this.Duplicate_Button.Size = new System.Drawing.Size(22, 20);
            this.Duplicate_Button.TabIndex = 3;
            this.Duplicate_Button.Text = "+";
            this.Duplicate_Button.UseVisualStyleBackColor = true;
            // 
            // productName_TextBox
            // 
            this.productName_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.catalogBindingSource, "ProductName", true));
            this.productName_TextBox.Location = new System.Drawing.Point(91, 3);
            this.productName_TextBox.Name = "productName_TextBox";
            this.productName_TextBox.Size = new System.Drawing.Size(86, 20);
            this.productName_TextBox.TabIndex = 1;
            this.productName_TextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // existingProductColor_Panel
            // 
            this.existingProductColor_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.existingProductColor_Panel.Location = new System.Drawing.Point(275, 3);
            this.existingProductColor_Panel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.existingProductColor_Panel.Name = "existingProductColor_Panel";
            this.existingProductColor_Panel.Size = new System.Drawing.Size(10, 20);
            this.existingProductColor_Panel.TabIndex = 5;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.catalogBindingSource, "Count", true));
            this.numericUpDown1.Location = new System.Drawing.Point(230, 3);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(42, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // catalogBindingSource
            // 
            this.catalogBindingSource.DataSource = typeof(Data.Catalogs.Catalog);
            // 
            // CatalogName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.existingProductColor_Panel);
            this.Controls.Add(this.productName_TextBox);
            this.Controls.Add(this.Duplicate_Button);
            this.Controls.Add(this.Remove_Button);
            this.Controls.Add(this.nameLabel1);
            this.Name = "CatalogName";
            this.Size = new System.Drawing.Size(288, 26);
            this.Load += new System.EventHandler(this.CatalogName_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource catalogBindingSource;
        private System.Windows.Forms.Label nameLabel1;
        public System.Windows.Forms.Button Remove_Button;
        public System.Windows.Forms.Button Duplicate_Button;
        private System.Windows.Forms.TextBox productName_TextBox;
        private System.Windows.Forms.Panel existingProductColor_Panel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
