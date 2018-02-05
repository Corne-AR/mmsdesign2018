namespace UserInterface.People.Forms
{
    partial class PersonEditor
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
            this.personel_Editor_Basic1 = new UserInterface.People.UserControls.Personel_Editor_Basic();
            this.SuspendLayout();
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(863, 30);
            this.header1.TabIndex = 1;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 332);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(863, 60);
            this.footer1.TabIndex = 2;
            // 
            // personel_Editor_Basic1
            // 
            this.personel_Editor_Basic1.AutoScroll = true;
            this.personel_Editor_Basic1.AutoSize = true;
            this.personel_Editor_Basic1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.personel_Editor_Basic1.Location = new System.Drawing.Point(0, 30);
            this.personel_Editor_Basic1.Name = "personel_Editor_Basic1";
            this.personel_Editor_Basic1.Size = new System.Drawing.Size(879, 307);
            this.personel_Editor_Basic1.TabIndex = 0;
            this.personel_Editor_Basic1.Load += new System.EventHandler(this.personel_Editor_Basic1_Load);
            // 
            // PersonEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 392);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.personel_Editor_Basic1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PersonEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PersonEditor";
            this.Load += new System.EventHandler(this.PersonEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserInterface.People.UserControls.Personel_Editor_Basic personel_Editor_Basic1;
        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
    }
}