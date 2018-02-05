namespace AMS.Security.Forms
{
    partial class Activation
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
            this.label1 = new System.Windows.Forms.Label();
            this.requestCode_TextBox = new System.Windows.Forms.TextBox();
            this.activate_Button = new System.Windows.Forms.Button();
            this.activateCode_TextBox = new System.Windows.Forms.TextBox();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.demo_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 30);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(518, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please email the \'Request Code\' to admin@inspirestudio.co.za\r\n to receive an acti" +
    "vation code for this computer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // requestCode_TextBox
            // 
            this.requestCode_TextBox.Location = new System.Drawing.Point(198, 118);
            this.requestCode_TextBox.Name = "requestCode_TextBox";
            this.requestCode_TextBox.ReadOnly = true;
            this.requestCode_TextBox.Size = new System.Drawing.Size(238, 20);
            this.requestCode_TextBox.TabIndex = 0;
            // 
            // activate_Button
            // 
            this.activate_Button.Location = new System.Drawing.Point(191, 190);
            this.activate_Button.Name = "activate_Button";
            this.activate_Button.Size = new System.Drawing.Size(136, 36);
            this.activate_Button.TabIndex = 2;
            this.activate_Button.Text = "Activate AMS";
            this.activate_Button.UseVisualStyleBackColor = true;
            this.activate_Button.Click += new System.EventHandler(this.activate_Button_Click);
            // 
            // activateCode_TextBox
            // 
            this.activateCode_TextBox.Location = new System.Drawing.Point(198, 144);
            this.activateCode_TextBox.Name = "activateCode_TextBox";
            this.activateCode_TextBox.Size = new System.Drawing.Size(238, 20);
            this.activateCode_TextBox.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(518, 30);
            this.header1.TabIndex = 4;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 271);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(518, 60);
            this.footer1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Request Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter Activation Code";
            // 
            // demo_Button
            // 
            this.demo_Button.Location = new System.Drawing.Point(205, 232);
            this.demo_Button.Name = "demo_Button";
            this.demo_Button.Size = new System.Drawing.Size(108, 23);
            this.demo_Button.TabIndex = 3;
            this.demo_Button.Text = "Launch Demo";
            this.demo_Button.UseVisualStyleBackColor = true;
            this.demo_Button.Click += new System.EventHandler(this.demo_Button_Click);
            // 
            // Activation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 331);
            this.Controls.Add(this.demo_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.activateCode_TextBox);
            this.Controls.Add(this.activate_Button);
            this.Controls.Add(this.requestCode_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Activation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activation";
            this.Load += new System.EventHandler(this.Activation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox requestCode_TextBox;
        private System.Windows.Forms.Button activate_Button;
        private System.Windows.Forms.TextBox activateCode_TextBox;
        private UserInterface.UserControls.Header header1;
        private UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button demo_Button;
    }
}