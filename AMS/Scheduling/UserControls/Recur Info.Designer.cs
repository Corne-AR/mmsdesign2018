namespace AMS.Scheduling.UserControls
{
    partial class Recur_Info
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
            this.recur_Button = new System.Windows.Forms.Button();
            this.info_Label = new System.Windows.Forms.Label();
            this.recurBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.recurBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // recur_Button
            // 
            this.recur_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.recur_Button.Location = new System.Drawing.Point(3, 3);
            this.recur_Button.Name = "recur_Button";
            this.recur_Button.Size = new System.Drawing.Size(75, 23);
            this.recur_Button.TabIndex = 0;
            this.recur_Button.Text = "Recur";
            this.recur_Button.UseVisualStyleBackColor = true;
            this.recur_Button.Click += new System.EventHandler(this.recur_Button_Click);
            // 
            // info_Label
            // 
            this.info_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_Label.Location = new System.Drawing.Point(3, 29);
            this.info_Label.Margin = new System.Windows.Forms.Padding(3);
            this.info_Label.Name = "info_Label";
            this.info_Label.Size = new System.Drawing.Size(137, 45);
            this.info_Label.TabIndex = 2;
            this.info_Label.Text = "Recur Info";
            // 
            // recurBindingSource
            // 
            this.recurBindingSource.DataSource = typeof(AMS.Data.Scheduling.Recur);
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.recurBindingSource, "Active", true));
            this.activeCheckBox.Location = new System.Drawing.Point(84, 7);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(56, 17);
            this.activeCheckBox.TabIndex = 4;
            this.activeCheckBox.Text = "Active";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // Recur_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.activeCheckBox);
            this.Controls.Add(this.info_Label);
            this.Controls.Add(this.recur_Button);
            this.Name = "Recur_Info";
            this.Size = new System.Drawing.Size(143, 77);
            this.Load += new System.EventHandler(this.Recur_Info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recurBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button recur_Button;
        private System.Windows.Forms.Label info_Label;
        private System.Windows.Forms.BindingSource recurBindingSource;
        private System.Windows.Forms.CheckBox activeCheckBox;
    }
}
