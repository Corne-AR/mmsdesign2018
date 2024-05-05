namespace UserInterface.Products.Forms
{
    partial class ProductList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tabProductsControl = new System.Windows.Forms.TabControl();
            this.tabMMSPage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.productListUC = new UserInterface.Products.UserControls.ProductListUC();
            this.toolStrip1.SuspendLayout();
            this.tabProductsControl.SuspendLayout();
            this.tabMMSPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(963, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "Save All";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tabProductsControl
            // 
            this.tabProductsControl.Controls.Add(this.tabMMSPage);
            this.tabProductsControl.Controls.Add(this.tabPage2);
            this.tabProductsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProductsControl.Location = new System.Drawing.Point(0, 25);
            this.tabProductsControl.Name = "tabProductsControl";
            this.tabProductsControl.SelectedIndex = 0;
            this.tabProductsControl.Size = new System.Drawing.Size(963, 629);
            this.tabProductsControl.TabIndex = 2;
            // 
            // tabMMSPage
            // 
            this.tabMMSPage.Controls.Add(this.productListUC);
            this.tabMMSPage.Location = new System.Drawing.Point(4, 22);
            this.tabMMSPage.Name = "tabMMSPage";
            this.tabMMSPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMMSPage.Size = new System.Drawing.Size(955, 603);
            this.tabMMSPage.TabIndex = 0;
            this.tabMMSPage.Text = "MMS";
            this.tabMMSPage.UseVisualStyleBackColor = true;
            this.tabMMSPage.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(955, 603);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Other Products";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // productListUC
            // 
            this.productListUC.AutoSize = true;
            this.productListUC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.productListUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productListUC.Location = new System.Drawing.Point(3, 3);
            this.productListUC.Margin = new System.Windows.Forms.Padding(0);
            this.productListUC.Name = "productListUC";
            this.productListUC.Size = new System.Drawing.Size(949, 597);
            this.productListUC.TabIndex = 1;
            this.productListUC.Load += new System.EventHandler(this.productListUC_Load);
            // 
            // ProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 654);
            this.Controls.Add(this.tabProductsControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ProductList";
            this.Text = "ProductList";
            this.Load += new System.EventHandler(this.ProductList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabProductsControl.ResumeLayout(false);
            this.tabMMSPage.ResumeLayout(false);
            this.tabMMSPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabControl tabProductsControl;
        private System.Windows.Forms.TabPage tabMMSPage;
        private System.Windows.Forms.TabPage tabPage2;
        private UserControls.ProductListUC productListUC;
    }
}