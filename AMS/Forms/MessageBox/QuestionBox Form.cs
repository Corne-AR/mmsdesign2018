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
    public partial class QuestionBox_Form : Form
    {
        public bool Accepted = false;

        public string Value { get; set; }

        public QuestionBox_Form(string Message)
        {
            InitializeComponent();

            message_textBox.Text = Message;
            textBox1.Select();
            textBox1.Text = AMS.MessageBox1.messageValue;

            #region Resize
            int textWidth = TextRenderer.MeasureText(message_textBox.Text.ToString(), message_textBox.Font).Width;
            int textHeight = TextRenderer.MeasureText(message_textBox.Text.ToString(), message_textBox.Font).Height;

            this.Size = new Size(this.Size.Width + textWidth, this.Size.Height + textHeight);

            this.panel1.Location = new Point((int)(this.Size.Width / 2) - (int)(this.panel1.Size.Width / 2), panel1.Location.Y);
            this.StartPosition = FormStartPosition.CenterScreen;
            #endregion
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {
            this.BackColor = ThemeColors.WorkSpace;
            message_textBox.BackColor = ThemeColors.WorkSpace;
            message_textBox.ForeColor = ThemeColors.InputText;
            panel1.BackColor = ThemeColors.Menu;

            no_Button.BackColor = ThemeColors.Menu;
            no_Button.ForeColor = ThemeColors.MenuText;

            yes_button.BackColor = ThemeColors.Menu;
            yes_button.ForeColor = ThemeColors.MenuText;

            ThemeColors.SetBorders(this);

            if (this.Height > Screen.PrimaryScreen.WorkingArea.Height - 100) message_textBox.ScrollBars = ScrollBars.Both;
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
