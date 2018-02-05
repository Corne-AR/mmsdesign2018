using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Utilities.Forms
{
    public partial class FileUtils : Form
    {
        public FileUtils()
        {
            InitializeComponent();
        }

        private void removeEmptyFolders_Button_Click(object sender, EventArgs e)
        {
            DirectoryInfo locationInfo = new DirectoryInfo(location_TextBox.Text);

            List<DirectoryInfo> dirInfoList = new List<DirectoryInfo>();

        }
    }
}
