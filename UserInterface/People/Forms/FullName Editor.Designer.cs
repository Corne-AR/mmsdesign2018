namespace UserInterface.People.Forms
{
    partial class FullName_Editor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nickNameLabel;
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label firstNameLabel;
            this.nickNameTextBox = new System.Windows.Forms.TextBox();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.titleComboBox = new System.Windows.Forms.ComboBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.ok_Button = new System.Windows.Forms.Button();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.displayNickNameCheckBox = new System.Windows.Forms.CheckBox();
            nickNameLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nickNameLabel
            // 
            nickNameLabel.AutoSize = true;
            nickNameLabel.Location = new System.Drawing.Point(75, 76);
            nickNameLabel.Name = "nickNameLabel";
            nickNameLabel.Size = new System.Drawing.Size(60, 13);
            nickNameLabel.TabIndex = 1;
            nickNameLabel.Text = "Nick Name";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(108, 49);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(27, 13);
            titleLabel.TabIndex = 3;
            titleLabel.Text = "Title";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(77, 128);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(58, 13);
            lastNameLabel.TabIndex = 4;
            lastNameLabel.Text = "Last Name";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(78, 102);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(57, 13);
            firstNameLabel.TabIndex = 6;
            firstNameLabel.Text = "First Name";
            // 
            // nickNameTextBox
            // 
            this.nickNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "NickName", true));
            this.nickNameTextBox.Location = new System.Drawing.Point(144, 73);
            this.nickNameTextBox.Name = "nickNameTextBox";
            this.nickNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nickNameTextBox.TabIndex = 1;
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(Data.People.Person);
            // 
            // titleComboBox
            // 
            this.titleComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "Title", true));
            this.titleComboBox.FormattingEnabled = true;
            this.titleComboBox.Items.AddRange(new object[] {
            "Mr.",
            "Mrs.",
            "Ms.",
            "Miss.",
            "Proff.",
            "Dr.",
            "Ps.",
            "Rev."});
            this.titleComboBox.Location = new System.Drawing.Point(144, 46);
            this.titleComboBox.Name = "titleComboBox";
            this.titleComboBox.Size = new System.Drawing.Size(76, 21);
            this.titleComboBox.TabIndex = 0;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "LastName", true));
            this.lastNameTextBox.Location = new System.Drawing.Point(144, 125);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameTextBox.TabIndex = 3;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "FirstName", true));
            this.firstNameTextBox.Location = new System.Drawing.Point(144, 99);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameTextBox.TabIndex = 2;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(345, 30);
            this.header1.TabIndex = 8;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 220);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(345, 60);
            this.footer1.TabIndex = 9;
            // 
            // ok_Button
            // 
            this.ok_Button.Location = new System.Drawing.Point(94, 174);
            this.ok_Button.Name = "ok_Button";
            this.ok_Button.Size = new System.Drawing.Size(75, 23);
            this.ok_Button.TabIndex = 4;
            this.ok_Button.Text = "Ok";
            this.ok_Button.UseVisualStyleBackColor = true;
            this.ok_Button.Click += new System.EventHandler(this.ok_Button_Click);
            // 
            // cancel_Button
            // 
            this.cancel_Button.Location = new System.Drawing.Point(175, 174);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 5;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // displayNickNameCheckBox
            // 
            this.displayNickNameCheckBox.AutoSize = true;
            this.displayNickNameCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.personBindingSource, "DisplayNickName", true));
            this.displayNickNameCheckBox.Location = new System.Drawing.Point(114, 151);
            this.displayNickNameCheckBox.Name = "displayNickNameCheckBox";
            this.displayNickNameCheckBox.Size = new System.Drawing.Size(116, 17);
            this.displayNickNameCheckBox.TabIndex = 13;
            this.displayNickNameCheckBox.Text = "Display Nick Name";
            this.displayNickNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // FullName_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 280);
            this.Controls.Add(this.displayNickNameCheckBox);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.ok_Button);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.Controls.Add(firstNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(lastNameLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(titleLabel);
            this.Controls.Add(this.titleComboBox);
            this.Controls.Add(nickNameLabel);
            this.Controls.Add(this.nickNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FullName_Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Full Name";
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.TextBox nickNameTextBox;
        private System.Windows.Forms.ComboBox titleComboBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button ok_Button;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.CheckBox displayNickNameCheckBox;
    }
}