using AMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Catalogs.Forms
{
    public partial class ContentEditor : Form
    {
        private string content;
        public string Content { get { return content; } }

        public ContentEditor(string Content)
        {
            InitializeComponent();
            this.content = Content;
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

        // Load

        private void ContentEditor_Load(object sender, EventArgs e)
        {
            ThemeColors.SetBorders(this);
            textBox1.Text = content;
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            content = textBox1.Text;
            this.Close();
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            content = null;
            this.Close();
        }
    }
}
