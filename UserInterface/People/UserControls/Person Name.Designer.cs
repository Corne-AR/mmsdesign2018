namespace UserInterface.People.UserControls
{
    partial class Person_Name
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
            this.fullName_label = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.edit_ContextButton = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fullName_label
            // 
            this.fullName_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fullName_label.Enabled = false;
            this.fullName_label.Location = new System.Drawing.Point(0, 0);
            this.fullName_label.Name = "fullName_label";
            this.fullName_label.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.fullName_label.Size = new System.Drawing.Size(160, 18);
            this.fullName_label.TabIndex = 0;
            this.fullName_label.Text = "Eugene A, Ahlers";
            this.fullName_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edit_ContextButton});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // edit_ContextButton
            // 
            this.edit_ContextButton.Name = "edit_ContextButton";
            this.edit_ContextButton.Size = new System.Drawing.Size(94, 22);
            this.edit_ContextButton.Text = "Edit";
            // 
            // Person_Name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.fullName_label);
            this.Name = "Person_Name";
            this.Size = new System.Drawing.Size(160, 18);
            this.Load += new System.EventHandler(this.Person_Name_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label fullName_label;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem edit_ContextButton;

    }
}
