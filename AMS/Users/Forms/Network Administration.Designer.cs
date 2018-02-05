namespace AMS.Users.Forms
{
    partial class Network_Administration
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
            System.Windows.Forms.Label usernameLabel;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label preFixLabel;
            System.Windows.Forms.Label contactNumberLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label noteLabel;
            this.userList_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.userHeader_Label = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.networkUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userLoginHeader_Label = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.preFixTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.administartorCheckBox = new System.Windows.Forms.CheckBox();
            this.createClientsCheckBox = new System.Windows.Forms.CheckBox();
            this.createCommerceCheckBox = new System.Windows.Forms.CheckBox();
            this.createInvoicesCheckBox = new System.Windows.Forms.CheckBox();
            this.createQuotesCheckBox = new System.Windows.Forms.CheckBox();
            this.createTasksCheckBox = new System.Windows.Forms.CheckBox();
            this.viewClientsCheckBox = new System.Windows.Forms.CheckBox();
            this.viewCommerceCheckBox = new System.Windows.Forms.CheckBox();
            this.viewInvoicesCheckBox = new System.Windows.Forms.CheckBox();
            this.viewQuotesCheckBox = new System.Windows.Forms.CheckBox();
            this.viewTasksCheckBox = new System.Windows.Forms.CheckBox();
            this.userRolesHeader_Label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.contactNumberTextBox = new System.Windows.Forms.TextBox();
            this.done_Button = new System.Windows.Forms.Button();
            this.userPerson_Label = new System.Windows.Forms.Label();
            this.remove_Button = new System.Windows.Forms.Button();
            this.editCancel_Button = new System.Windows.Forms.Button();
            this.addSave_Button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            usernameLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            preFixLabel = new System.Windows.Forms.Label();
            contactNumberLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.networkUserBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(17, 28);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(58, 13);
            usernameLabel.TabIndex = 6;
            usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(19, 54);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(56, 13);
            passwordLabel.TabIndex = 8;
            passwordLabel.Text = "Password:";
            // 
            // preFixLabel
            // 
            preFixLabel.AutoSize = true;
            preFixLabel.Location = new System.Drawing.Point(33, 80);
            preFixLabel.Name = "preFixLabel";
            preFixLabel.Size = new System.Drawing.Size(33, 13);
            preFixLabel.TabIndex = 10;
            preFixLabel.Text = "Prefix";
            // 
            // contactNumberLabel
            // 
            contactNumberLabel.AutoSize = true;
            contactNumberLabel.Location = new System.Drawing.Point(23, 80);
            contactNumberLabel.Name = "contactNumberLabel";
            contactNumberLabel.Size = new System.Drawing.Size(58, 13);
            contactNumberLabel.TabIndex = 0;
            contactNumberLabel.Text = "Contact Nr";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(49, 106);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(32, 13);
            emailLabel.TabIndex = 2;
            emailLabel.Text = "Email";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(24, 28);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(57, 13);
            firstNameLabel.TabIndex = 4;
            firstNameLabel.Text = "First Name";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(23, 54);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(58, 13);
            lastNameLabel.TabIndex = 6;
            lastNameLabel.Text = "Last Name";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(84, 138);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(35, 13);
            noteLabel.TabIndex = 8;
            noteLabel.Text = "Notes";
            // 
            // userList_FlowLayoutPanel
            // 
            this.userList_FlowLayoutPanel.Location = new System.Drawing.Point(15, 71);
            this.userList_FlowLayoutPanel.Name = "userList_FlowLayoutPanel";
            this.userList_FlowLayoutPanel.Padding = new System.Windows.Forms.Padding(1);
            this.userList_FlowLayoutPanel.Size = new System.Drawing.Size(154, 295);
            this.userList_FlowLayoutPanel.TabIndex = 2;
            // 
            // userHeader_Label
            // 
            this.userHeader_Label.Location = new System.Drawing.Point(15, 39);
            this.userHeader_Label.Margin = new System.Windows.Forms.Padding(6);
            this.userHeader_Label.Name = "userHeader_Label";
            this.userHeader_Label.Size = new System.Drawing.Size(154, 23);
            this.userHeader_Label.TabIndex = 3;
            this.userHeader_Label.Text = "Users";
            this.userHeader_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.networkUserBindingSource, "Username", true));
            this.usernameTextBox.Location = new System.Drawing.Point(81, 25);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 0;
            // 
            // networkUserBindingSource
            // 
            this.networkUserBindingSource.DataSource = typeof(AMS.Data.Users.NetworkUser);
            // 
            // userLoginHeader_Label
            // 
            this.userLoginHeader_Label.Location = new System.Drawing.Point(175, 39);
            this.userLoginHeader_Label.Margin = new System.Windows.Forms.Padding(6);
            this.userLoginHeader_Label.Name = "userLoginHeader_Label";
            this.userLoginHeader_Label.Size = new System.Drawing.Size(200, 23);
            this.userLoginHeader_Label.TabIndex = 8;
            this.userLoginHeader_Label.Text = "User Login";
            this.userLoginHeader_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.networkUserBindingSource, "Password", true));
            this.passwordTextBox.Location = new System.Drawing.Point(81, 51);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.Text = "password";
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // preFixTextBox
            // 
            this.preFixTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.networkUserBindingSource, "Prefix", true));
            this.preFixTextBox.Location = new System.Drawing.Point(81, 77);
            this.preFixTextBox.Name = "preFixTextBox";
            this.preFixTextBox.Size = new System.Drawing.Size(100, 20);
            this.preFixTextBox.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(usernameLabel);
            this.panel1.Controls.Add(this.usernameTextBox);
            this.panel1.Controls.Add(preFixLabel);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.preFixTextBox);
            this.panel1.Controls.Add(passwordLabel);
            this.panel1.Location = new System.Drawing.Point(175, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 125);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.administartorCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.createClientsCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.createCommerceCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.createInvoicesCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.createQuotesCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.createTasksCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.viewClientsCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.viewCommerceCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.viewInvoicesCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.viewQuotesCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.viewTasksCheckBox);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(175, 237);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 129);
            this.flowLayoutPanel2.TabIndex = 13;
            this.flowLayoutPanel2.Visible = false;
            // 
            // administartorCheckBox
            // 
            this.administartorCheckBox.AutoSize = true;
            this.administartorCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.Administartor", true));
            this.administartorCheckBox.Location = new System.Drawing.Point(3, 3);
            this.administartorCheckBox.Name = "administartorCheckBox";
            this.administartorCheckBox.Size = new System.Drawing.Size(86, 17);
            this.administartorCheckBox.TabIndex = 1;
            this.administartorCheckBox.Text = "Administrator";
            this.administartorCheckBox.UseVisualStyleBackColor = true;
            // 
            // createClientsCheckBox
            // 
            this.createClientsCheckBox.AutoSize = true;
            this.createClientsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.CreateClients", true));
            this.createClientsCheckBox.Location = new System.Drawing.Point(3, 26);
            this.createClientsCheckBox.Name = "createClientsCheckBox";
            this.createClientsCheckBox.Size = new System.Drawing.Size(78, 17);
            this.createClientsCheckBox.TabIndex = 3;
            this.createClientsCheckBox.Text = "Edit Clients";
            this.createClientsCheckBox.UseVisualStyleBackColor = true;
            // 
            // createCommerceCheckBox
            // 
            this.createCommerceCheckBox.AutoSize = true;
            this.createCommerceCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.CreateCommerce", true));
            this.createCommerceCheckBox.Location = new System.Drawing.Point(3, 49);
            this.createCommerceCheckBox.Name = "createCommerceCheckBox";
            this.createCommerceCheckBox.Size = new System.Drawing.Size(97, 17);
            this.createCommerceCheckBox.TabIndex = 5;
            this.createCommerceCheckBox.Text = "Edit Commerce";
            this.createCommerceCheckBox.UseVisualStyleBackColor = true;
            // 
            // createInvoicesCheckBox
            // 
            this.createInvoicesCheckBox.AutoSize = true;
            this.createInvoicesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.CreateInvoices", true));
            this.createInvoicesCheckBox.Location = new System.Drawing.Point(3, 72);
            this.createInvoicesCheckBox.Name = "createInvoicesCheckBox";
            this.createInvoicesCheckBox.Size = new System.Drawing.Size(87, 17);
            this.createInvoicesCheckBox.TabIndex = 7;
            this.createInvoicesCheckBox.Text = "Edit Invoices";
            this.createInvoicesCheckBox.UseVisualStyleBackColor = true;
            // 
            // createQuotesCheckBox
            // 
            this.createQuotesCheckBox.AutoSize = true;
            this.createQuotesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.CreateQuotes", true));
            this.createQuotesCheckBox.Location = new System.Drawing.Point(3, 95);
            this.createQuotesCheckBox.Name = "createQuotesCheckBox";
            this.createQuotesCheckBox.Size = new System.Drawing.Size(81, 17);
            this.createQuotesCheckBox.TabIndex = 9;
            this.createQuotesCheckBox.Text = "Edit Quotes";
            this.createQuotesCheckBox.UseVisualStyleBackColor = true;
            // 
            // createTasksCheckBox
            // 
            this.createTasksCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.CreateTasks", true));
            this.createTasksCheckBox.Location = new System.Drawing.Point(106, 3);
            this.createTasksCheckBox.Name = "createTasksCheckBox";
            this.createTasksCheckBox.Size = new System.Drawing.Size(104, 24);
            this.createTasksCheckBox.TabIndex = 11;
            this.createTasksCheckBox.Text = "checkBox1";
            this.createTasksCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewClientsCheckBox
            // 
            this.viewClientsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.ViewClients", true));
            this.viewClientsCheckBox.Location = new System.Drawing.Point(106, 33);
            this.viewClientsCheckBox.Name = "viewClientsCheckBox";
            this.viewClientsCheckBox.Size = new System.Drawing.Size(104, 24);
            this.viewClientsCheckBox.TabIndex = 13;
            this.viewClientsCheckBox.Text = "checkBox1";
            this.viewClientsCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewCommerceCheckBox
            // 
            this.viewCommerceCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.ViewCommerce", true));
            this.viewCommerceCheckBox.Location = new System.Drawing.Point(106, 63);
            this.viewCommerceCheckBox.Name = "viewCommerceCheckBox";
            this.viewCommerceCheckBox.Size = new System.Drawing.Size(104, 24);
            this.viewCommerceCheckBox.TabIndex = 15;
            this.viewCommerceCheckBox.Text = "checkBox1";
            this.viewCommerceCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewInvoicesCheckBox
            // 
            this.viewInvoicesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.ViewInvoices", true));
            this.viewInvoicesCheckBox.Location = new System.Drawing.Point(106, 93);
            this.viewInvoicesCheckBox.Name = "viewInvoicesCheckBox";
            this.viewInvoicesCheckBox.Size = new System.Drawing.Size(104, 24);
            this.viewInvoicesCheckBox.TabIndex = 17;
            this.viewInvoicesCheckBox.Text = "checkBox1";
            this.viewInvoicesCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewQuotesCheckBox
            // 
            this.viewQuotesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.ViewQuotes", true));
            this.viewQuotesCheckBox.Location = new System.Drawing.Point(216, 3);
            this.viewQuotesCheckBox.Name = "viewQuotesCheckBox";
            this.viewQuotesCheckBox.Size = new System.Drawing.Size(104, 24);
            this.viewQuotesCheckBox.TabIndex = 19;
            this.viewQuotesCheckBox.Text = "checkBox1";
            this.viewQuotesCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewTasksCheckBox
            // 
            this.viewTasksCheckBox.AutoSize = true;
            this.viewTasksCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.networkUserBindingSource, "UserRoles.ViewTasks", true));
            this.viewTasksCheckBox.Location = new System.Drawing.Point(216, 33);
            this.viewTasksCheckBox.Name = "viewTasksCheckBox";
            this.viewTasksCheckBox.Size = new System.Drawing.Size(78, 17);
            this.viewTasksCheckBox.TabIndex = 21;
            this.viewTasksCheckBox.Text = "ViewTasks";
            this.viewTasksCheckBox.UseVisualStyleBackColor = true;
            // 
            // userRolesHeader_Label
            // 
            this.userRolesHeader_Label.Location = new System.Drawing.Point(175, 205);
            this.userRolesHeader_Label.Margin = new System.Windows.Forms.Padding(6);
            this.userRolesHeader_Label.Name = "userRolesHeader_Label";
            this.userRolesHeader_Label.Size = new System.Drawing.Size(200, 23);
            this.userRolesHeader_Label.TabIndex = 14;
            this.userRolesHeader_Label.Text = "User Roles";
            this.userRolesHeader_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.userRolesHeader_Label.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(noteLabel);
            this.panel2.Controls.Add(this.noteTextBox);
            this.panel2.Controls.Add(lastNameLabel);
            this.panel2.Controls.Add(this.lastNameTextBox);
            this.panel2.Controls.Add(firstNameLabel);
            this.panel2.Controls.Add(this.firstNameTextBox);
            this.panel2.Controls.Add(emailLabel);
            this.panel2.Controls.Add(this.emailTextBox);
            this.panel2.Controls.Add(contactNumberLabel);
            this.panel2.Controls.Add(this.contactNumberTextBox);
            this.panel2.Location = new System.Drawing.Point(381, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 295);
            this.panel2.TabIndex = 1;
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.networkUserBindingSource, "Notes", true));
            this.noteTextBox.Location = new System.Drawing.Point(87, 154);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(223, 124);
            this.noteTextBox.TabIndex = 4;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.networkUserBindingSource, "LastName", true));
            this.lastNameTextBox.Location = new System.Drawing.Point(87, 51);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(114, 20);
            this.lastNameTextBox.TabIndex = 1;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.networkUserBindingSource, "FirstName", true));
            this.firstNameTextBox.Location = new System.Drawing.Point(87, 25);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(114, 20);
            this.firstNameTextBox.TabIndex = 0;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.networkUserBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(87, 103);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(223, 20);
            this.emailTextBox.TabIndex = 3;
            // 
            // contactNumberTextBox
            // 
            this.contactNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.networkUserBindingSource, "ContactNr", true));
            this.contactNumberTextBox.Location = new System.Drawing.Point(87, 77);
            this.contactNumberTextBox.Name = "contactNumberTextBox";
            this.contactNumberTextBox.Size = new System.Drawing.Size(114, 20);
            this.contactNumberTextBox.TabIndex = 2;
            // 
            // done_Button
            // 
            this.done_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.done_Button.Location = new System.Drawing.Point(635, 405);
            this.done_Button.Name = "done_Button";
            this.done_Button.Size = new System.Drawing.Size(75, 23);
            this.done_Button.TabIndex = 2;
            this.done_Button.Text = "Close";
            this.done_Button.UseVisualStyleBackColor = true;
            this.done_Button.Click += new System.EventHandler(this.Done_Click);
            // 
            // userPerson_Label
            // 
            this.userPerson_Label.Location = new System.Drawing.Point(381, 39);
            this.userPerson_Label.Margin = new System.Windows.Forms.Padding(6);
            this.userPerson_Label.Name = "userPerson_Label";
            this.userPerson_Label.Size = new System.Drawing.Size(326, 23);
            this.userPerson_Label.TabIndex = 17;
            this.userPerson_Label.Text = "User Profile";
            this.userPerson_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remove_Button
            // 
            this.remove_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remove_Button.Location = new System.Drawing.Point(554, 405);
            this.remove_Button.Name = "remove_Button";
            this.remove_Button.Size = new System.Drawing.Size(75, 23);
            this.remove_Button.TabIndex = 18;
            this.remove_Button.Text = "Remove";
            this.remove_Button.UseVisualStyleBackColor = true;
            this.remove_Button.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // editCancel_Button
            // 
            this.editCancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editCancel_Button.Location = new System.Drawing.Point(473, 405);
            this.editCancel_Button.Name = "editCancel_Button";
            this.editCancel_Button.Size = new System.Drawing.Size(75, 23);
            this.editCancel_Button.TabIndex = 19;
            this.editCancel_Button.Text = "Edit";
            this.editCancel_Button.UseVisualStyleBackColor = true;
            this.editCancel_Button.Click += new System.EventHandler(this.EditCancel_Click);
            // 
            // addSave_Button
            // 
            this.addSave_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addSave_Button.Location = new System.Drawing.Point(392, 405);
            this.addSave_Button.Name = "addSave_Button";
            this.addSave_Button.Size = new System.Drawing.Size(75, 23);
            this.addSave_Button.TabIndex = 20;
            this.addSave_Button.Text = "Add";
            this.addSave_Button.UseVisualStyleBackColor = true;
            this.addSave_Button.Click += new System.EventHandler(this.AddSave_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 380);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(722, 60);
            this.footer1.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(722, 30);
            this.header1.TabIndex = 0;
            // 
            // Network_Administration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 440);
            this.Controls.Add(this.addSave_Button);
            this.Controls.Add(this.editCancel_Button);
            this.Controls.Add(this.remove_Button);
            this.Controls.Add(this.userPerson_Label);
            this.Controls.Add(this.done_Button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.userRolesHeader_Label);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userLoginHeader_Label);
            this.Controls.Add(this.userHeader_Label);
            this.Controls.Add(this.userList_FlowLayoutPanel);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Network_Administration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Manager";
            this.Load += new System.EventHandler(this.Network_Administration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.networkUserBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserInterface.UserControls.Header header1;
        private UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.FlowLayoutPanel userList_FlowLayoutPanel;
        private System.Windows.Forms.Label userHeader_Label;
        private System.Windows.Forms.BindingSource networkUserBindingSource;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label userLoginHeader_Label;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox preFixTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label userRolesHeader_Label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox contactNumberTextBox;
        private System.Windows.Forms.Button done_Button;
        private System.Windows.Forms.Label userPerson_Label;
        private System.Windows.Forms.CheckBox administartorCheckBox;
        private System.Windows.Forms.CheckBox createClientsCheckBox;
        private System.Windows.Forms.CheckBox createCommerceCheckBox;
        private System.Windows.Forms.CheckBox createInvoicesCheckBox;
        private System.Windows.Forms.CheckBox createQuotesCheckBox;
        private System.Windows.Forms.CheckBox createTasksCheckBox;
        private System.Windows.Forms.CheckBox viewClientsCheckBox;
        private System.Windows.Forms.CheckBox viewCommerceCheckBox;
        private System.Windows.Forms.CheckBox viewInvoicesCheckBox;
        private System.Windows.Forms.CheckBox viewQuotesCheckBox;
        private System.Windows.Forms.CheckBox viewTasksCheckBox;
        private System.Windows.Forms.Button remove_Button;
        private System.Windows.Forms.Button editCancel_Button;
        private System.Windows.Forms.Button addSave_Button;
        private System.Windows.Forms.Timer timer1;
    }
}