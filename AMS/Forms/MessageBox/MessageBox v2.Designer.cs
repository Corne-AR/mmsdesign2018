namespace AMS.Forms.MessageBox
{
    partial class MessageBox_v2
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ok_Button = new System.Windows.Forms.Button();
            this.no_Button = new System.Windows.Forms.Button();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.buttons_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.autoClose_Timer = new System.Windows.Forms.Timer();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.buttons_FlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(79, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(283, 84);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "Some Test Text for the Message Box\n\nLine 1\nLine 2";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 132);
            this.textBox1.Margin = new System.Windows.Forms.Padding(21, 3, 9, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(365, 20);
            this.textBox1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AMS.Properties.Resources.message;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 90);
            this.panel1.TabIndex = 8;
            // 
            // ok_Button
            // 
            this.ok_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_Button.Location = new System.Drawing.Point(3, 3);
            this.ok_Button.Name = "ok_Button";
            this.ok_Button.Size = new System.Drawing.Size(75, 23);
            this.ok_Button.TabIndex = 0;
            this.ok_Button.Text = "Ok";
            this.ok_Button.UseVisualStyleBackColor = true;
            this.ok_Button.Click += new System.EventHandler(this.ok_Button_Click);
            // 
            // no_Button
            // 
            this.no_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no_Button.Location = new System.Drawing.Point(84, 3);
            this.no_Button.Name = "no_Button";
            this.no_Button.Size = new System.Drawing.Size(75, 23);
            this.no_Button.TabIndex = 1;
            this.no_Button.Text = "No";
            this.no_Button.UseVisualStyleBackColor = true;
            this.no_Button.Click += new System.EventHandler(this.no_Button_Click);
            // 
            // cancel_Button
            // 
            this.cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_Button.Location = new System.Drawing.Point(165, 3);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 2;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // buttons_FlowLayoutPanel
            // 
            this.buttons_FlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttons_FlowLayoutPanel.AutoSize = true;
            this.buttons_FlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons_FlowLayoutPanel.Controls.Add(this.cancel_Button);
            this.buttons_FlowLayoutPanel.Controls.Add(this.no_Button);
            this.buttons_FlowLayoutPanel.Controls.Add(this.ok_Button);
            this.buttons_FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttons_FlowLayoutPanel.Location = new System.Drawing.Point(134, 179);
            this.buttons_FlowLayoutPanel.Name = "buttons_FlowLayoutPanel";
            this.buttons_FlowLayoutPanel.Size = new System.Drawing.Size(243, 29);
            this.buttons_FlowLayoutPanel.TabIndex = 5;
            // 
            // autoClose_Timer
            // 
            this.autoClose_Timer.Interval = 1;
            this.autoClose_Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 132);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(365, 20);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 10;
            this.progressBar.Value = 100;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 160);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(389, 60);
            this.footer1.TabIndex = 1;
            this.footer1.TabStop = false;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(389, 30);
            this.header1.TabIndex = 0;
            this.header1.TabStop = false;
            // 
            // MessageBox_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 220);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttons_FlowLayoutPanel);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBox_v2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBox";
            this.Load += new System.EventHandler(this.MessageBox_v2_Load);
            this.Shown += new System.EventHandler(this.MessageBox_v2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.buttons_FlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserInterface.UserControls.Header header1;
        private UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ok_Button;
        private System.Windows.Forms.Button no_Button;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.FlowLayoutPanel buttons_FlowLayoutPanel;
        private System.Windows.Forms.Timer autoClose_Timer;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}