namespace UserInterface.People.Forms
{
    partial class Select_People
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
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.save_Button = new System.Windows.Forms.Button();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addPerson_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.aPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.people_CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPersonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 421);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(561, 60);
            this.footer1.TabIndex = 1;
            // 
            // save_Button
            // 
            this.save_Button.Location = new System.Drawing.Point(202, 12);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 0;
            this.save_Button.Text = "Save";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // cancel_Button
            // 
            this.cancel_Button.Location = new System.Drawing.Point(283, 12);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 1;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancel_Button);
            this.panel1.Controls.Add(this.save_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 47);
            this.panel1.TabIndex = 0;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(561, 30);
            this.header1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(83, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(165, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.TextChanged += new System.EventHandler(this.Search_Event);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter People";
            // 
            // addPerson_Button
            // 
            this.addPerson_Button.Location = new System.Drawing.Point(254, 4);
            this.addPerson_Button.Name = "addPerson_Button";
            this.addPerson_Button.Size = new System.Drawing.Size(75, 23);
            this.addPerson_Button.TabIndex = 2;
            this.addPerson_Button.Text = "Add";
            this.addPerson_Button.UseVisualStyleBackColor = true;
            this.addPerson_Button.Click += new System.EventHandler(this.addPerson_Button_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.addPerson_Button);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(561, 30);
            this.panel2.TabIndex = 3;
            // 
            // aPersonBindingSource
            // 
            this.aPersonBindingSource.DataSource = typeof(Data.People.Person);
            // 
            // checkedListBox1
            // 
            this.people_CheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.people_CheckedListBox.FormattingEnabled = true;
            this.people_CheckedListBox.Location = new System.Drawing.Point(0, 60);
            this.people_CheckedListBox.Name = "checkedListBox1";
            this.people_CheckedListBox.Size = new System.Drawing.Size(561, 314);
            this.people_CheckedListBox.TabIndex = 4;
            // 
            // Select_People
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 481);
            this.Controls.Add(this.people_CheckedListBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.footer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Select_People";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select People";
            this.Load += new System.EventHandler(this.Select_People_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPersonBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.Panel panel1;
        private AMS.UserInterface.UserControls.Header header1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addPerson_Button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource aPersonBindingSource;
        private System.Windows.Forms.CheckedListBox people_CheckedListBox;

    }
}