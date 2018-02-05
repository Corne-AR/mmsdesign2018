using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS
{
    public static class MessageBox_v2
    {
        private static Forms.MessageBox.MessageBox_v2 messageBox;

        private static string messageValue = "";
        public static string MessageValue
        {
            get
            {
                string getvalue = messageValue;
                messageValue = "";
                return getvalue;
            }
            set
            {
                messageValue = value;
            }
        }

        // Methods

        /// <summary>
        /// Standard Message Box with only OK
        /// </summary>
        /// <param name="Message">Message to show on MessageBox</param>
        public static MessageOut Show(string Message)
        {
            return Show(Message, null, MessageType.Normal, 0);
        }

        /// <summary>
        /// Standard Message Box with only OK
        /// </summary>
        /// <param name="Message">Message to show on MessageBox</param>
        /// <param name="InputValue">AutoFill</param>
        public static MessageOut Show(string Message, string InputValue)
        {
            return Show(Message, InputValue, MessageType.QuestionInput, 0);
        }

        /// <summary>
        /// Standard Message Box with only OK
        /// </summary>
        /// <param name="Message">Message to show on MessageBox</param>
        /// <param name="Milliseconds">0 = Normal; Greater than 0 will Auto Close in Specified time</param>
        public static MessageOut Show(string Message, int Milliseconds)
        {
            return Show(Message, null, MessageType.Normal, Milliseconds);
        }

        /// <summary>
        /// Quick Custom MessageBox
        /// </summary>
        /// <param name="Message">Message to show on MessageBox</param>
        /// <param name="MessageType">MessageBox Type, ex: Warning or Question</param>
        /// <returns>Ok/No/Cancel</returns>
        public static MessageOut Show(string Message, MessageType MessageType)
        {
            return Show(Message, null, MessageType, 0);
        }

        /// <summary>
        /// Full Control MessageBox
        /// </summary>
        /// <param name="Message">Message to show on MessageBox</param>
        /// <param name="Input">Define a Input Value. Useful for verifications</param>
        /// <param name="MessageType">MessageBox Type, ex: Warning or Question</param>
        /// <param name="Milliseconds">0 = Normal; Greater than 0 will Auto Close in Specified time</param>
        /// <returns>Ok/No/Cancel</returns>
        public static MessageOut Show(string Message, string Input, MessageType MessageType, int Milliseconds)
        {
            EndProcess();

            messageBox = new Forms.MessageBox.MessageBox_v2(Message, Input, MessageType, Milliseconds);
            messageBox.ShowDialog();

            if (messageBox.MessageOut == MessageOut.YesOk)
                messageValue = messageBox.InputValue;
            else
                messageValue = "";

            var messageOut = messageBox.MessageOut;
            messageBox.Dispose();

            return messageOut;
        }

        public static void ShowProcess(string Message)
        {
            ShowProcess(Message, 0, 0);
        }

        public static void ShowProcess(string Message, int Step, int TotalCount)
        {
            if (messageBox == null || messageBox.Visible == false)
            {
                messageBox = new Forms.MessageBox.MessageBox_v2(Message, Step, TotalCount);
                messageBox.Show();
            }
            else messageBox.UpdateProgress(Message, Step);
        }

        public static void EndProcess()
        {
            if (messageBox != null) messageBox.Dispose();
            if (messageBox != null) messageBox = null;
        }

        public static bool RunTests()
        {
            // Error
            Forms.MessageBox.TestMB t = new Forms.MessageBox.TestMB();
            t.ShowDialog();

            return false;
        }
    }
}