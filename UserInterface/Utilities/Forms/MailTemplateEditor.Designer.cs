namespace UserInterface.Utilities.Forms
{
    partial class MailTemplateEditor
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
            System.Windows.Forms.Label contentBottomLabel;
            System.Windows.Forms.Label contentMiddleLabel;
            System.Windows.Forms.Label contentTopLabel;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailTemplateEditor));
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.close_Button = new System.Windows.Forms.Button();
            this.save_Buttons = new System.Windows.Forms.Button();
            this.addSignatureCheckBox = new System.Windows.Forms.CheckBox();
            this.mailTemplateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contentBottomTextBox = new System.Windows.Forms.TextBox();
            this.contentTopTextBox = new System.Windows.Forms.TextBox();
            this.greetingTextBox = new System.Windows.Forms.TextBox();
            this.preview_Label = new System.Windows.Forms.Label();
            this.refresh_Button = new System.Windows.Forms.Button();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            contentBottomLabel = new System.Windows.Forms.Label();
            contentMiddleLabel = new System.Windows.Forms.Label();
            contentTopLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mailTemplateBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentBottomLabel
            // 
            contentBottomLabel.AutoSize = true;
            contentBottomLabel.Location = new System.Drawing.Point(9, 199);
            contentBottomLabel.Name = "contentBottomLabel";
            contentBottomLabel.Size = new System.Drawing.Size(80, 13);
            contentBottomLabel.TabIndex = 9;
            contentBottomLabel.Text = "Content Bottom";
            // 
            // contentMiddleLabel
            // 
            contentMiddleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            contentMiddleLabel.Location = new System.Drawing.Point(12, 152);
            contentMiddleLabel.Margin = new System.Windows.Forms.Padding(3);
            contentMiddleLabel.Name = "contentMiddleLabel";
            contentMiddleLabel.Size = new System.Drawing.Size(400, 44);
            contentMiddleLabel.TabIndex = 11;
            contentMiddleLabel.Text = "Program Generated Content";
            contentMiddleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentTopLabel
            // 
            contentTopLabel.AutoSize = true;
            contentTopLabel.Location = new System.Drawing.Point(9, 30);
            contentTopLabel.Name = "contentTopLabel";
            contentTopLabel.Size = new System.Drawing.Size(66, 13);
            contentTopLabel.TabIndex = 13;
            contentTopLabel.Text = "Content Top";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 7);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 26;
            label2.Text = "Greeting";
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(868, 30);
            this.header1.TabIndex = 0;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 407);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(868, 60);
            this.footer1.TabIndex = 1;
            // 
            // close_Button
            // 
            this.close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Button.Location = new System.Drawing.Point(781, 432);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(75, 23);
            this.close_Button.TabIndex = 2;
            this.close_Button.Text = "Close";
            this.close_Button.UseVisualStyleBackColor = true;
            this.close_Button.Click += new System.EventHandler(this.close_Button_Click);
            // 
            // save_Buttons
            // 
            this.save_Buttons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_Buttons.Location = new System.Drawing.Point(700, 432);
            this.save_Buttons.Name = "save_Buttons";
            this.save_Buttons.Size = new System.Drawing.Size(75, 23);
            this.save_Buttons.TabIndex = 4;
            this.save_Buttons.Text = "Save";
            this.save_Buttons.UseVisualStyleBackColor = true;
            this.save_Buttons.Click += new System.EventHandler(this.save_Buttons_Click);
            // 
            // addSignatureCheckBox
            // 
            this.addSignatureCheckBox.AutoSize = true;
            this.addSignatureCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.mailTemplateBindingSource, "AddSignature", true));
            this.addSignatureCheckBox.Location = new System.Drawing.Point(12, 321);
            this.addSignatureCheckBox.Name = "addSignatureCheckBox";
            this.addSignatureCheckBox.Size = new System.Drawing.Size(47, 17);
            this.addSignatureCheckBox.TabIndex = 8;
            this.addSignatureCheckBox.Text = "Sign";
            this.addSignatureCheckBox.UseVisualStyleBackColor = true;
            this.addSignatureCheckBox.Click += new System.EventHandler(this.LoadTemplate_Event);
            // 
            // mailTemplateBindingSource
            // 
            this.mailTemplateBindingSource.DataSource = typeof(Data.Communications.MailTemplate);
            // 
            // contentBottomTextBox
            // 
            this.contentBottomTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mailTemplateBindingSource, "ContentBottom", true));
            this.contentBottomTextBox.Location = new System.Drawing.Point(12, 215);
            this.contentBottomTextBox.Multiline = true;
            this.contentBottomTextBox.Name = "contentBottomTextBox";
            this.contentBottomTextBox.Size = new System.Drawing.Size(400, 100);
            this.contentBottomTextBox.TabIndex = 10;
            this.contentBottomTextBox.TextChanged += new System.EventHandler(this.LoadTemplate_Event);
            // 
            // contentTopTextBox
            // 
            this.contentTopTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mailTemplateBindingSource, "ContentTop", true));
            this.contentTopTextBox.Location = new System.Drawing.Point(12, 46);
            this.contentTopTextBox.Multiline = true;
            this.contentTopTextBox.Name = "contentTopTextBox";
            this.contentTopTextBox.Size = new System.Drawing.Size(400, 100);
            this.contentTopTextBox.TabIndex = 14;
            this.contentTopTextBox.TextChanged += new System.EventHandler(this.LoadTemplate_Event);
            // 
            // greetingTextBox
            // 
            this.greetingTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mailTemplateBindingSource, "Greeting", true));
            this.greetingTextBox.Location = new System.Drawing.Point(62, 4);
            this.greetingTextBox.Name = "greetingTextBox";
            this.greetingTextBox.Size = new System.Drawing.Size(96, 20);
            this.greetingTextBox.TabIndex = 16;
            this.greetingTextBox.TextChanged += new System.EventHandler(this.LoadTemplate_Event);
            // 
            // preview_Label
            // 
            this.preview_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.preview_Label.Location = new System.Drawing.Point(631, 59);
            this.preview_Label.Name = "preview_Label";
            this.preview_Label.Padding = new System.Windows.Forms.Padding(9);
            this.preview_Label.Size = new System.Drawing.Size(237, 348);
            this.preview_Label.TabIndex = 21;
            this.preview_Label.Text = "Mail Preview";
            // 
            // refresh_Button
            // 
            this.refresh_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh_Button.Location = new System.Drawing.Point(603, 432);
            this.refresh_Button.Name = "refresh_Button";
            this.refresh_Button.Size = new System.Drawing.Size(75, 23);
            this.refresh_Button.TabIndex = 28;
            this.refresh_Button.Text = "Refresh";
            this.refresh_Button.UseVisualStyleBackColor = true;
            this.refresh_Button.Click += new System.EventHandler(this.LoadTemplate_Event);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(57, 20);
            this.toolStripLabel1.Text = "Template";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.LoadTemplate_Event);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(868, 29);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(86, 20);
            this.toolStripButton1.Text = "Add Template";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.contentTopTextBox);
            this.panel1.Controls.Add(contentTopLabel);
            this.panel1.Controls.Add(this.greetingTextBox);
            this.panel1.Controls.Add(contentMiddleLabel);
            this.panel1.Controls.Add(this.contentBottomTextBox);
            this.panel1.Controls.Add(this.addSignatureCheckBox);
            this.panel1.Controls.Add(contentBottomLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(200, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 348);
            this.panel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkedListBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 348);
            this.panel2.TabIndex = 27;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 24);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(200, 324);
            this.checkedListBox1.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 31;
            this.label1.Text = "Program Sections";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MailTemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(868, 467);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.preview_Label);
            this.Controls.Add(this.refresh_Button);
            this.Controls.Add(this.save_Buttons);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MailTemplateEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mail Template Editor";
            this.Load += new System.EventHandler(this.MailTemplateEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mailTemplateBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button close_Button;
        private System.Windows.Forms.Button save_Buttons;
        private System.Windows.Forms.BindingSource mailTemplateBindingSource;
        private System.Windows.Forms.CheckBox addSignatureCheckBox;
        private System.Windows.Forms.TextBox contentBottomTextBox;
        private System.Windows.Forms.TextBox contentTopTextBox;
        private System.Windows.Forms.TextBox greetingTextBox;
        private System.Windows.Forms.Label preview_Label;
        private System.Windows.Forms.Button refresh_Button;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
    }
}