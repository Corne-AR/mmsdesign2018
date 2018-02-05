namespace AMS_Script.Forms
{
    partial class ScriptEditor
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
            this.header1 = new AMS.UserInterface.UserControls.Header();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.save_Button = new System.Windows.Forms.Button();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.variableDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.help_Button = new System.Windows.Forms.Button();
            this.script_TextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.result_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.testInValue_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.scriptName_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.remove_Button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.variableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(944, 30);
            this.header1.TabIndex = 0;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 474);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(944, 60);
            this.footer1.TabIndex = 1;
            // 
            // save_Button
            // 
            this.save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_Button.Location = new System.Drawing.Point(695, 499);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 2;
            this.save_Button.Text = "Save";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // cancel_Button
            // 
            this.cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_Button.Location = new System.Drawing.Point(857, 499);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 3;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // variableDataGridView
            // 
            this.variableDataGridView.AllowUserToAddRows = false;
            this.variableDataGridView.AllowUserToDeleteRows = false;
            this.variableDataGridView.AutoGenerateColumns = false;
            this.variableDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.variableDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.variableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.variableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.value,
            this.dataGridViewTextBoxColumn3});
            this.variableDataGridView.DataSource = this.variableBindingSource;
            this.variableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variableDataGridView.Location = new System.Drawing.Point(0, 28);
            this.variableDataGridView.Name = "variableDataGridView";
            this.variableDataGridView.ReadOnly = true;
            this.variableDataGridView.RowHeadersVisible = false;
            this.variableDataGridView.Size = new System.Drawing.Size(241, 356);
            this.variableDataGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // value
            // 
            this.value.DataPropertyName = "value";
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "VariableType";
            this.dataGridViewTextBoxColumn3.HeaderText = "Type";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // variableBindingSource
            // 
            this.variableBindingSource.DataSource = typeof(AMS_Script.Commands.Variable);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.variableDataGridView);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 386);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "List of Variables";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // help_Button
            // 
            this.help_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.help_Button.Location = new System.Drawing.Point(585, 499);
            this.help_Button.Name = "help_Button";
            this.help_Button.Size = new System.Drawing.Size(75, 23);
            this.help_Button.TabIndex = 7;
            this.help_Button.Text = "Help";
            this.help_Button.UseVisualStyleBackColor = true;
            this.help_Button.Click += new System.EventHandler(this.help_Button_Click);
            // 
            // script_TextBox
            // 
            this.script_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.script_TextBox.Location = new System.Drawing.Point(0, 28);
            this.script_TextBox.Multiline = true;
            this.script_TextBox.Name = "script_TextBox";
            this.script_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.script_TextBox.Size = new System.Drawing.Size(479, 356);
            this.script_TextBox.TabIndex = 11;
            this.script_TextBox.TextChanged += new System.EventHandler(this.script_TextBox_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.script_TextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(243, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(481, 386);
            this.panel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(479, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Logic";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.result_TextBox);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(724, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 386);
            this.panel3.TabIndex = 13;
            // 
            // result_TextBox
            // 
            this.result_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.result_TextBox.Location = new System.Drawing.Point(0, 28);
            this.result_TextBox.Multiline = true;
            this.result_TextBox.Name = "result_TextBox";
            this.result_TextBox.ReadOnly = true;
            this.result_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.result_TextBox.Size = new System.Drawing.Size(218, 356);
            this.result_TextBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.testInValue_TextBox);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.scriptName_TextBox);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(944, 58);
            this.panel4.TabIndex = 14;
            // 
            // testInValue_TextBox
            // 
            this.testInValue_TextBox.Location = new System.Drawing.Point(83, 32);
            this.testInValue_TextBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.testInValue_TextBox.Name = "testInValue_TextBox";
            this.testInValue_TextBox.Size = new System.Drawing.Size(160, 20);
            this.testInValue_TextBox.TabIndex = 3;
            this.testInValue_TextBox.TextChanged += new System.EventHandler(this.TestInValue_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Test InValue";
            // 
            // scriptName_TextBox
            // 
            this.scriptName_TextBox.Location = new System.Drawing.Point(83, 6);
            this.scriptName_TextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.scriptName_TextBox.Name = "scriptName_TextBox";
            this.scriptName_TextBox.Size = new System.Drawing.Size(160, 20);
            this.scriptName_TextBox.TabIndex = 1;
            this.scriptName_TextBox.LostFocus += new System.EventHandler(this.ScriptNameChange_Event);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Script Name";
            // 
            // remove_Button
            // 
            this.remove_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remove_Button.Location = new System.Drawing.Point(776, 499);
            this.remove_Button.Name = "remove_Button";
            this.remove_Button.Size = new System.Drawing.Size(75, 23);
            this.remove_Button.TabIndex = 15;
            this.remove_Button.Text = "Remove";
            this.remove_Button.UseVisualStyleBackColor = true;
            this.remove_Button.Click += new System.EventHandler(this.remove_Button_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 534);
            this.Controls.Add(this.remove_Button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.help_Button);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScriptEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script Editor";
            this.Load += new System.EventHandler(this.ScriptEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.variableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.UserInterface.UserControls.Header header1;
        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.BindingSource variableBindingSource;
        private System.Windows.Forms.DataGridView variableDataGridView;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button help_Button;
        private System.Windows.Forms.TextBox script_TextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox result_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox scriptName_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button remove_Button;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox testInValue_TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
    }
}