 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Forms.MessageBox
{
    public partial class InputBox_Form : Form
    {
        public string Value = "";
        
        public bool Accepted = false;

        public InputBox_Form(string Message)
        {
            InitializeComponent();

            message_Label.Text = Message;

            #region Resize
            int textWidth = TextRenderer.MeasureText(message_Label.Text.ToString(), message_Label.Font).Width;
            int textHeight = TextRenderer.MeasureText(message_Label.Text.ToString(), message_Label.Font).Height;

            this.Size = new Size(this.Size.Width + textWidth, this.Size.Height + textHeight);

            this.panel1.Location = new Point((int)(this.Size.Width / 2) - (int)(this.panel1.Size.Width / 2), panel1.Location.Y);
            this.StartPosition = FormStartPosition.CenterScreen;
            #endregion
        }

        #region DropShadow

        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        #endregion

        private void MessageBox_Load(object sender, EventArgs e)
        {
            this.BackColor = ThemeColors.WorkSpace;
            message_Label.BackColor = ThemeColors.WorkSpace;
            message_Label.ForeColor = ThemeColors.InputText;
            panel1.BackColor = ThemeColors.Menu;

            no_Button.BackColor = ThemeColors.Menu;
            no_Button.ForeColor = ThemeColors.MenuText;

            yes_button.BackColor = ThemeColors.Menu;
            yes_button.ForeColor = ThemeColors.MenuText;
            
            textBox1.Select();

            ThemeColors.SetBorders(this);
        }

        private void yes_button_Click(object sender, EventArgs e)
        {
            Value = textBox1.Text;
            Accepted = true;
            this.Close();
        }

        private void no_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
