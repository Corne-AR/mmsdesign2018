using AMS.Forms.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS
{
    public partial class MessageBox1
    {
        private static MessageBox_Form msg;

        public static bool Processing { get { return processing; } }
        private static bool processing = false;

        public static void ShowProcess(string Message)
        {
            if (!processing)
            {
                msg = new MessageBox_Form(Message);
                msg.ok_button.Visible = false;
                msg.Show();

                processing = true;

                System.Windows.Forms.Application.DoEvents();
            }
            else
            {
                msg.UpdateMessage(Message);
                System.Windows.Forms.Application.DoEvents();
            }
        }

        internal static void ShowProcess(string Message, MessageType messageType)
        {
            if (!processing)
            {
                msg = new MessageBox_Form(Message);
                msg.ok_button.Visible = false;
                msg.Show();

                processing = true;

                System.Windows.Forms.Application.DoEvents();
            }
            else
            {
                msg.UpdateMessage(Message);
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public static void UpdateProcess(string Message)
        {
            msg.UpdateMessage(Message);
        }

        public static void EndProcess()
        {
            System.Windows.Forms.Application.DoEvents();
            msg.Hide();
            processing = false;
        }
    }
}
