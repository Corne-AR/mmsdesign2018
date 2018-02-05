namespace AMS.Users.Forms
{
    partial class Login
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
            System.Windows.Forms.Label userNameLabel;
            System.Windows.Forms.Label passwordLabel;
            this.button1 = new System.Windows.Forms.Button();
            this.fastLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.password_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            userNameLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new System.Drawing.Point(52, 60);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new System.Drawing.Size(63, 13);
            userNameLabel.TabIndex = 4;
            userNameLabel.Text = "User Name:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(59, 86);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(56, 13);
            passwordLabel.TabIndex = 6;
            passwordLabel.Text = "Password:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(88, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Logon_Click);
            // 
            // fastLoginCheckBox
            // 
            this.fastLoginCheckBox.AutoSize = true;
            this.fastLoginCheckBox.Location = new System.Drawing.Point(110, 158);
            this.fastLoginCheckBox.Name = "fastLoginCheckBox";
            this.fastLoginCheckBox.Size = new System.Drawing.Size(75, 17);
            this.fastLoginCheckBox.TabIndex = 3;
            this.fastLoginCheckBox.Text = "Fast Login";
            this.fastLoginCheckBox.UseVisualStyleBackColor = true;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(124, 57);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(118, 20);
            this.userNameTextBox.TabIndex = 0;
            // 
            // password_maskedTextBox
            // 
            this.password_maskedTextBox.Location = new System.Drawing.Point(124, 83);
            this.password_maskedTextBox.Name = "password_maskedTextBox";
            this.password_maskedTextBox.PasswordChar = '*';
            this.password_maskedTextBox.Size = new System.Drawing.Size(118, 20);
            this.password_maskedTextBox.TabIndex = 1;
            this.password_maskedTextBox.UseSystemPasswordChar = true;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 202);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(295, 60);
            this.footer1.TabIndex = 1;
            this.footer1.TabStop = false;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(295, 30);
            this.header1.TabIndex = 0;
            this.header1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 262);
            this.Controls.Add(this.password_maskedTextBox);
            this.Controls.Add(this.fastLoginCheckBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(userNameLabel);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserInterface.UserControls.Header header1;
        private UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox fastLoginCheckBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.MaskedTextBox password_maskedTextBox;
    }
}