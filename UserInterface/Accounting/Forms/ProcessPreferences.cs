using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Accounting.Forms
{
    public partial class ProcessPreferences : Form
    {
        public ProcessPreferences()
        {
            InitializeComponent();
        }

        private void ProcessPreferences_Load(object sender, EventArgs e)
        {
            foreach (var i in DMS.ProcessPreferencesManager.WordList)
                if(!string.IsNullOrEmpty(i)) textBox1.Text += i.Trim() + "\r\n";
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            DMS.ProcessPreferencesManager.Clear();
            foreach (var line in textBox1.Text.Split('\r'))
                DMS.ProcessPreferencesManager.AddWord(line.Trim());

            DMS.ProcessPreferencesManager.Save();

            this.Close();
        }
    }
}
