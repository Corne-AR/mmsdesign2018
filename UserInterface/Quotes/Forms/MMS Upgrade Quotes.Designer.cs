namespace UserInterface.People.Forms
{
    partial class MMS_Upgrade_Quotes
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
            this.submitBT = new System.Windows.Forms.Button();
            this.pasteTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // submitBT
            // 
            this.submitBT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.submitBT.Location = new System.Drawing.Point(0, 304);
            this.submitBT.Name = "submitBT";
            this.submitBT.Size = new System.Drawing.Size(640, 23);
            this.submitBT.TabIndex = 0;
            this.submitBT.Text = "Submit";
            this.submitBT.UseVisualStyleBackColor = true;
            // 
            // pasteTB
            // 
            this.pasteTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pasteTB.Location = new System.Drawing.Point(0, 0);
            this.pasteTB.Multiline = true;
            this.pasteTB.Name = "pasteTB";
            this.pasteTB.Size = new System.Drawing.Size(640, 304);
            this.pasteTB.TabIndex = 1;
            // 
            // MMS_Upgrade_Quotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 327);
            this.Controls.Add(this.pasteTB);
            this.Controls.Add(this.submitBT);
            this.Name = "MMS_Upgrade_Quotes";
            this.Text = "MMS_Upgrade_Quotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitBT;
        private System.Windows.Forms.TextBox pasteTB;
    }
}