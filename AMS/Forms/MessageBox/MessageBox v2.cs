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
    public partial class MessageBox_v2 : Form
    {
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

        public MessageOut MessageOut { get { return messageOut; } }
        MessageOut messageOut;

        MessageType messageType;
        string message;
        string inputValue;
        public string InputValue { get { if(string.IsNullOrEmpty(inputValue)) return null; return inputValue; } }

        // Constructors

        public MessageBox_v2(string Message, string InputValue, MessageType MessageType, int Milliseconds)
        {
            InitializeComponent();

            messageType = MessageType;
            message = Message;
            if (!string.IsNullOrEmpty(InputValue)) inputValue = InputValue;

            progressBar.Visible = false;

            #region Auto Close Delay Form

            if (Milliseconds > 1)
            {
                messageType = AMS.MessageType.Normal;
                autoClose_Timer.Interval = Milliseconds;
                autoClose_Timer.Start();
            }

            #endregion
        }

        public MessageBox_v2(string Message, int Step, int TotalCount)
        {
            InitializeComponent();

            messageType = MessageType.Delay;
            message = Message;
            inputValue = "";

            progressBar.Visible = true;

            if (Step == TotalCount)
            {
                progressBar.Maximum = 100;
                progressBar.Value = 100;
            }
            else
            {
                progressBar.Maximum = TotalCount;
                if (Step <= progressBar.Maximum) progressBar.Value = Step;
            }
        }

        // Load

        private void MessageBox_v2_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetBorders(this);
            ThemeColors.SetControls(buttons_FlowLayoutPanel, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(buttons_FlowLayoutPanel.Controls);
            progressBar.ForeColor = ThemeColors.Primary;

            #endregion

            SetMessage();
            SetControls();
        }

        // Methods

        public void UpdateProgress(string Message, int Step)
        {
            message = Message;
            if (Step > progressBar.Maximum) progressBar.Maximum = Step;
            progressBar.Value = Step;
            SetMessage();
        }

        private void SetMessage()
        {
            richTextBox1.Text = message;
            textBox1.Text = inputValue;

            #region Resize Form
            int textWidth = TextRenderer.MeasureText(richTextBox1.Text.ToString(), richTextBox1.Font).Width;
            int textHeight = TextRenderer.MeasureText(richTextBox1.Text.ToString(), richTextBox1.Font).Height;

            textWidth = (int)richTextBox1.CreateGraphics().MeasureString(richTextBox1.Text.ToString(), richTextBox1.Font).Width;
            textHeight = (int)richTextBox1.CreateGraphics().MeasureString(richTextBox1.Text.ToString(), richTextBox1.Font).Height;

            int addWidght = 0;
            int addHeight = 0;
            int maxpadding = 50;

            if (richTextBox1.Width - textWidth < 0) addWidght = -(richTextBox1.Width - textWidth);
            if (richTextBox1.Height - textHeight < 0) addHeight = -(richTextBox1.Height - textHeight);

            this.Size = new Size(this.Size.Width + addWidght, this.Size.Height + addHeight);

            if (this.Width > Screen.PrimaryScreen.WorkingArea.Width) this.Size = new Size(this.Size.Width - maxpadding, this.Size.Height);
            if (this.Height > Screen.PrimaryScreen.WorkingArea.Height) this.Size = new Size(this.Size.Width, this.Size.Height - maxpadding);

            this.Location = new Point((int)Screen.PrimaryScreen.WorkingArea.Width / 2 - (int)this.Width / 2,
                (int)Screen.PrimaryScreen.WorkingArea.Height / 2 - (int)this.Height / 2);

            #endregion

            System.Windows.Forms.Application.DoEvents();
        }

        private void SetControls()
        {
            #region Icon

            Bitmap icon = Properties.Resources.message;

            if (messageType == MessageType.Question || messageType == MessageType.QuestionInput) icon = Properties.Resources.question;
            if (messageType == MessageType.Warning || messageType == MessageType.WarningQuestion) icon = Properties.Resources.warning;
            if (messageType == MessageType.Error) icon = Properties.Resources.error;

            pictureBox1.BackgroundImage = icon;

            this.Icon = Icon.FromHandle(icon.GetHicon());

            #endregion

            #region Buttons

            ok_Button.Visible = autoClose_Timer.Interval == 1 && messageType != MessageType.Delay;
            no_Button.Visible = false;
            cancel_Button.Visible = false;
          
            cancel_Button.Visible = (messageType == MessageType.WarningQuestion || messageType == MessageType.Warning);
            no_Button.Visible = (messageType == MessageType.QuestionInput || messageType == MessageType.Question || messageType == MessageType.WarningQuestion);

            if (no_Button.Visible)
                ok_Button.Text = "Yes";

            textBox1.Visible = (messageType == MessageType.QuestionInput);

            #endregion

            #region Focus

            if (!textBox1.Visible) { buttons_FlowLayoutPanel.Focus(); ok_Button.Focus(); }
            else textBox1.Focus();

            #endregion

            if (progressBar.Maximum == 0) progressBar.Style = ProgressBarStyle.Continuous;
            else progressBar.Style = ProgressBarStyle.Blocks;

        }

        // Events

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Size size = TextRenderer.MeasureText(textBox1.Text, textBox1.Font);
            //textBox1.Width = size.Width;
            //textBox1.Height = size.Height;
        }

        private void ok_Button_Click(object sender, EventArgs e)
        {
            if(textBox1.Visible) inputValue = textBox1.Text;
            messageOut = AMS.MessageOut.YesOk;
            this.Close();
        }

        private void no_Button_Click(object sender, EventArgs e)
        {
            inputValue = null;
            messageOut = AMS.MessageOut.No;
            this.Close();
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            inputValue = null;
            messageOut = AMS.MessageOut.Cancel;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            inputValue = "";
            this.Close();
        }
    }
}
