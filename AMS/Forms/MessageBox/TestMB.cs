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
    public partial class TestMB : Form
    {
        public TestMB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AMS.MessageBox_v2.Show("Normal Message");
            AMS.MessageBox_v2.Show("Normal Message" +
              "Looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo00000000000000000000000000000000000000000000000000000000oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong\r\n" +
              "\r\nLooo\r\n\r\noo\r\noo\r\n\r\no\r\no\r\no\r\no\r\no\r\noo\r\n\r\noooo\r\noo\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\noo\r\noooooooo\r\noooo\r\noooo\r\noo\r\noooo\r\noooo\r\noooo\r\noo\r\nooooo\r\nooooo\r\nooo\r\noo\r\noo\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\noo\r\nooo\r\noooo\r\no\r\no\r\no\r\nooo\r\n\r\n\r\noo\r\noooooooooong");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var outMessage = AMS.MessageBox_v2.Show("WHAT was That???", AMS.MessageType.Question);

            if (outMessage == AMS.MessageOut.YesOk)
                AMS.MessageBox_v2.Show("You said Yes", 1500);

            if (outMessage == AMS.MessageOut.No)
                AMS.MessageBox_v2.Show("NOOOO, don't say no", 1500);

            if (outMessage == AMS.MessageOut.Cancel)
                AMS.MessageBox_v2.Show("Why would you cancel?", 1500);

            // Input
            var inputMessage = AMS.MessageBox_v2.Show("Whats your mojo?", MessageType.QuestionInput);

            if (inputMessage == MessageOut.YesOk) AMS.MessageBox_v2.Show("Your mojo is: " + AMS.MessageBox_v2.MessageValue, 1500);
            if (inputMessage == MessageOut.No) AMS.MessageBox_v2.Show("You dont like to specify you mojo?\r\nFine go away!", 1500);
            if (inputMessage == MessageOut.Cancel) AMS.MessageBox_v2.Show("You cancelled you mind", 1500);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AMS.MessageBox_v2.Show("OH NOES, someone wants to do some message box tests", AMS.MessageType.Error);

           var outMessage = AMS.MessageBox_v2.Show("Red Pill?", MessageType.WarningQuestion);
            if (outMessage == MessageOut.YesOk) AMS.MessageBox_v2.Show("NO WAYYY!!!", AMS.MessageType.Warning);
            if (outMessage == MessageOut.No) AMS.MessageBox_v2.Show("Good for you, enjoy your bodily rest... in some pinkish gel", AMS.MessageType.Warning);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Process
            int count = 100;

            for (int i = 0; i < count; i++)
            {
                AMS.MessageBox_v2.ShowProcess("Testing Process Message\r\n\r\n" + i + " / " + count, i, count);
                System.Threading.Thread.Sleep(10);
            }
            AMS.MessageBox_v2.EndProcess();
            AMS.MessageBox_v2.Show("DONE", 1500);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
