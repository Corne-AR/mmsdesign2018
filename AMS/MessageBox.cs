using AMS.Forms.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS
{
    public partial class MessageBox1
    {
        internal static string messageValue = "";
        public static string MessageValue
        {
            get
            {
                string getvalue = messageValue;
                messageValue = "";
                return getvalue;
            }
        }

        public enum MessageType
        {
            Normal,
            Question,
            Input,
            Delay,
            DelayNoButton,
            //Warning,
            Error,
            QuestionNoInput,
        }

        public static void Show(string Message)
        {
            using (MessageBox_Form msg = new MessageBox_Form(Message))
            {
                msg.ShowDialog();
            }
        }

        public static bool Show(string Message, MessageType messageBox, int Delay)
        {
            bool interrupted = false;

            using (MessageBox_Form msg = new MessageBox_Form(Message, Delay))
            {
                if (messageBox == MessageType.DelayNoButton)
                {
                    msg.ok_button.Visible = false;
                }

                msg.ShowDialog();
                interrupted = msg.Interrupted;

                if (interrupted)
                    Show("Interrupted\r\n\r\n" + "\"" + Message + "\"");
            }

            return interrupted;
        }

        public static bool Show(string Message, MessageType messageBox)
        {
            bool accepted = false;

            switch (messageBox)
            {
                case MessageType.Normal:
                    Show(Message);
                    break;

                case MessageType.Question:
                    using (QuestionBox_Form qbox = new QuestionBox_Form(Message))
                    {
                        qbox.ShowDialog();
                        messageValue = qbox.Value;
                        accepted = qbox.Accepted;
                    }
                    break;

                case MessageType.QuestionNoInput:
                    using (QuestionBox_Form qbox = new QuestionBox_Form(Message))
                    {
                        qbox.textBox1.Visible = false;
                        qbox.ShowDialog();
                        accepted = qbox.Accepted;
                    }
                    break;

                case MessageType.Input:
                    using (InputBox_Form ibox = new InputBox_Form(Message))
                    {
                        ibox.ShowDialog();
                        accepted = ibox.Accepted;
                        messageValue = ibox.Value;
                    }
                    break;

                case MessageType.Error:
                    Show("Error\r\n\r\n" + Message);
                    break;
            }

            return accepted;
        }

        public static void SetMessageValue(string Message)
        {
            messageValue = Message;
        }
    }
}
