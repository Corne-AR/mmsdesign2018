namespace UserInterface.Main
{
    partial class StartUp
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dbLoation_textBox = new System.Windows.Forms.TextBox();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.version_TextBox = new System.Windows.Forms.TextBox();
            this.title_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dbLoation_textBox
            // 
            this.dbLoation_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dbLoation_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dbLoation_textBox.Location = new System.Drawing.Point(346, 243);
            this.dbLoation_textBox.Name = "dbLoation_textBox";
            this.dbLoation_textBox.ReadOnly = true;
            this.dbLoation_textBox.Size = new System.Drawing.Size(250, 13);
            this.dbLoation_textBox.TabIndex = 2;
            this.dbLoation_textBox.Text = "C:\\Users\\Eugene\\.MMS Design\\Test Data\\";
            this.dbLoation_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // footer1
            // 
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 200);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(600, 60);
            this.footer1.TabIndex = 0;
            // 
            // version_TextBox
            // 
            this.version_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.version_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.version_TextBox.Location = new System.Drawing.Point(346, 224);
            this.version_TextBox.Name = "version_TextBox";
            this.version_TextBox.ReadOnly = true;
            this.version_TextBox.Size = new System.Drawing.Size(250, 13);
            this.version_TextBox.TabIndex = 4;
            this.version_TextBox.Text = "Version";
            this.version_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // title_Label
            // 
            this.title_Label.BackColor = System.Drawing.Color.White;
            this.title_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_Label.Location = new System.Drawing.Point(0, 0);
            this.title_Label.Name = "title_Label";
            this.title_Label.Size = new System.Drawing.Size(600, 200);
            this.title_Label.TabIndex = 3;
            this.title_Label.Text = "Asset Management Studio";
            this.title_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 260);
            this.ControlBox = false;
            this.Controls.Add(this.title_Label);
            this.Controls.Add(this.dbLoation_textBox);
            this.Controls.Add(this.version_TextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.footer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartUp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartUp";
            this.Load += new System.EventHandler(this.StartUp_Load);
            this.Shown += new System.EventHandler(this.StartUp_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox dbLoation_textBox;
        private System.Windows.Forms.TextBox version_TextBox;
        private System.Windows.Forms.Label title_Label;
    }
}