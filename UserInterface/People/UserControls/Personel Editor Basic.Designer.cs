namespace UserInterface.People.UserControls
{
    partial class Personel_Editor_Basic
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
            System.Windows.Forms.Label titleLabel1;
            System.Windows.Forms.Label emailLabel2;
            System.Windows.Forms.Label contactNumberLabel;
            this.newSave_Button = new System.Windows.Forms.Button();
            this.editCancel_Button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.task_tabPage = new System.Windows.Forms.TabPage();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notes_tabPage = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.nickNameStatus_Label = new System.Windows.Forms.Label();
            this.fullName_TextBox = new System.Windows.Forms.TextBox();
            this.fullName_button = new System.Windows.Forms.Button();
            this.titleComboBox = new System.Windows.Forms.ComboBox();
            this.emailTextBox2 = new System.Windows.Forms.TextBox();
            this.contactNumberTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.remove_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            titleLabel1 = new System.Windows.Forms.Label();
            emailLabel2 = new System.Windows.Forms.Label();
            contactNumberLabel = new System.Windows.Forms.Label();
            this.task_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.notes_tabPage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel1
            // 
            titleLabel1.AutoSize = true;
            titleLabel1.Location = new System.Drawing.Point(221, 39);
            titleLabel1.Name = "titleLabel1";
            titleLabel1.Size = new System.Drawing.Size(27, 13);
            titleLabel1.TabIndex = 62;
            titleLabel1.Text = "Title";
            // 
            // emailLabel2
            // 
            emailLabel2.AutoSize = true;
            emailLabel2.Location = new System.Drawing.Point(216, 104);
            emailLabel2.Name = "emailLabel2";
            emailLabel2.Size = new System.Drawing.Size(32, 13);
            emailLabel2.TabIndex = 57;
            emailLabel2.Text = "Email";
            // 
            // contactNumberLabel
            // 
            contactNumberLabel.AutoSize = true;
            contactNumberLabel.Location = new System.Drawing.Point(164, 130);
            contactNumberLabel.Name = "contactNumberLabel";
            contactNumberLabel.Size = new System.Drawing.Size(84, 13);
            contactNumberLabel.TabIndex = 7;
            contactNumberLabel.Text = "Contact Number";
            // 
            // newSave_Button
            // 
            this.newSave_Button.Location = new System.Drawing.Point(3, 3);
            this.newSave_Button.Name = "newSave_Button";
            this.newSave_Button.Size = new System.Drawing.Size(75, 23);
            this.newSave_Button.TabIndex = 0;
            this.newSave_Button.Text = "New";
            this.newSave_Button.UseVisualStyleBackColor = true;
            this.newSave_Button.Click += new System.EventHandler(this.NewSave_Click);
            // 
            // editCancel_Button
            // 
            this.editCancel_Button.Location = new System.Drawing.Point(84, 3);
            this.editCancel_Button.Name = "editCancel_Button";
            this.editCancel_Button.Size = new System.Drawing.Size(75, 23);
            this.editCancel_Button.TabIndex = 1;
            this.editCancel_Button.Text = "Edit";
            this.editCancel_Button.UseVisualStyleBackColor = true;
            this.editCancel_Button.Click += new System.EventHandler(this.EditCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(260, 234);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // task_tabPage
            // 
            this.task_tabPage.Controls.Add(this.flowLayoutPanel1);
            this.task_tabPage.Location = new System.Drawing.Point(4, 25);
            this.task_tabPage.Name = "task_tabPage";
            this.task_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.task_tabPage.Size = new System.Drawing.Size(266, 240);
            this.task_tabPage.TabIndex = 0;
            this.task_tabPage.Text = "Tasks";
            this.task_tabPage.UseVisualStyleBackColor = true;
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "Notes", true));
            this.noteTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteTextBox.Location = new System.Drawing.Point(3, 3);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(260, 234);
            this.noteTextBox.TabIndex = 0;
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(Data.People.Person);
            // 
            // notes_tabPage
            // 
            this.notes_tabPage.Controls.Add(this.noteTextBox);
            this.notes_tabPage.Location = new System.Drawing.Point(4, 25);
            this.notes_tabPage.Name = "notes_tabPage";
            this.notes_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.notes_tabPage.Size = new System.Drawing.Size(266, 240);
            this.notes_tabPage.TabIndex = 1;
            this.notes_tabPage.Text = "Note";
            this.notes_tabPage.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.notes_tabPage);
            this.tabControl.Controls.Add(this.task_tabPage);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(473, 35);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(274, 269);
            this.tabControl.TabIndex = 67;
            // 
            // nickNameStatus_Label
            // 
            this.nickNameStatus_Label.AutoSize = true;
            this.nickNameStatus_Label.Location = new System.Drawing.Point(254, 85);
            this.nickNameStatus_Label.Name = "nickNameStatus_Label";
            this.nickNameStatus_Label.Size = new System.Drawing.Size(60, 13);
            this.nickNameStatus_Label.TabIndex = 66;
            this.nickNameStatus_Label.Text = "Nick Name";
            // 
            // fullName_TextBox
            // 
            this.fullName_TextBox.Location = new System.Drawing.Point(254, 63);
            this.fullName_TextBox.Name = "fullName_TextBox";
            this.fullName_TextBox.Size = new System.Drawing.Size(213, 20);
            this.fullName_TextBox.TabIndex = 1;
            this.fullName_TextBox.TextChanged += new System.EventHandler(this.fullName_TextBox_TextChanged);
            // 
            // fullName_button
            // 
            this.fullName_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fullName_button.Location = new System.Drawing.Point(173, 63);
            this.fullName_button.Name = "fullName_button";
            this.fullName_button.Size = new System.Drawing.Size(75, 20);
            this.fullName_button.TabIndex = 64;
            this.fullName_button.Text = "Full Name";
            this.fullName_button.UseVisualStyleBackColor = true;
            this.fullName_button.Click += new System.EventHandler(this.fullName_button_Click);
            // 
            // titleComboBox
            // 
            this.titleComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "Title", true));
            this.titleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.titleComboBox.FormattingEnabled = true;
            this.titleComboBox.Items.AddRange(new object[] {
            "Mr.",
            "Mrs.",
            "Ms.",
            "Miss.",
            "Dr.",
            "Proff.",
            "Ps.",
            "Rev."});
            this.titleComboBox.Location = new System.Drawing.Point(254, 36);
            this.titleComboBox.Name = "titleComboBox";
            this.titleComboBox.Size = new System.Drawing.Size(93, 21);
            this.titleComboBox.TabIndex = 0;
            // 
            // emailTextBox2
            // 
            this.emailTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "Email", true));
            this.emailTextBox2.Location = new System.Drawing.Point(254, 101);
            this.emailTextBox2.Name = "emailTextBox2";
            this.emailTextBox2.Size = new System.Drawing.Size(213, 20);
            this.emailTextBox2.TabIndex = 2;
            // 
            // contactNumberTextBox
            // 
            this.contactNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "ContactNumber", true));
            this.contactNumberTextBox.Location = new System.Drawing.Point(254, 127);
            this.contactNumberTextBox.Name = "contactNumberTextBox";
            this.contactNumberTextBox.Size = new System.Drawing.Size(213, 20);
            this.contactNumberTextBox.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.remove_Button);
            this.panel1.Controls.Add(this.editCancel_Button);
            this.panel1.Controls.Add(this.newSave_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 29);
            this.panel1.TabIndex = 5;
            // 
            // remove_Button
            // 
            this.remove_Button.Location = new System.Drawing.Point(165, 3);
            this.remove_Button.Name = "remove_Button";
            this.remove_Button.Size = new System.Drawing.Size(75, 23);
            this.remove_Button.TabIndex = 2;
            this.remove_Button.Text = "Remove";
            this.remove_Button.UseVisualStyleBackColor = true;
            this.remove_Button.Click += new System.EventHandler(this.remove_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(2, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 156);
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // Personel_Editor_Basic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.nickNameStatus_Label);
            this.Controls.Add(this.fullName_TextBox);
            this.Controls.Add(this.fullName_button);
            this.Controls.Add(titleLabel1);
            this.Controls.Add(this.titleComboBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(emailLabel2);
            this.Controls.Add(this.emailTextBox2);
            this.Controls.Add(contactNumberLabel);
            this.Controls.Add(this.contactNumberTextBox);
            this.Name = "Personel_Editor_Basic";
            this.Size = new System.Drawing.Size(750, 307);
            this.Load += new System.EventHandler(this.Personnel_Editor_Basic_Load);
            this.task_tabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.notes_tabPage.ResumeLayout(false);
            this.notes_tabPage.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newSave_Button;
        private System.Windows.Forms.Button editCancel_Button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabPage task_tabPage;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.TabPage notes_tabPage;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label nickNameStatus_Label;
        private System.Windows.Forms.TextBox fullName_TextBox;
        private System.Windows.Forms.Button fullName_button;
        private System.Windows.Forms.ComboBox titleComboBox;
        private System.Windows.Forms.TextBox emailTextBox2;
        private System.Windows.Forms.TextBox contactNumberTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button remove_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
