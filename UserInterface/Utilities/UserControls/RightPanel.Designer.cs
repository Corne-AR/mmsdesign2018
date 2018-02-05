namespace UserInterface.Utilities.UserControls
{
    partial class RightPanel
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.split0 = new System.Windows.Forms.Panel();
            this.documents_Label = new System.Windows.Forms.Label();
            this.letters_Button = new System.Windows.Forms.Button();
            this.repairsLetter_button = new System.Windows.Forms.Button();
            this.labe3x8_Button = new System.Windows.Forms.Button();
            this.fax_Button = new System.Windows.Forms.Button();
            this.invoiceExport_Button = new System.Windows.Forms.Button();
            this.purchaseOrderExport_Button = new System.Windows.Forms.Button();
            this.splt1 = new System.Windows.Forms.Panel();
            this.discs_Label = new System.Windows.Forms.Label();
            this.discs_PictureBox = new System.Windows.Forms.PictureBox();
            this.burnMM_Button = new System.Windows.Forms.Button();
            this.burnMMDVD_Button = new System.Windows.Forms.Button();
            this.images_Label = new System.Windows.Forms.Label();
            this.imageMM_Button = new System.Windows.Forms.Button();
            this.imageMMDVD_Button = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discs_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.split0);
            this.flowLayoutPanel1.Controls.Add(this.documents_Label);
            this.flowLayoutPanel1.Controls.Add(this.letters_Button);
            this.flowLayoutPanel1.Controls.Add(this.repairsLetter_button);
            this.flowLayoutPanel1.Controls.Add(this.labe3x8_Button);
            this.flowLayoutPanel1.Controls.Add(this.fax_Button);
            this.flowLayoutPanel1.Controls.Add(this.invoiceExport_Button);
            this.flowLayoutPanel1.Controls.Add(this.purchaseOrderExport_Button);
            this.flowLayoutPanel1.Controls.Add(this.splt1);
            this.flowLayoutPanel1.Controls.Add(this.discs_Label);
            this.flowLayoutPanel1.Controls.Add(this.discs_PictureBox);
            this.flowLayoutPanel1.Controls.Add(this.burnMM_Button);
            this.flowLayoutPanel1.Controls.Add(this.burnMMDVD_Button);
            this.flowLayoutPanel1.Controls.Add(this.images_Label);
            this.flowLayoutPanel1.Controls.Add(this.imageMM_Button);
            this.flowLayoutPanel1.Controls.Add(this.imageMMDVD_Button);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(94, 801);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // split0
            // 
            this.split0.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.split0.Location = new System.Drawing.Point(9, 6);
            this.split0.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.split0.Name = "split0";
            this.split0.Size = new System.Drawing.Size(78, 3);
            this.split0.TabIndex = 17;
            // 
            // documents_Label
            // 
            this.documents_Label.Location = new System.Drawing.Point(6, 12);
            this.documents_Label.Name = "documents_Label";
            this.documents_Label.Size = new System.Drawing.Size(84, 20);
            this.documents_Label.TabIndex = 16;
            this.documents_Label.Text = "Documents";
            this.documents_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.documents_Label.Click += new System.EventHandler(this.ToggleDocuments_Click);
            // 
            // letters_Button
            // 
            this.letters_Button.Location = new System.Drawing.Point(6, 35);
            this.letters_Button.Name = "letters_Button";
            this.letters_Button.Size = new System.Drawing.Size(84, 23);
            this.letters_Button.TabIndex = 6;
            this.letters_Button.Text = "Letter Head";
            this.letters_Button.UseVisualStyleBackColor = true;
            this.letters_Button.Click += new System.EventHandler(this.Document_Click);
            // 
            // repairsLetter_button
            // 
            this.repairsLetter_button.Location = new System.Drawing.Point(6, 64);
            this.repairsLetter_button.Name = "repairsLetter_button";
            this.repairsLetter_button.Size = new System.Drawing.Size(84, 23);
            this.repairsLetter_button.TabIndex = 21;
            this.repairsLetter_button.Text = "Repair Instr";
            this.repairsLetter_button.UseVisualStyleBackColor = true;
            this.repairsLetter_button.Click += new System.EventHandler(this.RepairsLetter_button_Click);
            // 
            // labe3x8_Button
            // 
            this.labe3x8_Button.Location = new System.Drawing.Point(6, 93);
            this.labe3x8_Button.Name = "labe3x8_Button";
            this.labe3x8_Button.Size = new System.Drawing.Size(84, 23);
            this.labe3x8_Button.TabIndex = 11;
            this.labe3x8_Button.Text = "Labels 3x8";
            this.labe3x8_Button.UseVisualStyleBackColor = true;
            this.labe3x8_Button.Click += new System.EventHandler(this.Labe3x8_Button_Click);
            // 
            // fax_Button
            // 
            this.fax_Button.Location = new System.Drawing.Point(6, 122);
            this.fax_Button.Name = "fax_Button";
            this.fax_Button.Size = new System.Drawing.Size(84, 23);
            this.fax_Button.TabIndex = 19;
            this.fax_Button.Text = "Fax";
            this.fax_Button.UseVisualStyleBackColor = true;
            this.fax_Button.Click += new System.EventHandler(this.Fax_Button_Click);
            // 
            // invoiceExport_Button
            // 
            this.invoiceExport_Button.Location = new System.Drawing.Point(6, 151);
            this.invoiceExport_Button.Name = "invoiceExport_Button";
            this.invoiceExport_Button.Size = new System.Drawing.Size(84, 23);
            this.invoiceExport_Button.TabIndex = 20;
            this.invoiceExport_Button.Text = "Invoice Export";
            this.invoiceExport_Button.UseVisualStyleBackColor = true;
            this.invoiceExport_Button.Click += new System.EventHandler(this.InvoiceExport_Event);
            // 
            // purchaseOrderExport_Button
            // 
            this.purchaseOrderExport_Button.Location = new System.Drawing.Point(6, 180);
            this.purchaseOrderExport_Button.Name = "purchaseOrderExport_Button";
            this.purchaseOrderExport_Button.Size = new System.Drawing.Size(84, 23);
            this.purchaseOrderExport_Button.TabIndex = 22;
            this.purchaseOrderExport_Button.Text = "PO Export";
            this.purchaseOrderExport_Button.UseVisualStyleBackColor = true;
            this.purchaseOrderExport_Button.Click += new System.EventHandler(this.PurchaseOrderExport_Button_Click);
            // 
            // splt1
            // 
            this.splt1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splt1.Location = new System.Drawing.Point(9, 209);
            this.splt1.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.splt1.Name = "splt1";
            this.splt1.Size = new System.Drawing.Size(78, 3);
            this.splt1.TabIndex = 9;
            // 
            // discs_Label
            // 
            this.discs_Label.Location = new System.Drawing.Point(3, 215);
            this.discs_Label.Margin = new System.Windows.Forms.Padding(0);
            this.discs_Label.Name = "discs_Label";
            this.discs_Label.Size = new System.Drawing.Size(65, 20);
            this.discs_Label.TabIndex = 8;
            this.discs_Label.Text = "Burn Discs";
            this.discs_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.discs_Label.Click += new System.EventHandler(this.ToggleISO_Click);
            // 
            // discs_PictureBox
            // 
            this.discs_PictureBox.Image = global::UserInterface.Properties.Resources.settings;
            this.discs_PictureBox.Location = new System.Drawing.Point(68, 215);
            this.discs_PictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.discs_PictureBox.Name = "discs_PictureBox";
            this.discs_PictureBox.Size = new System.Drawing.Size(20, 20);
            this.discs_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.discs_PictureBox.TabIndex = 18;
            this.discs_PictureBox.TabStop = false;
            this.discs_PictureBox.Click += new System.EventHandler(this.DiscSettings_Click);
            // 
            // burnMM_Button
            // 
            this.burnMM_Button.Location = new System.Drawing.Point(6, 236);
            this.burnMM_Button.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.burnMM_Button.Name = "burnMM_Button";
            this.burnMM_Button.Size = new System.Drawing.Size(84, 23);
            this.burnMM_Button.TabIndex = 7;
            this.burnMM_Button.Text = "Model Maker";
            this.burnMM_Button.UseVisualStyleBackColor = true;
            this.burnMM_Button.Click += new System.EventHandler(this.BurnMM_Click);
            // 
            // burnMMDVD_Button
            // 
            this.burnMMDVD_Button.Location = new System.Drawing.Point(6, 261);
            this.burnMMDVD_Button.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.burnMMDVD_Button.Name = "burnMMDVD_Button";
            this.burnMMDVD_Button.Size = new System.Drawing.Size(84, 23);
            this.burnMMDVD_Button.TabIndex = 10;
            this.burnMMDVD_Button.Text = "Intro DVD";
            this.burnMMDVD_Button.UseVisualStyleBackColor = true;
            this.burnMMDVD_Button.Click += new System.EventHandler(this.BurnMMDVD_Click);
            // 
            // images_Label
            // 
            this.images_Label.Location = new System.Drawing.Point(6, 285);
            this.images_Label.Name = "images_Label";
            this.images_Label.Size = new System.Drawing.Size(84, 15);
            this.images_Label.TabIndex = 13;
            this.images_Label.Text = "Images";
            this.images_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageMM_Button
            // 
            this.imageMM_Button.Location = new System.Drawing.Point(6, 301);
            this.imageMM_Button.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.imageMM_Button.Name = "imageMM_Button";
            this.imageMM_Button.Size = new System.Drawing.Size(84, 23);
            this.imageMM_Button.TabIndex = 12;
            this.imageMM_Button.Text = "Model Maker";
            this.imageMM_Button.UseVisualStyleBackColor = true;
            this.imageMM_Button.Click += new System.EventHandler(this.ImageMM_Button_Click);
            // 
            // imageMMDVD_Button
            // 
            this.imageMMDVD_Button.Location = new System.Drawing.Point(6, 326);
            this.imageMMDVD_Button.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.imageMMDVD_Button.Name = "imageMMDVD_Button";
            this.imageMMDVD_Button.Size = new System.Drawing.Size(84, 23);
            this.imageMMDVD_Button.TabIndex = 14;
            this.imageMMDVD_Button.Text = "Intro DVD";
            this.imageMMDVD_Button.UseVisualStyleBackColor = true;
            this.imageMMDVD_Button.Click += new System.EventHandler(this.ImageMMDVD_Button_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Click += new System.EventHandler(this.OpenClose_Event);
            this.splitContainer1.Panel1MinSize = 1;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2MinSize = 1;
            this.splitContainer1.Size = new System.Drawing.Size(120, 801);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 801);
            this.label1.TabIndex = 0;
            this.label1.Text = "4";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            this.label1.DoubleClick += new System.EventHandler(this.OpenClose_Event);
            // 
            // RightPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RightPanel";
            this.Size = new System.Drawing.Size(122, 800);
            this.Load += new System.EventHandler(this.RightPanel_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.discs_PictureBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button letters_Button;
        private System.Windows.Forms.Panel splt1;
        private System.Windows.Forms.Label discs_Label;
        private System.Windows.Forms.Button burnMM_Button;
        private System.Windows.Forms.Button burnMMDVD_Button;
        private System.Windows.Forms.Button labe3x8_Button;
        private System.Windows.Forms.Label images_Label;
        private System.Windows.Forms.Button imageMM_Button;
        private System.Windows.Forms.Button imageMMDVD_Button;
        private System.Windows.Forms.Label documents_Label;
        private System.Windows.Forms.Panel split0;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox discs_PictureBox;
        private System.Windows.Forms.Button fax_Button;
        private System.Windows.Forms.Button invoiceExport_Button;
        private System.Windows.Forms.Button repairsLetter_button;
        private System.Windows.Forms.Button purchaseOrderExport_Button;
    }
}
