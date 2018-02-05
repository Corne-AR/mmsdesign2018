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
    public partial class MessageBox_Form : Form
    {
        private Timer timer = new Timer();
        //private DateTime timerStart;
        private DateTime timerEnd;
        private bool DelayMessage = false;
        public bool Interrupted = false;

        // Constructors

        public MessageBox_Form(string Message)
        {
            InitializeComponent();

            message_Label.Text = Message;

            #region Resize
            int textWidth = TextRenderer.MeasureText(message_Label.Text.ToString(), message_Label.Font).Width;
            int textHeight = TextRenderer.MeasureText(message_Label.Text.ToString(), message_Label.Font).Height;

            this.Size = new Size(this.Size.Width + textWidth, this.Size.Height + textHeight);

            this.ok_button.Location = new Point((int)(this.Size.Width / 2) - (int)(this.ok_button.Size.Width / 2), ok_button.Location.Y);
            this.StartPosition = FormStartPosition.CenterScreen;
            #endregion
        }

        public MessageBox_Form(string Message, int Milliseconds)
        {
            InitializeComponent();

            message_Label.Text = Message;

            #region Resize
            int textWidth = TextRenderer.MeasureText(message_Label.Text.ToString(), message_Label.Font).Width;
            int textHeight = TextRenderer.MeasureText(message_Label.Text.ToString(), message_Label.Font).Height;

            this.Size = new Size(this.Size.Width + textWidth, this.Size.Height + textHeight);

            this.ok_button.Location = new Point((int)(this.Size.Width / 2) - (int)(this.ok_button.Size.Width / 2), ok_button.Location.Y);
            this.StartPosition = FormStartPosition.CenterScreen;
            #endregion

            DelayMessage = true;

            var start = DateTime.UtcNow; // Use UtcNow instead of Now
            timerEnd = start.AddMilliseconds(Milliseconds); //endTime is a member, not a local variable
            timer.Enabled = true;
            timer.Tick += timer_Tick;
        }

        // Load

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

            ok_button.BackColor = ThemeColors.Menu;
            ok_button.ForeColor = ThemeColors.MenuText;

            ThemeColors.SetBorders(this);
        }

        // Methods

        public void UpdateMessage(string Message)
        {
            message_Label.Text = Message;
            message_Label.Refresh();
        }

        // Events

        void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = timerEnd - DateTime.UtcNow;
            if (remainingTime < TimeSpan.Zero)
            {
                ok_button.Text = "Done!";
                timer.Enabled = false;
                Interrupted = false;
                this.Close();
            }
            else
            {

                string timeLeft = string.Format("{0}", remainingTime.Seconds);
                ok_button.Text = "Ok [" + timeLeft + "]";
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (DelayMessage)
            {
                Interrupted = true;
                this.Close();
            }
            else
                this.Close();
        }
    }
}
